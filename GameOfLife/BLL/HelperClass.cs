﻿using System;
using System.Linq;
using System.Text;

namespace GameOfLife.BLL
{
    class HelperClass
    {
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

        public void MakeSaveData(byte[,] b, string name, int FrameNumber) //OK
        {
            GameData gd = new GameData();
            SeedTable st = new SeedTable();
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
                gd.SeedId = st.Id;
                gd.SaveGame(gd);

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
                st.GameDataId = id;
                st.Seed = seed;
                st.FrameNumber = FrameNumber;
                st.SaveGame(st);


            }

        }


        public void MakeEditData(object o, byte[,] b, string name, int FrameNumber)
        {

            using (Connection conn = new Connection())
            {
                var g = o as GameData;
                SeedTable st = new SeedTable();
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
       st.Id = g.SeedId;
                st.Seed = seed;
                st.EditSave(st);
                gd.Id = g.Id;
                gd.SeedId = st.Id;
                gd.EditSave(gd);


            }

        } //OK

        public byte[,] MakeLoadData(FrameTable o) //OK
        {
            using (Connection connection = new Connection())
            {
                var GameObject = o as FrameTable;
                SeedTable st = new SeedTable();
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
        }

        public void MakeDeleteSave(object o)
        {

            using (Connection connection = new Connection())
            {

                var GameDatatoRemove = o as GameData;
                var SeedIdtoRemove = GameDatatoRemove.SeedId;
                var SeedTabletoRemove = connection.SeedTables.Find(SeedIdtoRemove) as SeedTable;
                SeedTable st = new SeedTable();
                GameData gd = new GameData();


                gd.DeleteSave(GameDatatoRemove);
                st.DeleteSave(SeedTabletoRemove);



            }






        } //OK
    }
}

