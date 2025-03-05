using System.Linq;
using System.Web.Mvc;
using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;
using GadgetHub.WebUI.Models;

namespace GadgetHub.WebUI.Controllers
{
    public class GadgetController : Controller
    {
        private readonly IGadgetRepository repository;
        public int PageSize = 5;

        public GadgetController(IGadgetRepository gadgetRepository)
        {
            repository = gadgetRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            // Apply category filtering if a category is selected
            var filteredGadgets = repository.Gadgets
                .Where(g => category == null || g.Category == category)
                .OrderBy(g => g.GadgetId)
                .ToList();  // Force execution once

            var gadgetsOnPage = filteredGadgets
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            var model = new GadgetListViewModel
            {
                Gadgets = gadgetsOnPage,
                PageProperties = new PageProperties
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = filteredGadgets.Count  // Avoid duplicate count calls
                },
                CurrentCategory = category  // Pass selected category
            };

            return View(model);
        }
    }
}
