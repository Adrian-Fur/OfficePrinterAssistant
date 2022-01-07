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
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddUserHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<User>(request);
            var command = new AddUserCommand()
            {
                Parameter = user
            };
            var printerFromDb = await this.commandExecutor.Execute(command);
            return new AddUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.UserDto>(printerFromDb)
            };
        }
    }
}
