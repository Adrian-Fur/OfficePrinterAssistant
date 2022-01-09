using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsResponses;
using OfficePrinterAssistant.DataAccess.CQRS;
using OfficePrinterAssistant.DataAccess.CQRS.Commands.InvoiceDetailsCommands;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.InvoiceDetailsHandlers
{
    public class AddInvoiceDetailsHandler : IRequestHandler<AddInvoiceDetailsRequest, AddInvoiceDetailsResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddInvoiceDetailsHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddInvoiceDetailsResponse> Handle(AddInvoiceDetailsRequest request, CancellationToken cancellationToken)
        {
            var invoiceDetails = this.mapper.Map<InvoiceDetails>(request);
            var command = new AddInvoiceDetailsCommand()
            {
                Parameter = invoiceDetails
            };
            var invoiceDetailsFromDb = await this.commandExecutor.Execute(command);
            var response = new AddInvoiceDetailsResponse()
            {
                Data = this.mapper.Map<Domain.Models.InvoiceDetailsDto>(invoiceDetailsFromDb)
            };
            return response;
        }
    }
}
