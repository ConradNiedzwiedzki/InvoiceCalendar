using System.Collections.Generic;
using InvoiceCalendar.Domain.Abstract;
using InvoiceCalendar.Domain.Entities;

namespace InvoiceCalendar.Domain.Concrete
{
    public class EFInvoiceRepository : IInvoiceRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Invoice> Invoices
        {
            get { return context.Invoices; }
        }
    }
}
