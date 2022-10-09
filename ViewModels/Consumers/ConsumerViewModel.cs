using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetwork.Domain.Models;

namespace WaterNetwork.WPF.ViewModels.Consumers
{
    public class ConsumerViewModel
    {
        private readonly Consumer _consumer;

        public int Id => _consumer.Id;
        public string FirstName => _consumer.FirstName;
        public string LastName => _consumer.LastName;   

        public ConsumerViewModel(Consumer consumer)
        {
            _consumer = consumer;
        }
    }
}
