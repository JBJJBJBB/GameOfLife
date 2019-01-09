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
        }

        public virtual DbSet<GameData> GameData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameData>()
                .Property(e => e.GameName)
                .IsFixedLength();

            modelBuilder.Entity<GameData>()
                .Property(e => e.Seed)
                .IsUnicode(false);
        }
    }
}
