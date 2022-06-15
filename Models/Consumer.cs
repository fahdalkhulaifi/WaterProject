using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterNetworkProject.Models
{
    public class Consumer
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Consumer(long id, string lastName, string firstName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
