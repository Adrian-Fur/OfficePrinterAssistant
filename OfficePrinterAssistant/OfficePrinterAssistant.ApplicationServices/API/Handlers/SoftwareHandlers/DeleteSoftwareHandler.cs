using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareResponses;
using OfficePrinterAssistant.DataAccess.CQRS;
using OfficePrinterAssistant.DataAccess.CQRS.Commands.SoftwareCommands;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.SoftwareHandlers
{
    public class DeleteSoftwareHandler : IRequestHandler<DeleteSoftwareRequest, DeleteSoftwareResponse>
    {
        private readonly ICommandExecutor commandExecutor;

        public DeleteSoftwareHandler(ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }
        public async Task<DeleteSoftwareResponse> Handle(DeleteSoftwareRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteSoftwareCommand()
            {
                Id = request.Id,
            };
            var softwareFromDb = await this.commandExecutor.Execute(command);
            return new DeleteSoftwareResponse()
            {
                Data = softwareFromDb
            };

        }
    }
}
