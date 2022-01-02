using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers
{
    public class GetPrintersHandler : IRequestHandler<GetPrintersRequest, GetPrintersResponse>
    {
        private readonly IRepository<Printer> printerRepository;
        private readonly IMapper mapper;

        public GetPrintersHandler(IRepository<Printer> printerRepository, IMapper mapper)
        {
            this.printerRepository = printerRepository;
            this.mapper = mapper;
        }
        public Task<GetPrintersResponse> Handle(GetPrintersRequest request, CancellationToken cancellationToken)
        {
            var printers = this.printerRepository.GetAll();

            var mappedPrinter = this.mapper.Map<List<Domain.Models.Printer>>(printers);
            //var domainPrinters = printers.Select(x => new Domain.Models.Printer()
            //{
            //    Id = x.Id,
            //    Mark = x.Mark,
            //    Model = x.Model

            //});

            var response = new GetPrintersResponse()
            {
                //Data = domainPrinters.ToList()
                Data = mappedPrinter
            };

            return Task.FromResult(response);

            
        }
    }
}
