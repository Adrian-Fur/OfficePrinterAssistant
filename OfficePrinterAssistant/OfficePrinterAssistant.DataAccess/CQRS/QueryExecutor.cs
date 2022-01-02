using OfficePrinterAssistant.DataAccess.CQRS.Queries;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly PrinterAssistantDbContext context;

        public QueryExecutor(PrinterAssistantDbContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context); 
        }
    }
}
