﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterNetworkProject.Services.Models
{
    public class ConsumerDTO
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<RegistrationDTO> RegistrationDTOs { get; set; }
    }
}
