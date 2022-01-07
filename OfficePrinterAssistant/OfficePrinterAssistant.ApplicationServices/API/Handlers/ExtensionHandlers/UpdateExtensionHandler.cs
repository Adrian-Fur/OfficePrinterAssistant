using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionResponses;
using OfficePrinterAssistant.DataAccess.CQRS;
using OfficePrinterAssistant.DataAccess.CQRS.Commands.ExtensionCommands;
using OfficePrinterAssistant.DataAccess.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers.ExtensionHandlers
{
    public class UpdateExtensionHandler : IRequestHandler<UpdateExtensionRequest, UpdateExtensionResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public UpdateExtensionHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<UpdateExtensionResponse> Handle(UpdateExtensionRequest request, CancellationToken cancellationToken)
        {
            var extension = this.mapper.Map<Extension>(request);
            var command = new UpdateExtensionCommand()
            {
                Parameter = extension
            };
            var extensionFromDb = await this.commandExecutor.Execute(command);
            return new UpdateExtensionResponse()
            {
                Data = this.mapper.Map<Domain.Models.ExtensionDto>(extensionFromDb)
            };

        }
    }
}
