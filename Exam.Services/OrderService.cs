using Exam.Models;
using Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace Exam.Services
{
	public class OrderService : IOrderService
	{
		private readonly IRepository<Order> _orderRepository;
		private readonly IRepository<OrderItem> _orderItemRepository;
        private readonly IRepository<Product> _productRepository;

		public OrderService(Microsoft.EntityFrameworkCore.DbContext dbContext)
		{
			_orderRepository = new ExamRepository<Order>(dbContext);
			_orderItemRepository = new ExamRepository<OrderItem>(dbContext);
            _productRepository = new ExamRepository<Product>(dbContext);
		}

        public int SaveOrder(string userId, List<OrderItem> orderItems)
        {
            
            var orderId = _orderRepository.Add(new Order
            {
                UserId = userId,
                Status = ORDER_STATUS.PLACED
            });

            foreach (var item in orderItems)
            {
                item.OrderId = orderId;
            }

            _orderItemRepository.Add(orderItems);

            foreach (var item in orderItems)
            {
                var product = _productRepository.GetById(item.ProductId);
                if(product != null)
                {
                    product.Quantity = product.Quantity - item.Quantity;
                    _productRepository.Update(product);
                }
            }

            return orderId;
        }
    }
}
