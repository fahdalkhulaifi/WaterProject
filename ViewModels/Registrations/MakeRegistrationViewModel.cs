using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WaterNetworkProject.Commands;
using WaterNetwork.Domain.Models;
using WaterNetworkProject.Services;
using WaterNetworkProject.Stores;
using WaterNetwork.Domain.Commands.Registrations;
using WaterNetworkProject.Stores;
using WaterNetworkProject.ViewModels;
using WaterNetworkProject.Commands.Registrations;

namespace WaterNetworkProject.ViewModels.Registrations
{
    public class MakeRegistrationViewModel : ViewModelBase
    {
        private int _userId;
        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        private int _counterLecture;
        public int CounterLecture
        {
            get
            {
                return _counterLecture;
            }
            set
            {
                _counterLecture = value;
                OnPropertyChanged(nameof(CounterLecture));
            }
        }

        private DateTime _registrationDate = DateTime.UtcNow;
        private readonly RegistrationsStore registrationsStore;

        public DateTime RegistrationDate
        {
            get
            {
                return _registrationDate;
            }
            set
            {
                _registrationDate = value;
                OnPropertyChanged(nameof(RegistrationDate));
            }
        }

        public ICommand RegisterCommand { get; }
        public ICommand CancelCommand { get; }

        public MakeRegistrationViewModel(RegistrationsStore registrationsStore, ConsumersStore consumersStore, NavigationService registrationNavigationService)
        {
            RegisterCommand = new MakeRegistrationCommand(this, registrationsStore, consumersStore, registrationNavigationService);
            CancelCommand = new NavigateCommand(registrationNavigationService);
        }
    }
}
