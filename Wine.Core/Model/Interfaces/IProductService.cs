using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wine.Core.Model.Dto;

namespace Wine.Core.Model.Interfaces
{
	public interface IProductService
	{
		int Create(ProductsDto dto);
		void Update(ProductsDto dto);
		void Delete(int id);
		List<ProductsDto> Search(ProductsDto dto);
		ProductsDto Get(int id);
		List<ProductsDto> GetAllData();

		void UploadCSV(string filePath);
	}
}
