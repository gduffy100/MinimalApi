using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext // must inherit from this to be used in db connection
    {
        //need constructor 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) // inherit base options
        {
            
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Motorbike> Motorbikes { get; set; }
        public DbSet<CarRace> CarRaces { get; set; }
        public DbSet<MotorbikeRace> MotorbikeRaces { get; set; }

    }
}
