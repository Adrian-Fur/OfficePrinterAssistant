using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands.SoftwareCommands
{
    public class UpdateSoftwareCommand : CommandBase<Software, Software>
    {
        public override async Task<Software> Execute(PrinterAssistantDbContext context)
        {
            context.Softwares.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
