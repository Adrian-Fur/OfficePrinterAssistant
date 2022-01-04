using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands
{
    public class DeletePrinterCommand : CommandBase<Printer, int>
    {
        public int PrinterId { get; set; }

        public override async Task<int> Execute(PrinterAssistantDbContext context)
        {
            var printer = await context.Printers.Where(x => x.Id == PrinterId).FirstOrDefaultAsync();
            context.Printers.Remove(printer);
            await context.SaveChangesAsync();
            return printer.Id;
        }
    }
}
