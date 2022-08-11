using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetwork.WPF.Services.Models;

namespace WaterNetwork.WPF.Services.API.Registrations
{
    public class RegistrationsService : IRegistrationsService
    {
        public Task<IEnumerable<RegistrationDTO>> GetRegistrations()
        {
            throw new NotImplementedException();
        }
    }
}
