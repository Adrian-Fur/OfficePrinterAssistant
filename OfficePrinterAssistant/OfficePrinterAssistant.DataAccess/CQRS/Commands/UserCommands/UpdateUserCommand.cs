using OfficePrinterAssistant.DataAccess.Entities;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Commands.UserCommands
{
    public class UpdateUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(PrinterAssistantDbContext context)
        {
            context.Users.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
