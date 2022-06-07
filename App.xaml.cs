using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WaterNetworkProject.Models;

namespace WaterNetworkProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            Consumer consumer = new Consumer(1, "Fahd", "AL-KHULAIFI");
            Consumation consumation = new Consumation(1, 1000, new DateTime(2022,6,1));

            Registration registration = new Registration(consumer, consumation);
            RegistrationsBook registrationsBook = new RegistrationsBook();

            registrationsBook.MakeRegestration(registration);
              
            base.OnStartup(e);
        }
    }
}
