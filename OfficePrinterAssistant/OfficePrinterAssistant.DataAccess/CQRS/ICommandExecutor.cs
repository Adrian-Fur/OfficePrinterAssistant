using OfficePrinterAssistant.DataAccess.CQRS.Commands;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);
    }
}
