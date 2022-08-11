using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterNetwork.WPF.Services.Models
{
    public class RegistrationDTO
    {
        [Key]
        public int Id { get; set; }
        public string ConsumerName { get; set; }
        public int CounterLecture { get; set; }
        public DateTime ConsumationDate { get; set; }

        public int ConsumerId { get; }
        public ConsumerDTO ConsumerDTO { get; set; }
    }
}
