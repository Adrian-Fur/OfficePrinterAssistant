using System;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }

        public User User { get; set; }


    }
}
