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
	public class MemberService : IMemberService
	{
		private readonly IMemberRepository _memberRepo;
		public MemberService() : this(new MemberDapperRepository())
		{

		}
		public MemberService(IMemberRepository repo)
		{
			_memberRepo = repo;
		}

		public int Create(MemberDto dto)
		{
			int minAge = 18;
			TimeSpan age = (DateTime.Now - dto.DateOfBirth);
			int years = (int)(age.TotalDays / 365.25); // 以平均年份計算年齡
			bool isExist = _memberRepo.SearchAccount(dto.Account).Any(x => x.Account.ToLower() == dto.Account.ToLower()); //如果帳號存在就不能新增
			if (isExist)
			{
				throw new Exception($"帳號已有人使用");
			}
			if (!string.IsNullOrEmpty(dto.Email) && !dto.Email.Contains("@gmail.com"))
			{
				// 如果email有輸入且不包含@gmail.com
				throw new Exception("Email必須包含 @gmail.com");
			}
			if (dto.Password != dto.ConfirmPassword)
			{
				throw new Exception("密碼和確認密碼不相符");
			}
			if (years < minAge)
			{
				throw new Exception("年齡未滿18歲，無法註冊");
			}
			return _memberRepo.Create(dto);
		}

		public void Delete(int id)
		{
			_memberRepo.Delete(id);
		}

		public List<MemberDto> GetAllData()
		{
			return _memberRepo.GetAllData();
		}

		public MemberDto GetMember(string account,string password)
		{
			if (string.IsNullOrWhiteSpace(account))
			{
				throw new Exception("請輸入帳號");
			}

			if (string.IsNullOrWhiteSpace(password))
			{
				throw new Exception("請輸入密碼");
			}

			MemberDto member = _memberRepo.GetMember(account,password);

			if (member == null || member.Password != password)
			{
				throw new Exception("帳號不存在或密碼不正確");
			}
			return _memberRepo.GetMember(account,password);
		}

		public List<MemberDto> Search(int id)
		{
			return _memberRepo.Search(id);
		}

		public List<MemberDto> SearchAccount(string account)
		{
			return _memberRepo.SearchAccount(account);
		}

		public void Update(MemberDto dto)
		{
			int minAge = 18;
			TimeSpan age = (DateTime.Now - dto.DateOfBirth);
			int years = (int)(age.TotalDays / 365.25); // 以平均年份計算年齡
			bool isExist = _memberRepo.Search(dto.Id).Any(x => x.Account == dto.Account && x.Id != dto.Id);
			if (isExist)
			{
				throw new Exception("此帳號已有人使用");
			}
			if (!string.IsNullOrEmpty(dto.Email) && !dto.Email.Contains("@gmail.com"))
			{
				// 如果email有輸入且不包含@gmail.com
				throw new Exception("Email必須包含 @gmail.com");
			}
			if (dto.Password != dto.ConfirmPassword)
			{
				throw new Exception("密碼和確認密碼不相符");
			}
			if (years < minAge)
			{
				throw new Exception("年齡未滿18歲，請再次確認");
			}
			_memberRepo.Update(dto);
		}
	}
}
