using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Queries.InvoiceQueries
{
    public class GetInvoicesQuery : QueryBase<List<Invoice>>
    {
        public override async Task<List<Invoice>> Execute(PrinterAssistantDbContext context)
        {
            var invoice = await context.Invoices.Include(x => x.InvoiceDetails).ToListAsync();
            return invoice;
        }
    }
}
