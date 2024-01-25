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
	public class CapacityService : ICapacityService
	{
		private readonly ICapacityRepository _repository;
		public CapacityService() : this(new CapacityDapperRepository())
		{

		}
		public CapacityService(ICapacityRepository repo)
		{
			_repository = repo;
		}
		public List<CapacityDto> GetData()
		{
			return _repository.GetData();
		}
	}
}
