using GameOfLife.BLL;
using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        //Initialize
        
        Color[] cColors = new Color[9];

        SolidBrush cBrush = new SolidBrush(Color.Red);
        Rectangle cRect = new Rectangle(0, 0, 30, 30);
        int CellsX = 300;
        int CellsY = 150;

        int cFPS = 0;

        byte[,] Cells = new byte[300, 150];
        byte[,] Cells2 = new byte[300, 150];

        //Kommentar Daniel
        double CellsXsize = 0;
        double CellsYsize = 0;
        
   
        public Form1()
        {
            InitializeComponent();
            Populate();
        }

        #region UI
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 1;
            comboBox3.SelectedIndex = 7;

            cColors[0] = Color.Red;
            cColors[1] = Color.Yellow;
            cColors[2] = Color.Green;
            cColors[3] = Color.GreenYellow;
            cColors[4] = Color.Purple;
            cColors[5] = Color.Blue;
            cColors[6] = Color.BlueViolet;
            cColors[7] = Color.DarkSeaGreen;
            cColors[8] = Color.Orange;

  
            try
            {
                string[] files = System.IO.Directory.GetFiles(@"Presets\");
                this.cFiles.Items.AddRange(files);
            }
            catch
            {

            }
        }



        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            buttonExit.Left = this.Width - buttonExit.Width;
            pView.Width = this.Width;
            pView.Height = this.Height - pView.Top;

            CellsXsize = (double) pView.Width / CellsX;
            CellsYsize = (double) pView.Height / CellsY;

            cRect.Width = Convert.ToInt32(CellsXsize);
            cRect.Height = Convert.ToInt32(CellsYsize);

        }

        private void bClear_Click(object sender, EventArgs e)
        {
            ClearCells();
            pView.Refresh();
        }

        private void pView_Paint(object sender, PaintEventArgs e)
        {
            for (int y = 0; y < CellsY; y++)
            {
                for (int x = 0; x < CellsX; x++)
                {
                    if (Cells[x, y] != 0)
                    {
                        double tempX = x * CellsXsize;
                        double tempY = y * CellsYsize;
                        cRect.X = Convert.ToInt32(tempX);
                        cRect.Y = Convert.ToInt32(tempY);
                        cBrush.Color = cColors[Cells[x, y] - 1];
                        e.Graphics.FillRectangle(cBrush, cRect);
                    }
                }
            }
        }

        private void pView_Click(object sender, EventArgs e)
        {

        }

        private void pView_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void pView_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {

                double selX = Math.Round((double) (e.X - CellsXsize / 2) / CellsXsize);
                double selY = Math.Round((double) (e.Y - CellsYsize / 2) / CellsYsize);

                lStats.Text = Convert.ToString(selX) + ", " + Convert.ToString(selY);

                if (e.Button == MouseButtons.Left)
                {
                    Cells[Convert.ToInt32(selX), Convert.ToInt32(selY)] = 1;
                    pView.Refresh();
                }

                if (e.Button == MouseButtons.Right)
                {
                    Cells[Convert.ToInt32(selX), Convert.ToInt32(selY)] = 0;
                    pView.Refresh();
                }

            }
            catch
            {

            }

        }

        private void hSpeed_Scroll(object sender, ScrollEventArgs e)
        {
            timer1.Interval = hSpeed.Value;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            MainLoop();
            pView.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void bLoadPreset_Click(object sender, EventArgs e)
        {
            try
            {
                string path = cFiles.Text;

                if (!File.Exists(path))
                {

                }
                else
                {
                    if (cRun.Checked == true)
                    {
                        cRun.Checked = false;
                    }

                    ClearCells();
                    // Open the stream and read it back.
                    using (StreamReader sr = File.OpenText(@path))
                    {
                        int yPos = 40;
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            for (int i = 0; i < s.Length; i++)
                            {
                                if (s.Substring(i, 1) == "2")
                                {
                                    Cells[i + 50, yPos] = 0;
                                }
                                else
                                {
                                    Cells[i + 50, yPos] = 1;
                                }
                            }
                            yPos++;
                        }
                    }
                }
                pView.Refresh();
            }
            catch
            {

            }
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameBox.Text = comboBox1.SelectedText;
        }

        private void saveButton_Click(object sender, EventArgs e) 
        {
            HelperClass help = new HelperClass();
            string Name = nameBox.Text.ToString();
            if (Name != "")
            {
                
            
            try
            {
                help.MakeSaveData(Cells, Name);
            }
            catch (Exception)
            {

                throw;
            }

            Populate();
        }
            else
            {
                MessageBox.Show("Error no Name");
            }

          

        } //OK

        private void loadButton_Click(object sender, EventArgs e)  //OK
        {
           
            GameData ga = new GameData();
            HelperClass helper = new HelperClass();;
            var o = comboBox1.SelectedItem as GameData;
            if (o != null)
            {

                try
            {
                Cells = helper.MakeLoadData(o);
                Cells2 = Cells;
                if (cRun.Checked == true)
                {
                    cRun.Checked = false;
                }

                
          
            pView.Refresh();
            Populate();
             }
            catch
            {
                throw;
            }

            }
        }

        private void delButton_Click(object sender, EventArgs e) 
        {
            var deldata = comboBox1.SelectedItem as GameData;
            if (deldata != null)
                
            {

                HelperClass help = new HelperClass();
                GameData ga = new GameData();
            try
            {
               help.MakeDeleteSave(deldata);
            }

            catch (Exception)
            {
                throw;
            }
            }
            pView.Refresh();
            Populate();
        } //OK

        private void editButton_Click(object sender, EventArgs e) 
        {
           
            HelperClass helper = new HelperClass();
            Name = nameBox.Text.ToString();
            if (Name != "")
            {

                try
                {
                    var g = comboBox1.SelectedItem as GameData;
                    helper.MakeEditData(g, Cells, Name);
                    Populate();

                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Error no Name");
            }
        }


        #endregion

        // Modules 
        #region Modules
        void Populate()
        {

            comboBox1.ResetText();
            GameData ga = new GameData();

            using (Connection conn = new Connection())
            {
                var ds = conn.GameData.ToList();
                comboBox1.DataSource = ds;
                comboBox1.DisplayMember = "GameName";

            }
        }

        public void MainLoop()
        {

            //Random Color Generator
            //Get color from boxes
            

            int color1 = comboBox2.SelectedIndex;
            int color2 = comboBox3.SelectedIndex;
            
            if (color2 < color1)
            {
                color1 = color1 + color2;
                color2 = color1 - color2;
                color1 = color1 - color2;
            }

            if (color1 == color2)
            {
                if (color1 == 8)
                {
                    color2 -= 2;

                }
                else
                {
                    color2++;
                }

            }

            HelperClass help = new HelperClass();
            int rColor = help.GetRandomNumber(color1, color2);


            //Random Color Generator


            for (int y = 0; y < CellsY; y++)
            {
                for (int x = 0; x < CellsX; x++)
                {
                    //Count neighbours
                    byte cCount = 0;

                    for (int i = 0; i < 8; i++)
                    {
                        int tempX = 0;
                        int tempY = 0;

                        switch (i)
                        {
                            case 0:
                                tempX = mod((x - 1), CellsX);
                                tempY = mod((y - 1), CellsY);
                                break;
                            case 1:
                                tempX = mod(x, CellsX);
                                tempY = mod((y - 1), CellsY);
                                break;
                            case 2:
                                tempX = mod((x + 1), CellsX);
                                tempY = mod((y - 1), CellsY);
                                break;
                            case 3:
                                tempX = mod((x - 1), CellsX);
                                tempY = mod(y, CellsY);
                                break;
                            case 4:
                                tempX = mod((x + 1), CellsX);
                                tempY = mod(y, CellsY);
                                break;
                            case 5:
                                tempX = mod((x - 1), CellsX);
                                tempY = mod((y + 1), CellsY);
                                break;
                            case 6:
                                tempX = mod(x, CellsX);
                                tempY = mod((y + 1), CellsY);
                                break;
                            case 7:
                                tempX = mod((x + 1), CellsX);
                                tempY = mod((y + 1), CellsY);
                                break;
                        }

                        if (Cells[tempX, tempY] != 0)
                            cCount++;
                    }

                    if (Cells[x, y] != 0) //Current cell is alive
                    {
                        if (cCount < 2) //Underpopulation, cell dies
                            Cells2[x, y] = 0;
                        if (cCount == 2 || cCount == 3) //Live on to next generation

                   //Random Color check
                            if (randomBox.Checked == true)
                            {
                                Cells2[x, y] = Convert.ToByte(rColor);
                            }
                    
                            else { Cells2[x, y] = Convert.ToByte(cCount + 1); }
                    //Random Color check


                        if (cCount > 3) //Overpopulation, cell dies
                            Cells2[x, y] = 0;
                    }

                    if (Cells[x, y] == 0) //Current cell is dead
                    {
                        if (cCount == 3) //A new cell is born!
                            Cells2[x, y] = Convert.ToByte(cCount + 1);
                    }
                }
            }

            CopyCellsFromBuffer();
            cFPS++;
        }

        int mod(int x, int m)
        {
            return (x % m + m) % m;
        }

        public void CopyCellsFromBuffer()
        {
            for (int y = 0; y < CellsY; y++)
            {
                for (int x = 0; x < CellsX; x++)
                {
                    Cells[x, y] = Cells2[x, y];
                }
            }
        }

        public void ClearCells()
        {
            for (int y = 0; y < CellsY; y++)
            {
                for (int x = 0; x < CellsX; x++)
                {
                    Cells[x, y] = 0;
                    Cells2[x, y] = 0;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cRun.Checked == true)
            {
                MainLoop();
                pView.Refresh();
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.F2)
            {

                if (cRun.Checked == false)
                    cRun.Checked = true;
                else
                    cRun.Checked = false;
                return true;
            }

            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                Application.Exit();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void FPS_Tick(object sender, EventArgs e)
        {
            lFps.Text = "FPS: " + cFPS.ToString();
            cFPS = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
#endregion
}
