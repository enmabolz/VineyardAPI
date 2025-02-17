using Microsoft.EntityFrameworkCore;
using VineyardManager.Models;

namespace VineyardManager.Data
{
    public class VineyardContext : DbContext
    {
        public VineyardContext(DbContextOptions<VineyardContext> options): base(options) {}

        public DbSet<Manager> Managers { set; get; }
        public DbSet<Grape> Grapes { get; set; }
        public DbSet<Vineyard> Vineyards { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
    }
}
