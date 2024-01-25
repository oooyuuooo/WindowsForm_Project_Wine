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
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _repository;
		public CategoryService() : this(new CategoryDapperRepositroy())
		{

		}

		public CategoryService(ICategoryRepository repo)
		{
			_repository = repo;
		}

		public List<CategoryDto> GetData()
		{
			return _repository.GetData();
		}
	}
}
