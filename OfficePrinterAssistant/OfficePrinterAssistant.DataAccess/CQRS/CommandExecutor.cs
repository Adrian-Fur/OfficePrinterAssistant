using OfficePrinterAssistant.DataAccess.CQRS.Commands;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly PrinterAssistantDbContext context;

        public CommandExecutor(PrinterAssistantDbContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}
