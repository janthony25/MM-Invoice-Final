using Microsoft.EntityFrameworkCore;
using MM_Invoice_Final.Data;
using MM_Invoice_Final.Models.Dto;
using MM_Invoice_Final.Models.Entities;
using MM_Invoice_Final.Repository.IRepository;

namespace MM_Invoice_Final.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _data;

        public CustomerRepository(DataContext data)
        {
            _data = data;
        }

        public async Task AddNewCustomerAsync(AddCustomerDto customerDto)
        {
            var customer = new tblCustomer
            {
                CustomerName = customerDto.CustomerName,
                CustomerEmail = customerDto.CustomerEmail,
                CustomerNumber = customerDto.CustomerNumber,
            };

            _data.tblCustomer.AddAsync(customer);
            await _data.SaveChangesAsync();
        }

        public async Task<CustomerSummaryDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _data.tblCustomer
                .Where(c => c.CustomerId == id)
                .Select(c => new CustomerSummaryDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    CustomerEmail = c.CustomerEmail,
                    CustomerNumber = c.CustomerNumber
                }).FirstOrDefaultAsync();

            return customer;
        }


        //public Task<List<CustomerSummaryDto>> GetCustomerByIdAsync(int id)
        //{
        //    return _data.tblCustomer
        //        .Where(c => c.CustomerId == id)
        //        .Select(c => new CustomerSummaryDto
        //        {
        //            CustomerId = c.CustomerId,
        //            CustomerName = c.CustomerName,
        //            CustomerEmail = c.CustomerEmail,
        //            CustomerNumber = c.CustomerNumber
        //        }).ToListAsync();
        //}

        public async Task<List<CustomerSummaryDto>> GetCustomerSummaryAsync()
        {
            return await _data.tblCustomer
                .Select(c => new CustomerSummaryDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    CustomerEmail = c.CustomerEmail,
                    CustomerNumber = c.CustomerNumber,
                }).ToListAsync();
        }
    }
}
