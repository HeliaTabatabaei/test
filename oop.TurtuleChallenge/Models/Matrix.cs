using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.TurtuleChallenge.Models
{
    public class Matrix
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Turtule Turtule { get; set; }
        public List<Mine> Mines { get; set; }
        public Position Exit { get; set; }

        public Matrix(int width, int height, Turtule turtule, List<Mine> mines, Position exit)
        {
            this.Turtule = turtule;
            this.Mines = mines;
            this.Exit = exit;
            this.Width = width;
            this.Height = height;
        }

        public StatusType Start(string motions)
        {
            if (CheckTurtleIsOnMine())
                return StatusType.Dead;
            foreach (char m in motions)
            {
                if (Char.ToLower(m) == 'm')
                {
                    switch (Turtule.Direction)
                    {
                        case DirectionType.Up:
                            if (Turtule.PositionX > 0)
                                Turtule.PositionX--;
                            else
                                throw new Exception("out of range");
                            break;
                        case DirectionType.Right:
                            if (Turtule.PositionY < Width - 1)
                                Turtule.PositionY++;
                            else
                                throw new Exception("out of range");
                            break;
                        case DirectionType.Down:
                            if (Turtule.PositionX < Height - 1)
                                Turtule.PositionX++;
                            else
                                throw new Exception("out of range");
                            break;
                        case DirectionType.Left:
                            if (Turtule.PositionY > 0)
                                Turtule.PositionY--;
                            else
                                throw new Exception("out of range");
                            break;
                        default:
                            break;
                    }
                    if (CheckTurtleIsOnMine())
                        return StatusType.Dead;
                }
                else if (Char.ToLower(m) == 'r')
                {
                    if (Turtule.Direction == (DirectionType)3)
                        Turtule.Direction = DirectionType.Up;
                    else
                        Turtule.Direction = (DirectionType)((int)Turtule.Direction + 1);
                    //Turtule.Direction != (DirectionType)3 ? (int)Turtule.Direction++ : Turtule.Direction = DirectionType.Up;
                }
                else
                    throw new Exception("motion not valid");
            }
            if (Turtule.PositionX == Exit.PositionX && Turtule.PositionY == Exit.PositionY)
                return StatusType.Survived;
            return StatusType.InDanger;
        }

        public bool CheckTurtleIsOnMine()
        {
            return Mines.Any(m => Turtule.PositionX == m.PositionX && Turtule.PositionY == m.PositionY);
        }
    }
}
