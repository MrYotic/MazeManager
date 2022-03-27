using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeManager
{
    public class Recursive_backtracker : BaseMaze
    {
        public bool unique;
        public Recursive_backtracker() : base(new Info("Recursive_backtracker", new Size(16, 16), 2)) { }
        Graphics g;
        public override void Gen(Panel panel)
        {
            g = panel.CreateGraphics();
            g.Clear(Color.FromArgb(49, 49, 49));
            Maze = new Pixel[info.Size.Width, info.Size.Height];
            for(int i = 0; i < info.Size.Width; i += 1)
            {
                Set(0, i, Pixel.Wall);
                Set(i, 0, Pixel.Wall);
                Set(info.Size.Width - 1, i, Pixel.Wall);
                Set(i, info.Size.Height - 1, Pixel.Wall);
            }
            void Set(int x, int y, Pixel p)
            {
                //Thread.Sleep(1);
                Maze[x, y] = p;
                Draw(x, y, p);
            }
        }
        public override void Complite()
        {

        }
        private void Draw(int x, int y, Pixel p)
        {
            Size ps = new Size(256 / info.Size.Width, 256 / info.Size.Height);
            g.FillRectangle(new SolidBrush(p == Pixel.Wall ? Color.Black : Color.White), new Rectangle(x * ps.Width, y * ps.Height, ps.Width, ps.Height));
        }
    }
}
