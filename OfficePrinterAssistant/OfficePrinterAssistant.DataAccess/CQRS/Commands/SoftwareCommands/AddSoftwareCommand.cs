using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands.SoftwareCommands
{
    public class AddSoftwareCommand : CommandBase<Software, Software>
    {
        public override async Task<Software> Execute(PrinterAssistantDbContext context)
        {
            await context.Softwares.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
