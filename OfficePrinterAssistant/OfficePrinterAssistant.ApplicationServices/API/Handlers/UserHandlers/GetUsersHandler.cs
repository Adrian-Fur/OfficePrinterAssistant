using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.CQRS.Queries.UserQueries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.UserHandlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetUsersHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery()
            {
                Name = request.Name
            };

            var users = await this.queryExecutor.Execute(query);
            var mappedUsers = this.mapper.Map<List<Domain.Models.UserDto>>(users);

            var response = new GetUsersResponse()
            {
                Data = mappedUsers
            };

            return response;
        }
    }
}
