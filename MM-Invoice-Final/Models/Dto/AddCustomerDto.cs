﻿namespace MM_Invoice_Final.Models.Dto
{
    public class AddCustomerDto
    {
        public required string CustomerName { get; set; }
        public string? CustomerNumber { get; set; }
        public string? CustomerEmail { get; set; }
    }
}
