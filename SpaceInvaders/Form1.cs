using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class Form1 : Form
    {

        Bitmap bmp = null;
        Graphics g = null;
        Timer tm = new Timer();
        

        int dx = 5;
        Image navinha = Properties.Resources.nave;
        public Form1()
        {
            InitializeComponent();


            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;

            pbNave.Dock = DockStyle.Fill;
            
            Controls.Add(pbNave);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.Left:
                    dx--;
                    break;
                case Keys.Right:
                    dx++;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tm.Interval = 25;
            bmp = new Bitmap(pbNave.Width, pbNave.Height);

            g = Graphics.FromImage(bmp);

            tm.Tick += delegate
            {
                pbNave.Image = navinha;
            };
            tm.Start();
        }
    }
}
