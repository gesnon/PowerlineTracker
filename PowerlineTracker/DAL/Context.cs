using PowerlineTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PowerlineTracker.DAL
{
    public class Context : DbContext
    {
        public DbSet<Powerline> Powerlines { get; set; }

        public DbSet<ContractPIR> ContractsPIR { get; set; }

        public DbSet<ContractSMR> ContractSMR { get; set; }

        public DbSet<TypeOfContract> TypesOfContract { get; set; }

        public DbSet<InternalNote> InternalNotes { get; set; }

        public Context() : base ("PowerlinesDB")
        {
            Database.SetInitializer<Context>(new ContextInitializer());
        }
    }
}