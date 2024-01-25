using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Wine.Core.Model.Dto;
using Wine.Core.Model.Interfaces;
using Wine.Core.Model.Repositories;

namespace Wine.Core.Model.Services
{
	public class StaffService : IStaffService
	{
		private readonly IStaffRepository _staffRepo;
        public StaffService(): this (new StaffDapperRepository())
        {
            
        }
        public StaffService(IStaffRepository staffRepo)
		{
			_staffRepo = staffRepo;
		}
		public StaffDto Get(string account, string password)
		{
			StaffDto member = _staffRepo.Get(account,password);

			if (member == null || member.StaffAccount != account || member.StaffPassword != password)
			{
				throw new Exception("帳號不存在或密碼不正確");
			}
			return _staffRepo.Get(account,password);
		}
	}
}
