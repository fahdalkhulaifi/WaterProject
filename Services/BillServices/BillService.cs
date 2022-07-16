using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetwork.Domain.Models;

namespace WaterNetworkProject.Services
{
    public class BillService
    {
        public PathHelper PathHelper { get; set; }

        public BillService()
        {
            PathHelper = new PathHelper();
        }

        public void CreateBill(RegistrationsBook registrationBook)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            foreach (var registration in registrationBook.Registrations)
            {

                var consumer = registrationBook.Consumers.Where(c => c.Id == registration.ConsumerId).FirstOrDefault();

                //ToDo: Add exception if consumer not found
                if(consumer != null)
                {
                    string outputFile = PathHelper.SourceDirectory + $"{consumer.GetFullName()}.xlsx";


                    if (!Directory.Exists(Path.GetDirectoryName(outputFile)))
                        Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

                    if (File.Exists(outputFile))
                        File.Delete(outputFile);

                    //Copy template with new name
                    File.Copy(PathHelper.ExcelTemplatePath, outputFile);


                    using (var package = new ExcelPackage(new FileInfo(outputFile)))
                    {
                        var ws = package.Workbook.Worksheets[0];


                        ws.Cells["I10"].Value = consumer.FirstName + ' ' + consumer.LastName;

                        ws.Cells["I4"].Value = registration.ConsumationDate;

                        ws.Cells["C10"].Value = consumer.Id;


                        package.SaveAs(new FileInfo(outputFile));
                    }
                }
            }
        }
    }
}
