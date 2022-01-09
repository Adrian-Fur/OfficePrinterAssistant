using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsResponses;
using OfficePrinterAssistant.ApplicationServices.API.Domain.Models;
using OfficePrinterAssistant.DataAccess.CQRS;
using OfficePrinterAssistant.DataAccess.CQRS.Commands.InvoiceDetailsCommands;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.InvoiceDetailsHandlers
{
    public class UpdateInvoiceDetailsHandler : IRequestHandler<UpdateInvoiceDetailsRequest, UpdateInvoiceDetailsResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public UpdateInvoiceDetailsHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<UpdateInvoiceDetailsResponse> Handle(UpdateInvoiceDetailsRequest request, CancellationToken cancellationToken)
        {
            var invoiceDetails = this.mapper.Map<InvoiceDetails>(request);
            var command = new UpdateInvoiceDetailsCommand()
            {
                Parameter = invoiceDetails
            };
            var invoiceDetailsFromDb = await this.commandExecutor.Execute(command);
            return new UpdateInvoiceDetailsResponse()
            {
                Data = this.mapper.Map<InvoiceDetailsDto>(invoiceDetailsFromDb)
            };
        }
    }
}
