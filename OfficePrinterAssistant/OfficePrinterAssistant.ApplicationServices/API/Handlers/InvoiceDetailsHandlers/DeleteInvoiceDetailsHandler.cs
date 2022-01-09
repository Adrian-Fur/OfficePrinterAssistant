using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsResponses;
using OfficePrinterAssistant.DataAccess.CQRS;
using OfficePrinterAssistant.DataAccess.CQRS.Commands.InvoiceDetailsCommands;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.InvoiceDetailsHandlers
{
    public class DeleteInvoiceDetailsHandler : IRequestHandler<DeleteInvoiceDetailsRequest, DeleteInvoiceDetailsResponse>
    {
        private readonly ICommandExecutor commandExecutor;

        public DeleteInvoiceDetailsHandler(ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }
        public async Task<DeleteInvoiceDetailsResponse> Handle(DeleteInvoiceDetailsRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteInvoiceDetailsCommand()
            {
                Id = request.Id
            };
            var invoiceDetailsFromDb = await this.commandExecutor.Execute(command);
            return new DeleteInvoiceDetailsResponse()
            {
                Data = invoiceDetailsFromDb
            };
        }
    }
}
