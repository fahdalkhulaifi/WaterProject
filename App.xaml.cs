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
using WaterNetwork.EntityFramework.Queries;
using WaterNetwork.Domain.Queries;
using WaterNetworkProject.Stores;
using WaterNetwork.Domain.Commands.Consumers;
using WaterNetwork.Entities.Commands.Consumers;
using WaterNetwork.EntityFramework.Commands.Consumers;
using WaterNetwork.Entities.Queries;
using WaterNetworkProject.ViewModels.Registrations;
using WaterNetworkProject.ViewModels.Consumers;

namespace WaterNetworkProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly RegistrationBookService _registrationsBookService;

        private readonly NavigationStore _navigationStore;
        private readonly RegistrationsStore _registrationsStore;
        private readonly ConsumersStore _consumersStore;

        private readonly IAddRegistrationCommand _addRegistrationCommand;
        private readonly IDeleteRegistrationCommand _deleteRegistrationCommand;
        private readonly IGetAllRegistrationsQuery _getAllRegistrationsQuery;

        private readonly IAddConsumerCommand _addConsumerCommand;
        private readonly IDeleteConsumerCommand _deleteConsumerCommand;
        private readonly IGetAllConsumersQuery _getAllConsumersQuery;
        private readonly IGetConsumerQuery _getConsumerQuery;

        private readonly AppDbContextFactory _appDbContextFactory;

        public App()
        {
            string connectionString = "Server=.;Database=WaterNetwork;Trusted_connection=true";

            _navigationStore = new NavigationStore();

            _appDbContextFactory = new AppDbContextFactory(
                new DbContextOptionsBuilder().UseSqlServer(connectionString).Options
                );

            _getAllRegistrationsQuery = new GetAllRegistarationsQuery(_appDbContextFactory);
            _addRegistrationCommand = new AddRegistrationCommand(_appDbContextFactory);
            _deleteRegistrationCommand = new DeleteRegistrationCommand(_appDbContextFactory);

            _getAllConsumersQuery = new GetAllConsumersQuery(_appDbContextFactory);
            _getConsumerQuery = new GetConsumerQuery(_appDbContextFactory);

            _addConsumerCommand = new AddConsumerCommand(_appDbContextFactory);
            _deleteConsumerCommand = new DeleteConsumerCommand(_appDbContextFactory);

            _registrationsBookService = new RegistrationBookService(_getAllRegistrationsQuery, _addRegistrationCommand, _deleteRegistrationCommand);

            _consumersStore = new ConsumersStore(_getAllConsumersQuery, _getConsumerQuery, _addConsumerCommand, _deleteConsumerCommand);
            _registrationsStore = new RegistrationsStore(_getAllRegistrationsQuery, _addRegistrationCommand, _deleteRegistrationCommand);

            //_registrationsBookService.RegistrationBook.Consumers = File.ReadAllLines(_registrationsBookService.PathHelper.ConsumersFilePath)
            //    .Skip(1)
            //    .Select(v => Consumer.FromCsv(v))
            //    .ToList();
            //if (File.Exists(_registrationsBookService.PathHelper.RegistrationsFilePath))
            //{
            //    _registrationsBookService.RegistrationBook.Registrations = File.ReadAllLines(_registrationsBookService.PathHelper.RegistrationsFilePath)
            //    .Skip(1)
            //    .Select(v => _registrationsBookService.FromCsv(v))
            //    .ToList();
            //}

        }

        protected override void OnStartup(StartupEventArgs e)
        {

            //_navigationStore.CurrentviewModel = CreateMakeRegistrationViewMode();
            _navigationStore.CurrentviewModel = CreateConsumersListViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel( _navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            //ToDo: Activate local saving on Exit app
            //_registrationsBookService.SaveRegistrationsLocally();
        }

        private MakeRegistrationViewModel CreateMakeRegistrationViewMode()
        {
            //return new MakeRegistrationViewModel(_registrationsStore, _registrationsBookService.RegistrationBook, new NavigationService(_navigationStore, CreateRegistrationViewModel), _addRegistrationCommand);
            return new MakeRegistrationViewModel(_registrationsStore, _consumersStore,  new NavigationService(_navigationStore, CreateRegistrationsListViewModel));
        }

        private RegistrationListViewModel CreateRegistrationsListViewModel()
        {
            return RegistrationListViewModel.LoadViewModel(_registrationsStore,CreateMakeRegistrationViewMode(), new NavigationService(_navigationStore, CreateMakeRegistrationViewMode));
        }

        //-------------------------------------------------------------------------------------------
        // Consumers 

        private AddConsumerViewModel CreateAddConsumerViewModel()
        {
            return new AddConsumerViewModel(_consumersStore, new NavigationService(_navigationStore, CreateConsumersListViewModel));
        }

        private ViewModelBase CreateConsumersListViewModel()
        {
            return ConsumersListViewModel.LoadViewModel(_consumersStore, CreateAddConsumerViewModel(), new NavigationService(_navigationStore, CreateAddConsumerViewModel));
        }



        //ToDo: stopped 2:29:15  https://www.youtube.com/watch?v=54ZmhbpjBmg&list=LL&index=4&t=38s&ab_channel=SingletonSean
        //https://www.youtube.com/watch?v=STt3U122wiU&list=PLA8ZIAm2I03hS41Fy4vFpRw8AdYNBXmNm&index=6&ab_channel=SingletonSean
    }
}
