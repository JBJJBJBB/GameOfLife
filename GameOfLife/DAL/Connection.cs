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
            : base("Context")
        {
          // Database.SetInitializer<Connection>(new DropCreateDatabaseAlways<Connection>()); //Debug or after DB change
            Database.SetInitializer<Connection>(new CreateDatabaseIfNotExists<Connection>());
      
        }

    
        public virtual DbSet<GameData> GameData { get; set; }

        public virtual DbSet<SeedTable> SeedTables { get; set; }
        public virtual DbSet<FrameTable> FrameTables { get; set; }

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


            modelBuilder.Entity<FrameTable>()
                .Property(e => e.FrameNumber);

            modelBuilder.Entity<FrameTable>()
                .Property(e => e.GameDataId);




        }
    }
}
