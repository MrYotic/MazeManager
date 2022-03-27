using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeManager
{
    public class Info
    {
        public Info(string name, Size size, int strange)
        {
            Name = name;
            Size = size;
            Strange = strange;
        }
        public Info(Size size, int strange) : this( "TEST-" + (DateTime.Now.Ticks % 99), size, strange) { }
        public string Name { get; set; }
        public Size Size { get; set; }
        public int Strange { get; set; }
    }
    public enum Pixel
    {
        None,
        Space,
        Wall
    }
}
