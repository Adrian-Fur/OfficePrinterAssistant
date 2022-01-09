using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Queries.UserQueries
{
    public class GetUserQuery : QueryBase<User>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public override async Task<User> Execute(PrinterAssistantDbContext context)
        {
            if(this.Username == null)
            {
                return await context.Users.Include(x => x.PrintersList).FirstOrDefaultAsync(x => x.Id == this.Id);
            }
            return await context.Users.Include(x => x.PrintersList).FirstOrDefaultAsync(x => x.Name == this.Username);
        }
    }
}
