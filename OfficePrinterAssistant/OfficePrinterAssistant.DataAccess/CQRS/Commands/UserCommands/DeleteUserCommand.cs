using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands.UserCommands
{
    public class DeleteUserCommand : CommandBase<User, int>
    {
        public int UserId { get; set; }

        public override async Task<int> Execute(PrinterAssistantDbContext context)
        {
            var user = await context.Users.Where(x => x.Id == this.UserId).FirstOrDefaultAsync();
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return user.Id;
        }
    }
}
