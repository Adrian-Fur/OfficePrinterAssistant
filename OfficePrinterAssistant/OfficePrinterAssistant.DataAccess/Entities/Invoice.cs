using System;
using System.Collections.Generic;

namespace OfficePrinterAssistant.DataAccess.Entities
{
    public class Invoice : EntityBase
    {
        public DateTime CreateDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }

        public virtual User User { get; set; }
        public virtual IEnumerable<InvoiceDetails> InvoiceDetails { get; set; } 

    }
}
