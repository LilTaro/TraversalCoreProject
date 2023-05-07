using BusinessLayer.Abstract;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ExcelManager : IExcelService
    {
        public byte[] ExcelList<T>(List<T> list) where T : class
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Sayfa1");
            worksheet.Cells["A1"].LoadFromCollection(list, true, OfficeOpenXml.Table.TableStyles.Dark1);
            return package.GetAsByteArray();
        }
    }
}
