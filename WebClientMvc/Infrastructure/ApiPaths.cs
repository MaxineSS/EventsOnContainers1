using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClientMvc.Infrastructure
{
    public class ApiPaths
    {
        public static class Catalog
        {
            public static string GetAllFormats(string baseUri)
            {
                return $"{baseUri}eventformats";
            }
            public static string GetAllCategories(string baseUri)
            {
                return $"{baseUri}eventcategories";
            }
            public static string GetAllLocations(string baseUri)
            {
                return $"{baseUri}eventlocations";
            }
            public static string GetAllOnlineLocations(string baseUri, int? location)
            {
                var filterQs = string.Empty;
                if (location.Value == 7)
                {
                    var locationQs = location.Value.ToString();
                    filterQs = $"/location/{locationQs}";
                }
                return $"{baseUri}items{filterQs}";
            }
            public static string GetAllItems(string baseUri, int page, int take, int? format, int? category, int? location)
            {
                var filterQs = string.Empty;
                if (format.HasValue || category.HasValue || location.HasValue)
                {
                    var formatQs = (format.HasValue) ? format.Value.ToString() : " ";
                    var categoryQs = (category.HasValue) ? category.Value.ToString() : " ";
                    var locationQs = (location.HasValue) ? location.Value.ToString() : " ";
                    filterQs = $"/format/{formatQs}/category/{categoryQs}/location/{locationQs}";
                }
                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            }
        }
        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }
        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }

            //public static string GetOrdersByUser(string baseUri, string userName)
            //{
            //    return $"{baseUri}/userOrders?userName={userName}";
            //}
            public static string GetOrders(string baseUri)
            {
                return baseUri;
            }
            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        }
    }
}
