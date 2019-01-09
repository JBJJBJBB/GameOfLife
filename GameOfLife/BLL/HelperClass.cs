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

/// Funkar ej string savedata = Encoding.UTF8.GetBytes(b)

            ;
            for (int i = 0; i < 150; i++)
            {
                for (int j = 0; j < 300; j++)
                {
                    StringBuilder sb = new StringBuilder();
                 

                    //TODO CONVERTARA TILL STRÄNG
                   
                }
            }


            GameData gd = new GameData();

            using (Connection conn = new Connection()) { 
            gd.GameName = name;
       //     gd.Seed = savedata;

            gd.SaveGame(gd);

       

            }
            
        }
    }
}
