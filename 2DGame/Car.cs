using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2DGame
{
    class Car
    {
        public int x, y, size, speed;
        public SolidBrush brushColour;

        public Car(int _x, int _y, int _size, int _speed, SolidBrush _brushColor)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            brushColour = _brushColor;
        }

        public void Move()
        {
            x += speed;
        }

        public void Move(string direction)
        {

            if (direction == "up")
            {
                y -= speed;
            }
            else if (direction == "down")
            {
                y += speed;

            }
            else if (direction == "left")
            {
                x -= speed;
            }
            else if(direction == "right")
            {
                x += speed;
            }
        }

        public bool Collision(Car c)
        {
            Rectangle frogRec = new Rectangle(x, y, size, size);
            Rectangle carRec = new Rectangle(c.x, c.y, c.size, c.size);

            if (frogRec.IntersectsWith(carRec))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
