using Microsoft.EntityFrameworkCore;
using MM_Invoice_Final.Data;
using MM_Invoice_Final.Models.Dto;
using MM_Invoice_Final.Models.Entities;
using MM_Invoice_Final.Repository.IRepository;

namespace MM_Invoice_Final.Repository
{
    public class CustomerCarRepository : ICustomerCarRepository
    {
        private readonly DataContext _data;
        public CustomerCarRepository(DataContext data)
        {
            _data = data;
        }

        public async Task<List<CustomerCarSummaryDto>> GetCustomerCarsByIdAsync(int id)
        {

            return await _data.tblCustomer
                .Include(c => c.tblCar)
                .Where(c => c.CustomerId == id)
                .SelectMany(c => c.tblCar.DefaultIfEmpty(), (customer, car) => new CustomerCarSummaryDto // Will still retrieve data of tblCustomer even tblCar is empty
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    CustomerEmail = customer.CustomerEmail,
                    CustomerNumber = customer.CustomerNumber,
                    CarRego = car != null ? car.CarRego : string.Empty,
                    CarMake = car != null ? car.CarMake : string.Empty,
                    CarModel = car != null ? car.CarModel : string.Empty
                }).ToListAsync();
        }

        public async Task DeleteCustomerByIdAsync(int id)
        {
            var customer = _data.tblCustomer.FirstOrDefault(c => c.CustomerId == id);
            if (id != null || id != 0)
            {
                _data.tblCustomer.Remove(customer);
                await _data.SaveChangesAsync();
            }
        }

        public async Task UpdateCustomerById(CustomerSummaryDto customerDto)
        {
            var customer = await _data.tblCustomer.FindAsync(customerDto.CustomerId);
            if(customer != null)
            {
                customer.CustomerName = customerDto.CustomerName;
                customer.CustomerEmail = customerDto.CustomerEmail;
                customer.CustomerNumber = customerDto.CustomerNumber;

                _data.tblCustomer.Update(customer);
                await _data.SaveChangesAsync();
            }
        }

        public async Task AddCarToCustomer(AddCarToCustomerDto addCarDto)
        {
            var customer = await _data.tblCustomer
                .Include(c => c.tblCar)
                .FirstOrDefaultAsync(c => c.CustomerId == addCarDto.CustomerId);

            if (customer != null)
            {
                var newCar = new tblCar
                {
                    CarRego = addCarDto.CarRego,
                    CarMake = addCarDto.CarMake,
                    CarModel = addCarDto.CarModel
                };

                customer.tblCar.Add(newCar);
                await _data.SaveChangesAsync();
            }
        }
    }
}
