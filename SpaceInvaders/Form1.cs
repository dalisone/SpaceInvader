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

        Nave navinha = new Nave(0, 0, 0, 0, 100, 100);
        Inimigo inimiguinho = new Inimigo(0, 0, 0, 0, 150, 150);
        Inimigo inimiguinho2 = new Inimigo(80, 0, 0, 0, 150, 150);
        Inimigo inimiguinho3 = new Inimigo(160, 0, 0, 0, 150, 150);
        Inimigo inimiguinho4 = new Inimigo(240, 0, 0, 0, 150, 150);
        Inimigo inimiguinho5 = new Inimigo(320, 0, 0, 0, 150, 150);
        Inimigo inimiguinho6 = new Inimigo(400, 0, 0, 0, 150, 150);
        Inimigo inimiguinho7 = new Inimigo(480, 0, 0, 0, 150, 150);
        Inimigo inimiguinho8 = new Inimigo(560, 0, 0, 0, 150, 150);
        Inimigo inimiguinho9 = new Inimigo(640, 0, 0, 0, 150, 150);

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

            navinha.setSizeX(this.Width / 18);
            navinha.setSizeY(this.Height / 12);

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
                inimiguinho.Colisao(pbNave);
                inimiguinho2.Colisao(pbNave);
                inimiguinho3.Colisao(pbNave);
                inimiguinho4.Colisao(pbNave);
                inimiguinho5.Colisao(pbNave);
                inimiguinho6.Colisao(pbNave);
                inimiguinho7.Colisao(pbNave);
                inimiguinho8.Colisao(pbNave);
                inimiguinho9.Colisao(pbNave);
                navinha.Draw(pbNave, g);
                inimiguinho.Draw(pbNave, g);
                inimiguinho2.Draw(pbNave, g);
                inimiguinho3.Draw(pbNave, g);
                inimiguinho4.Draw(pbNave, g);
                inimiguinho5.Draw(pbNave, g);
                inimiguinho6.Draw(pbNave, g);
                inimiguinho7.Draw(pbNave, g);
                inimiguinho8.Draw(pbNave, g);
                inimiguinho9.Draw(pbNave, g);
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
