using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.UserRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.UserResponses;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.CQRS.Queries.UserQueries;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.UserHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetUserByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                Id = request.UserId,
            };

            var user = await this.queryExecutor.Execute(query);
            var mappedUser = this.mapper.Map<Domain.Models.UserDto>(user);
            var response = new GetUserByIdResponse()
            {
                Data = mappedUser
            };

            return response;
        }
    }
}
