using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WaterNetworkProject.Commands;
using WaterNetworkProject.Models;
using WaterNetworkProject.Stores;

namespace WaterNetworkProject.ViewModels
{
    public class RegistrationListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<RegistrationViewModel> _registrations;

        public IEnumerable<RegistrationViewModel> Registrations => _registrations;
        public ICommand MakeRegistrationCommand { get; }

        public RegistrationListViewModel(NavigationStore navigationStore, Func<MakeRegistrationViewModel> createMakeRegistrationViewModel)
        {
            _registrations = new ObservableCollection<RegistrationViewModel>();

            MakeRegistrationCommand = new NavigateCommand(navigationStore, createMakeRegistrationViewModel);

            _registrations.Add(new RegistrationViewModel(new Registration(new Consumer(1, "Fahd", "AL-KHULAIFI"), 1000, new DateTime(2022, 6, 1))));
            _registrations.Add(new RegistrationViewModel(new Registration(new Consumer(1, "Abdulmaged", "AL-KHULAIFI"), 1000, new DateTime(2022, 5, 1))));
            _registrations.Add(new RegistrationViewModel(new Registration(new Consumer(1, "Omar", "AL-KHULAIFI"), 1000, new DateTime(2019, 6, 1))));

        }
    }
}
