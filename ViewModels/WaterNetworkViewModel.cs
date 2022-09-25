using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetwork.WPF.Stores;
using WaterNetworkProject.ViewModels;

namespace WaterNetwork.WPF.ViewModels
{
    public class WaterNetworkViewModel : ViewModelBase
    {
        //private readonly RegistrationsStore _registrationsStore;
        public RegistrationListViewModel RegistrationListViewModel { get; }
        public RegistrationViewModel RegistrationViewModel { get; }

    }
}
