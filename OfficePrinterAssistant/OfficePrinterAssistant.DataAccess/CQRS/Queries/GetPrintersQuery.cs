using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Queries
{
    public class GetPrintersQuery : QueryBase<List<Printer>>
    {
        public string Mark { get; set; }

        public override Task<List<Printer>> Execute(PrinterAssistantDbContext context)
        {
            if(this.Mark == null)
            {
                return context.Printers.ToListAsync();
            }
            return context.Printers.Where(x => x.Mark == this.Mark).ToListAsync();
        }
    }
}
