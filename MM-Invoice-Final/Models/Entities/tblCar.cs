using System.ComponentModel.DataAnnotations;

namespace MM_Invoice_Final.Models.Entities
{
    public class tblCar
    {
        [Key]
        public int CarId { get; set; }
        public required string CarRego { get; set; }
        public required string CarMake { get; set; }
        public string? CarModel { get; set; }

        // Connection to tblCustomer
        public int CustomerId { get; set; }
        public tblCustomer tblCustomer { get; set; }

        // one-to-many Connection to tblInvoice
        public ICollection<tblInvoice> tblInvoice { get; set; }

    }
}
