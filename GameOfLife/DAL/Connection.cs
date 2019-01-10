using System.Diagnostics;

namespace GameOfLife
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Connection : DbContext
    {
        public Connection()
            : base("name=Context")
        {
         //   Database.SetInitializer<Connection>(new DropCreateDatabaseAlways<Connection>()); //Debug ONLY
            Database.SetInitializer<Connection>(new CreateDatabaseIfNotExists<Connection>());
      
        }

    
        public virtual DbSet<GameData> GameData { get; set; }

        public virtual DbSet<SeedTable> SeedTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameData>()
                .Property(e => e.GameName)
                .IsFixedLength();

            modelBuilder.Entity<GameData>()
                .Property(e => e.SeedId);
      

            modelBuilder.Entity<SeedTable>()
                .Property(e => e.Seed)
                .IsUnicode(false);


        }
    }
}
