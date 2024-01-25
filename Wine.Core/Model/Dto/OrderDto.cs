using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wine.Core.Model.Dto
{
	public class OrderDto
	{
		public int Id { get; set; }
		public int MemberID { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal TotalMoney { get; set; }
		public int StateID { get; set; }

		public string StateName {  get; set; }

		public string Account {  get; set; }
	}
}
