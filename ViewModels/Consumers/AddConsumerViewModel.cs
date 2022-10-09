using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
