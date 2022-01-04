using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.PrinterRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.PrinterResponses;
using OfficePrinterAssistant.DataAccess.CQRS;
using OfficePrinterAssistant.DataAccess.CQRS.Commands;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers
{
    public class UpdatePrinterHandler : IRequestHandler<UpdatePrinterRequest, UpdatePrinterResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public UpdatePrinterHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<UpdatePrinterResponse> Handle(UpdatePrinterRequest request, CancellationToken cancellationToken)
        {
            var printer = this.mapper.Map<Printer>(request);
            var command = new UpdatePrinterCommand()
            {
                Parameter = printer
            };

            var printerFromDb = await this.commandExecutor.Execute(command);
            return new UpdatePrinterResponse()
            {
                Data = this.mapper.Map<Domain.Models.PrinterDto>(printerFromDb)
            };
        }
    }
}
