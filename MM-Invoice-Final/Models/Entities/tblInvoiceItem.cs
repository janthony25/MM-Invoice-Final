﻿using System.ComponentModel.DataAnnotations;

namespace MM_Invoice_Final.Models.Entities
{
    public class tblInvoiceItem
    {
        [Key]
        public int InvoiceItemId { get; set; }
        public required string ItemName { get; set; }
        public required int Quantity { get; set; }
        public required decimal ItemPrice { get; set; }

        // Foreign key to tblInvoice
        public int InvoiceId { get; set; }
        public tblInvoice tblInvoice { get; set; }
    }
}
