using Backend.Models;
using Microsoft.EntityFrameworkCore;
using SWA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWA.Database.Repositories.ExcelRepository
{
	public class ExcelRepository : BaseRepository, IExcelRepository
	{
		public ExcelRepository(SWADbContext context) : base(context) { }

		public async Task<string> GetHeadMenAsync(int Id, int Year)
		{
			try
			{
				var userInfo = await _context.UserInfo.FirstOrDefaultAsync(c => c.UserID == Id);

				if(userInfo == null)
					throw new Exception($"Error");

				return await Task.Run(() => ExcelParser.SearchHeadManInDocumentById(userInfo.Group, Year));
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<string> GetListGroupAsync(string GroupName, int Id)
		{
			try
			{
				return await Task.Run(() => ExcelParser.SearchListGroupsDocumentById(GroupName, Id));
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<string> GetProgressAsync(int Id)
		{
			try
			{
				var userInfo = await _context.UserInfo.FirstOrDefaultAsync(c => c.UserID == Id);

				if (userInfo == null)
					throw new Exception($"Error");

				return await Task.Run(() => ExcelParser.ProgresBySecondName(userInfo.Group, userInfo.SecondName, Id));
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<string> GetCuratorsAsync(int Id)
		{
			try
			{
				var userInfo = await _context.UserInfo.FirstOrDefaultAsync(c => c.UserID == Id);

				if (userInfo == null)
					throw new Exception($"Error");

				return await Task.Run(() => ExcelParser.SearchCurator(userInfo.Group));
			}
			catch
			{
				throw new Exception($"Error");
			}
		}
	}
}
