using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands.InvoiceCommands
{
    public class DeleteInvoiceCommand : CommandBase<Invoice, int>
    {
        public int Id { get; set; }
        public override async Task<int> Execute(PrinterAssistantDbContext context)
        {
            var invoice = await context.Invoices.FirstOrDefaultAsync(x => x.Id == this.Id);
            context.Invoices.Remove(invoice);
            await context.SaveChangesAsync();
            return invoice.Id;
        }
    }
}
