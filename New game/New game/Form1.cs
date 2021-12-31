using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_game
{
    public partial class Form1 : Form
    {
        #region "Menu bg"
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(800, 600);
            Image Menu = Properties.Resources.Mainmenu;
            BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Menu;
        }

        #endregion

        #region "Strona startowa"
        public void Form1_Load(object sender, EventArgs e)
        {
            Button Zaczynajmy = new Button();
            Zaczynajmy.Click += new EventHandler(Zaczynajmy_Click);
            Zaczynajmy.Text = "Zaczynajmy";
            Zaczynajmy.ForeColor = Color.Maroon;
            Zaczynajmy.Font = new Font("Algerian", 22);
            Zaczynajmy.Dock = DockStyle.Bottom;
            Zaczynajmy.Size = new Size(800, 50);
            Zaczynajmy.Visible = true;
            Zaczynajmy.Enabled = true;
            Zaczynajmy.BackColor = Color.Transparent;
            Zaczynajmy.BringToFront();
            this.Controls.Add(Zaczynajmy);
        }
        #endregion

        #region "Pierwsze spotkanie moba"
        public void Zaczynajmy_Click(object sender, EventArgs e)
        {
            Image Dungeon = Properties.Resources.Dungeon;
            BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Dungeon;
            ActiveControl.Visible = false;

            PictureBox Narrator = new PictureBox();
            Narrator.Image = Properties.Resources.Narrator;
            Narrator.Size = new Size(210, 330);
            Narrator.Location = new Point(590, 270);
            Narrator.BackColor = Color.Transparent;
            Narrator.Visible = false;
            Narrator.BringToFront();

            PictureBox Mob = new PictureBox();
            Mob.Image = Properties.Resources.Mob;
            Mob.Size = new Size(200, 400);
            Mob.BackColor = Color.Transparent;
            Mob.SizeMode = PictureBoxSizeMode.StretchImage;
            Mob.Visible = false;
            Mob.Dock = DockStyle.Fill;
            Mob.BringToFront();

            Mob.Visible = true;
            Narrator.Visible = true;

            SoundPlayer narracjawalki = new SoundPlayer();
            narracjawalki.SoundLocation = @"E:\visuakl\New game\New game\Resources\alligator3.wav";
            narracjawalki.Play();
            Task.Run(() => narracjawalki.LoadAsync());

            this.Controls.Add(Narrator);
            this.Controls.Add(Mob);

            Button Walcz = new Button();
            Walcz.Click += new EventHandler(Walcz_Click);
            Walcz.Click += Walcz_Click;
            Walcz.Text = "Walcz";
            Walcz.ForeColor = Color.Maroon;
            Walcz.Font = new Font("Algerian", 22);
            Walcz.Location = new Point(50, 100);
            Walcz.Anchor = AnchorStyles.Left;
            Walcz.Size = new Size(150, 50);
            Walcz.Visible = true;
            Walcz.Enabled = true;
            Walcz.BackColor = Color.Transparent;
            this.Controls.Add(Walcz);
            Walcz.BringToFront();

            Button Uciekaj = new Button();
            Uciekaj.Click += new EventHandler(Uciekaj_Click);
            Uciekaj.Click += Uciekaj_Click;
            Uciekaj.Text = "Uciekaj";
            Uciekaj.ForeColor = Color.Maroon;
            Uciekaj.Font = new Font("Algerian", 22);
            Uciekaj.Location = new Point(50, 250);
            Uciekaj.Anchor = AnchorStyles.Left;
            Uciekaj.Size = new Size(150, 50);
            Uciekaj.Visible = true;
            Uciekaj.Enabled = true;
            Uciekaj.BackColor = Color.Transparent;
            this.Controls.Add(Uciekaj);
            Uciekaj.BringToFront();

            Narrator.CancelAsync();
            Mob.CancelAsync();
        }
        #endregion

        #region "Walcz button"
        public void Walcz_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                    this.Controls.Remove(control);
                }
            }

            PictureBox Mob = new PictureBox();
            Mob.Image = Properties.Resources.Mob;
            Mob.Size = new Size(200, 400);
            Mob.BackColor = Color.Transparent;
            Mob.SizeMode = PictureBoxSizeMode.StretchImage;
            Mob.Visible = true;
            Mob.Dock = DockStyle.Fill;
            this.Controls.Add(Mob);
            Mob.BringToFront();

            Button HIT = new Button();
            HIT.Text = "Atak";
            HIT.ForeColor = Color.Maroon;
            HIT.Font = new Font("Algerian", 22);
            HIT.Location = new Point(50, 100);
            HIT.Anchor = AnchorStyles.Left;
            HIT.Size = new Size(150, 50);
            HIT.Visible = true;
            HIT.Enabled = true;
            HIT.BackColor = Color.Transparent;
            this.Controls.Add(HIT);
            HIT.BringToFront();

            Button DEF = new Button();
            DEF.Text = "Obrona";
            DEF.ForeColor = Color.Maroon;
            DEF.Font = new Font("Algerian", 22);
            DEF.Location = new Point(50, 250);
            DEF.Anchor = AnchorStyles.Left;
            DEF.Size = new Size(150, 50);
            DEF.Visible = true;
            DEF.Enabled = true;
            DEF.BackColor = Color.Transparent;
            this.Controls.Add(DEF);
            DEF.BringToFront();

            TextBox Info = new TextBox();
            Info.Text = "Przegrana";
            Info.ForeColor = Color.Maroon;
            Info.Font = new Font("Algerian", 36);
            Info.Enabled = true;
            Info.Anchor = AnchorStyles.Top;
            Info.Visible = false;
            Info.Size = new Size(800, 150);
            this.Controls.Add(Info);
            Info.BringToFront();

            int hp_mob = 100;
            int AT_mob = 10;
            int HIT1 = 25;
            //int DEF1 = 5;
            int HP = 100;
            int HP1 = 0;
            int walka = 0;

            //if (HIT.Enabled)
            //{
            //    walka = hp_mob - HIT1;

            //    while (walka < 0)
            //        Info.Visible = true;
            //}
                
            //else if (DEF.Enabled && AT_mob > DEF1)
                //{
              //  HP1 = HP - (DEF1 - AT_mob);
               // }     
        }
        #endregion

        #region "Ucieczka 1st"
        public void Uciekaj_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Controls.Clear();
            Image Death = Properties.Resources.Śmierć;
            BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Death;

            Button Reset = new Button();
            Reset.Click += new EventHandler(Reset_Click);
            Reset.Text = "Spróbuj jeszcze raz";
            Reset.ForeColor = Color.Maroon;
            Reset.Font = new Font("Algerian", 22);
            Reset.Anchor = AnchorStyles.Bottom;
            Reset.Size = new Size(800, 50);
            Reset.Visible = true;
            Reset.Enabled = true;
            Reset.BackColor = Color.Transparent;
            this.Controls.Add(Reset);
            Reset.BringToFront();
        }
        public void Reset_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }
        #endregion
    }
}
