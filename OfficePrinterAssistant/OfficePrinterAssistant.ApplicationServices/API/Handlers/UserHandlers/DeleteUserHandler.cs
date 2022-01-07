using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.UserRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.UserResponses;
using OfficePrinterAssistant.DataAccess.CQRS;
using OfficePrinterAssistant.DataAccess.CQRS.Commands.UserCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.UserHandlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly ICommandExecutor commandExecutor;

        public DeleteUserHandler(ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }
        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteUserCommand()
            {
                UserId = request.Id
            };

            var userFromDb = await this.commandExecutor.Execute(command);
            return new DeleteUserResponse()
            {
                Data = userFromDb
            };
        }
    }
}
