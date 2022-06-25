using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterNetworkProject.Models
{
    public class Registration
    {
        public int ConsumerId { get; }
        public string ConsumerName { get; set; }
        public int CounterLecture { get; set; }
        public DateTime ConsumationDate { get; set; }

        public Registration(int consumerId, int counterLecture, DateTime consumationDate)
        {
            ConsumerId = consumerId;
            CounterLecture = counterLecture;
            ConsumationDate = consumationDate;
        }

        public Registration(int consumerId, string consumerName, int counterLecture, DateTime consumationDate)
        {
            ConsumerId = consumerId;
            ConsumerName = consumerName;
            CounterLecture = counterLecture;
            ConsumationDate = consumationDate;
        }
    }
}
