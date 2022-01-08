using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfficePrinterAssistant.DataAccess.Entities
{
    public class Invoice : EntityBase
    {
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public List<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
