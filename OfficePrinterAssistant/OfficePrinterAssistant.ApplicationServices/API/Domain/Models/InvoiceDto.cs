using System;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.Models
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }

        public UserDto User { get; set; }


    }
}
