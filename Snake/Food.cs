using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Food
    {
        //The attributes for the food

        public int x, y;
        public int width = 20;
        public int height = 20;
        public Rectangle food;
        public Food(int _x, int _y)
        {
            x = _x;
            y = _y;

            food = new Rectangle(x, y, width, height);
        }
    }
}
