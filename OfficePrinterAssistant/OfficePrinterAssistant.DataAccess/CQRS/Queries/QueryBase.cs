using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess.CQRS.Queries
{
    public abstract class QueryBase<TResult>
    {
        public abstract Task<TResult> Execute(PrinterAssistantDbContext context);
    }
}
