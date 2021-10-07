using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace _2DGame
{
    public partial class MainScreen : UserControl
    {
        new SoundPlayer click = new SoundPlayer(Properties.Resources.Click);
        public MainScreen()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            click.Play();
           
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameScreen gs = new GameScreen();
            f.Controls.Add(gs);
            gs.Location = new Point((f.Width - gs.Width) / 2, (f.Height - gs.Height) / 2);
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            click.Play();

            System.Windows.Forms.Application.Exit();
        }
    }
}
