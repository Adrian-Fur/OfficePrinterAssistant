using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Queries.InvoiceQueries
{
    public class GetInvoiceQuery : QueryBase<Invoice>
    {
        public int Id { get; set; }
        public override async Task<Invoice> Execute(PrinterAssistantDbContext context)
        {
            var invoice = await context.Invoices.Include(x => x.InvoiceDetails).FirstOrDefaultAsync(x => x.Id == this.Id);
            return invoice;
        }
    }
}
