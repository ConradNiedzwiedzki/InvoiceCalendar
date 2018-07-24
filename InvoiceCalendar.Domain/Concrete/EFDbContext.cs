using InvoiceCalendar.Domain.Entities;
using System.Data.Entity;

namespace InvoiceCalendar.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
    }
}