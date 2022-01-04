using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands
{
    public class UpdatePrinterCommand : CommandBase<Printer, Printer>
    {
        public override async Task<Printer> Execute(PrinterAssistantDbContext context)
        {
            context.Printers.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
