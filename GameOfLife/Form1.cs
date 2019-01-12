using GameOfLife.BLL;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        //Initialize

        Color[] cColors = new Color[9];
        Pen sPen = new Pen(Color.Red);
        SolidBrush cBrush = new SolidBrush(Color.Red);
        Rectangle cRect = new Rectangle(0, 0, 30, 30);
        int CellsX = 300;
        int CellsY = 150;

        byte tSel = 0; //0 = no selection, 1 = line, 2 = rectangle
        double tSelX = 0; //Selection positions
        double tSelY = 0;
        double tSelX2 = 0;
        double tSelY2 = 0;

        byte Rule = 0; //0 = Conway, 1 = Day & Night
        int cFPS = 0;

        byte[,] Cells = new byte[300, 150];
        byte[,] Cells2 = new byte[300, 150];

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
            CreateGradient(Color.Red, Color.Blue);
            cRule.Items.Add("Conway");
            cRule.Items.Add("Day & Night");

            cRule.Text = "Conway";

            try
            {
                string[] files = Directory.GetFiles(@"Presets\");
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

            CellsXsize = (double)pView.Width / CellsX;
            CellsYsize = (double)pView.Height / CellsY;

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
            if (tSel == 1) //Line selection is active, display line
            {
                e.Graphics.DrawLine(sPen, Convert.ToInt32(tSelX * CellsXsize), Convert.ToInt32(tSelY * CellsYsize), Convert.ToInt32(tSelX2 * CellsXsize), Convert.ToInt32(tSelY2 * CellsYsize));
            }
            if (tSel == 2) //Rectangle selection is active, display rectangle
            {
                e.Graphics.DrawRectangle(sPen, Convert.ToInt32(tSelX * CellsXsize), Convert.ToInt32(tSelY * CellsYsize), Convert.ToInt32((tSelX2 - tSelX) * CellsXsize), Convert.ToInt32((tSelY2 - tSelY) * CellsYsize));
            }
        }

        private void pView_Click(object sender, EventArgs e)
        {

        }

        private void pView_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (rPen.Checked == true) //Pen tool
                {
                    double selX = Math.Round((double)(e.X - CellsXsize / 2) / CellsXsize);
                    double selY = Math.Round((double)(e.Y - CellsYsize / 2) / CellsYsize);

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

                if (rLine.Checked == true) //Line tool
                {
                    tSel = 1;
                    tSelX = Math.Round((double)(e.X - CellsXsize / 2) / CellsXsize);
                    tSelY = Math.Round((double)(e.Y - CellsYsize / 2) / CellsYsize);
                    tSelX2 = tSelX + 1;
                    tSelY2 = tSelY + 1;
                }

                if (rRect.Checked == true) //Rectangle tool
                {
                    tSel = 2;
                    tSelX = Math.Round((double)(e.X - CellsXsize / 2) / CellsXsize);
                    tSelY = Math.Round((double)(e.Y - CellsYsize / 2) / CellsYsize);
                    tSelX2 = tSelX + 1;
                    tSelY2 = tSelY + 1;
                }
            }
            catch
            {

            }
        }

        private void pView_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (tSel == 1) //Line tool was selected, create the line
                {
                    tSel = 0;
                    if (e.Button == MouseButtons.Left) //Add cells
                        DrawLine(Convert.ToInt32(tSelX), Convert.ToInt32(tSelY), Convert.ToInt32(tSelX2), Convert.ToInt32(tSelY2), 0);
                    if (e.Button == MouseButtons.Right) //Remove cells
                        DrawLine(Convert.ToInt32(tSelX), Convert.ToInt32(tSelY), Convert.ToInt32(tSelX2), Convert.ToInt32(tSelY2), 1);
                    pView.Refresh();
                }

                if (tSel == 2) //Rectangle tool was selected, create the rectangle
                {
                    tSel = 0;
                    if (tSelX2 > tSelX && tSelY2 > tSelY && tSelY2 > 0)
                    {
                        if (e.Button == MouseButtons.Left) //Add cells
                        {
                            DrawLine(Convert.ToInt32(tSelX), Convert.ToInt32(tSelY), Convert.ToInt32(tSelX2), Convert.ToInt32(tSelY), 0); //Upper line
                            DrawLine(Convert.ToInt32(tSelX), Convert.ToInt32(tSelY2), Convert.ToInt32(tSelX2), Convert.ToInt32(tSelY2), 0); //Bottom line
                            DrawLine(Convert.ToInt32(tSelX), Convert.ToInt32(tSelY), Convert.ToInt32(tSelX), Convert.ToInt32(tSelY2), 0); //Left line
                            DrawLine(Convert.ToInt32(tSelX2), Convert.ToInt32(tSelY), Convert.ToInt32(tSelX2), Convert.ToInt32(tSelY2), 0); //Right line
                        }
                        if (e.Button == MouseButtons.Right) //Remove cells
                        {
                            DrawLine(Convert.ToInt32(tSelX), Convert.ToInt32(tSelY), Convert.ToInt32(tSelX2), Convert.ToInt32(tSelY), 1); //Upper line
                            DrawLine(Convert.ToInt32(tSelX), Convert.ToInt32(tSelY2), Convert.ToInt32(tSelX2), Convert.ToInt32(tSelY2), 1); //Bottom line
                            DrawLine(Convert.ToInt32(tSelX), Convert.ToInt32(tSelY), Convert.ToInt32(tSelX), Convert.ToInt32(tSelY2), 1); //Left line
                            DrawLine(Convert.ToInt32(tSelX2), Convert.ToInt32(tSelY), Convert.ToInt32(tSelX2), Convert.ToInt32(tSelY2), 1); //Right line
                        }

                        pView.Refresh();
                    }
                }
            }
            catch
            {

            }
        }

        private void pView_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (rPen.Checked == true) //Pen tool
                {
                    double selX = Math.Round((double)(e.X - CellsXsize / 2) / CellsXsize);
                    double selY = Math.Round((double)(e.Y - CellsYsize / 2) / CellsYsize);

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

                if (tSel == 1 || tSel == 2) //Line tool or rectangle tool is selected
                {
                    tSelX2 = Math.Round((double)(e.X - CellsXsize / 2) / CellsXsize);
                    tSelY2 = Math.Round((double)(e.Y - CellsYsize / 2) / CellsYsize);
                    pView.Refresh();
                }
            }
            catch
            {

            }
        }

        public void DrawLine(int x, int y, int x2, int y2, byte button) //Draw a line using Bresenham's line-algorithm 
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                if (button == 0)
                    Cells[x, y] = 1;
                if (button == 1)
                    Cells[x, y] = 0;
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
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

                if (!File.Exists(@path))
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
                        int yPos = 0;
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            for (int i = 0; i < s.Length; i++)
                            {
                                if (s.Substring(i, 1) == "2")
                                {
                                    Cells[i, yPos] = 0;
                                }
                                else
                                {
                                    Cells[i, yPos] = 1;
                                }
                            }
                            yPos++;
                        }
                    }
                }
                CenterCells();
                pView.Refresh();
            }
            catch
            {

            }
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameBox.Text = comboBox1.Text.Trim();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            HelperClass help = new HelperClass();
            string Name = nameBox.Text.ToString();
            if (Name != null)
            {


                try
                {
                    help.MakeSaveData(Cells, Name);

                }
                catch (Exception)
                {

                    throw;
                }

                Populate(Name);
            }
            else
            {
                MessageBox.Show("Error no Name");
            }



        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            GameData ga = new GameData();
            HelperClass helper = new HelperClass(); ;
            try
            {
                var loaddata = comboBox1.SelectedItem as GameData;
                //   byte [,]  Cells = helper.MakeLoadData(loaddata);
                ClearCells();
                Cells = helper.MakeLoadData(loaddata);
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

        private void delButton_Click(object sender, EventArgs e)
        {
            var deldata = comboBox1.SelectedItem as GameData;
            if (deldata != null)
            {


                GameData ga = new GameData();
                try
                {
                    ga.DeleteSave(deldata);
                }

                catch (Exception)
                {
                    throw;
                }
            }
            Populate();
        }

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
                Populate(Name);
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
                comboBox1.DisplayMember = "GameName".Trim();
                comboBox1.DataSource = ds;
                this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        void Populate(string Name)
        {
            if (Name != "")
            {


                comboBox1.ResetText();
                GameData ga = new GameData();

                using (Connection conn = new Connection())
                {


                    var ds = conn.GameData.ToList();
                    comboBox1.DataSource = ds;
                    comboBox1.SelectedText = Name;
                    this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
            else { Populate(); }
        }

        public void MainLoop()
        {
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

                    if (Rule == 0)//Conway
                    {
                        if (Cells[x, y] != 0) //Current cell is alive
                        {
                            if (cCount == 2 || cCount == 3) //Live on to next generation
                                Cells2[x, y] = Convert.ToByte(cCount + 1);
                            else
                                Cells2[x, y] = 0; //Undercrowded/Overpopulatoin.. KILL Cell!
                        }
                        if (Cells[x, y] == 0) //Current cell is dead
                        {
                            if (cCount == 3) //A new cell is born!
                                Cells2[x, y] = Convert.ToByte(cCount + 1);
                        }
                    }

                    if (Rule == 1)//Day & Night
                    {
                        if (Cells[x, y] != 0) //Current cell is alive
                        {
                            if (cCount == 3 || cCount == 4 || cCount == 6 || cCount == 7 || cCount == 8) //Live on to next generation
                                Cells2[x, y] = Convert.ToByte(cCount + 1);
                            else
                                Cells2[x, y] = 0;
                        }
                        if (Cells[x, y] == 0)
                        {
                            if (cCount == 3 || cCount == 6 || cCount == 7 || cCount == 8)
                                Cells2[x, y] = Convert.ToByte(cCount + 1);
                        }
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

        public void CreateGradient(Color col1, Color col2)
        {
            int size = 9;
            int rMax = col2.R;
            int rMin = col1.R;
            int gMax = col2.G;
            int gMin = col1.G;
            int bMax = col2.B;
            int bMin = col1.B;

            for (int i = 0; i < size; i++)
            {
                var rAverage = rMin + (int)((rMax - rMin) * i / size);
                var gAverage = gMin + (int)((gMax - gMin) * i / size);
                var bAverage = bMin + (int)((bMax - bMin) * i / size);
                cColors[i] = (Color.FromArgb(rAverage, gAverage, bAverage));
            }
        }

        public void CenterCells()
        {
            int xMin = CellsX;
            int yMin = CellsY;
            int xMax = 0;
            int yMax = 0;

            for (int y = 0; y < CellsY; y++) //Loop trough all cells to find min/max x/y values
            {
                for (int x = 0; x < CellsX; x++)
                {
                    if (Cells[x, y] != 0) //Alive cell found
                    {
                        if (x > xMax)
                            xMax = x;
                        if (y > yMax)
                            yMax = y;
                        if (x < xMin)
                            xMin = x;
                        if (y < yMin)
                            yMin = y;
                    }
                }
            }
            int xDiff = (CellsX / 2) - xMin - ((xMax - xMin) / 2); //Calculate how many pixels to shift
            int yDiff = (CellsY / 2) - yMin - ((yMax - yMin) / 2);

            if (xDiff > 0) //Move Right
                ShiftCells(xDiff, 0);
            if (xDiff < 0) //Move Left
                ShiftCells(Math.Abs(xDiff), 1);
            if (yDiff < 0) //Move Up
                ShiftCells(Math.Abs(yDiff), 2);
            if (yDiff > 0) //Move Down
                ShiftCells(yDiff, 3);
        }

        public void ShiftCells(int steps, byte direction)
        {
            for (int y = 0; y < CellsY; y++)
            {
                for (int x = 0; x < CellsX; x++)
                {
                    if (direction == 0) //Right
                        Cells2[x, y] = Cells[mod(x - steps, CellsX), mod(y, CellsY)];
                    if (direction == 1) //Left
                        Cells2[x, y] = Cells[mod(x + steps, CellsX), mod(y, CellsY)];
                    if (direction == 2) //Up
                        Cells2[x, y] = Cells[mod(x, CellsX), mod(y + steps, CellsY)];
                    if (direction == 3) //Down
                        Cells2[x, y] = Cells[mod(x, CellsX), mod(y - steps, CellsY)];
                }
            }
            CopyCellsFromBuffer();
            pView.Refresh();
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

            if (Form.ModifierKeys == Keys.None && keyData == Keys.Right) //Shift right
            {
                ShiftCells(1, 0);
                return true;
            }
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Left) //Shift left
            {
                ShiftCells(1, 1);
                return true;
            }
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Up) //Shift up
            {
                ShiftCells(1, 2);
                return true;
            }
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Down) //Shift down
            {
                ShiftCells(1, 3);
                return true;
            }

            if (Form.ModifierKeys == Keys.None && keyData == Keys.Delete)
            {
                ClearCells();
                pView.Refresh();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void FPS_Tick(object sender, EventArgs e)
        {
            lFps.Text = "FPS: " + cFPS.ToString();
            cFPS = 0;
        }

        private void cRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cRule.Text == "Conway")
                Rule = 0;
            if (cRule.Text == "Day & Night")
                Rule = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CenterCells();
            pView.Refresh();
        }
    }
    #endregion
}
