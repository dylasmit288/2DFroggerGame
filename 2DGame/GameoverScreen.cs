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
    public partial class GameoverScreen : UserControl
    {
        new SoundPlayer click = new SoundPlayer(Properties.Resources.Click);
        public GameoverScreen()
        {
            InitializeComponent();
        }

        private void GameoverScreen_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            click.Play();

            Form f = this.FindForm();
            f.Controls.Remove(this);
            MainScreen ms = new MainScreen();
            f.Controls.Add(ms);
            ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            click.Play();
            System.Windows.Forms.Application.Exit();
        }
    }
}
