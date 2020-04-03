using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerlineTracker.DAL.Models
{
    public class Powerline
    {
        public string Name { get; set; }

        public ContractPIR ContractPIR { get; set; }

        public ConractSMR ConractSMR { get; set; }

        public List<InternalNote> InternalNotes { get; set; }

        public int ID { get; set; }
    }
}