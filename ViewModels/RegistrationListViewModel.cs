using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WaterNetworkProject.Commands;
using WaterNetworkProject.Models;
using WaterNetworkProject.Services;
using WaterNetworkProject.Stores;

namespace WaterNetworkProject.ViewModels
{
    public class RegistrationListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<RegistrationViewModel> _registrations;
        private readonly RegistrationsBook _registrationsBook;

        public IEnumerable<RegistrationViewModel> Registrations => _registrations;
        public ICommand MakeRegistrationCommand { get; }

        public RegistrationListViewModel(RegistrationsBook registrationsBook, NavigationService makeRegisrationNavigationService)
        {
            _registrations = new ObservableCollection<RegistrationViewModel>();
            _registrationsBook = registrationsBook;

            MakeRegistrationCommand = new NavigateCommand(makeRegisrationNavigationService);
            UpdateRegistrations();
        }

        private void UpdateRegistrations()
        {
           _registrations.Clear();

            foreach (var registration in _registrationsBook.GetAllRegistrations())
            {
                RegistrationViewModel registrationViewModel = new RegistrationViewModel(registration);
                
                _registrations.Add(registrationViewModel);
            }
        }
    }
}
