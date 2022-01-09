using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands.InvoiceDetailsCommands
{
    public class AddInvoiceDetailsCommand : CommandBase<InvoiceDetails, InvoiceDetails>
    {
        public async override Task<InvoiceDetails> Execute(PrinterAssistantDbContext context)
        {
            await context.InvoicesDetails.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
