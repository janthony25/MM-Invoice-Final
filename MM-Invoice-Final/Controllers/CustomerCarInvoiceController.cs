using Microsoft.AspNetCore.Mvc;
using MM_Invoice_Final.Models.Dto;
using MM_Invoice_Final.Repository.IRepository;

namespace MM_Invoice_Final.Controllers
{
    public class CustomerCarInvoiceController : Controller
    {
        private readonly ICustomerCarInvoiceRepository _customerCarInvoiceRepository;
        public CustomerCarInvoiceController(ICustomerCarInvoiceRepository customerCarInvoiceRepository)
        {
            _customerCarInvoiceRepository = customerCarInvoiceRepository;
        }

        // GET - CustomerCarInvoice Summary
        public async Task<IActionResult> GetCustomerCarInvoiceById(int id)
        {
            var result = await _customerCarInvoiceRepository.GetCustomerCarInvoiceByIdAsync(id);
            return View(result);
        }

        // GET - Add Invoice & InvoiceItem to Car
        public async Task<IActionResult> AddInvoiceToCar(int id)
        {
            var customerDetails = await _customerCarInvoiceRepository.GetCustomerCarInvoiceByIdAsync(id);

            if(customerDetails == null)
            {
                return NotFound();
            }

            var model = new AddInvoiceToCarDto
            {
                CustomerId = customerDetails.First().CustomerId,
                CustomerName = customerDetails.First().CustomerName,
                CustomerEmail = customerDetails.First().CustomerEmail,
                CustomerNumber = customerDetails.First().CustomerNumber,
                CarId = customerDetails.First().CarId,
                CarRego = customerDetails.First().CarRego,
                CarMake = customerDetails.First().CarMake,
                CarModel = customerDetails.First().CarModel,
                IssueName = string.Empty
            };

            return View(model);
        }

        // POST - Add Invoice & InvoiceItem to Car
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInvoice(AddInvoiceToCarDto model)
        {
            if(ModelState.IsValid)
            {
                await _customerCarInvoiceRepository.AddCarInvoiceAsync(model);
                return RedirectToAction("GetCustomerCars", new { id = model.CarId });
            }
            return View(model);
        }
    }
}
