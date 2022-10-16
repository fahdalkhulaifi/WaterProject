using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetworkProject.Services.Models;

namespace WaterNetworkProject.Services.API.Users
{
    public interface IUsersService
    {
        public IEnumerable<ConsumerDTO> GetConsumers();
    }
}
