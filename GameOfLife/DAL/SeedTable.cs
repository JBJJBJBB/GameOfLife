using System.Data.Entity.Migrations;

namespace GameOfLife
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SeedTable")]
    public partial class SeedTable
    {
        public int Id { get; set; }

        public string Seed { get; set; }

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
}
