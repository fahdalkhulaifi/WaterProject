using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WaterNetworkProject.Entities;
using WaterNetworkProject.Models;
using WaterNetworkProject.Services;

namespace WaterNetworkProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            CurrencyInfo currency = new CurrencyInfo(CurrencyInfo.Currencies.Syria);

            NumberToWordConverter converter = new NumberToWordConverter(3220, currency);

            var result = converter.ConvertToArabic();
            Console.WriteLine(result);

            //Consumer consumer = new Consumer(1, "Fahd", "AL-KHULAIFI");
            //Consumation consumation = new Consumation(1, 1000, new DateTime(2022,6,1));

            //Registration registration = new Registration(consumer, consumation);
            //RegistrationsBook registrationsBook = new RegistrationsBook();

            //registrationsBook.MakeRegestration(registration);

            base.OnStartup(e);
        }
    }
}
