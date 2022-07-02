using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.TurtuleChallenge.Models
{
    public class Turtule: Position
    {
        #region Ctor
        public Turtule(DirectionType direction,int x, int y) :base(x,y)
        {
            Direction = direction;
        }
        #endregion
        public DirectionType Direction { get; set; }
    }
}
