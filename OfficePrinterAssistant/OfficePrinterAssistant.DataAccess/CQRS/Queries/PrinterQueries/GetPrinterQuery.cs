using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Queries
{
    public class GetPrinterQuery : QueryBase<Printer>
    {
        public int Id { get; set; }

        public override async Task<Printer> Execute(PrinterAssistantDbContext context)
        {
            var printer = await context.Printers.FirstOrDefaultAsync(x => x.Id == this.Id);
            return printer;
        }
    }
}
