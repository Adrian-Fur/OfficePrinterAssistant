using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsResponses;
using OfficePrinterAssistant.ApplicationServices.API.Domain.Models;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.CQRS.Queries.InvoiceDetailsQueries;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.InvoiceDetailsHandlers
{
    public class GetInvoiceDetailsByIdHandler : IRequestHandler<GetInvoiceDetailsByIdRequest, GetInvoiceDetailsByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetInvoiceDetailsByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetInvoiceDetailsByIdResponse> Handle(GetInvoiceDetailsByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoiceDetialsByIdQuery()
            {
                Id = request.Id
            };
            var invoiceDetails = await this.queryExecutor.Execute(query);
            var mappedInvoiceDetails = this.mapper.Map<InvoiceDetailsDto>(invoiceDetails);
            var response = new GetInvoiceDetailsByIdResponse()
            {
                Data = mappedInvoiceDetails
            };
            return response;
        }
    }
}
