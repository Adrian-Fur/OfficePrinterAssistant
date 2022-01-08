using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands.SoftwareCommands
{
    public class DeleteSoftwareCommand : CommandBase<Software, int>
    {
        public int Id { get; set; }
        public override async Task<int> Execute(PrinterAssistantDbContext context)
        {
            var software = await context.Softwares.Where(x => x.Id == this.Id).FirstOrDefaultAsync();
            context.Softwares.Remove(software);
            await context.SaveChangesAsync();
            return software.Id;
        }
    }
}
