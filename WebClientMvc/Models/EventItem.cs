using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClientMvc.Models
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAndTime { get; set; }
        public string PictureUrl { get; set; }

        public int EventCategoryId { get; set; }
        public int EventFormatId { get; set; }
        public int EventLocationId { get; set; }

        public string EventCategory { get; set; }
        public string EventFormat { get; set; }
        public string EventLocation { get; set; }
    }
}
