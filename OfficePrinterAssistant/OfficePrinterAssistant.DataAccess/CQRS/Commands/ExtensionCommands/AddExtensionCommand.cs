using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands.ExtensionCommands
{
    public class AddExtensionCommand : CommandBase<Extension, Extension>
    {
        public override async Task<Extension> Execute(PrinterAssistantDbContext context)
        {
            await context.Extensions.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
