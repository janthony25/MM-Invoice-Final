using Microsoft.AspNetCore.Mvc;
using MM_Invoice_Final.Models.Dto;
using MM_Invoice_Final.Repository;
using MM_Invoice_Final.Repository.IRepository;

namespace MM_Invoice_Final.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerCarRepository _customerCarRepository;
        public CustomerController(ICustomerRepository customerRepository, ICustomerCarRepository customerCarRepository)
        {
            _customerRepository = customerRepository;
            _customerCarRepository = customerCarRepository;

        }

        // GET - Customer List
        public async Task<IActionResult> GetCustomerList()
        {
            var customer = await _customerRepository.GetCustomerSummaryAsync();
            return View(customer);
        }

        // GET - ADD NEW CUSTOMER
        public async Task<IActionResult> AddNewCustomer()
        {
            return View();
        }

        // POST - Add NEW CUSTOMER
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewCustomer(AddCustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                await _customerRepository.AddNewCustomerAsync(customerDto);
                return RedirectToAction("GetCustomerList");
            }

            return View(customerDto);
        }

     

    }
}
