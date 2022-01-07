using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.CQRS.Queries.ExtensionQueries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.ExtensionHandlers
{
    public class GetExtensionsHandler : IRequestHandler<GetExtensionsRequest, GetExtensionsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetExtensionsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetExtensionsResponse> Handle(GetExtensionsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetExtensionsQuery();
            var extensions = await this.queryExecutor.Execute(query);
            var mappedExtensions = this.mapper.Map<List<Domain.Models.ExtensionDto>>(extensions);
            var response = new GetExtensionsResponse()
            {
                Data = mappedExtensions
            };
            return response;
        }
    }
}
