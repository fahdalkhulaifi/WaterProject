using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterNetworkProject.Models
{
    public class Consumation
    {
        public int ConsumerId { get; set; }
        public int CounterLecture { get; set; }
        public DateTime ConsumationDate { get; set; }

        public Consumation(int consumerId, int counterLecture, DateTime consumationDate)
        {
            ConsumerId = consumerId;
            CounterLecture = counterLecture;
            ConsumationDate = consumationDate;
        }
    }
}
