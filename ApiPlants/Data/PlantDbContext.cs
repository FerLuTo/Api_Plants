using Microsoft.EntityFrameworkCore;
using ApiPlants.Models;

namespace ApiPlants.Data
{
    public class PlantDbContext:DbContext
    {
        public PlantDbContext(DbContextOptions<PlantDbContext>options):base(options)
        {

        }

        public DbSet<Plant> Plants { get; set; }
    }
}
