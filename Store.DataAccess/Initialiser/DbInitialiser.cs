using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.Initialiser
{
    public class DbInitialiser
    {
        public static void Seed(IServiceProvider applicationBuilder)
        {

            AppDbContext context = applicationBuilder.GetRequiredService<AppDbContext>();

            if (!context.Categories.Any()) 
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }
            if (!context.Products.Any())
            {
                context.AddRange(

                    new Product
                    {
                        Name = "Crankshaft",
                        Price = 567.23M,
                        Description = "Rotax crankshaft 1000",
                        Category = Categories["Engine"],
                        ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSfRNXySBrQ6HjXCSE9eIasZyGgilxbuynxQg&usqp=CAU",
                        Subcategory = "Engine",
                        InStock = true,
                        IsPreferredProduct = true,
                        ImageThumbnailURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSfRNXySBrQ6HjXCSE9eIasZyGgilxbuynxQg&usqp=CAU"
                    },

                    new Product
                    {
                        Name = "Head",
                        Price = 567.23M,
                        Description = "Rotax head 1000",
                        Category = Categories["Engine"],
                        ImageURL = "https://i.ebayimg.com/images/g/Q4YAAOSwwnpeYHyR/s-l1600.jpg",
                        Subcategory = "Engine",
                        InStock = false,
                        IsPreferredProduct = true,
                        ImageThumbnailURL = "https://i.ebayimg.com/images/g/Q4YAAOSwwnpeYHyR/s-l1600.jpg"
                    },

                    new Product
                    {
                        Name = "Handl bar",
                        Price = 87.34M,
                        Description = "XTP style",
                        Category = Categories["Engine"],
                        ImageURL = "https://www.motorsportgoetz.com/media/image/product/162587/lg/handlebar-aluminum-blue-22mm-high-yamaha-xt-600-660-tenere.jpg",
                        Subcategory = "Steering system",
                        InStock = false,
                        IsPreferredProduct = false,
                        ImageThumbnailURL = "https://www.motorsportgoetz.com/media/image/product/162587/lg/handlebar-aluminum-blue-22mm-high-yamaha-xt-600-660-tenere.jpg"
                    }

                );
            }
            context.SaveChanges();
        }



        private static Dictionary<string, Category> _categories;
        public static Dictionary<string, Category> Categories {
            
            get 
            {
                if (_categories == null) 
                {
                    var genresList = new Category[]
                   {
                       new Category {Name ="ATV", Description = "All-terrain vehicle parts and accesories" },
                       new Category {Name ="UTV", Description = "Side-by-side parts and accesories" },
                       new Category {Name ="BOAT", Description = "Boat parts and accesories" },
                       new Category {Name ="WATERCRAFT", Description = "Watercraft parts and accesories" },
                       new Category {Name ="SNOWMOBILE", Description = "Snowmobile parts and accesories" },
                   };

                    _categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        _categories.Add(genre.Name, genre);
                    }
                }

                return _categories;
            }

        }

    }
}
