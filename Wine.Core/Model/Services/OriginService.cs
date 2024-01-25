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
	public class OriginService : IOriginService
	{
		private readonly IOriginRepository _repository;
		public OriginService() : this(new OriginDapperRepository())
		{

		}

		public OriginService(IOriginRepository repo)
		{
			_repository = repo;
		}

		public List<OriginDto> GetData()
		{
			return _repository.GetData();
		}
	}
}
