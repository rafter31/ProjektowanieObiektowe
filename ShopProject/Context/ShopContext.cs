using ShopProject.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace ShopProject.Context
{
    public class ShopContext :DbContext
    {
       

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Payment> Payments { get; set; }


        public ShopContext() : base("DbName")
        {
            SetInitializer();
        }

        public ShopContext(string connString) : base(connString)
        {
            SetInitializer();
        }

        private static void SetInitializer()
        {

            Database.SetInitializer(new MyDbMigrateToLatest());
        }
    }



    class MyDbMigrateToLatest : MigrateDatabaseToLatestVersion<ShopContext, Configuration>
    {
    }
    public sealed class Configuration : DbMigrationsConfiguration<ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ShopContext context)
        {
            // Whatever
        }

    }

}