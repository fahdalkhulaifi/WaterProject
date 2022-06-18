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
using WaterNetworkProject.Stores;
using WaterNetworkProject.ViewModels;

namespace WaterNetworkProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly RegistrationsBook _registrationsBook;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _registrationsBook = new RegistrationsBook();
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateRegistrationViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private MakeRegistrationViewModel CreateMakeRegistrationViewMode()
        {
            return new MakeRegistrationViewModel(_registrationsBook, _navigationStore, CreateRegistrationViewModel);
        }

        private RegistrationListViewModel CreateRegistrationViewModel()
        {
            return new RegistrationListViewModel(_navigationStore, CreateMakeRegistrationViewMode);
        }



        //ToDo: stopped at video 5 minute : 7:04 (navigate from list to make view)
    }
}
