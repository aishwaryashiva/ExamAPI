using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
	public class BaseModel
	{
		[Key]
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }			
    }
}