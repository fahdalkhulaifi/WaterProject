using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetwork.Domain.Models;

namespace WaterNetworkProject.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private readonly Registration _registration;

        public long ConsumerId => _registration.ConsumerId;
        public string ConsumerName => _registration.ConsumerName;

        public int CounterLecture => _registration.CounterLecture;
        public string ConsumationDate => _registration.ConsumationDate.ToString("dd/MM/yyyy");

        public RegistrationViewModel(Registration registration)
        {
            _registration = registration;
        }
    }
}
