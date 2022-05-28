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
                string FileName = Directory.GetCurrentDirectory() + @"\ListsGroups\" + Id + ".xlsx";

                var fi = new FileInfo(FileName);
                using (var package = new ExcelPackage(fi))
                {
                    for (int i = 0; i < package.Workbook.Worksheets.Count; i++)
                    {
                        using (ExcelWorksheet workSheet = package.Workbook.Worksheets[i])
                        {

                            var str = workSheet.Cells[workSheet.Dimension.Start.Row, 1, workSheet.Dimension.End.Row, workSheet.Dimension.End.Column].ToList();
                            for (int j = 0; j < str.Count; j++)
                            {
                                if(str[j].Text.Replace(" ","") == GroupName)
                                {
                                    var str2 = workSheet.Cells[str[j].Start.Row + 1, str[j].Start.Column, workSheet.Dimension.End.Row, str[j].Start.Column + 3].ToList();
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

        public static string SearchListGroupsDocumentById(string GroupName, int Id)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            try
            {
                string FileName = Directory.GetCurrentDirectory() + @"\ListsGroups\" + Id + ".xlsx";

                var fi = new FileInfo(FileName);
                using (var package = new ExcelPackage(fi))
                {
                    for (int i = 0; i < package.Workbook.Worksheets.Count; i++)
                    {
                        using (ExcelWorksheet workSheet = package.Workbook.Worksheets[i])
                        {

                            var str = workSheet.Cells[workSheet.Dimension.Start.Row, 1, workSheet.Dimension.End.Row, workSheet.Dimension.End.Column].ToList();
                            for (int j = 0; j < str.Count; j++)
                            {
                                if (str[j].Text.Replace(" ", "") == GroupName)
                                {
                                    var str2 = workSheet.Cells[str[j].Start.Row + 1, str[j].Start.Column - 1, workSheet.Dimension.End.Row, str[j].Start.Column + 2].ToList();
                                    int k = 0;
                                    string result = "";
                                    while(str2[k].Text != "")
                                    {
                                        result += str2[k].Text + " " + str2[k + 1].Text + " " + str2[k + 2].Text + "\n";
                                        k += 3;
									}
                                
                                    return result;
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

        public static string ProgresBySecondName(string GroupName, string SecondName, int Id)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            try
            {
                string FileName = Directory.GetCurrentDirectory() + @"\Sheets\Ковалёв" + Id + ".xlsx";
                List<string> result = new List<string>();

                var fi = new FileInfo(FileName);
                using (var package = new ExcelPackage(fi))
                {
                    for (int i = 0; i < package.Workbook.Worksheets.Count; i++)
                    {
                        using (ExcelWorksheet workSheet = package.Workbook.Worksheets[i])
                        {
                            if(workSheet.Name.Replace(" ","") == GroupName)
                            {
                                var str = workSheet.Cells[workSheet.Dimension.Start.Row, workSheet.Dimension.Start.Column + 3, workSheet.Dimension.Start.Row, workSheet.Dimension.End.Column].ToList();

                                for(int d = 0; d < str.Count; d++)
                                {
                                    result.Add(str[d].Text);
								}

                                str = workSheet.Cells[workSheet.Dimension.Start.Row+1, 2, workSheet.Dimension.End.Row, 2].ToList();
                                for (int j = 0; j < str.Count; j++)
                                {
                                    if (str[j].Text.Replace(" ", "") == SecondName)
                                    {
                                        var str2 = workSheet.Cells[j+2, workSheet.Dimension.Start.Row + 3, j+2, workSheet.Dimension.End.Row].ToList(); ;


                                        var res = "";
                                        int count = 0;
                                        if (result.Count < str2.Count)
                                            count = result.Count;
                                        else
                                            count = str2.Count;

                                        for (int k = 0; k < count; k++)
										{
											result[k] += " " + str2[k].Text + "\n";
                                            res += result[k];
                                        }

                                        return res;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //throw new Exception("Ошибка чтения excel-файла.");
            }
            return "Undefind";
        }
    }
}
