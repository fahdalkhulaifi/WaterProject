using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
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

            _registrationsBook.Consumers = File.ReadAllLines(_registrationsBook.PathHelper.ConsumersFilePath)
                .Skip(1)
                .Select(v => Consumer.FromCsv(v))
                .ToList();
            if (File.Exists(_registrationsBook.PathHelper.RegistrationsFilePath))
            {
                _registrationsBook.Registrations = File.ReadAllLines(_registrationsBook.PathHelper.RegistrationsFilePath)
                .Skip(1)
                .Select(v => _registrationsBook.FromCsv(v))
                .ToList();
            } 
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

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _registrationsBook.SaveRegistrationsLocally();
        }

        private MakeRegistrationViewModel CreateMakeRegistrationViewMode()
        {
            return new MakeRegistrationViewModel(_registrationsBook,new NavigationService( _navigationStore, CreateRegistrationViewModel));
        }

        private RegistrationListViewModel CreateRegistrationViewModel()
        {
            return new RegistrationListViewModel(_registrationsBook, new NavigationService(_navigationStore, CreateMakeRegistrationViewMode));
        }

        //ToDo: stopped at video 5 minute : 7:04 (navigate from list to make view)
    }
}
