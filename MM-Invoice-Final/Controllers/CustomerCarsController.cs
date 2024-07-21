using Microsoft.AspNetCore.Mvc;
using MM_Invoice_Final.Models.Dto;
using MM_Invoice_Final.Repository;
using MM_Invoice_Final.Repository.IRepository;

namespace MM_Invoice_Final.Controllers
{
    public class CustomerCarsController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerCarRepository _customerCarRepository;
        public CustomerCarsController(ICustomerRepository customerRepository, ICustomerCarRepository customerCarRepository)
        {
            _customerRepository = customerRepository;
            _customerCarRepository = customerCarRepository;

        }

        // GET - CUSTOMER'S CAR LIST
        public async Task<IActionResult> GetCustomerCars(int id)
        {
            var customerCar = await _customerCarRepository.GetCustomerCarsByIdAsync(id);
            return View(customerCar);
        }

        // POST - DELETE CUSTOMER
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCustomerById(int id)
        {
            await _customerCarRepository.DeleteCustomerByIdAsync(id);
            return RedirectToAction("GetCustomerList", "Customer");
        }


        // GET - UPDATE CUSTOMER
        public async Task<IActionResult> EditCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST - UPDATE CUSTOMER
        [HttpPost, ActionName("EditCustomer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCustomerPost(CustomerSummaryDto customerDto)
        {
            if (ModelState.IsValid)
            {
                await _customerCarRepository.UpdateCustomerById(customerDto);
                return RedirectToAction("GetCustomerCars", new {id = customerDto.CustomerId}); // To make sure you go back to the same CustomerPage
            }
            return View(customerDto);
           
        }

        // GET - ADD CAR TO CUSTOMER
        public async Task<IActionResult> AddCarToCustomer(int id)
        {
            var car = new AddCarToCustomerDto
            {
                CustomerId = id
            };
            return View(car);
        }

        // POST - ADD CAR TO CUSTOMER
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCarToCustomer(AddCarToCustomerDto addCarDto)
        {
            if (ModelState.IsValid)
            {
                await _customerCarRepository.AddCarToCustomer(addCarDto);
                return RedirectToAction("GetCustomerCars", new {id = addCarDto.CustomerId});
            }
            return View(addCarDto);
        }
    }
}
