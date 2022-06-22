using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetworkProject.Models;

namespace WaterNetworkProject.Services
{
    public class BillService
    {
        public PathHelper PathHelper { get; set; }

        public BillService()
        {
            PathHelper = new PathHelper();
        }

        public void CreateBill(Registration registration)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            string outputFile = PathHelper.SourceDirectory + $"{registration.Consumer.GetFullName()}.xlsx";


            if(!Directory.Exists(Path.GetDirectoryName(outputFile)))
                Directory.CreateDirectory(Path.GetDirectoryName(outputFile));
                
            if (File.Exists(outputFile))
                File.Delete(outputFile);

            //Copy template with new name
            File.Copy(PathHelper.ExcelTemplatePath, outputFile);


            using (var package = new ExcelPackage(new FileInfo(outputFile)))
            {
                var ws = package.Workbook.Worksheets[0];

                //var test1 = ws.Cells["C16"].Value;

                ws.Cells["I10"].Value = registration.Consumer.FirstName + ' ' + registration.Consumer.LastName;

                ws.Cells["I4"].Value = registration.ConsumationDate;

                ws.Cells["C10"].Value = registration.Consumer.Id;


                package.SaveAs(new FileInfo(outputFile));
            }
        }
    }
}
