using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Obstacles
    {
        //The atributes for the Obstacles
        public int x, y;
        public int width = 30;
        public int height = 30;
        public Rectangle obstacle;
        public Obstacles(int _x, int _y) 
        {
            x = _x;
            y = _y;

            obstacle = new Rectangle(x,y,width,height);
        }
    }
}
