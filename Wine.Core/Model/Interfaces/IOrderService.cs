using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wine.Core.Model.Dto;

namespace Wine.Core.Model.Interfaces
{
	public interface IOrderService
	{
		int Create(OrderDto dto);
		void Update(int orderId, int state);
		OrderDto Get(int id);
		List<OrderDto> Search(DateTime orderDate, int stateId);
		void UpdateOrderTotalMoney(int orderId, decimal newTotalMoney);
		List<OrderDto> GetAll();
		List<OrderDto> GetAllforMember(int memberId);
	}
}
