using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterNetworkProject.Models
{
    public class Registration
    {
        public Consumer Consumer { get; }
        public Consumation Consumation { get; }

        public Registration(Consumer consumer, Consumation consumation)
        {
            Consumer = consumer;
            Consumation = consumation;
        }
    }
}
