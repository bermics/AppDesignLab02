using System;
using System.Linq;
using System.Web.Mvc;
using GadgetHub.Domain.Abstract;
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

        public ViewResult List(int page = 1)
        {
            var gadgets = repository.Gadgets
                                    .OrderBy(g => g.GadgetId)
                                    .Skip((page - 1) * PageSize)
                                    .Take(PageSize);

            var totalItems = repository.Gadgets.Count();

            var model = new GadgetListViewModel
            {
                Gadgets = repository.Gadgets.OrderBy(g => g.GadgetId)
                                .Skip((page - 1) * PageSize)
                                .Take(PageSize),
                PageProperties = new PageProperties
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Gadgets.Count()
                }
            };

            return View(model);

        }
    }
}
