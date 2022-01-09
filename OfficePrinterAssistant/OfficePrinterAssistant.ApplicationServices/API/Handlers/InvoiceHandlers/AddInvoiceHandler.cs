using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceResponses;
using OfficePrinterAssistant.ApplicationServices.API.Domain.Models;
using OfficePrinterAssistant.DataAccess.CQRS;
using OfficePrinterAssistant.DataAccess.CQRS.Commands.InvoiceCommands;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class AddInvoiceHandler : IRequestHandler<AddInvoiceRequest, AddInvoiceResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddInvoiceHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddInvoiceResponse> Handle(AddInvoiceRequest request, CancellationToken cancellationToken)
        {
            var invoice = this.mapper.Map<Invoice>(request);
            var command = new AddInvoiceCommand()
            {
                Parameter = invoice
            };
            var invoiceFromDb = await this.commandExecutor.Execute(command);
            return new AddInvoiceResponse()
            {
                Data = this.mapper.Map<InvoiceDto>(invoiceFromDb)
            };
        }
    }
}
