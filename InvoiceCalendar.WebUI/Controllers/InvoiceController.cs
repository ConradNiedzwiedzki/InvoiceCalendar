using InvoiceCalendar.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceCalendar.WebUI.Controllers
{
    public class InvoiceController : Controller
    {
        private IInvoiceRepository _repository;
        public int PageSize = 4;
        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            this._repository = invoiceRepository;
        }

        public ViewResult List(int page = 1)
        {
            return View(_repository.Invoices
            .OrderBy(p => p.InvoiceID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize));
        }
    }
}