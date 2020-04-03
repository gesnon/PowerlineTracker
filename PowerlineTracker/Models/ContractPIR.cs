using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PowerlineTracker.Models
{
    public class ContractPIR
    {
        [Display (Name = "Номер договора ПИР") ]
        public int Number { get; set; }

        [Display(Name = "Дата заключения договора")]
        public DateTime DateOfSigned { get; set; }

        [Display(Name = "Тип договора")]
        public string TypeOfContract { get; set; }

        [Display(Name = "Дата окончания ПИР")]
        public DateTime DateOfComplete { get; set; }

        [Display(Name = "Сумма договора")]
        public decimal ContractSum { get; set; }

        public int ID { get; set; }
    }
}