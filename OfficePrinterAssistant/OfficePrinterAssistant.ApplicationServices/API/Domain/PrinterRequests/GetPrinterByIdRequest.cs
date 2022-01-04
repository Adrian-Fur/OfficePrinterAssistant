using MediatR;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain
{
    public class GetPrinterByIdRequest : IRequest<GetPrinterByIdResponse>
    {
        public int PrinterId { get; set; }

    }
}
