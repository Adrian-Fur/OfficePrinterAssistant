using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareResponses;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.CQRS.Queries.SoftwareQueries;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.SoftwareHandlers
{
    public class GetSoftwareByIdHandler : IRequestHandler<GetSoftwareByIdRequest, GetSoftwareByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetSoftwareByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetSoftwareByIdResponse> Handle(GetSoftwareByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetSoftwareQuery()
            {
                Id = request.Id
            };

            var software = await this.queryExecutor.Execute(query);
            var mappedSoftware = this.mapper.Map<Domain.Models.SoftwareDto>(software);
            var response = new GetSoftwareByIdResponse()
            {
                Data = mappedSoftware
            };
            return response;
        }
    }
}
