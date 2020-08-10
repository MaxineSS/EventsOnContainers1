using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebClientMvc.Services;
using WebClientMvc.ViewModels;

namespace WebClientMvc.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _service;
        public CatalogController(ICatalogService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int? page, int? formatFilterapplied, int? categoryFilterapplied, int? locationFilterapplied)
        {
            var itemsOnPage = 6;
            var catalog = await _service.GetEventItemsAsync(page ?? 0, itemsOnPage, formatFilterapplied, categoryFilterapplied, locationFilterapplied);
            var vm = new CatalogIndexViewModel
            {
                EventItems = catalog.Data,
                Formats = await _service.GetFormatsAsync(),
                Categories = await _service.GetCategoriesAsync(),
                Locations = await _service.GetLocationsAsync(),
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = catalog.PageSize,
                    TotalItems = catalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsOnPage)
                },
                FormatFilterApplied = formatFilterapplied ?? 0,
                CategoryFilterApplied = categoryFilterapplied ?? 0,
                LocationFilterApplied = locationFilterapplied ?? 0
            };
            return View(vm);
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }
}
