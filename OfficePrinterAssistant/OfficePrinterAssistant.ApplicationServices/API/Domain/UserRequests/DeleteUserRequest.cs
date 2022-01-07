using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.UserResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.UserRequests
{
    public class DeleteUserRequest : IRequest<DeleteUserResponse>
    {
        public int Id { get; set; }

    }
}
