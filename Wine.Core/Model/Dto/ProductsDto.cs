using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wine.Core.Model.Dto
{
	public class ProductsDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Year { get; set; } //allow null
		public int Cat_Id { get; set; }
		public int Orig_Id { get; set; }
		public int Cap_Id { get; set; }
		public int TastesId { get; set; }
		public decimal Price { get; set; }
		public string ImageLink { get; set; } //allow null
		public int Count { get; set; }

		public string Capacity { get; set; }
		public string Category { get; set; }
		public string Origin { get; set; }
		public string Taste { get; set; }
	}
}
