﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerlineTracker.DAL.Models
{
    public class ContractPIR
    {
        public int Number { get; set; }

        public DateTime DateOfSigned { get; set; }

        public string TypeOfContract { get; set; }

        public DateTime DateOfComplete { get; set; }

        public decimal ContractSum { get; set; }

        public int ID { get; set; }
    }
}