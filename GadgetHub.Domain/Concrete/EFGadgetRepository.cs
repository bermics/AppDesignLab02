using System;
using System.Collections.Generic;
using System.Linq;
using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;

namespace GadgetHub.Domain.Concrete
{
    public class EFGadgetRepository : IGadgetRepository
    {
        private readonly EFDbContext context = new EFDbContext();

        public IEnumerable<Gadget> Gadgets
        {
            get
            {
                var gadgets = context.Gadgets.ToList();
                Console.WriteLine($"Retrieved {gadgets.Count} gadgets from database.");
                return gadgets;
            }
        }
    }
}
