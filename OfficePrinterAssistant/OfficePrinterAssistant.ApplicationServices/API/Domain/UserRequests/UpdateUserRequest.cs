using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.UserResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.UserRequests
{
    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
