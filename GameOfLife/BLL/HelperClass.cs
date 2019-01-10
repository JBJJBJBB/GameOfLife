﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife.BLL
{
    class HelperClass
    {
        static string RandomString(int length)
        {
            Random random = new Random();
            const string pool = "0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < 45000; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }




        public void MakeSaveData(byte[,] b, string name) //OK
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

        public void MakeEditData(object o, byte[,] b, string name)
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

            using (Connection conn = new Connection())
            {
                gd.Id = g.Id;
                st.Seed = seed;
                gd.EditSave(gd);

            }

        } //TODO
        
        public byte[,] MakeLoadData(GameData o) //OK
        {
            using (Connection connection = new Connection())
            {
                var GameObject = o as GameData;
                SeedTable st = new SeedTable();

                int SeedID = o.SeedId;
                var SeedObject = connection.SeedTables.Find(SeedID) as SeedTable;

                byte[,] Cells = new byte[300, 150];


                string SeedString = st.LoadGame(SeedObject);

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

            using (Connection connection= new Connection())
            {

                var GameDatatoRemove = o as GameData;
                var SeedIdtoRemove = GameDatatoRemove.SeedId;
                var SeedTabletoRemove = connection.SeedTables.Find(SeedIdtoRemove) as SeedTable;
                SeedTable st = new SeedTable();
                GameData gd = new GameData();


                gd.DeleteSave(GameDatatoRemove);
                st.DeleteSave(SeedTabletoRemove);



            }






        }
    }
}

