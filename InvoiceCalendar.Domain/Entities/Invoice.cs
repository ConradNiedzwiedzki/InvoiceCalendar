using System;

namespace InvoiceCalendar.Domain.Entities
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
