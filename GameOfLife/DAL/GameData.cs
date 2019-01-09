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



        //CRUD


        //C
        public void SaveGame(GameData g)
        {
            using (Connection connection = new Connection())
            {
                var gobjecttoAdd = g as GameData;
                connection.GameData.Add(g);
                connection.SaveChanges();
            }
        }
        //R
        //public void LoadGame(GameData g)
        //{
        //    using (Connection connection = new Connection())
        //    {
        //        var objecttoLoad = g as GameData;
        //        connection.GameData.Find(g);


        //    }

        //}


        //U



        //D (TODO)


        public void DeleteGame(GameData o)
        {
            using (Connection context = new Connection())
            {
                var objecttoRemove = context.GameData.Find(o);
                context.GameData.Attach(o);
                context.GameData.Remove(o);
                context.SaveChanges();
            }


        }
    }
}
