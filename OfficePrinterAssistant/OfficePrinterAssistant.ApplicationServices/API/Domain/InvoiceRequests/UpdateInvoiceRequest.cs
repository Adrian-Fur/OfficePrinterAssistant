using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceResponses;
using System;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceRequests
{
    public class UpdateInvoiceRequest : IRequest<UpdateInvoiceResponse>
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public int UserId { get; set; }
    }
}
