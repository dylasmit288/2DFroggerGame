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
    public partial class GameScreen : UserControl
    {
        Boolean upArrowDown, downArrowDown, leftArrowDown, rightArrowDown, escKeyDown;

        new SoundPlayer crash = new SoundPlayer(Properties.Resources.Crash);
        new SoundPlayer Win = new SoundPlayer(Properties.Resources.Win);


        List<Car> cars = new List<Car>();

        int yStart = 230;
        int roadGap = -60;

        int newCarCounter = 0;

        SolidBrush carBrush = new SolidBrush(Color.Red);

        Random randGen = new Random();

        Car frog;

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }
    
        public void OnStart()
        {
            cars.Clear();
            newCarCounter = 0;
            yStart = 230;
            roadGap = -60;

            CreateCar(yStart, yStart + roadGap, yStart + roadGap + roadGap, yStart + roadGap + roadGap + roadGap);
            
            frog = new Car(this.Width / 2 - 15, this.Height - 35, 20, 12, new SolidBrush(Color.LawnGreen));

        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Escape:
                    escKeyDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Escape:
                    escKeyDown = false;
                    break;
            }
        }

        public void CreateCar(int y1, int y2, int y3, int y4)
        {
            SolidBrush carBrush = new SolidBrush(Color.White);
            int colourValue = randGen.Next(1, 4);

            if (colourValue == 1)
            {
                carBrush = new SolidBrush(Color.Red);
            }
            else if (colourValue == 2)
            {
                carBrush = new SolidBrush(Color.Purple);
            }
            else
            {
                carBrush = new SolidBrush(Color.Blue);
            }

            
            Car c1 = new Car(10, y1, 30, 10, carBrush);
            cars.Add(c1);

            Car c2 = new Car(10, y2, 30, 17, carBrush);
            cars.Add(c2);

            Car c3 = new Car(10, y3, 30, 10, carBrush);
            cars.Add(c3);

            Car c4 = new Car(10, y4, 30, 13, carBrush);
            cars.Add(c4);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            newCarCounter++;

            if (upArrowDown)
            {
                frog.Move("up");
            }
            else if (downArrowDown)
            {
                frog.Move("down");
            }
            else if (leftArrowDown)
            {
                frog.Move("left");
            }
            else if (rightArrowDown)
            {
                frog.Move("right");
            }

            if (escKeyDown)
            {
                Application.Exit();
            }

            foreach (Car c in cars)
            {
                c.Move();
            }
            
            if (cars[0].x > this.Width)
            {
                cars.RemoveAt(0);
            }

            if (frog.y < 0)
            {
                Win.Play();
                Form f = this.FindForm();
                f.Controls.Remove(this);
                WinScreen ws = new WinScreen();
                f.Controls.Add(ws);
                ws.Location = new Point((f.Width - ws.Width) / 2, (f.Height - ws.Height) / 2);

                gameTimer.Enabled = false;

            }

            if (newCarCounter == 13)
            {
                CreateCar(yStart, yStart + roadGap, yStart + roadGap + roadGap, yStart + roadGap + roadGap + roadGap);

                newCarCounter = 0;
            }

            foreach (Car c in cars)
            {
                if (frog.Collision(c))
                {
                    crash.Play();
                    Form f = this.FindForm();
                    f.Controls.Remove(this);
                    GameoverScreen gos = new GameoverScreen();
                    f.Controls.Add(gos);
                    gos.Location = new Point((f.Width - gos.Width) / 2, (f.Height - gos.Height) / 2);

                    gameTimer.Enabled = false;
                }
            }
            Refresh();
        }

        private void GameScreen_Paint_1(object sender, PaintEventArgs e)
        {
            foreach (Car c in cars)
            {
                e.Graphics.FillRectangle(carBrush, c.x, c.y, c.size, c.size);
            }

            e.Graphics.FillRectangle(frog.brushColour, frog.x, frog.y, frog.size, frog.size);

        }
    }
}
