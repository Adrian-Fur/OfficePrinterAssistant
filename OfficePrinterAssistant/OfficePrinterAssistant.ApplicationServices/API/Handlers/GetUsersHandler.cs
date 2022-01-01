using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IRepository<User> userRepository;

        public GetUsersHandler(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = this.userRepository.GetAll();

            var domainUsers = users.Select(x => new Domain.Models.User()
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email
            });

            var response = new GetUsersResponse()
            {
                Data = domainUsers.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
