using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using KFP.DATA;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFP.DATA
{
    public class KFG_Db : DbContext
    {
        public KFG_Db()
            : base("KFP Data")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderAddress> OrderAddress { get; set; }
        


        public DbSet<Cart> Carts { get; set; }
        public DbSet<Cart_Package> Cart_Packages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderTracking> OrderTracking { get; set; }

        public DbSet<Order_Item> Order_Items { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<MembershipPackages> MembershipPackages { get; set; }
        public DbSet<KlassType> KlassType { get; set; }
        public DbSet<BankingDetails> BankingDetails { get; set; }

        public DbSet<KlassVenue> KlassVenue { get; set; }
        public DbSet<Equipment_Type> Equipment_Type { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Klass> Klass { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Message> Messages { get; set; }


        public DbSet<Booking> Booking { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Instructor> Instructor { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");

            EntityTypeConfiguration<ApplicationUser> table =
                modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");

            table.Property((ApplicationUser u) => u.UserName).IsRequired();

            modelBuilder.Entity<ApplicationUser>().HasMany<IdentityUserRole>((ApplicationUser u) => u.Roles);
            modelBuilder.Entity<IdentityUserRole>().HasKey((IdentityUserRole r) =>
                new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("AspNetUserRoles");

            EntityTypeConfiguration<IdentityUserLogin> entityTypeConfiguration =
                modelBuilder.Entity<IdentityUserLogin>().HasKey((IdentityUserLogin l) =>
                    new
                    {
                        UserId = l.UserId,
                        LoginProvider = l.LoginProvider,
                        ProviderKey
                            = l.ProviderKey
                    }).ToTable("AspNetUserLogins");

            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");

            EntityTypeConfiguration<ApplicationRole> entityTypeConfiguration1 = modelBuilder.Entity<ApplicationRole>().ToTable("AspNetRoles");

            entityTypeConfiguration1.Property((ApplicationRole r) => r.Name).IsRequired();

        }

        public System.Data.Entity.DbSet<KFP.DATA.EventsClass> EventsClasses { get; set; }

        public System.Data.Entity.DbSet<KFP.DATA.Eventsdates> Eventsdates { get; set; }

        public System.Data.Entity.DbSet<KFP.DATA.EventsVanue> EventsVanues { get; set; }
    }
}
