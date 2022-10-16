using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetworkProject.Stores;
using WaterNetworkProject.ViewModels;
using WaterNetworkProject.ViewModels.Registrations;

namespace WaterNetworkProject.ViewModels
{
    public class WaterNetworkViewModel : ViewModelBase
    {
        //private readonly RegistrationsStore _registrationsStore;
        public RegistrationListViewModel RegistrationListViewModel { get; }
        public RegistrationViewModel RegistrationViewModel { get; }

    }
}
