using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands
{
    public class AddPrinterCommand : CommandBase<Printer, Printer>
    {
        public override async Task<Printer> Execute(PrinterAssistantDbContext context)
        {
            await context.Printers.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
