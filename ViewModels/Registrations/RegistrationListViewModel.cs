using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WaterNetworkProject.Commands;
using WaterNetwork.Domain.Models;
using WaterNetworkProject.Services;
using WaterNetworkProject.Stores;
using WaterNetworkProject.Stores;
using WaterNetworkProject.Commands;
using WaterNetworkProject.ViewModels;
using WaterNetworkProject.Commands.Registrations;

namespace WaterNetworkProject.ViewModels.Registrations
{
    public class RegistrationListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<RegistrationViewModel> _registrations;
        private readonly RegistrationsBook _registrationsBook;
        private RegistrationsStore _registrationsStore;

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);


        public IEnumerable<RegistrationViewModel> Registrations => _registrations;
        public ICommand MakeRegistrationCommand { get; }
        public ICommand ConsumersListNavigationService { get; }
        public ICommand LoadRegistrationsCommand { get; }

        public RegistrationListViewModel(RegistrationsStore registrationsStore, NavigationService makeRegisrationNavigationService, NavigationService consumersListNavigationService)
        {
            _registrationsStore = registrationsStore;
            _registrations = new ObservableCollection<RegistrationViewModel>();

            MakeRegistrationCommand = new NavigateCommand(makeRegisrationNavigationService);
            ConsumersListNavigationService = new NavigateCommand(consumersListNavigationService);
            LoadRegistrationsCommand = new LoadRegistrationsCommand(this, _registrationsStore);
        }

        internal void UpdateRegistrations(IEnumerable<Registration> registrations)
        {
            _registrations.Clear();

            foreach (var registration in registrations)
            {
                RegistrationViewModel registrationViewModel = new RegistrationViewModel(registration);

                _registrations.Add(registrationViewModel);
            }
        }

        public static RegistrationListViewModel LoadViewModel(RegistrationsStore registrationsStore, MakeRegistrationViewModel makeRegistrationViewModel, NavigationService navigationService, NavigationService consumersListNavigationService)
        {
            RegistrationListViewModel viewModel = new RegistrationListViewModel(registrationsStore, navigationService,consumersListNavigationService);

            viewModel.LoadRegistrationsCommand.Execute(null);


            return viewModel;
        }
    }
}
