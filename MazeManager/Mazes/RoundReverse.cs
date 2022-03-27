using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeManager
{
    public class RoundReverse : BaseMaze
    {
        public bool unique;
        public RoundReverse() : base(new Info("RoundReverse", new Size(16, 16), 2)) { }
        public override void Gen(Panel panel)
        {
            g = panel.CreateGraphics();
            g.Clear(Color.FromArgb(49, 49, 49));
            Maze = new Pixel[Info.Size.Width, Info.Size.Height];
            List<Point> blocks = new List<Point>();
            for (int w = 0; w < Info.Size.Width; w += 1)
            {
                for (int h = 0; h < Info.Size.Height; h += 1)
                {
                    Point coord = GetBlock();
                    int count = GetOneVoidLinerNearCount(new Point(coord.X, coord.Y));
                    if (count == info.Strange)
                    {
                        Set(coord.X, coord.Y, Pixel.Space);
                    }
                    else Set(coord.X, coord.Y, Pixel.Wall);
                }
            }
            if (!unique)
                for (int w = 0; w < Info.Size.Width; w += 1)
                    for (int h = 0; h < Info.Size.Height; h += 1)
                        if (Maze[w, h] == Pixel.None)
                            Set(w, h, Pixel.Space);
            Point GetBlock()
            {
                while (true)
                {
                    Point coord = new Point(Random.Next(0, Info.Size.Width), Random.Next(0, Info.Size.Height));
                    if (unique)
                    {
                        if (!blocks.Contains(new Point(coord.X, coord.Y)))
                        {
                            blocks.Add(new Point(coord.X, coord.Y));
                            return new Point(coord.X, coord.Y);
                        }
                    }
                    else
                        return new Point(coord.X, coord.Y);
                }
            }
            void Set(int x, int y, Pixel p)
            {
                //Thread.Sleep(1);
                Maze[x, y] = p;
                Draw(x, y, p);
            }
        }
        Graphics g;
        void Draw(int x, int y, Pixel p)
        {
            Size ps = new Size(256 / info.Size.Width, 256 / info.Size.Height);
            g.FillRectangle(new SolidBrush(p == Pixel.Wall ? Color.Black : Color.White), new Rectangle(x * ps.Width, y * ps.Height, ps.Width, ps.Height));
        }
        public override void Complite()
        {

        }
    }
}
