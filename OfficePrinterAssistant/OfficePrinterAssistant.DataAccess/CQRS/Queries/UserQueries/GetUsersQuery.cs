using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Queries.UserQueries
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        public string Name { get; set; }

        public override async Task<List<User>> Execute(PrinterAssistantDbContext context)
        {

            if(this.Name == null)
            {
                var users = await context.Users
                    .Include(x => x.PrintersList).ToListAsync();
                return users;
            }
            return await context.Users.Where(x => x.Name == this.Name).Include(x => x.PrintersList).ToListAsync();
        }
    }
}
