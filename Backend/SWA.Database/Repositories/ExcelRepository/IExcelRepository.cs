﻿using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWA.Database.Repositories.ExcelRepository
{
	public interface IExcelRepository
	{
		Task<string> GetHeadMenAsync(string GroupName, int Id);
		Task<string> GetListGroupAsync(string GroupName, int Id);
	}
}
