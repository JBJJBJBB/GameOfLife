using System.Data.Entity.Migrations;
using GameOfLife.BLL;

namespace GameOfLife
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    [Table("SeedTable")]
    public partial class SeedTable
    {
        //public SeedTable()
        //{
        //    Database.SetInitializer(new SeedTableDBInitializer());
        //}
        //Doesnt Work :/

        public int Id { get; set; }

        public string Seed { get; set; }

        public int FrameNumber { get; set; }

        public virtual ICollection<GameData> GameData { get; set; }

        #region  //CRUD


        //Create 
        public void SaveGame(SeedTable s)
        {
            using (Connection connection = new Connection())
            {
                var gobjecttoAdd = s as SeedTable;
                connection.SeedTables.Add(s);
                connection.SaveChanges();
            }
        }

        //Read

        public string LoadGame(SeedTable s)
        {
            using (Connection connection = new Connection())
            {
                var objecttoLoad = s as SeedTable;
                string SeedString = objecttoLoad.Seed.ToString();
                return SeedString;
            }
        }

        //Update

        public void EditSave(SeedTable s)
        {

            using (Connection connection = new Connection())
            {
                var objecttoedit = s as SeedTable;
                connection.SeedTables.AddOrUpdate(s);
                connection.SaveChanges();
            }
        }


        //Delete

        public void DeleteSave(SeedTable s)
        {
            using (Connection connection = new Connection())
            {
                int remID =  s.Id;
                var gametoremove = connection.SeedTables.Find(remID);
                connection.SeedTables.Remove(gametoremove);
                connection.SaveChanges();
            }

        }
#endregion
    }



       #region //Initializer
    public class SeedTableDBInitializer : DropCreateDatabaseAlways<Connection> //DEBUG ONLY
    // public class SeedTableDBInitializer : CreateDatabaseIfNotExists<Connection>
    {
        HelperClass help = new HelperClass();
        protected override void Seed(Connection context) => context.SeedTables.AddOrUpdate(x => x.Id,
           
            new SeedTable() { Id = 1, Seed = help.RandomString()},
            new SeedTable() { Id = 2, Seed = help.RandomString() },
            new SeedTable() { Id = 3, Seed = help.RandomString() },
            new SeedTable() { Id = 4, Seed = help.RandomString() },
            new SeedTable() { Id = 5, Seed = help.RandomString() },
            new SeedTable() { Id = 6, Seed = help.RandomString() },
            new SeedTable() { Id = 7, Seed = help.RandomString() },
            new SeedTable() { Id = 8, Seed = help.RandomString() },
            new SeedTable() { Id = 9, Seed = help.RandomString() },
            new SeedTable() { Id = 10, Seed = help.RandomString() }
             );
    }
#endregion
}
