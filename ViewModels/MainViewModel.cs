using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetworkProject.Models;

namespace WaterNetworkProject.ViewModels
{
    public class MainViewModel : ViewModelBase 
    {
        public ViewModelBase CurrentViewModel{ get; }

        public MainViewModel()
        {
            RegistrationsBook registrationsBook = new RegistrationsBook();

            CurrentViewModel = new MakeRegistrationViewModel(registrationsBook);
        }
    }
}
