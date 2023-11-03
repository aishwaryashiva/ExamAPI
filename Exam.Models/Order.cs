using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public enum ORDER_STATUS { PLACED, PROCESSING, DELIVERED, CANCELLED }
	public class Order : BaseModel
	{
        public string UserId { get; set; }
        public ORDER_STATUS Status { get; set; }
    }
}
