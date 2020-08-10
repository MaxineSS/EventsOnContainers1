using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClientMvc.Infrastructure;
using WebClientMvc.Models;

namespace WebClientMvc.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly string _baseUrl;
        private readonly IHttpClient _client;
        public CatalogService(IConfiguration config, IHttpClient client)
        {
            _baseUrl = $"{config["CatalogUrl"]}/api/catalog/";
            _client = client;
        }
        public async Task<Catalog> GetAllOnlineItemsAsync(int? location)
        {
            var onlineItemsUri = ApiPaths.Catalog.GetAllOnlineLocations(_baseUrl, location);
            var dataString = await _client.GetStringAsync(onlineItemsUri);
            return JsonConvert.DeserializeObject<Catalog>(dataString);
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var eventCategoriesUri = ApiPaths.Catalog.GetAllCategories(_baseUrl);
            var dataString = await _client.GetStringAsync(eventCategoriesUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected = true
                }
            };
            var categories = JArray.Parse(dataString);
            foreach (var category in categories)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = category.Value<string>("id"),
                        Text = category.Value<string>("category")
                    });
            }
            return items;
        }

        public async Task<Catalog> GetEventItemsAsync(int page, int size, int? format, int? category, int? location)
        {
            var eventItemsUri = ApiPaths.Catalog.GetAllItems(_baseUrl, page, size, format, category, location);
            var datastring = await _client.GetStringAsync(eventItemsUri);
            return JsonConvert.DeserializeObject<Catalog>(datastring);
        }

        public async Task<IEnumerable<SelectListItem>> GetFormatsAsync()
        {
            var eventFormatsUri = ApiPaths.Catalog.GetAllFormats(_baseUrl);
            var dataString = await _client.GetStringAsync(eventFormatsUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected = true
                }
            };
            var formats = JArray.Parse(dataString);
            foreach (var format in formats)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = format.Value<string>("id"),
                        Text = format.Value<string>("format")
                    });
            }
            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetLocationsAsync()
        {
            var eventLocationsUri = ApiPaths.Catalog.GetAllLocations(_baseUrl);
            var dataString = await _client.GetStringAsync(eventLocationsUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected = true
                }
            };
            var locations = JArray.Parse(dataString);
            foreach (var location in locations)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = location.Value<string>("id"),
                        Text = location.Value<string>("location")
                    });
            }
            return items;
        }
    }
}
