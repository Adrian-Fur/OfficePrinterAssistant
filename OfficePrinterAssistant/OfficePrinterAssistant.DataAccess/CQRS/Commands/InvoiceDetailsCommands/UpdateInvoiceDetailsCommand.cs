using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands.InvoiceDetailsCommands
{
    public class UpdateInvoiceDetailsCommand : CommandBase<InvoiceDetails, InvoiceDetails>
    {
        public override async Task<InvoiceDetails> Execute(PrinterAssistantDbContext context)
        {
            context.InvoicesDetails.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
