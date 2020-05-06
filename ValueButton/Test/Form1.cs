using System;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void valueButton1_Click(object sender, EventArgs e) => label1.Text = valueButton1.ButtonValue.ToString();
    }
}
