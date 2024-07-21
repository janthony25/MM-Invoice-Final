using System.ComponentModel.DataAnnotations;

namespace MM_Invoice_Final.Models.Entities
{
    public class tblInvoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public DateTime? DateAdded { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        public required string IssueName { get; set; }
        public string? PaymentTerm { get; set; }
        public string? Notes { get; set; }
        public decimal? LaborPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? AmountPaid { get; set; }
        public bool? IsPaid { get; set; }


        // Foreign key to tblCar
        public int CarId { get; set; }
        public tblCar tblCar { get; set; }


        // one-to-many connection to tblInvoiceItem
        public ICollection<tblInvoiceItem> tblInvoiceItem { get; set; }
    }
}
