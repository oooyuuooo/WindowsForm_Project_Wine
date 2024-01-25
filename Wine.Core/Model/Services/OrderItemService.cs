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
	public class OrderItemService : IOrderItemService
	{
		private readonly IOrderItemRepository _OrderItemRepo;
		public OrderItemService() : this(new OrderItemDapperRepository())
		{

		}
		public OrderItemService(IOrderItemRepository repo)
		{
			_OrderItemRepo = repo;
		}

		public int Create(OrderItemDto dto)
		{
			return _OrderItemRepo.Create(dto);
		}

		public void Delete(int productId)
		{
			_OrderItemRepo.Delete(productId);
		}

		public List<OrderItemDto> Get(int productId)
		{
			return _OrderItemRepo.Get(productId);
		}

		public List<OrderItemDto> GetAll(int orderId)
		{
			return _OrderItemRepo.GetAll(orderId);
		}

		public void Update(OrderItemDto dto)
		{
			_OrderItemRepo.Update(dto);
		}
	}
}
