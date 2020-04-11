namespace API_ODATA.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApiContext : DbContext
    {
        public ApiContext()
            : base("name=ApiContext")
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<People> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>()
                .HasMany(e => e.Comments)
                .WithOptional(e => e.People)
                .HasForeignKey(e => e.IdPerson);
        }
    }
}
