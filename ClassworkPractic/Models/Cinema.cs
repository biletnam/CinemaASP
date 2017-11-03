namespace ClassworkPractic
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Cinema : DbContext
    {
        public Cinema()
            : base("name=Cinema")
        {
        }

        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<FilmLibrary> FilmLibrary { get; set; }
        public virtual DbSet<Halls> Halls { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmLibrary>()
                .HasMany(e => e.Sessions)
                .WithRequired(e => e.FilmLibrary)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Halls>()
                .HasMany(e => e.Sessions)
                .WithRequired(e => e.Halls)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sessions>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Sessions>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Sessions)
                .WillCascadeOnDelete(false);
        }
    }
}
