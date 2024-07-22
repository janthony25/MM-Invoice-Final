using MM_Invoice_Final.Models.Dto;

namespace MM_Invoice_Final.Repository.IRepository
{
    public interface ICustomerCarInvoiceRepository
    {
        Task<List<CustomerCarInvoiceSummaryDto>> GetCustomerCarInvoiceByIdAsync(int id);
    }
}
