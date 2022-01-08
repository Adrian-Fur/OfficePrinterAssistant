using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Queries.SoftwareQueries
{
    public class GetSoftwaresQuery : QueryBase<List<Software>>
    {
        public override async Task<List<Software>> Execute(PrinterAssistantDbContext context)
        {
            var software = await context.Softwares.ToListAsync();
            return software;
        }
    }
}
