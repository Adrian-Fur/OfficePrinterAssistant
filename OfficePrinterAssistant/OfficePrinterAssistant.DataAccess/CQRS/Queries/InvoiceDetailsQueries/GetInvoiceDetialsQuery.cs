using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Queries.InvoiceDetailsQueries
{
    public class GetInvoiceDetialsQuery : QueryBase<List<InvoiceDetails>>
    {
        public override async Task<List<InvoiceDetails>> Execute(PrinterAssistantDbContext context)
        {
            var invoiceDetails = await context.InvoicesDetails.ToListAsync();
            return invoiceDetails;
        }
    }
}
