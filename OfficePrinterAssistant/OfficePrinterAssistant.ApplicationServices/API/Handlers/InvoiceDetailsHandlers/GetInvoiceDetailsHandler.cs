using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsResponses;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.CQRS.Queries.InvoiceDetailsQueries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.InvoiceDetailsHandlers
{
    public class GetInvoiceDetailsHandler : IRequestHandler<GetInvoiceDetailsRequest, GetInvoiceDetailsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetInvoiceDetailsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetInvoiceDetailsResponse> Handle(GetInvoiceDetailsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoiceDetialsQuery();
            var invoiceDetails = await this.queryExecutor.Execute(query);
            var mappedInvoiceDetails = this.mapper.Map<List<Domain.Models.InvoiceDetailsDto>>(invoiceDetails);
            var response = new GetInvoiceDetailsResponse()
            {
                Data = mappedInvoiceDetails
            };
            return response;
        }
    }
}
