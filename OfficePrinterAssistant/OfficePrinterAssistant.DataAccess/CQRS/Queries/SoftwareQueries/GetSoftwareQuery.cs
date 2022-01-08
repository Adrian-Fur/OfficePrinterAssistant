using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Queries.SoftwareQueries
{
    public class GetSoftwareQuery : QueryBase<Software>
    {
        public int Id { get; set; }
        public override async Task<Software> Execute(PrinterAssistantDbContext context)
        {
            var user = await context.Softwares.FirstOrDefaultAsync(x => x.Id == this.Id);
            return user;
        }
    }
}
