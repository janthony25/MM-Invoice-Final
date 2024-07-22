﻿namespace MM_Invoice_Final.Models.Dto
{
    public class CustomerCarInvoiceSummaryDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string? CustomerNumber { get; set; }
        public string? CustomerEmail { get; set; }
        public int CarId { get; set; }
        public required string CarRego { get; set; }
        public required string CarMake { get; set; }
        public string CarModel { get; set; }
        public int InvoiceId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DueDate { get; set; }
        public required string IssueName { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? AmountPaid { get; set; }
    }
}
