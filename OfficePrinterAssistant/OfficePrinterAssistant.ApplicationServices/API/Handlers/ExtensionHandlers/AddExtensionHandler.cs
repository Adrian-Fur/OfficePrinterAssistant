using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionResponses;
using OfficePrinterAssistant.DataAccess.CQRS;
using OfficePrinterAssistant.DataAccess.CQRS.Commands.ExtensionCommands;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.ExtensionHandlers
{
    public class AddExtensionHandler : IRequestHandler<AddExtensionRequest, AddExtensionResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddExtensionHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddExtensionResponse> Handle(AddExtensionRequest request, CancellationToken cancellationToken)
        {
            var extension = this.mapper.Map<Extension>(request);
            var command = new AddExtensionCommand()
            {
                Parameter = extension
            };
            var extensionFromDb = await this.commandExecutor.Execute(command);
            return new AddExtensionResponse()
            {
                Data = this.mapper.Map<Domain.Models.ExtensionDto>(extensionFromDb)
            };
        }
    }
}
