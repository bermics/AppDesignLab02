using System.Data.Entity;
using GadgetHub.Domain.Entities;

namespace GadgetHub.Domain
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("GadgetHubDb") { } // ✅ Must match Web.config name

        public DbSet<Gadget> Gadgets { get; set; }
    }
}
