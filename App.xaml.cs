using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WaterNetworkProject.Entities;
using WaterNetwork.Domain.Models;
using WaterNetworkProject.Services;
using WaterNetworkProject.Stores;
using WaterNetworkProject.ViewModels;
using WaterNetwork.Domain.Commands.Registrations;
using WaterNetwork.EntityFramework.Commands.Registrations;
using WaterNetwork.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace WaterNetworkProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly RegistrationBookService _registrationsBookService;
        private readonly NavigationStore _navigationStore;
        private readonly IAddRegistrationCommand _addRegistrationCommand;
        private readonly AppDbContextFactory _appDbContextFactory;

        public App()
        {
            string connectionString = "Data Source=Waternetwork";

            _registrationsBookService = new RegistrationBookService();
            _navigationStore = new NavigationStore();

            _appDbContextFactory = new AppDbContextFactory(
                new DbContextOptionsBuilder().UseSqlite(connectionString).Options
                );

            _addRegistrationCommand = new AddRegistrationCommand(_appDbContextFactory);

            _registrationsBookService.RegistrationBook.Consumers = File.ReadAllLines(_registrationsBookService.PathHelper.ConsumersFilePath)
                .Skip(1)
                .Select(v => Consumer.FromCsv(v))
                .ToList();
            if (File.Exists(_registrationsBookService.PathHelper.RegistrationsFilePath))
            {
                _registrationsBookService.RegistrationBook.Registrations = File.ReadAllLines(_registrationsBookService.PathHelper.RegistrationsFilePath)
                .Skip(1)
                .Select(v => _registrationsBookService.FromCsv(v))
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
            _registrationsBookService.SaveRegistrationsLocally();
        }

        private MakeRegistrationViewModel CreateMakeRegistrationViewMode()
        {
            return new MakeRegistrationViewModel(_registrationsBookService.RegistrationBook, new NavigationService( _navigationStore, CreateRegistrationViewModel),_addRegistrationCommand);
        }

        private RegistrationListViewModel CreateRegistrationViewModel()
        {
            return new RegistrationListViewModel(_registrationsBookService.RegistrationBook, new NavigationService(_navigationStore, CreateMakeRegistrationViewMode));
        }

        //ToDo: stopped 2:29:15  https://www.youtube.com/watch?v=54ZmhbpjBmg&list=LL&index=4&t=38s&ab_channel=SingletonSean
    }
}
