using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetworkProject.Models;

namespace WaterNetworkProject.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private readonly Registration _registration;

        public int ConsumerId => _registration.Consumer.Id;
        public string ConsumerName => _registration.Consumer.FirstName + " " + _registration.Consumer.LastName;
      
        public int CounterLecture => _registration.CounterLecture;
        public DateTime ConsumationDate => _registration.ConsumationDate;

        public RegistrationViewModel(Registration registration)
        {
            _registration = registration;
        }
    }
}
