using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeManager
{
    public static partial class Maze
    {
        public static List<List<Point>> ValidatePath(Pixel[,] maze)
        {
            int size = maze.Length;
            List<List<Point>> result = new List<List<Point>>();

            List<Point> passed = new List<Point>();
            for(int x = 0; x < maze.Length; x += 1)
            {
                for (int y = 0; y < maze.Length; y += 1)
                {
                    if(maze[x, y] == Pixel.Space && !passed.Contains(new Point(x, y)))
                    {
                        List<Point> locPassed = new List<Point>() { new Point(x, y) };
                        //Point startCoord = new Point(x, y);
                        //Point currentCoord = startCoord;
                        CheckBlock(new Point(x, y));
                        if (locPassed.FindAll(z => z.X == 0 || z.X == size - 1 || z.Y == 0 || z.Y == size - 1).Count >= 2)
                            result.Add(locPassed);
                        void CheckBlock(Point coord)
                        {
                            List<Point> near = GetLinerNear(coord);
                            foreach (Point block in near) locPassed.Add(block);
                            foreach (Point block in near) CheckBlock(block);
                        }
                        List<Point> GetLinerNear(Point coord) => new (int, int)[4] { (1, 0), (0, 1), (-1, 0), (0, -1) }.Select(z => (coord.X + z.Item1, coord.Y + z.Item2)).Where(z => z.Item1 > 0 && z.Item1 < size && z.Item2 > 0 && z.Item2 < size).Where(z => maze[z.Item1, z.Item2] == Pixel.Wall).Select(z => new Point(z.Item1, z.Item2)).Where(z => !locPassed.Contains(z) && !passed.Contains(z)).ToList();
                    }
                }
            }
            return result;
        }
    }
}
