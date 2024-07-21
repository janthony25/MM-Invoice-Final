using MM_Invoice_Final.Models.Dto;

namespace MM_Invoice_Final.Repository.IRepository
{
    public interface ICustomerRepository
    {
        Task<List<CustomerSummaryDto>> GetCustomerSummaryAsync();
        Task AddNewCustomerAsync(AddCustomerDto customerDto);
        Task<CustomerSummaryDto> GetCustomerByIdAsync(int id);
    }
}
