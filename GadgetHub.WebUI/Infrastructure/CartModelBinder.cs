using System.Web.Mvc;
using GadgetHub.Models;

namespace GadgetHub.Infrastructure
{
    public class CartModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var cart = (Cart)controllerContext.HttpContext.Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session["Cart"] = cart;
            }
            return cart;
        }
    }
}
