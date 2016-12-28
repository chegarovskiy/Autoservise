using System.Data.Entity;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer.Context
{
    /// <summary>
    /// DbContext class
    /// </summary>
    public class CarServiceDbContext : DbContext
    {
         public CarServiceDbContext() : base("name=CarServiceBase")
        {
            //setting DB intializer
            //Database.SetInitializer(new CarServiceDbInitializer());
            //Database.Initialize(true);
            //this.Configuration.ProxyCreationEnabled = false;// Configurations.
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //this.Configuration.ProxyCreationEnabled = false;// Configurations.
            //base.OnModelCreating(modelBuilder);
        }

        // Context entities
        public DbSet<Brand> Brands { get; set; } //1
        public DbSet<Car> Cars { get; set; } //2
        public DbSet<Client> Client { get; set; } //3
        public DbSet<Currency> Currencies { get; set; } //4
        public DbSet<Discount> Discounts { get; set; } //5
        public DbSet<Grant> Grants { get; set; } //6
        public DbSet<Manufacturer> Manufacturers { get; set; } //7
        public DbSet<Model> Models { get; set; } //8
        public DbSet<Order> Orders { get; set; } //9
        public DbSet<OrderedService> OrderedServices { get; set; } //10
        public DbSet<OrderedSpare> OrderedSpares { get; set; } //11
        public DbSet<OrderStatus> OrderStatuses { get; set; } //12
        public DbSet<PaidSalary> PaidSalaries { get; set; } //13
        public DbSet<Payment> Payments { get; set; } //14
        public DbSet<PaymentType> PaymentTypes { get; set; } //15
        public DbSet<PriceMarkup> PriceMarkups { get; set; } // 16
        public DbSet<Service> Services { get; set; }//17
        public DbSet<ServiceType> ServiceTypes { get; set; } //18
        public DbSet<Spare> Spares { get; set; } //19
        public DbSet<User> Users { get; set; } //20
        public DbSet<UserGroup> UsersGroups { get; set; } //21
        public DbSet<WorkType> WorkTypes { get; set; } //22
    }
}