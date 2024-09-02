using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.DTOs
{
	public class ReviewDto
	{
		public int Id { get; set; }
		public string Comment { get; set; }
		public string UserId { get; set; }
	}
}
