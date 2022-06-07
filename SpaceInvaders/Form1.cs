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
        int x = 0;
        Timer tm = new Timer();
        Timer tmShot = new Timer();
        List<Enemy> listas = new List<Enemy>();

        Nave navinha = new Nave(0, 0, 0, 0, 100, 100);
        EnemyCollection coll = null;

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
            

            int sizeHor = this.Width / 12;
            int sizeVert = this.Height / 7;

            navinha.setSizeX(sizeHor / 2);
            navinha.setSizeY(sizeVert / 2);

            pbNave.Image = new Bitmap(pbNave.Width, pbNave.Height);

            Bitmap bmp = pbNave.Image as Bitmap;
            Graphics g = Graphics.FromImage(bmp);

            coll = GameManager.Current.LoadClassic(this.Width, this.Height, 9, 4);

            navinha.PosX = (this.Width / 2) - 50;
            navinha.PosY = this.Height - 100; 

            tm.Interval = 15;
            tmShot.Interval = 1200;

            tm.Tick += delegate
            {
                GameManager.Current.Frames(pbNave, g, this.Width, this.Height, navinha, coll);
            };

            tmShot.Tick += delegate
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                int pos = rand.Next(1, 35);

                GameManager.Current.EnemyShot(coll, pos);
            };

            tm.Start();
            tmShot.Start();
        }

        private void ReadKey(object sender, KeyEventArgs e)
        {
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
            if (e.KeyCode == Keys.Space)
            {
                GameManager.Current.Shooting(navinha);
            }

        }

        private void ReadDalisa(object sender, KeyPressEventArgs e)
        {

        }

        private void ReadKey2(object sender, KeyEventArgs e)
        {
            
        }
    }
}
