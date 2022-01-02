using MediatR;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain
{
    public class GetPrintersRequest : IRequest<GetPrintersResponse>
    {
        public string Mark { get; set; }
    }
}
