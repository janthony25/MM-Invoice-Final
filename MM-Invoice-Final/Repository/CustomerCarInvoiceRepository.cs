using Microsoft.EntityFrameworkCore;
using MM_Invoice_Final.Data;
using MM_Invoice_Final.Models.Dto;
using MM_Invoice_Final.Repository.IRepository;

namespace MM_Invoice_Final.Repository
{
    public class CustomerCarInvoiceRepository : ICustomerCarInvoiceRepository
    {
        private readonly DataContext _data;
        public CustomerCarInvoiceRepository(DataContext data)
        {
            _data = data;
        }

        public async Task<List<CustomerCarInvoiceSummaryDto>> GetCustomerCarInvoiceByIdAsync(int id)
        {
            var result = await _data.tblCar
                 .Include(c => c.tblCustomer)
                 .Include(c => c.tblInvoice)
                 .Where(c => c.CarId == id)
                 .SelectMany(c => c.tblInvoice.DefaultIfEmpty(), (car, invoice) => new CustomerCarInvoiceSummaryDto
                 {
                     CustomerId = car.CustomerId,
                     CustomerName = car.tblCustomer.CustomerName,
                     CustomerEmail = car.tblCustomer.CustomerEmail,
                     CustomerNumber = car.tblCustomer.CustomerNumber,
                     CarId = car.CarId,
                     CarRego = car.CarRego,
                     CarMake = car.CarMake,
                     CarModel = car.CarModel,
                     InvoiceId = invoice != null ? invoice.InvoiceId : 0,
                     DateAdded = invoice.DateAdded,
                     DueDate = invoice.DueDate,
                     IssueName = invoice.IssueName,
                     TotalAmount = invoice.TotalAmount,
                     AmountPaid = invoice.AmountPaid
                 }).ToListAsync();

            return result;
        }

        
    }
}
