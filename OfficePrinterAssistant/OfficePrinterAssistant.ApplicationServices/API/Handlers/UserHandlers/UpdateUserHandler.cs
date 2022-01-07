using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.UserRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.UserResponses;
using OfficePrinterAssistant.DataAccess.CQRS;
using OfficePrinterAssistant.DataAccess.CQRS.Commands.UserCommands;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.UserHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public UpdateUserHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<User>(request);
            var command = new UpdateUserCommand()
            {
                Parameter = user
            };
            var userFromDb = await this.commandExecutor.Execute(command);
            return new UpdateUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.UserDto>(userFromDb)
            };
        }
    }
}
