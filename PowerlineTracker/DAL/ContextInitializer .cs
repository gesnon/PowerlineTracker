using PowerlineTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PowerlineTracker.DAL
{
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            List<Powerline> Powerlines = new List<Powerline>();

            Powerlines.Add(new Powerline
            {
                Name = "test_1",
                ContractPIR = new ContractPIR
                {
                    Number = 1,
                    DateOfSigned = new DateTime(2020, 4, 2),
                    DateOfComplete = new DateTime(2020, 6, 2),
                    ContractSum = 120000

                },
                InternalNotes = new List<InternalNote> {
                    new InternalNote
                    {
                        Number = 2,
                        Date = new DateTime(2020,4,2),
                        Theme = "Internal Note to PSO about PIR",
                        Department = "PSO"
                    },
                        new InternalNote
                    {
                        Number = 3,
                        Date = new DateTime(2020,5,2),
                        Theme = "Internal Note to UZ about PIR",
                        Department = "UZ"
                    }
                }

            });

            Powerlines.Add(new Powerline
            {
                Name = "test_2",
                ContractPIR = new ContractPIR
                {
                    Number = 2,
                    DateOfSigned = new DateTime(2030, 4, 2),
                    DateOfComplete = new DateTime(2030, 3, 1),
                    ContractSum = 100000

                },
                InternalNotes = new List<InternalNote> {
                    new InternalNote
                    {
                        Number = 4,
                        Date = new DateTime(2030,4,2),
                        Theme = "Internal Note to UZ about PIR",
                        Department = "UZ"
                    }
                }
            });

            foreach(Powerline powerline in Powerlines)
            {
                context.Powerlines.Add(powerline);
            }
            context.SaveChanges();
        }

    }
}