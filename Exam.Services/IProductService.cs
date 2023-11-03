using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Services
{
	public interface IProductService
	{
		List<Product> GetProducts();
		void AddProduct(Product product);
		void ResetQuantities(List<Product> products);
    }
}
