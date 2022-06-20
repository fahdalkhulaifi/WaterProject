using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterNetworkProject.Services
{
    public class PathHelper
    {
        public string SourceDirectory { get;  }
        public string RootDirectory { get; }
        public string ConsumersFilePath { get; }
        public string RegistrationsFilePath { get; }

        public PathHelper()
        {
            string up3 = null;
            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());
            if (d.Parent.Parent != null && d.Parent.Parent.Parent != null)
            {
                up3 = d.Parent.Parent.Parent.ToString();
            }

            RootDirectory = up3 + @"\";
            SourceDirectory = RootDirectory + @"Source\";

            ConsumersFilePath = SourceDirectory + "Consumers.csv";
            RegistrationsFilePath = SourceDirectory + "Registrations.csv";
        }
    }
}
