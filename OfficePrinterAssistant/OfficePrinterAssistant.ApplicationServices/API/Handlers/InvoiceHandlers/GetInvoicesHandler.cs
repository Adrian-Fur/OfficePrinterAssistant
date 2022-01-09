using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceReponses;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.Models;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.CQRS.Queries.InvoiceQueries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class GetInvoicesHandler : IRequestHandler<GetInvoicesRequest, GetInvoicesResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetInvoicesHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetInvoicesResponse> Handle(GetInvoicesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoicesQuery();
            var users = await this.queryExecutor.Execute(query);
            var mappedInvoices = this.mapper.Map<List<InvoiceDto>>(users);

            var response = new GetInvoicesResponse()
            {
                Data = mappedInvoices
            };

            return response;
        }
    }
}
