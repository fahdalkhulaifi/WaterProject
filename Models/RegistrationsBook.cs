using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterNetworkProject.Models
{
    public class RegistrationsBook
    {
        private readonly List<Registration> _registrations;

        public RegistrationsBook()
        {
            _registrations = new List<Registration>();
        }

        public List<Registration> GetAllRegistrations()
        {
            return _registrations;
        }

        public void MakeRegestration(Registration registration)
        {
            _registrations.Add(registration);
        }
    }
}
