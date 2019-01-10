using System.Data.Entity.Migrations;
using System.Linq;

namespace GameOfLife
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GameData")]
    public partial class GameData
    {
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
}
