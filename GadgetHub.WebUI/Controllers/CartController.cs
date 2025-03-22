using System;
using System.Linq;
using System.Web.Mvc;
using GadgetHub.Models;

namespace GadgetHub.WebUI.Controllers
{
    public class CartController : Controller
    {
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart ?? new Cart();
            return cart;
        }

        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult AddToCart(int productId, string name, decimal price)
        {
            Cart cart = GetCart();
            cart.AddItem(productId, name, price);
            // Success message
            TempData["SuccessMessage"] = $"{name} has been added to your cart!";
            Session["Cart"] = cart;
            return RedirectToAction("List", "Gadget");
        }

        public ActionResult RemoveFromCart(int productId)
        {
            Cart cart = GetCart();
            cart.RemoveItem(productId);

            // Success message
            TempData["SuccessMessage"] = "Item removed from cart!";

            Session["Cart"] = cart;
            return RedirectToAction("Index");
        }
    }
}
