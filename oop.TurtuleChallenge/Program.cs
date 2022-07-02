using OOP.TurtuleChallenge.Helpers;
using OOP.TurtuleChallenge.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop.TurtuleChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string dataPath = Environment.CurrentDirectory + "/Data";
                IniFile iniFile = new IniFile(dataPath + "/Config.ini");
                string motions = File.ReadAllText(dataPath + "/Motions.txt");

                int startPositionX = Int32.Parse(iniFile.IniReadValue("Turtule", "Start").Split(',')[0]);
                int startPositionY = Int32.Parse(iniFile.IniReadValue("Turtule", "Start").Split(',')[1]);
                int startDirection = Int32.Parse(iniFile.IniReadValue("Turtule", "Direction"));

                int exitPositionX = Int32.Parse(iniFile.IniReadValue("Matrix", "Exit").Split(',')[0]);
                int exitPositionY = Int32.Parse(iniFile.IniReadValue("Matrix", "Exit").Split(',')[1]);
                int height = Int32.Parse(iniFile.IniReadValue("Matrix", "Matrix").Split(',')[0]);
                int width = Int32.Parse(iniFile.IniReadValue("Matrix", "Matrix").Split(',')[1]);

                List<Mine> mines = new List<Mine>();
                string[] listM = iniFile.IniReadValue("Matrix", "Mine").Split(' ');
                foreach (var mine in listM)
                {
                    mines.Add(new Mine(Int32.Parse(mine.Split(',')[0]), Int32.Parse(mine.Split(',')[1])));
                }


                foreach (string motion in motions.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    try
                    {
                        Matrix matrix = new Matrix(width, height, new Turtule((DirectionType)startDirection, startPositionX, startPositionY), mines, new Position(exitPositionX, exitPositionY));
                        Console.WriteLine(matrix.Start(motion));
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
        }
    }

