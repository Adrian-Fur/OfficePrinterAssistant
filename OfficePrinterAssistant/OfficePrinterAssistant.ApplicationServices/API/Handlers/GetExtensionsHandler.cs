using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers
{
    public class GetExtensionsHandler : IRequestHandler<GetExtensionsRequest, GetExtensionsResponse>
    {
        private readonly IRepository<Extension> extensionRepository;

        public GetExtensionsHandler(IRepository<Extension> extensionRepository)
        {
            this.extensionRepository = extensionRepository;
        }
        public Task<GetExtensionsResponse> Handle(GetExtensionsRequest request, CancellationToken cancellationToken)
        {
            var extensions = this.extensionRepository.GetAll();

            var domainExtensions = extensions.Select(x => new Domain.Models.Extension()
            {
                Id = x.Id,
                Name = x.Name,
                SerialNumber = x.SerialNumber
            });

            var response = new GetExtensionsResponse()
            {
                Data = domainExtensions.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
