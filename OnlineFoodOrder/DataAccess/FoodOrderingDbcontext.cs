using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrder.Models;
using System.Reflection.Emit;

namespace OnlineFoodOrder.DataAccess
{
    public class FoodOrderingDbcontext:IdentityDbContext<ApplicationUser>
    {
        public FoodOrderingDbcontext(DbContextOptions<FoodOrderingDbcontext>options):base(options) 
        { 
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    ModelBuilder.Seed();
        //}
        public DbSet<Productmenu> Productmenu { get; set; }
       
        //public DbSet<Cart> Carts { get; set; }
        //public DbSet<Cart> Carts { get; set; }



    }
}
