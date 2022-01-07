using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands.ExtensionCommands
{
    public class UpdateExtensionCommand : CommandBase<Extension, Extension>
    {
        public override async Task<Extension> Execute(PrinterAssistantDbContext context)
        {
            context.Extensions.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
