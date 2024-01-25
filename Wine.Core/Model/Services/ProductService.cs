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
	public class ProductService : IProductService
	{
		private readonly IProductRepository _repository;
		public ProductService() : this(new ProductDapperRepository())
		{

		}
		public ProductService(IProductRepository repo)
		{
			_repository = repo;
		}

		public int Create(ProductsDto dto)
		{
			bool isExist = _repository.Search(dto).Any(x => x.Name.ToLower() == dto.Name.ToLower()); //如果產品名稱相同不能增加
			if (isExist)
			{
				throw new Exception($"此商品已存在 {dto.Name}");
			}
			bool isNull = _repository.Search(dto).Any(x => x.Count < 0);
			if (isNull)
			{
				throw new Exception("商品數量不可以小於0");
			}
			return _repository.Create(dto);
		}

		public void Update(ProductsDto dto)
		{
			bool isExist = _repository.Search(dto).Any(x => x.Name.ToLower() == dto.Name.ToLower() && x.Id != dto.Id); //如果產品名稱相同不能增加
			if (isExist)
			{
				throw new Exception($"商品名稱重複 {dto.Name}");
			}
			_repository.Update(dto);
		}

		public void Delete(int id)
		{
			_repository.Delete(id);
		}

		public ProductsDto Get(int id)
		{
			return _repository.Get(id);
		}

		public List<ProductsDto> Search(ProductsDto dto)
		{
			return _repository.Search(dto);
		}

		public List<ProductsDto> GetAllData()
		{
			return _repository.GetAllData();
		}

		public void UploadCSV(string filePath)
		{
			_repository.UploadCSV(filePath);
		}
	}
}
