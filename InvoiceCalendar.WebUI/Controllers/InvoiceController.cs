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
        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            this._repository = invoiceRepository;
        }

        public ViewResult List()
        {
            return View(_repository.Invoices);
        }
    }
}