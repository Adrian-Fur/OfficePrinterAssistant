using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.DataAccess.CQRS;
using OfficePrinterAssistant.DataAccess.CQRS.Commands;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers
{
    public class AddPrinterHandler : IRequestHandler<AddPrinterRequest, AddPrinterResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddPrinterHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddPrinterResponse> Handle(AddPrinterRequest request, CancellationToken cancellationToken)
        {
            var printer = this.mapper.Map<Printer>(request);
            var command = new AddPrinterCommand()
            {
                Parameter = printer
            };
            var printerFromDb = await this.commandExecutor.Execute(command);
            return new AddPrinterResponse()
            {
                Data = this.mapper.Map<Domain.Models.Printer>(printerFromDb)
            };
        }
    }
}
