using System;
using System.Collections.Generic;

namespace OfficePrinterAssistant.DataAccess.Entities
{
    public class Invoice : EntityBase
    {
        public DateTime CreateDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public IEnumerable<InvoiceDetails> InvoiceDetails { get; set; } 

    }
}
