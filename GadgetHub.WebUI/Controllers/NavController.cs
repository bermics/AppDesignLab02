using System;
using System.Linq;
using System.Web.Mvc;
using GadgetHub.Domain.Abstract;

namespace GadgetHub.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IGadgetRepository repository;

        public NavController(IGadgetRepository repo)
        {
            this.repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            if (repository == null || repository.Gadgets == null)
            {
                return PartialView(Enumerable.Empty<string>());
            }

            var categories = repository.Gadgets
                                       .Select(g => g.Category)
                                       .Distinct()
                                       .OrderBy(c => c)
                                       .ToList();

            return PartialView("Menu", categories);
        }
    }
}
