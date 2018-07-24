using InvoiceCalendar.Domain.Abstract;
using InvoiceCalendar.WebUI.Models;
using System.Linq;
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
            InvoicesListViewModel model = new InvoicesListViewModel
            {
                Invoices = _repository.Invoices
                    .OrderBy(p => p.InvoiceID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Invoices.Count()
                }
            };
            return View(model);
        }
    }
}