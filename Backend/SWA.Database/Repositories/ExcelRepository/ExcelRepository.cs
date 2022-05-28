using Backend.Models;
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

		public async Task<string> GetHeadMenAsync(string GroupName, int Id)
		{
			try
			{
				return await Task.Run(() => ExcelParser.SearchHeadManInDocumentById(GroupName, Id));
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
	}
}
