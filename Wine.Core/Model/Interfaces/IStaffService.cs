using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wine.Core.Model.Dto;

namespace Wine.Core.Model.Interfaces
{
	public interface IStaffService
	{
		StaffDto Get(string account,string password);
	}
}
