using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetwork.Domain.Models;

namespace WaterNetwork.WPF.Services.Models
{
    public class RegistrationBookDTO
    {
        public List<Registration> Registrations;
        public List<Consumer> Consumers;
    }
}
