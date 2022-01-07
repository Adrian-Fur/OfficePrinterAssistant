using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands.UserCommands
{
    public class AddUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(PrinterAssistantDbContext context)
        {
            await context.Users.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
