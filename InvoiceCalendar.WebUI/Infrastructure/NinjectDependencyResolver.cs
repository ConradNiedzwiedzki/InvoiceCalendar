using InvoiceCalendar.Domain.Abstract;
using InvoiceCalendar.Domain.Entities;
using InvoiceCalendar.Domain.Concrete;
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
            _kernel.Bind<IInvoiceRepository>().To<EFInvoiceRepository>();
        }
    }
}