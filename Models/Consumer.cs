using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterNetworkProject.Models
{
    public class Consumer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }



        #region constructors
        public Consumer() {}
        public Consumer(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        #endregion

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public static Consumer FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(",");
            Consumer consumer = new Consumer();

            consumer.Id = (int)Convert.ToInt64(values[0]);
            consumer.FirstName = values[1];
            consumer.LastName = values[2];

            return consumer;
        }
    }
}
