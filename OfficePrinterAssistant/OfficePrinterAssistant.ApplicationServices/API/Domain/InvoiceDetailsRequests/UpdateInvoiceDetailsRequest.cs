using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsRequests
{
    public class UpdateInvoiceDetailsRequest : IRequest<UpdateInvoiceDetailsResponse>
    {
        public int Id { get; set; }
        public decimal PrinterFee { get; set; }
        public decimal ExtensionsFee { get; set; }
        public decimal SoftwareFee { get; set; }
        public int InvoiceId { get; set; }
    }
}
