using InvoiceCalendar.Domain.Entities;
using System.Collections.Generic;

namespace InvoiceCalendar.Domain.Abstract
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> Invoices { get; }
    }
}
