using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceResponses;
using OfficePrinterAssistant.DataAccess.CQRS;
using OfficePrinterAssistant.DataAccess.CQRS.Commands.InvoiceCommands;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class DeleteInvoiceHandler : IRequestHandler<DeleteInvoiceRequest, DeleteInvoiceResponse>
    {
        private readonly ICommandExecutor commandExecutor;

        public DeleteInvoiceHandler(ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }
        public async Task<DeleteInvoiceResponse> Handle(DeleteInvoiceRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteInvoiceCommand()
            {
                Id = request.Id,
            };
            var invoiceFromDb = await this.commandExecutor.Execute(command);
            return new DeleteInvoiceResponse()
            {
                Data = invoiceFromDb
            };
        }
    }
}
