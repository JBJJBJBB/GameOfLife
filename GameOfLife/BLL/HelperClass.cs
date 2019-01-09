using System;
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
        
        public void MakeSaveData(byte[,] b, string name)
        {
            GameData gd = new GameData();
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
            
            using (Connection conn = new Connection()) { 
                gd.GameName = name;
                gd.Seed = seed;
                gd.SaveGame(gd);
                
            }
            
        }
        
        public void MakeEditData(object o, byte[,] b, string name)
        {


          var g = o as GameData;
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
                    sb.Append($"{b[i, j]}");
                }

                sb.Append(" ");
            }

            var seed = sb.ToString();

            using (Connection conn = new Connection())
            {
                gd.Id = g.Id;
                gd.Seed = seed;
                gd.EditSave(gd);

            }

        }


        //TODO
        public byte[,] MakeLoadData(object o)
        {
            GameData gd = new GameData();
            var objecttoload = o as GameData;
            byte[,] Cells = new byte[300, 150];
            string SeedString = gd.LoadGame(objecttoload); 
            string [] SeedArray = SeedString.Split(' ');

            for (int i = 0; i < SeedArray.Length; i++)
            {
                string[] TempArray = SeedArray[i].Split('.');
           

          
            for (int j = 0; j < TempArray.Length; j++)
            {
                if (TempArray[j] != null)
                {
                    var bytes = System.Text.Encoding.Unicode.GetBytes(TempArray[j]);

                 
                        Cells[i, j] = bytes[j];
                    
                }
                }
            }
            return Cells;
            }
        }
    }

