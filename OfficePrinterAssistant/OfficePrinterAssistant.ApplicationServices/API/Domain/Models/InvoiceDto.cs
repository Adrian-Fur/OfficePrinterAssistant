using System;
using System.Collections.Generic;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.Models
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }

        public List<InvoiceDetailsDto> InvoiceDetailsList { get; set; }


    }
}
