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
        public int CounterLecture { get; set; }
        public DateTime ConsumationDate { get; set; }

        public Registration(Consumer consumer, int counterLecture, DateTime consumationDate)
        {
            Consumer = consumer;
            CounterLecture = counterLecture;
            ConsumationDate = consumationDate;
        }

        public string toCsv()
        {
            return Consumer.Id + "," + Consumer.FirstName + "," + Consumer.LastName + "," + CounterLecture + "," + ConsumationDate.ToString();
        }
    }
}
