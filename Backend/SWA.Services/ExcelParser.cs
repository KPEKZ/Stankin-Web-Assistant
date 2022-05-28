using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWA.Services
{
	public class ExcelParser
	{     
		public static string SearchHeadManInDocumentById(string GroupName, int Id)
		{
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            try
            {
                string FileName = @"C:\Users\maksi\Desktop\Hackaton\Stankin-Web-Assistant\Backend\Backend\ListsGroups\" + Id + ".xlsx";

                var fi = new FileInfo(FileName);
                using (var package = new ExcelPackage(fi))
                {
                    for (int i = 0; i < package.Workbook.Worksheets.Count; i++)
                    {
                        using (ExcelWorksheet workSheet = package.Workbook.Worksheets[i])
                        {

                            var str = workSheet.Cells[workSheet.Dimension.Start.Row, 1, workSheet.Dimension.End.Row, 5].ToList();
                            for (int j = 0; j < str.Count; j++)
                            {
                                if(str[j].Text.Replace(" ","") == GroupName)
                                {
                                    var str2 = workSheet.Cells[str[j].Start.Row + 1, 3, workSheet.Dimension.End.Row, 4].ToList();
                                        for(int k = 0; k < str2.Count; k++)
                                        {
                                            if(str2[k].Style.Font.Bold)
                                            {
                                                return str2[k].Text + " " + str2[k+1].Text + " " + str2[k+2].Text;
											}
										}
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка чтения excel-файла.");
            }
            return "Undefind";
        }
	}
}
