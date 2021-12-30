using Microsoft.EntityFrameworkCore;
using OfficePrinterAssistant.DataAccess.Entities;

namespace OfficePrinterAssistant.DataAccess
{
    public class PrinterAssistantDbContext : DbContext
    {
        public PrinterAssistantDbContext(DbContextOptions<PrinterAssistantDbContext> options) : base(options)
        {
        }

        public DbSet<Printer> Printers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices { get; set; }    
        public DbSet<InvoiceDetails> InvoicesDetails { get; set; }
        public DbSet<Extension> Extensions { get; set; }
        public DbSet<Software>  Softwares { get; set; } 
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
