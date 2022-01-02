using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.CQRS.Queries;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers
{
    public class GetPrintersHandler : IRequestHandler<GetPrintersRequest, GetPrintersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetPrintersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetPrintersResponse> Handle(GetPrintersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPrintersQuery()
            {
                Mark = request.Mark
            };
            var printers = await this.queryExecutor.Execute(query);
            var mappedPrinter = this.mapper.Map<List<Domain.Models.Printer>>(printers);

            var response = new GetPrintersResponse()
            {
                Data = mappedPrinter
            };

            return response;
        }
    }
}
