using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace OfficePrinterAssistant.DataAccess
{
    public class PrinterAssistantDbContextFactory : IDesignTimeDbContextFactory<PrinterAssistantDbContext>
    {
        public PrinterAssistantDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PrinterAssistantDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=OfficePrinterAssistant;Integrated Security=True");
            return new PrinterAssistantDbContext(optionsBuilder.Options);
        }
    }
}
