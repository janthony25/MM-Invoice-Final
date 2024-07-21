using MM_Invoice_Final.Models.Dto;

namespace MM_Invoice_Final.Repository.IRepository
{
    public interface ICustomerCarRepository
    {
        Task<List<CustomerCarSummaryDto>> GetCustomerCarsByIdAsync(int id);
        Task DeleteCustomerByIdAsync(int id);
        Task UpdateCustomerById(CustomerSummaryDto customerDto);
        Task AddCarToCustomer(AddCarToCustomerDto addCarDto);

    }
}
