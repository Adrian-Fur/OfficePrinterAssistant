using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands.ExtensionCommands
{
    public class DeleteExtensionCommand : CommandBase<Extension, int>
    {
        public int Id { get; set; }
        public override async Task<int> Execute(PrinterAssistantDbContext context)
        {
            var extension = await context.Extensions.Where(x => x.Id == this.Id).FirstOrDefaultAsync();
            context.Extensions.Remove(extension);
            await context.SaveChangesAsync();
            return extension.Id;
        }
    }
}
