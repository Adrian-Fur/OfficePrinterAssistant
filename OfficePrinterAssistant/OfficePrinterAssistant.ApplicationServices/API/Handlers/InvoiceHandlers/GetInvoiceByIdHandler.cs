using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceResponses;
using OfficePrinterAssistant.ApplicationServices.API.Domain.Models;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.CQRS.Queries.InvoiceQueries;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class GetInvoiceByIdHandler : IRequestHandler<GetInvoiceByIdRequest, GetInvoiceByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetInvoiceByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetInvoiceByIdResponse> Handle(GetInvoiceByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoiceQuery()
            {
                Id = request.Id
            };

            var invoice = await this.queryExecutor.Execute(query);
            var mappedInvoice = this.mapper.Map<InvoiceDto>(invoice);
            var response = new GetInvoiceByIdResponse()
            {
                Data = mappedInvoice
            };
            return response;
        }
    }
}
