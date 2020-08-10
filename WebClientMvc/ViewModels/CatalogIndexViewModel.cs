using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClientMvc.Models;

namespace WebClientMvc.ViewModels
{
    // what I want on the UI
    public class CatalogIndexViewModel
    {
        public IEnumerable<SelectListItem> Formats { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }
        public IEnumerable<EventItem> EventItems { get; set; }
        public PaginationInfo PaginationInfo { get; set; }

        public int? FormatFilterApplied { get; set; }
        public int? CategoryFilterApplied { get; set; }
        public int? LocationFilterApplied { get; set; }
    }
}
