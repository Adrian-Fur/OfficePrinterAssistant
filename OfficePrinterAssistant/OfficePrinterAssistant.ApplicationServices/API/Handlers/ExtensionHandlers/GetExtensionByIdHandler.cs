using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionResponses;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.CQRS.Queries.ExtensionQueries;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.ExtensionHandlers
{
    public class GetExtensionByIdHandler : IRequestHandler<GetExtensionByIdRequest, GetExtensionByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetExtensionByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetExtensionByIdResponse> Handle(GetExtensionByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetExtensionQuery()
            {
                Id = request.Id,
            };
            var extension = await this.queryExecutor.Execute(query);
            var mappedExtension = this.mapper.Map<Domain.Models.ExtensionDto>(extension);
            var response = new GetExtensionByIdResponse()
            {
                Data = mappedExtension
            };
            return response;
        }
    }
}
