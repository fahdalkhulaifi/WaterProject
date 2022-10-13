using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WaterNetwork.WPF.Commands.Consumers;
using WaterNetwork.WPF.Stores;
using WaterNetworkProject.Commands;
using WaterNetworkProject.Services;
using WaterNetworkProject.ViewModels;

namespace WaterNetwork.WPF.ViewModels.Consumers
{
    public class AddConsumerViewModel: ViewModelBase
    {
       private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { 
                _firstName = value; 
                OnPropertyChanged(nameof(FirstName));
            }
        }


        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public ICommand RegisterCommand { get;  }
        public ICommand CancelCommand { get; }

        public AddConsumerViewModel(ConsumersStore consumersStore, NavigationService consumerNavigationService)
        {
            RegisterCommand = new AddConsumerCommand(this, consumersStore, consumerNavigationService);
            CancelCommand = new NavigateCommand(consumerNavigationService);
        }

    }
}
