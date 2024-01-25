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
	public class TasteService : ITasteService
	{
		private readonly ITasteRepository _repository;
		public TasteService() : this(new TasteDapperRepository())
		{

		}
		public TasteService(ITasteRepository repo)
		{
			_repository = repo;
		}
		public List<TasteDto> GetData()
		{
			return _repository.GetData();
		}
	}
}
