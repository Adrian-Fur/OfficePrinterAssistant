using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionResponses;
using OfficePrinterAssistant.DataAccess.CQRS;
using OfficePrinterAssistant.DataAccess.CQRS.Commands.ExtensionCommands;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.ExtensionHandlers
{
    public class DeleteExtensionHandler : IRequestHandler<DeleteExtensionRequest, DeleteExtensionResponse>
    {
        private readonly ICommandExecutor commandExecutor;

        public DeleteExtensionHandler(ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }
        public async Task<DeleteExtensionResponse> Handle(DeleteExtensionRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteExtensionCommand()
            {
                Id = request.Id
            };
            var extensionFromDb = await this.commandExecutor.Execute(command);
            return new DeleteExtensionResponse()
            {
                Data = extensionFromDb
            };
        }
    }
}
