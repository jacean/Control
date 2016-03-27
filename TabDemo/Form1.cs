using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlEX;

namespace TabDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabControlEX te = new TabControlEX();
            this.Controls.Add(te);
        }

        private void closeTab_Click(object sender, EventArgs e)
        {

        }
    }
}
