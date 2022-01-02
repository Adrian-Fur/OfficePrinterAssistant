using OfficePrinterAssistant.DataAccess.CQRS.Queries;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
