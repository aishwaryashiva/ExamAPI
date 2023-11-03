using Exam.Models;
using Exam.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System.Security.Claims;

namespace ExamAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class OrdersController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public OrdersController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult Post()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int res = _orderService.SaveOrder(UserId, CartController.Cart.Select(c => new OrderItem { Price = c.product.Price, Quantity = c.quantity, ProductId = c.productId }).ToList());
            if (res > 0)
            {
                CartController.Cart = new List<CartItem>();
                return Ok(string.Format("Order placed successfully. Order Id: {0}", res));
            }

            return BadRequest("Failed to place order.");
        }
    }
}
