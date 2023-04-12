using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class snake
    {
        public int x, y;
        public static int speed = 6;
        public int width = 30;
        public int height = 30;
        public Rectangle Player;

        public snake(int _x, int _y)
        {
            x = _x;
            y = _y;
            Player = new Rectangle(x, y, width, height);

        }
        public void Move(string direction)
        {
            if (direction == "up")
            {
                y -= speed;

            }
            if (direction == "down")
            {
                y += speed;
            }
            if (direction == "right")
            {
                x += speed;
            }
            if (direction == "left")
            {
                x -= speed;
            }
        }
    }
}
