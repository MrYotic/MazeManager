using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeManager
{
    public partial class Form1 : Form
    {
        #region Misc
        public void Controls_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                ((Control)sender).Capture = false;
                var m = Message.Create(Handle, 0xa1, new IntPtr(0x2), IntPtr.Zero);
                WndProc(ref m);
            }
        }
        #endregion
        public Form1()
        {
            InitializeComponent();
            MouseDown += Controls_MouseDown;
        }
        private void button1_Click(object sender, EventArgs e) => Process.GetCurrentProcess().Kill();
        private Round Maze = new Round();
        //private Recursive_backtracker Maze = new Recursive_backtracker();
        //private RoundReverse Maze = new RoundReverse();
        private void button2_Click(object sender, EventArgs e)
        {
            Maze.Gen(panel1);
            label3.Text = "Count: " + Maze.Maze.Cast<Pixel>().Where(z => z == Pixel.Space).Count();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int num = -256;
            int.TryParse(textBox1.Text, out num);
            if (num != -256)
                Maze.Info.Strange = num;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Maze.unique = checkBox1.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int num = -256;
            int.TryParse(textBox2.Text, out num);
            if (num != -256)
                Maze.Info.Size = new Size(num, num);
        }
    }
}
