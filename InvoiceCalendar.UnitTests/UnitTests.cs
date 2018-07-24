using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using InvoiceCalendar.Domain.Abstract;
using InvoiceCalendar.Domain.Entities;
using InvoiceCalendar.WebUI.Controllers;
using InvoiceCalendar.WebUI.Models;
using System.Web.Mvc;
using InvoiceCalendar.WebUI.HtmlHelpers;
using System;

namespace InvoiceCalendar.UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IInvoiceRepository> mock = new Mock<IInvoiceRepository>();
            mock.Setup(m => m.Invoices).Returns(new Invoice[] {
                new Invoice {InvoiceID = 1, Company = "I1"},
                new Invoice {InvoiceID = 2, Company = "I2"},
                new Invoice {InvoiceID = 3, Company = "I3"},
                new Invoice {InvoiceID = 4, Company = "I4"},
                new Invoice {InvoiceID = 5, Company = "I5"}
            });
            InvoiceController controller = new InvoiceController(mock.Object);
            controller.PageSize = 3;

            IEnumerable<Invoice> result = (IEnumerable<Invoice>)controller.List(2).Model;

            Invoice[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Company, "P4");
            Assert.AreEqual(prodArray[1].Company, "P5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper myHelper = null;
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            Func<int, string> pageUrlDelegate = i => "Strona" + i;

            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Strona1"">1</a>" + @"<a class="" btn btn-default btn-primary selected"" href=""Strona2"">2</a>"
                    + @"<a class=""btn btn-default"" href=""Strona3"">3</a>", result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            Mock<IInvoiceRepository> mock = new Mock<IInvoiceRepository>();
            mock.Setup(m => m.Invoices).Returns(new Invoice[] {
                new Invoice {InvoiceID = 1, Company = "I1"},
                new Invoice {InvoiceID = 2, Company = "I2"},
                new Invoice {InvoiceID = 3, Company = "I3"},
                new Invoice {InvoiceID = 4, Company = "I4"},
                new Invoice {InvoiceID = 5, Company = "I5"}
            });

            InvoiceController controller = new InvoiceController(mock.Object);
            controller.PageSize = 3;

            InvoicesListViewModel result = (InvoicesListViewModel)controller.List(2).Model;

            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}