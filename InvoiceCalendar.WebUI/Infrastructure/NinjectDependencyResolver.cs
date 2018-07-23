using InvoiceCalendar.Domain.Abstract;
using InvoiceCalendar.Domain.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceCalendar.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
        
        private void AddBindings()
        {
            Mock<IInvoiceRepository> mock = new Mock<IInvoiceRepository>();
            mock.Setup(m => m.Invoices).Returns(new List<Invoice> {
                new Invoice { Company = "KMD", Price = 1100, Date = DateTime.Today },
                new Invoice { Company = "DPD", Price = 800, Date = DateTime.Today },
                new Invoice { Company = "Paxer", Price = 350, Date = DateTime.Today }
            });
            _kernel.Bind<IInvoiceRepository>().ToConstant(mock.Object);
        }
    }
}