using System.ComponentModel.DataAnnotations;

namespace MM_Invoice_Final.Models.Entities
{
    public class tblCustomer
    {
        [Key]
        public int CustomerId { get; set; }
        public required string CustomerName { get; set; }
        public string? CustomerNumber { get; set; }
        public string? CustomerEmail { get; set; }
        public string? PaymentStatus { get; set; }

        public ICollection<tblCar> tblCar { get; set; }
    }
}
