using Microsoft.AspNetCore.Mvc;
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
    }
}
