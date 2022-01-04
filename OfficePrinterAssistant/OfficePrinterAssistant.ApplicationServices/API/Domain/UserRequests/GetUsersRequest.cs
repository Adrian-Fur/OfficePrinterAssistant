using MediatR;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain
{
    public class GetUsersRequest : IRequest<GetUsersResponse>
    {
        public string Name { get; set; }

    }
}
