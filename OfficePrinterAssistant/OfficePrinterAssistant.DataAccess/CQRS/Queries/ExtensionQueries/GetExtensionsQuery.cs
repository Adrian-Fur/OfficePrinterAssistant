using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Queries.ExtensionQueries
{
    public class GetExtensionsQuery : QueryBase<List<Extension>>
    {
        public async override Task<List<Extension>> Execute(PrinterAssistantDbContext context)
        {
            var extensions = await context.Extensions.ToListAsync();
            return extensions;
        }
    }
}
