using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.TurtuleChallenge.Models
{
    public class Position
    {
        public Position(int x, int y)
        {
            this.PositionX = x;
            this.PositionY = y;
        }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}
