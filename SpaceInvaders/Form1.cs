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
        new List<Inimigo> listas = new List<Inimigo>();

        Nave navinha = new Nave(0, 0, 0, 0, 100, 100);
        Inimigo inimiguinho = new Inimigo(0, 0, 0, 0, 150, 150, new Image[]{ Properties.Resources.inimigo_1 });
        Inimigo inimiguinho2 = new Inimigo(80, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_1 });
        Inimigo inimiguinho3 = new Inimigo(160, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_1 });
        Inimigo inimiguinho4 = new Inimigo(240, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_1 });
        Inimigo inimiguinho5 = new Inimigo(320, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_1 });
        Inimigo inimiguinho6 = new Inimigo(400, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_1 });
        Inimigo inimiguinho7 = new Inimigo(480, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_1 });
        Inimigo inimiguinho8 = new Inimigo(560, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_1 });
        Inimigo inimiguinho9 = new Inimigo(640, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_1 });
        Inimigo inimiguinho10 = new Inimigo(0, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_2 });
        Inimigo inimiguinho11 = new Inimigo(80, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_2 });
        Inimigo inimiguinho12 = new Inimigo(160, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_2 });
        Inimigo inimiguinho13 = new Inimigo(240, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_2 });
        Inimigo inimiguinho14 = new Inimigo(320, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_2 });
        Inimigo inimiguinho15 = new Inimigo(400, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_2 });
        Inimigo inimiguinho16 = new Inimigo(480, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_2 });
        Inimigo inimiguinho17 = new Inimigo(560, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_2 });
        Inimigo inimiguinho18 = new Inimigo(640, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_2 });
        Inimigo inimiguinho19 = new Inimigo(640, 0, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_2 });

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
            Inimigo inimigays = new Inimigo(listas);
            int sizeHor = this.Width / 12;
            int sizeVert = this.Height / 7;

            navinha.setSizeX(sizeHor / 2);
            navinha.setSizeY(sizeVert / 2);
            inimiguinho.setSizeX(sizeHor);
            inimiguinho.setSizeY(sizeVert);
            inimiguinho2.setSizeX(sizeHor);
            inimiguinho2.setSizeY(sizeVert);
            inimiguinho3.setSizeX(sizeHor);
            inimiguinho3.setSizeY(sizeVert);
            inimiguinho4.setSizeX(sizeHor);
            inimiguinho4.setSizeY(sizeVert);
            inimiguinho5.setSizeX(sizeHor);
            inimiguinho5.setSizeY(sizeVert);
            inimiguinho6.setSizeX(sizeHor);
            inimiguinho6.setSizeY(sizeVert);
            inimiguinho7.setSizeX(sizeHor);
            inimiguinho7.setSizeY(sizeVert);
            inimiguinho8.setSizeX(sizeHor);
            inimiguinho8.setSizeY(sizeVert);
            inimiguinho9.setSizeX(sizeHor);
            inimiguinho9.setSizeY(sizeVert);
            inimiguinho10.setSizeX(sizeHor);
            inimiguinho10.setSizeY(sizeVert);
            inimiguinho11.setSizeX(sizeHor);
            inimiguinho11.setSizeY(sizeVert);
            inimiguinho12.setSizeX(sizeHor);
            inimiguinho12.setSizeY(sizeVert);
            inimiguinho13.setSizeX(sizeHor);
            inimiguinho13.setSizeY(sizeVert);
            inimiguinho14.setSizeX(sizeHor);
            inimiguinho14.setSizeY(sizeVert);
            inimiguinho15.setSizeX(sizeHor);
            inimiguinho15.setSizeY(sizeVert);
            inimiguinho16.setSizeX(sizeHor);
            inimiguinho16.setSizeY(sizeVert);
            inimiguinho17.setSizeX(sizeHor);
            inimiguinho17.setSizeY(sizeVert);
            inimiguinho18.setSizeX(sizeHor);
            inimiguinho18.setSizeY(sizeVert);
            inimiguinho19.setSizeX(sizeHor);
            inimiguinho19.setSizeY(sizeVert);

            pbNave.Image = new Bitmap(pbNave.Width, pbNave.Height);

            Bitmap bmp = pbNave.Image as Bitmap;
            Graphics g = Graphics.FromImage(bmp);


            navinha.PosX = (this.Width / 2) - 50;
            navinha.PosY = this.Height - 100;
            inimiguinho.PosX = this.Width - (this.Width - 40);
            inimiguinho.PosY = this.Height - this.Height;
            inimiguinho2.PosX = inimiguinho.PosX + (this.Width /18);
            inimiguinho2.PosY = this.Height - this.Height;
            inimiguinho3.PosX = inimiguinho2.PosX + (this.Width / 18);
            inimiguinho3.PosY = this.Height - this.Height;
            inimiguinho4.PosX = inimiguinho3.PosX + (this.Width / 18);
            inimiguinho4.PosY = this.Height - this.Height;
            inimiguinho5.PosX = inimiguinho4.PosX + (this.Width / 18);
            inimiguinho5.PosY = this.Height - this.Height;
            inimiguinho6.PosX = inimiguinho5.PosX + (this.Width / 18);
            inimiguinho6.PosY = this.Height - this.Height;
            inimiguinho7.PosX = inimiguinho6.PosX + (this.Width / 18);
            inimiguinho7.PosY = this.Height - this.Height;
            inimiguinho8.PosX = inimiguinho7.PosX + (this.Width / 18);
            inimiguinho8.PosY = this.Height - this.Height;
            inimiguinho9.PosX = inimiguinho8.PosX + (this.Width / 18);
            inimiguinho9.PosY = this.Height - this.Height;
            inimiguinho10.PosX = this.Width - (this.Width - 40);
            inimiguinho10.PosY = this.Height - (this.Height - 80);
            inimiguinho11.PosX = inimiguinho.PosX + (this.Width / 18);
            inimiguinho11.PosY = this.Height - (this.Height - 80);
            inimiguinho12.PosX = inimiguinho2.PosX + (this.Width / 18);
            inimiguinho12.PosY = this.Height - (this.Height - 80);
            inimiguinho13.PosX = inimiguinho3.PosX + (this.Width / 18);
            inimiguinho13.PosY = this.Height - (this.Height - 80);
            inimiguinho14.PosX = inimiguinho4.PosX + (this.Width / 18);
            inimiguinho14.PosY = this.Height - (this.Height - 80);
            inimiguinho15.PosX = inimiguinho5.PosX + (this.Width / 18);
            inimiguinho15.PosY = this.Height - (this.Height - 80);
            inimiguinho16.PosX = inimiguinho6.PosX + (this.Width / 18);
            inimiguinho16.PosY = this.Height - (this.Height - 80);
            inimiguinho17.PosX = inimiguinho7.PosX + (this.Width / 18);
            inimiguinho17.PosY = this.Height - (this.Height - 80);
            inimiguinho18.PosX = inimiguinho8.PosX + (this.Width / 18);
            inimiguinho18.PosY = this.Height - (this.Height - 80);
            inimiguinho19.PosX = inimiguinho8.PosX + (this.Width / 18);
            inimiguinho19.PosY = this.Height - (this.Height - 80);

            inimigays.CreateEnemies();


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
                inimiguinho10.Colisao(pbNave);
                inimiguinho11.Colisao(pbNave);
                inimiguinho12.Colisao(pbNave);
                inimiguinho13.Colisao(pbNave);
                inimiguinho14.Colisao(pbNave);
                inimiguinho15.Colisao(pbNave);
                inimiguinho16.Colisao(pbNave);
                inimiguinho17.Colisao(pbNave);
                inimiguinho18.Colisao(pbNave);
                inimiguinho19.Colisao(pbNave);
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
                inimiguinho10.Draw(pbNave, g);
                inimiguinho11.Draw(pbNave, g);
                inimiguinho12.Draw(pbNave, g);
                inimiguinho13.Draw(pbNave, g);
                inimiguinho14.Draw(pbNave, g);
                inimiguinho15.Draw(pbNave, g);
                inimiguinho16.Draw(pbNave, g);
                inimiguinho17.Draw(pbNave, g);
                inimiguinho18.Draw(pbNave, g);
                inimiguinho19.Draw(pbNave, g);
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
