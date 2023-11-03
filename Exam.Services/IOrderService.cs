using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace Exam.Services
{
	public interface IOrderService
	{
        int SaveOrder(string userId, List<OrderItem> orderItems);
    }
}
