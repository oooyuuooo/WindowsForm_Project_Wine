using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wine.Core.Model.Dto;
using Wine.Core.Model.Interfaces;
using Wine.Core.Model.Repositories;

namespace Wine.Core.Model.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepo;
		public OrderService() : this(new OrderDapperRepository())
		{

		}
		public OrderService(IOrderRepository repo)
		{
			_orderRepo = repo;
		}

		public int Create(OrderDto dto)
		{
			return _orderRepo.Create(dto);
		}

		public OrderDto Get(int memberId)
		{
			return _orderRepo.Get(memberId);
		}

		public List<OrderDto> GetAll()
		{
			return _orderRepo.GetAll();
		}

		public List<OrderDto> GetAllforMember(int memberId)
		{
			return _orderRepo.GetAllforMember(memberId);
		}

		public List<OrderDto> Search(DateTime orderDate, int stateId)
		{
			return _orderRepo.Search(orderDate, stateId);
		}

		public void Update(int orderId, int state)
		{
			_orderRepo.Update(orderId,state);
		}

		public void UpdateOrderTotalMoney(int orderId, decimal newTotalMoney)
		{
			_orderRepo.UpdateOrderTotalMoney(orderId, newTotalMoney);
		}
	}
}
