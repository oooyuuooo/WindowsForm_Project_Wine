using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wine.Core.Model.Dto;

namespace Wine.Core.Model.Interfaces
{
	public interface IOrderItemService
	{
		int Create(OrderItemDto dto);
		void Update(OrderItemDto dto);
		void Delete(int id);
		List<OrderItemDto> GetAll(int orderId);
		List<OrderItemDto> Get(int id);
	}
}
