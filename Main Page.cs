using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortItemsToFolders
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
            // Add this line to change the cursor to a hand on hover
            button1.Cursor = Cursors.Hand;
            
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0; 
            
            SetRoundedRegion(button1, 20);
            button1.Resize += (s, e) => SetRoundedRegion(button1, 20);
        }

        private void SetRoundedRegion(Button btn, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            btn.Region = new Region(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Sorter form1 = new Sorter();
            form1.FormClosed += (s, args) => this.Close();

            form1.Show();
            form1.Location = this.Location;
            this.Hide();

        }
    }
}
