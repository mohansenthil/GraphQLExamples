using Microsoft.EntityFrameworkCore;

namespace BigBlueClothingFactory.Database
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Clothes> Clothes { get; set; }


    }
}
