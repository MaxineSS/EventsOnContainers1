using EventCatalogApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogApi.Data
{
    public class CatalogSeed
    {
        public static void Seed(CatalogContext catalogContext)
        {
            catalogContext.Database.Migrate();

            if (!catalogContext.EventCategories.Any())
            {
                catalogContext.EventCategories.AddRange(GetEventCategories());
                catalogContext.SaveChanges();
            }
            if (!catalogContext.EventFormats.Any())
            {
                catalogContext.EventFormats.AddRange(GetEventFormats());
                catalogContext.SaveChanges();
            }
            if (!catalogContext.EventLocations.Any())
            {
                catalogContext.EventLocations.AddRange(GetEventLocations());
                catalogContext.SaveChanges();
            }
            if (!catalogContext.EventItems.Any())
            {
                catalogContext.EventItems.AddRange(GetEventItems());
                catalogContext.SaveChanges();
            }
        }

        private static IEnumerable<EventCategory> GetEventCategories()
        {
            return new List<EventCategory>
            {
                new EventCategory
                {
                    Category ="Music"
                },
                new EventCategory
                {
                    Category ="Food & Drink"
                },
                new EventCategory
                {
                    Category ="Health"
                },
                new EventCategory
                {
                    Category ="Charity & Causes"
                },
                new EventCategory
                {
                    Category ="Community"
                },
                new EventCategory
                {
                    Category ="Arts"
                },
                new EventCategory
                {
                    Category ="Business"
                },
                new EventCategory
                {
                    Category ="Film & Media"
                },
                new EventCategory
                {
                    Category ="Hobbies"
                },
                new EventCategory
                {
                    Category ="Science & Tech"
                },

            };
        }

        private static IEnumerable<EventFormat> GetEventFormats()
        {
            return new List<EventFormat>
            {
                new EventFormat
                {
                    Format = "Class"
                },
                new EventFormat
                {
                    Format = "Conference"
                },
                new EventFormat
                {
                    Format = "Festival"
                },
                new EventFormat
                {
                    Format = "Networking"
                },
                new EventFormat
                {
                    Format = "Convention"
                },
                new EventFormat
                {
                    Format = "Party"
                },
                new EventFormat
                {
                    Format = "Workshop"
                }
            };
        }
        private static IEnumerable<EventLocation> GetEventLocations()
        {
            return new List<EventLocation>
            {
                new EventLocation
                {
                    Location = "Seattle"
                },
                new EventLocation
                {
                    Location = "Bellevue"
                },
                new EventLocation
                {
                    Location = "Redmond"
                },
                new EventLocation
                {
                    Location = "Tacoma"
                },
                new EventLocation
                {
                    Location = "NewYork"
                },
                new EventLocation
                {
                    Location = "Portland"
                },
                new EventLocation
                {
                    Location = "Online"
                }

            };
        }
        private static IEnumerable<EventItem> GetEventItems()
        {
            return new List<EventItem>
            {
                new EventItem { EventLocationId = 6, EventCategoryId = 1, EventFormatId = 3, Description= "Online Event", Name="Harry Styles: The tour at home", DateAndTime=new DateTime(2020,6,25,19,30,00), Price=0, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem { EventLocationId = 3, EventCategoryId = 2, EventFormatId = 1, Description= "This week's cocktail (July 11th), we will learn how to make our own cordials!", Name = "Herbal Cocktail Class", Price = 0, DateAndTime = new DateTime(2020, 7, 01, 15, 00, 0), PictureUrl ="http://externalcatalogbaseurltobereplaced/api/pic/2" },
                new EventItem { EventLocationId = 1, EventCategoryId = 3, EventFormatId = 5, Description = "Understand how people living with Mood Disorders and their caregivers can better cope and be resilient during the COVID-19 pandemic.", Name = "Coping with Mood Disorders during the Pandemic",  DateAndTime=new DateTime(2020,9,22,11,00,0), Price = 0, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3"},
                new EventItem { EventLocationId = 2, EventCategoryId = 4, EventFormatId = 2, Description = "Join FoodShare Toronto for a conversation featuring four Black women leading the call for Black food sovereignty in Canada, the U.S.A., and the United Kingdom. Through our panelists’ uniquely valuable perspectives and experiences, we’ll explore what Black food sovereignty means, why it is important, and how we can collectively work to advance it.", Name = "Black Women on Black Food Sovereignty",  DateAndTime=new DateTime(2020,12,22,8,00,0), Price = 12, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4"},
                new EventItem { EventLocationId = 4, EventCategoryId = 5, EventFormatId = 2, Description = "A tour de force of neuroscience and philosophy, Iain McGilchrist’s The Master and His Emissary speaks to everyone searching for happiness, meaning and understanding in the modern world.", Name = "The Divided Brain and the Search for Meaning | Iain McGilchrist", DateAndTime=new DateTime(2020,11,22,11,00,0), Price = 15, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new EventItem { EventLocationId = 5, EventCategoryId = 6, EventFormatId = 6, Description = "Grab your paper and pencil crayons, your canvases and paints, a glass of your favorite drink and join us for some creative expression.", Name = "Virtual Paint Party", DateAndTime=new DateTime(2020,12,25,18,00,0), Price = 0, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6" },
                new EventItem { EventLocationId = 1, EventCategoryId = 7, EventFormatId = 1, Description = "Learn about how to master various interviewing skills and techniques!", Name = "Interviewing Techniques", DateAndTime=new DateTime(2020,7,2,16,00,0), Price = 25, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7" },
                new EventItem { EventLocationId = 3, EventCategoryId = 10, EventFormatId = 1, Description= "This is an online training course sponsored by the Henry C. Lee Institute of Forensic Science at the University of New Haven.", Name="Advanced Forensic Science Training", DateAndTime=new DateTime(2020,6,22,11,00,0), Price=25, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/8" },
                new EventItem { EventLocationId = 2, EventCategoryId = 8, EventFormatId = 1, Description= "In lectures students learn the theoritical aspects, while in lab sessions, students complete programming tasks and get direct feedback by the instructor", Name="Data Science with Python", DateAndTime=new DateTime(2020,8,5,19,20,0), Price=200, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/9" },
                new EventItem { EventLocationId = 6, EventCategoryId = 9, EventFormatId = 4, Description= "Introducing Delta Bingo at Home! A new gaming experience with a minimum prize board of $10,000!", Name="Delta Bingo at Home", DateAndTime=new DateTime(2020,7,2,16,00,0), Price=20, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/10" },
                new EventItem { EventLocationId = 5, EventCategoryId = 4, EventFormatId = 2, Description= "This 75-minute interactive webinar will dive deeper into defining white supremacy and how it shows up beyond overt acts of hatred, explore how white supremacy is upheld in the ideologies and practices of “traditional” design thinking, and examine how we might shift design mindsets to more equitable, diverse, and inclusive practice.", Name="How Traditional Design Thinking Protects White Supremacy", DateAndTime=new DateTime(2020,10,6,15,30,0), Price=19, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/11" },
                new EventItem { EventLocationId = 4, EventCategoryId = 4, EventFormatId = 5, Description= "The Animal Rights National Conference is proud to safely bring you this year's event on a dynamic interactive platform! Emphasizing the importance of staying connected during these challenging times, the AR2020 Virtual Event will incorporate these exciting features and more", Name="Animal Rights 2020 Virtual Event", DateAndTime=new DateTime(2020,7,17,16,00,0), Price=20, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/12" },
                new EventItem { EventLocationId = 3, EventCategoryId = 3, EventFormatId = 2, Description= "The new world of medical cannabis is full of misinformation and confusion. Dr Dani Gordon is here to separate the science from nonsense and offer clear guidance through this wellness revolution.", Name="CBD and Medical Cannabis: What You Need to Know | with Dr. Dani Gordon", DateAndTime=new DateTime(2020,7,23,10,30,0), Price=20, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/13" },
                new EventItem { EventLocationId = 3, EventCategoryId = 9, EventFormatId = 6, Description= "What better way to celebrate the Fourth of July than with the ultimate patriotic superhero, Captain America? It's time to explore the story behind one of the most iconic superheroes, and how he was masterfully portrayed throughout the 20th-century.", Name="'Captain America: A Fourth of July Celebration' Webinar", DateAndTime=new DateTime(2020,7,2,17,00,0), Price=10, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/14" },
                new EventItem { EventLocationId = 2, EventCategoryId = 2, EventFormatId = 1, Description= "Every week, we invite a new bud to whip up one of their favorite recipes.", Name="Baking with Our Buds - Open House Online!", DateAndTime=new DateTime(2020,6,26,19,20,0), Price=0, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/15" },
                new EventItem { EventLocationId = 7, EventCategoryId = 4, EventFormatId = 7, Description= "It’s time for liberation. It’s not enough to just read the books, watch the movies, or listen to the lectures. It’s time we do the work.", Name="Cultivating Liberation: Becoming an Anti-Biased, Anti-Racist Educator", DateAndTime=new DateTime(2020,8,30,05,00,0), Price=170, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/16"},
                new EventItem { EventLocationId = 7, EventCategoryId = 5, EventFormatId = 7, Description= "This event will be panel style webinars, inviting anyone wanting to do their part in reversing systemic racism.", Name="Reversing Structural Racism In Maine; Series One: Understanding What It Is", DateAndTime=new DateTime(2020,8,03,04,30,0), Price=25, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/17"},
                new EventItem { EventLocationId = 7, EventCategoryId = 4, EventFormatId = 7, Description= "Edward Ball discusses his new book LIFE OF A KLANSMAN with Dr. Ibram X. Kendi.", Name="P&P Live! Edward Ball | LIFE OF A KLANSMAN with Ibram X. Kendi", DateAndTime=new DateTime(2020,8,04,03,00,0), Price=0, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/18"},
                new EventItem { EventLocationId = 7, EventCategoryId = 5, EventFormatId = 7, Description= "The inaugural Black Music Matters Festival, featuring Black Country and Americana artists will give a musical platform to Black musicians.", Name="Black Music Matters Festival, featuring Black Country and Americana artists", DateAndTime=new DateTime(2020,8,04,04,00,0), Price=0, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/19"},
                new EventItem { EventLocationId = 7, EventCategoryId = 4, EventFormatId = 7, Description= "BOOKS IN BLOOM RETURNS WITH ALL-STAR LINEUP OF BESTSELLING AUTHORS", Name="In Conversation with Robin DiAngelo, Author of White Fragility", DateAndTime=new DateTime(2020,8,20,05,00,0), Price=0, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/20"},
            };
        }
    }
}
