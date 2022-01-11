using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace OfficePrinterAssistant.DataAccess
{
    public class PrinterAssistantDbContextFactory : IDesignTimeDbContextFactory<PrinterAssistantDbContext>
    {
        public PrinterAssistantDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PrinterAssistantDbContext>();
            optionsBuilder.UseSqlServer("Server=tcp:office-printer-assistant.database.windows.net,1433;Initial Catalog=OfficePrinterAssistant;Persist Security Info=False;User ID=adrian;Password=vcgnbeXm5WJdAQek;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new PrinterAssistantDbContext(optionsBuilder.Options);
        }
    }
}
