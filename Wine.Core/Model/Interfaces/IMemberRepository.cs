using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wine.Core.Model.Dto;

namespace Wine.Core.Model.Interfaces
{
	public interface IMemberRepository
	{
		int Create(MemberDto dto);
		MemberDto GetMember(string account,string password);
		void Delete(int id);
		void Update(MemberDto dto);
		List<MemberDto> Search(int id);
		List<MemberDto> GetAllData();
		List<MemberDto> SearchAccount(string account);
	}
}
