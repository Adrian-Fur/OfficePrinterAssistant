using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.CQRS.Queries.SoftwareQueries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.SoftwareHandlers
{
    public class GetSoftwaresHandler : IRequestHandler<GetSoftwaresRequest, GetSoftwaresResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetSoftwaresHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetSoftwaresResponse> Handle(GetSoftwaresRequest request, CancellationToken cancellationToken)
        {
            var query = new GetSoftwaresQuery();
            var softwares = await this.queryExecutor.Execute(query);
            var mappedSoftwares = this.mapper.Map<List<Domain.Models.SoftwareDto>>(softwares);
            var response = new GetSoftwaresResponse()
            {
                Data = mappedSoftwares
            };
            return response;
        }
    }
}
