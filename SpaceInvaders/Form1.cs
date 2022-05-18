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
        List<Enemy> listas = new List<Enemy>();

        Nave navinha = new Nave(0, 0, 0, 0, 100, 100);
        EnemyCollection coll = null;

        public Form1()
        {
            InitializeComponent();

            //WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;

            pbNave.Dock = DockStyle.Fill;

            Controls.Add(pbNave);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.coll = EnemyCollection.LoadClassic(this.Width, this.Height, 9, 4);

            int sizeHor = this.Width / 12;
            int sizeVert = this.Height / 7;

            navinha.setSizeX(sizeHor / 2);
            navinha.setSizeY(sizeVert / 2);

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
                coll.Colisao(pbNave);

                navinha.Draw(pbNave, g);
                coll.Draw(pbNave, g);

                if(x == 0)
                {
                    coll.Right();
                    coll.Move();
                }

                pbNave.Refresh();

            };
            tm.Start();

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
        }
    }
}
