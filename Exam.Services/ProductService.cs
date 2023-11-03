using Exam.Models;
using Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Services
{
	public class ProductService : IProductService
	{
		private readonly IRepository<Product> _productRepository;
		public ProductService(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
			_productRepository = new ExamRepository<Product>(dbContext);
        }

        public List<Product> GetProducts()
		{
			return _productRepository.GetAll().ToList();
		}

		public void AddProduct(Product product)
		{
			_productRepository.Add(product);
		}

		public void ResetQuantities(List<Product> products)
		{
			foreach (var product in products)
			{
				product.Quantity = 10;
				_productRepository.Update(product);
			}
		}
	}
}
