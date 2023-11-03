using Exam.Models;
using Exam.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace ExamAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class CartController : ControllerBase
    {
        /// <summary>
        /// NOT THE RIGHT WAY - Temporarily doing this for demo purposes.
        /// </summary>
        public static List<CartItem> Cart = new List<CartItem>();

        private readonly IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { 
                Cart.Count,
                Cart
            });
        }

        [HttpPost]
        public IActionResult Post(ProductIDViewModel model)
        {
            var product = _productService.GetProducts().Where(c => c.Id == model.productId).FirstOrDefault();
            if (product != null)
            {
                var inCart = Cart.Where(c => c.productId == model.productId).FirstOrDefault();
                if (inCart != null)
                {
                    if (product.Quantity >= (inCart.quantity + 1))
                    {
                        inCart.quantity++;
                    }
                    else
                        return Ok("Out of stock.");
                }
                else
                {
                    if (product.Quantity > 0)
                    {
                        Cart.Add(new CartItem
                        {
                            productId = model.productId,
                            quantity = 1,
                            product = product
                        });
                    }
                    else
                        return Ok("Out of stock.");
                }
            }
            return Ok("Item Added to Cart.");
        }


        [HttpDelete]
        public IActionResult Delete(ProductIDViewModel model)
        {
            var inCart = Cart.Where(c => c.productId == model.productId).FirstOrDefault();
            if (inCart != null)
            {
                Cart = Cart.Where(c => c.productId != model.productId).ToList();
            }
            return Ok("Item Removed from Cart");
        }
    }

    public class ProductIDViewModel
    {
        public int productId { get; set; }
    }

    public class CartItem
    {
        public int productId { get; set; }
        public int quantity { get; set; }
        public Product product { get; set; }
    }
}
