using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Queries.ExtensionQueries
{
    public class GetExtensionQuery : QueryBase<Extension>
    {
        public int Id { get; set; }

        public async override Task<Extension> Execute(PrinterAssistantDbContext context)
        {
            var extension = await context.Extensions.FirstOrDefaultAsync(x => x.Id == this.Id);
            return extension;
        }
    }
}
