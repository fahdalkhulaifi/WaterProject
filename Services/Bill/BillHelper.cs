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
    public class BillHelper
    {

        public void CreateBill()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            string up3 = null;
            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());
            if (d.Parent.Parent != null && d.Parent.Parent.Parent != null)
            {
                up3 = d.Parent.Parent.Parent.ToString();
            }
            string sourceDirectory = up3 + @"\Source\";

            var registration = new Registration(new Consumer(1, "الخليفي", "فهد خالد عمر محسن"), 1000, new DateTime(2022, 6, 1));

            string inputFile = sourceDirectory + "WaterProjectBillTemplate.xlsx";
            string outputFile = sourceDirectory + "WaterProjectBillTemplate2.xlsx";


            if (File.Exists(outputFile))
                File.Delete(outputFile);

            //Copy template with new name
            File.Copy(inputFile, outputFile);


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
