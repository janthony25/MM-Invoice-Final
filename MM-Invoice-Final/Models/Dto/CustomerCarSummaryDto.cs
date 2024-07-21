﻿namespace MM_Invoice_Final.Models.Dto
{
    public class CustomerCarSummaryDto
    {
        public int CustomerId { get; set; }
        public required string CustomerName { get; set; }
        public string? CustomerNumber { get; set; }
        public string? CustomerEmail { get; set; }
        public string CarRego { get; set; }
        public string CarMake { get; set; }
        public string? CarModel { get; set; }
    }
}
