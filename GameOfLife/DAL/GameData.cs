using System.Data.Entity.Migrations;
using System.Linq;

namespace GameOfLife
{
    using GameOfLife.BLL;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;



    [Table("GameData")]
    public partial class GameData
    {
        //public GameData()
        //{
        //    Database.SetInitializer(new GameDataDBInitializer());
        //}
        //Doesnt Work :/

        public int Id { get; set; }

        [StringLength(20)]
        public string GameName { get; set; }

        public int SeedId { get; set; }

        public virtual ICollection<SeedTable> SeedTable { get; set; }

        #region  //CRUD


        //Create 
        public void SaveGame(GameData g)
        {
            using (Connection connection = new Connection())
            {
                var gobjecttoAdd = g as GameData;
                connection.GameData.Add(g);
                connection.SaveChanges();
            }
        }

        //Read

        //public string LoadGame(GameData g)
        //{
        //    using (Connection connection = new Connection())
        //    {
        //        SeedTable st = new SeedTable();
        //        var objecttoLoad = g as GameData;
              
        //        string SeedString = objecttoLoad.SeedTable.ToString();
        //        return SeedString;
        //    }
        //}

        //Update

        public void EditSave(GameData g)
        {

            using (Connection connection = new Connection())
            {
                var objecttoedit = g as GameData;
                connection.GameData.AddOrUpdate(g);
                connection.SaveChanges();
            }
        }


        //Delete

        public void DeleteSave(GameData g)
        {
            using (Connection connection = new Connection())
            {
                int remID =  g.Id;
                var gametoremove = connection.GameData.Find(remID);
                connection.GameData.Remove(gametoremove);
                connection.SaveChanges();
            }

        }
#endregion
    }

        #region //Initializer

    public class GameDataDBInitializer :DropCreateDatabaseAlways<Connection> //DEBUG ONLY
  //  public class GameDataDBInitializer : CreateDatabaseIfNotExists<Connection>
    {
        HelperClass help = new HelperClass();
        protected override void Seed(Connection context) => context.GameData.AddOrUpdate(x => x.Id,
            new GameData() { Id = 1, GameName ="First", SeedId = 1 },
            new GameData() { Id = 2, GameName = "Second", SeedId = 2 },
            new GameData() { Id = 3, GameName = "Third", SeedId = 3 },
            new GameData() { Id = 4, GameName = "Forth", SeedId = 4 },
            new GameData() { Id = 5, GameName = "Fift", SeedId = 5 },
            new GameData() { Id = 6, GameName = "Sixt", SeedId = 6 },
            new GameData() { Id = 7, GameName = "Seventh", SeedId = 7 },
            new GameData() { Id = 8, GameName = "Eight", SeedId = 8 },
            new GameData() { Id = 9, GameName = "Nineth", SeedId = 9 },
            new GameData() { Id = 10, GameName = "Tenth", SeedId = 10 }
      
        );
    }
#endregion
}
