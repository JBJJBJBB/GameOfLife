using System.Data.Entity.Migrations;

namespace GameOfLife
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GameData")]
    public partial class GameData
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string GameName { get; set; }

        public string Seed { get; set; }



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

        public string LoadGame(GameData g)
        {
            using (Connection connection = new Connection())
            {
                var objecttoLoad = g as GameData;
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
