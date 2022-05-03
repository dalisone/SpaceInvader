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

        Timer tm = new Timer();

        Nave navinha = new Nave(0, 0, 0, 0, 100,100);
        public Form1()
        {
            InitializeComponent();


            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;

            pbNave.Dock = DockStyle.Fill;
            
            Controls.Add(pbNave);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            pbNave.Image = new Bitmap(pbNave.Width, pbNave.Height);

            Bitmap bmp = pbNave.Image as Bitmap;
            Graphics g = Graphics.FromImage(bmp);


            navinha.PosX = (this.Width / 2) - 50;
            navinha.PosY = this.Height - 100;

            tm.Interval = 15;

            tm.Tick += delegate
            {
                g.Clear(Color.Black);
                navinha.Colisao(pbNave);
                navinha.Draw(pbNave, g);
                pbNave.Refresh();
            };
            tm.Start();

        }

        private void ReadKey(object sender, KeyEventArgs e)
        {
            var KeyPress = e.KeyCode;
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
                return;
            }
            if (e.KeyCode == Keys.Right)
            {
                navinha.Right();
                navinha.Move();
                return;
            }
            if (e.KeyCode == Keys.Left)
            {
                navinha.Left();
                navinha.Move();
                return;
            }
        }
    }
}
