using OfficeOpenXml;
using Recuperos.Aplicacion.Interfaces.Exportacion;
using System.Collections.Generic;
using System.IO;

namespace Recuperos.Servicios.Exportador.Excel
{
    public class ExportadorExcel : IExportadorExcel
    {
        public byte[] Exportar<T>(IList<T> data)
        {
            byte[] fileData = null;
            using (var package = new ExcelPackage())
            {
                var workSheet = package.Workbook.Worksheets.Add("Siniestros");
                workSheet.Cells.LoadFromCollection(data, true, OfficeOpenXml.Table.TableStyles.Dark6);
                for (int col = 1; col <= workSheet.Dimension.End.Column; col++)
                {
                    workSheet.Column(col).AutoFit();
                }
                using (var ms = new MemoryStream())
                {
                    package.SaveAs(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    fileData = ms.ToArray();
                }
            }
            return fileData;
        }
    }
}
