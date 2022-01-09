using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands.InvoiceCommands
{
    public class AddInvoiceCommand : CommandBase<Invoice, Invoice>
    {
        public override async Task<Invoice> Execute(PrinterAssistantDbContext context)
        {
            await context.Invoices.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
