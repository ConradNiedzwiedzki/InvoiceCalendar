using InvoiceCalendar.Domain.Entities;
using System.Collections.Generic;

namespace InvoiceCalendar.WebUI.Models
{
    public class InvoicesListViewModel
    {
        public IEnumerable<Invoice> Invoices { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}