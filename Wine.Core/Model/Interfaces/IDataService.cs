using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wine.Core.Model.Interfaces
{
	public interface IDataService<T>
	{
		List<T> GetData();
	}
}
