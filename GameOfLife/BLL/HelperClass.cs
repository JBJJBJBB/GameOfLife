using System;
using System.Linq;
using System.Text;

namespace GameOfLife.BLL
{
    class HelperClass
    {



        public void MakeSaveData(byte[,] b, string name, int FrameNumber) //OK
        {
            GameData gd = new GameData();
            FrameTable st = new FrameTable();
            var sb = new StringBuilder(string.Empty);
            var maxI = b.GetLength(0);
            var maxJ = b.GetLength(1);
            

            for (var i = 0; i < maxI; i++)
            {
                for (var j = 0; j < maxJ; j++)
                {
                    sb.Append($"{b[i, j]}.");
                }

                sb.Append(" ");
            }

            var seed = sb.ToString();
            
            using (Connection conn = new Connection())
            {
                st.Seed = seed;
                st.SaveGame(st);
             
                gd.GameName = name;
                gd.Id = st.GameDataId;
                gd.SaveGame(gd);
                MakeSaveFrame(b, gd, FrameNumber);
            }

        }

        public void MakeSaveFrame(byte[,] b, object o, int FrameNumber) //OK
        {


            GameData gd = new GameData();
            FrameTable st = new FrameTable();
            var sb = new StringBuilder(string.Empty);
            var maxI = b.GetLength(0);
            var maxJ = b.GetLength(1);
            var ft = o as GameData;
            var id = ft.Id;

        
            for (var i = 0; i < maxI; i++)
            {
                for (var j = 0; j < maxJ; j++)
                {
                    sb.Append($"{b[i, j]}.");
                }

                sb.Append(" ");
            }

            var seed = sb.ToString();



            using (Connection conn = new Connection())
            {
                if (st.Id == 0)
                {
                    
             

                st.GameDataId = id;
                st.Seed = seed;
                st.FrameNumber = FrameNumber;
                st.SaveGame(st);
                }
                else { MakeEditData(gd, b, gd.GameName,FrameNumber);}
            }

        }
        
        public void MakeEditData(object o, byte[,] b, string name, int FrameNumber)
        {

            using (Connection conn = new Connection())
            {
                var g = o as GameData;
                var f = o as FrameTable;
                FrameTable ft = new FrameTable();
                GameData gd = new GameData();
                var sb = new StringBuilder(string.Empty);
                var maxI = b.GetLength(0);
                var maxJ = b.GetLength(1);

                if (g.GameName != name)
                {
                    gd.GameName = name;
                }

                for (var i = 0; i < maxI; i++)
                {
                    for (var j = 0; j < maxJ; j++)
                    {
                        sb.Append($"{b[i, j]}.");
                    }
                    sb.Append(" ");
                }

                var seed = sb.ToString();
                ft.GameDataId = g.Id;
                ft.Seed = seed;
                ft.FrameNumber = FrameNumber;
                ft.EditSave(ft);
                gd.Id = g.Id;
                gd.Id = ft.GameDataId;
                gd.EditSave(gd);


            }

        } //OK

        public byte[,] MakeLoadData(FrameTable o) 
        {
            using (Connection connection = new Connection())
            {
                var GameObject = o as FrameTable;
             FrameTable ft = new FrameTable();
                int FrameNumber = ft.FrameNumber;
                int SeedID = o.Id;
                var SeedObject = connection.FrameTables.Find(SeedID) as FrameTable;

                byte[,] Cells = new byte[300, 150];


                string SeedString = ft.LoadGame(SeedObject);

                string[] SeedArray = SeedString.Split(' ');


                for (int i = 0; i < SeedArray.Length; i++)
                {
                    string[] TempArray = SeedArray[i].Split('.');

                    for (int j = 0; j <= TempArray.Length - 2; j++)
                    {
                        if (TempArray[j] != null)
                        {
                            var bytes = Convert.ToByte(TempArray[j]);
                            Cells[i, j] = bytes;
                        }

                        if (TempArray[j] == null)
                        {
                            Cells[i, j] = 0;
                        }

                    }

                }
                return Cells;
            }
        } //OK
        
        public byte[,] MakeReplayData(FrameTable o, int FrameNumber) 
        {
            using (Connection connection = new Connection())
            {
                var GameObject = o as FrameTable;
                FrameTable ft = new FrameTable();
               
                if (FrameNumber <= o.FrameNumber)
                {
                    int SeedID = o.Id++;
                    var SeedObject = connection.FrameTables.Find(SeedID) as FrameTable;
                    byte[,] Cells = new byte[300, 150];
                    string SeedString = ft.LoadGame(SeedObject);
                    string[] SeedArray = SeedString.Split(' ');
                    
                    for (int i = 0; i < SeedArray.Length; i++)
                    {
                        string[] TempArray = SeedArray[i].Split('.');

                        for (int j = 0; j <= TempArray.Length - 2; j++)
                        {
                            if (TempArray[j] != null)
                            {
                                var bytes = Convert.ToByte(TempArray[j]);
                                Cells[i, j] = bytes;
                            }

                            if (TempArray[j] == null)
                            {
                                Cells[i, j] = 0;
                            }
                        }
                    }

                    return Cells;
                }
                else
                {
                    int SeedID = o.Id;
                    var SeedObject = connection.FrameTables.Find(SeedID) as FrameTable;
                    byte[,] Cells = new byte[300, 150];
                    string SeedString = ft.LoadGame(SeedObject);
                    string[] SeedArray = SeedString.Split(' ');
                    
                    for (int i = 0; i < SeedArray.Length; i++)
                    {
                        string[] TempArray = SeedArray[i].Split('.');

                        for (int j = 0; j <= TempArray.Length - 2; j++)
                        {
                            if (TempArray[j] != null)
                            {
                                var bytes = Convert.ToByte(TempArray[j]);
                                Cells[i, j] = bytes;
                            }

                            if (TempArray[j] == null)
                            {
                                Cells[i, j] = 0;
                            }

                        }

                    }

                    return Cells;

                }
            }
            
        } //OK
        
        public void MakeDeleteSave(object o)
        {

            using (Connection connection = new Connection())
            {

                var GameDatatoRemove = o as GameData;
                var SeedIdtoRemove = GameDatatoRemove.Id;
                var SeedTabletoRemove = connection.FrameTables.Find(SeedIdtoRemove) as FrameTable;
                FrameTable st = new FrameTable();
                GameData gd = new GameData();


                gd.DeleteSave(GameDatatoRemove);
                st.DeleteSave(SeedTabletoRemove);
                }
            } //OK


        #region Unused for Initializer
        public string RandomString()
        {
            Random random = new Random();
            const string pool = "01";
            var builder = new StringBuilder();

            for (var i = 0; i < 45000; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }

        //Function to get random number
        private static readonly Random getrandom = new Random();

        public int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        #endregion
    }
}

