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
using WaterNetwork.WPF.Stores;
using WaterNetwork.WPF.Commands;
using WaterNetworkProject.ViewModels;

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
        public ICommand LoadRegistrationsCommand { get; }

        public RegistrationListViewModel(RegistrationsStore registrationsStore, NavigationService makeRegisrationNavigationService)
        {
            _registrationsStore = registrationsStore;
            _registrations = new ObservableCollection<RegistrationViewModel>();
            //_registrationsBook = registrationsBook;

            MakeRegistrationCommand = new NavigateCommand(makeRegisrationNavigationService);
            LoadRegistrationsCommand = new LoadRegistrationsCommand(this, _registrationsStore);

            //UpdateRegistrations();
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

        public void UpdateRegistrations()
        {
            _registrations.Clear();

            foreach (var registration in _registrationsBook.GetAllRegistrations())
            {
                RegistrationViewModel registrationViewModel = new RegistrationViewModel(registration);

                _registrations.Add(registrationViewModel);
            }
        }

        public static RegistrationListViewModel LoadViewModel(RegistrationsStore registrationsStore, MakeRegistrationViewModel makeRegistrationViewModel, NavigationService navigationService)
        {
            RegistrationListViewModel viewModel = new RegistrationListViewModel(registrationsStore, navigationService);

            viewModel.LoadRegistrationsCommand.Execute(null);


            return viewModel;
        }
    }
}
