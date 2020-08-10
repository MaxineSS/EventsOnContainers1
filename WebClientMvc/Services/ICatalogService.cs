using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClientMvc.Models;

namespace WebClientMvc.Services
{
    public interface ICatalogService
    {
        Task<Catalog> GetEventItemsAsync(int page, int size, int? format, int? category, int? location);
        Task<Catalog> GetAllOnlineItemsAsync(int? location);
        Task<IEnumerable<SelectListItem>> GetLocationsAsync();
        Task<IEnumerable<SelectListItem>> GetFormatsAsync();
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
    }
}
