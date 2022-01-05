using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Queries.UserQueries
{
    public class GetUserQuery : QueryBase<User>
    {
        public int Id { get; set; }

        public override async Task<User> Execute(PrinterAssistantDbContext context)
        {
            var user = await context.Users.Include(x => x.PrintersList).FirstOrDefaultAsync(x => x.Id == this.Id);
            return user;
        }
    }
}
