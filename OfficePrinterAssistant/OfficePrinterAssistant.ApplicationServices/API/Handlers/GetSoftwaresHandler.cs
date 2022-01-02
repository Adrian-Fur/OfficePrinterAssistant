using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers
{
    public class GetSoftwaresHandler : IRequestHandler<GetSoftwaresRequest, GetSoftwareResponse>
    {
        private readonly IRepository<Software> softwareRepository;

        public GetSoftwaresHandler(IRepository<Software> softwareRepository)
        {
            this.softwareRepository = softwareRepository;
        }
        public Task<GetSoftwareResponse> Handle(GetSoftwaresRequest request, CancellationToken cancellationToken)
        {
            var softwares = this.softwareRepository.GetAll();

            var domainSoftwares = softwares.Select(x => new Domain.Models.Software()
            {
                Id = x.Id,
                Name = x.Name,
                LicenseNumber = x.LicenseNumber
            });

            var response = new GetSoftwareResponse()
            {
                Data = domainSoftwares.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
