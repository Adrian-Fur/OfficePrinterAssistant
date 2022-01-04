using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.PrinterRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.PrinterResponses;
using OfficePrinterAssistant.DataAccess.CQRS;
using OfficePrinterAssistant.DataAccess.CQRS.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers
{
    public class DeletePrinterHandler : IRequestHandler<DeletePrinterRequest, DeletePrinterResponse>
    {
        private readonly ICommandExecutor commandExecutor;

        public DeletePrinterHandler(ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }
        public async Task<DeletePrinterResponse> Handle(DeletePrinterRequest request, CancellationToken cancellationToken)
        {
            var command = new DeletePrinterCommand()
            {
                PrinterId = request.PrinterId
            };

            var printerFromDb = await this.commandExecutor.Execute(command);
            return new DeletePrinterResponse()
            {
                Data = printerFromDb
            };
            
        }
    }
}
