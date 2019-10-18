using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FitBody.Entities.Concrete
{
    public class FitBodyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-4DUE46S;Database=FitBody; Trusted_Connection=true");
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseType> ExerciseTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }      
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<SupplementCategory> SupplementCategories { get; set; }
        public DbSet<SupplementSubCategory> SupplementSubCategories { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<About> Abouts{ get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

    

    }
}
