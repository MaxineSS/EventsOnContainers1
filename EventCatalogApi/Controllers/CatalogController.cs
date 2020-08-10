using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogApi.Data;
using EventCatalogApi.Domain;
using EventCatalogApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;

namespace EventCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly CatalogContext _context;
        public CatalogController(CatalogContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 4)
        {
            var itemsCount = _context.EventItems.LongCountAsync();
            var items = await _context.EventItems
                .OrderBy(e => e.Price)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };

            return Ok(model);
        }

        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(item =>
            item.PictureUrl = item.PictureUrl.Replace(
                "http://externalcatalogbaseurltobereplaced",
                _config["ExternalCatalogBaseUrl"]));

            return items;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventFormats()
        {
            var formats = await _context.EventFormats.ToListAsync();
            return Ok(formats);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventCategories()
        {
            var categories = await _context.EventCategories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventLocations()
        {
            var locations = await _context.EventLocations.ToListAsync();
            return Ok(locations);
        }

        // filter : ex) only show me locations, given the catalog category, format, and location
        // it's supposed to get you the data for that given input(what user selected)
        // I can build multiple API, create another API which are only filtered by the location.
        [HttpGet]
        [Route("[action]/format/{eventFormatId}/category/{eventCategoryId}/location/{eventLocationId}")]
        // User have to choose all 3 params(category, format, location) to get the data.
        public async Task<IActionResult> Items(
            int? eventFormatId,
            int? eventCategoryId,
            int? eventLocationId,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 4
            )
        {
            var query = (IQueryable<EventItem>)_context.EventItems;


            if (eventCategoryId.HasValue)
            {
                query = query.Where(e => e.EventCategoryId == eventCategoryId);
            }
            if (eventFormatId.HasValue)
            {
                query = query.Where(e => e.EventFormatId == eventFormatId);
            }
            if (eventLocationId.HasValue)
            {
                query = query.Where(e => e.EventLocationId == eventLocationId);
            }

            var itemsCount = query.LongCountAsync();

            var items = await query
                .OrderBy(e => e.Price)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };

            return Ok(model);
        }

        [HttpGet]
        [Route("[action]/{eventCategoryId}")]
        public async Task<IActionResult> Category(
            int? eventCategoryId,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 4 )
        {
            var query = (IQueryable<EventItem>)_context.EventItems;

            if (eventCategoryId.HasValue)
            {
                query = query.Where(e => e.EventCategoryId == eventCategoryId);
            }

            var itemsCount = query.LongCountAsync();

            var items = await query
                .OrderBy(e => e.Price)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };

            return Ok(model);
        }

        [HttpGet]
        [Route("[action]/{eventFormatId}")]
        public async Task<IActionResult> Format(
            int? eventFormatId,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 4)
        {
            var query = (IQueryable<EventItem>)_context.EventItems;

            if (eventFormatId.HasValue)
            {
                query = query.Where(e => e.EventFormatId == eventFormatId);
            }

            var itemsCount = query.LongCountAsync();

            var items = await query
                .OrderBy(e => e.Price)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };

            return Ok(model);
        }

        [HttpGet]
        [Route("[action]/{eventLocationId}")]
        public async Task<IActionResult> Location(
            int? eventLocationId,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 4)
        {
            var query = (IQueryable<EventItem>)_context.EventItems;

            if (eventLocationId.HasValue)
            {
                query = query.Where(e => e.EventLocationId == eventLocationId);
            }

            var itemsCount = query.LongCountAsync();

            var items = await query
                .OrderBy(e => e.Price)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };

            return Ok(model);
        }
    }
}
