using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetwork.Domain.Models;

namespace WaterNetworkProject.ViewModels.Consumers
{
    public class UpdateConsumerViewModel: ViewModelBase
    {
        public Consumer Consumer { get; set; }
    }
}
