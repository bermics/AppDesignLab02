using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Moq;
using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;
using Ninject.Planning.Targets;
using System.Web.Mvc;
using GadgetHub.Domain.Concrete;

namespace GadgetHub.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel mykernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            mykernel = kernelParam;
            AddBinding();
        }

        public object GetService(Type myserviceType)
        {
            return mykernel.TryGet(myserviceType);
        }

        public IEnumerable<object> GetServices(Type myserviceType)
        {
            return mykernel.GetAll(myserviceType);
        }

        private void AddBinding()
        {
            mykernel.Bind<IGadgetRepository>().To<EFGadgetRepository>();
            // Mock Repository
            //var mock = new Mock<IGadgetRepository>();
            //mock.Setup(m => m.Gadgets).Returns(new List<Gadget>
            //{
            //    new Gadget { GadgetId = 1, Name = "Galaxy S23", Brand = "Samsung", Price = 500, Description = "Samsung Smartphone with Galaxy AI", Category = "Smartphones" },
            //    new Gadget { GadgetId = 2, Name = "ASUS TUF Gaming Laptop A15", Brand = "ASUS", Price = 699, Description = "144 Hz Gaming Laptop", Category = "Laptops" },
            //    new Gadget { GadgetId = 3, Name = "Samsung Buds Pro 3", Brand = "Samsung", Price = 149, Description = "3rd Gen of Samsung Earbuds", Category = "Headphones" },
            //    new Gadget { GadgetId = 4, Name = "Focusrite Scarlett Solo 3rd Gen USB Audio Interface", Brand = "Focusrite", Price = 130, Description = "Audio Interface for Guitarists, Vocalists, Podcasters, etc.", Category = "Accessories" }
            //});

            //mykernel.Bind<IGadgetRepository>().ToConstant(mock.Object);
        }
    }
}