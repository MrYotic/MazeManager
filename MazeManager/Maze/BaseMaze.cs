using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeManager
{
    public abstract class BaseMaze
    {
  
        protected BaseMaze(Info info)
        {
            this.info = info;
        }
        public Random Random = new Random();
        protected Info info;
        public Info Info { get => info; set => info = value; }
        public Pixel[,] Maze { get; set; }
        public List<Point> Complited { get; set; }
        public List<Point> ComplitedESP { get; set; }
        public abstract void Gen(Panel panel);
        public abstract void Complite();
        public List<Point> GetOneVoidLinerNear(Point coord) => new (int, int)[4] { (2, 0), (0, 2), (-2, 0), (0, -2) }.Select(z => (coord.X + z.Item1, coord.Y + z.Item2)).Where(z => z.Item1 > 0 && z.Item1 < info.Size.Width && z.Item2 > 0 && z.Item2 < info.Size.Height).Where(z => Maze[z.Item1, z.Item2] == Pixel.Wall).Select(z => new Point(z.Item1, z.Item2)).ToList();
        public List<Point> GetLinerNear(Point coord) => new (int, int)[4] { (1, 0), (0, 1), (-1, 0), (0, -1)}.Select(z => (coord.X + z.Item1, coord.Y + z.Item2)).Where(z => z.Item1 > 0 && z.Item1 < info.Size.Width && z.Item2 > 0 && z.Item2 < info.Size.Height).Where(z => Maze[z.Item1, z.Item2] == Pixel.Wall).Select(z => new Point(z.Item1, z.Item2)).ToList();
        public List<Point> GetNear(Point coord) => new (int, int)[8] { ( 1, 0 ), ( 0, 1 ), ( -1, 0), ( 0, -1), ( 1, 1), (1, -1), (-1, 1), (-1, -1) }.Select(z => (coord.X + z.Item1, coord.Y + z.Item2)).Where(z => z.Item1 > 0 && z.Item1 < info.Size.Width && z.Item2 > 0 && z.Item2 < info.Size.Height).Where(z => Maze[z.Item1, z.Item2] == Pixel.Wall).Select(z => new Point(z.Item1, z.Item2)).ToList();
        public int GetOneVoidLinerNearCount(Point coord) => GetOneVoidLinerNear(coord).Count;
        public int GetLinerNearCount(Point coord) => GetLinerNear(coord).Count;
        public int GetNearCount(Point coord) => GetNear(coord).Count;
    }
}
