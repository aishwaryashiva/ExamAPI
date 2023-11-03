using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public static ProductViewModel FromProductModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Quantity = product.Quantity,
                Price = product.Price
            };
        }

        public static List<Product> SeedProducts()
        {
            return new List<Product>
            {
                new Product { Name = "Cookies", ImageUrl = "https://www.verybestbaking.com/sites/g/files/jgfbjl326/files/styles/large/public/recipe-thumbnail/87838-30872d9f6bf0bee23cfb508c299de65d_original_milk_chocolate_chip_cookies_original.jpg?itok=oYHJPSE6", Price = 20, Quantity = 10 },
                new Product { Name = "Tea", ImageUrl = "https://www.teaforturmeric.com/wp-content/uploads/2021/11/Masala-Chai-Tea-Recipe-Card.jpg", Price = 30, Quantity = 5 },
                new Product { Name = "Mineral Water", ImageUrl = "https://www.bigbasket.com/media/uploads/p/xxl/412087_1-bisleri-mineral-water.jpg", Price = 10, Quantity = 5 }
            };
        }
    }
}
