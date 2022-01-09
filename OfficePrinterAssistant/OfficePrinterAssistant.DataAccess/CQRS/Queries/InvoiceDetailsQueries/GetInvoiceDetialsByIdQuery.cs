using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Queries.InvoiceDetailsQueries
{
    public class GetInvoiceDetialsByIdQuery : QueryBase<InvoiceDetails>
    {
        public int Id { get; set; }
        public override async Task<InvoiceDetails> Execute(PrinterAssistantDbContext context)
        {
            var invoiceDetails = await context.InvoicesDetails.FirstOrDefaultAsync(x => x.Id == this.Id);
            return invoiceDetails;
        }
    }
}
