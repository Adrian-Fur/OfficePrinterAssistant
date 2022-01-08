using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareResponses;
using OfficePrinterAssistant.DataAccess.CQRS;
using OfficePrinterAssistant.DataAccess.CQRS.Commands.SoftwareCommands;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.SoftwareHandlers
{
    public class AddSoftwareHandler : IRequestHandler<AddSoftwareRequest, AddSoftwareResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddSoftwareHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddSoftwareResponse> Handle(AddSoftwareRequest request, CancellationToken cancellationToken)
        {
            var software = this.mapper.Map<Software>(request);
            var command = new AddSoftwareCommand()
            {
                Parameter = software
            };
            var softwareFromDb = await this.commandExecutor.Execute(command);
            return new AddSoftwareResponse()
            {
                Data = this.mapper.Map<Domain.Models.SoftwareDto>(softwareFromDb)
            };
        }
    }
}
