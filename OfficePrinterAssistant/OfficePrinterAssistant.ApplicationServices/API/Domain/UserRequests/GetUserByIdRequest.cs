using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.UserResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.UserRequests
{
    public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
    {
        public int UserId { get; set; }
    }
}
