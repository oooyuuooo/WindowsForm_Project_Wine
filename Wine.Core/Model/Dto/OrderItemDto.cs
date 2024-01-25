using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wine.Core.Model.Dto
{
	public class OrderItemDto
	{
		public int Id { get; set; }
		public int OrderID { get; set; }
		public int ProductsID { get; set; }
		public int ProductCount { get; set; }
		public decimal ProductsPrice { get; set; }
		public decimal TotalMoney { get; set; }

	public string Name { get; set; }
	}
}
