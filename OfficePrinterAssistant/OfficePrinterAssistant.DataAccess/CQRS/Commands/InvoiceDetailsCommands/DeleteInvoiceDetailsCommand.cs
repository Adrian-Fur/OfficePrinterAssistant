using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands.InvoiceDetailsCommands
{
    public class DeleteInvoiceDetailsCommand : CommandBase<InvoiceDetails, int>
    {
        public int Id { get; set; }
        public override async Task<int> Execute(PrinterAssistantDbContext context)
        {
            var invoiceDetails = await context.InvoicesDetails.FirstOrDefaultAsync(x => x.Id == this.Id);
            context.InvoicesDetails.Remove(invoiceDetails);
            await context.SaveChangesAsync();
            return invoiceDetails.Id;
        }
    }
}
