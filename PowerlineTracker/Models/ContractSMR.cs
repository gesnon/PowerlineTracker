using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PowerlineTracker.Models
{
    public class ContractSMR
    {
        [Display(Name = "Номер договора СМР")]
        public int Number { get; set; }

        [Display(Name = "Дата заключения договора")]
        public DateTime DateOfSigned { get; set; }

        [Display(Name = "Тип договора")]
        public string TypeOfContract { get; set; }

        [Display(Name = "Дата окончания 1 этапа")]
        public DateTime? DateOfCompleteFirstStage { get; set; }

        [Display(Name = "Дата окончания 2 этапа")]
        public DateTime? DateOfCompleteSecondtStage { get; set; }

        [Display(Name = "Сумма договора")]
        public decimal ContractSum { get; set; }
        
        public int ID { get; set; }
               
    }
}