using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.MdiParent = this;
            f1.Show();
        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.Show();
        }

        private void form5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 f5 = new Form10();
            f5.MdiParent = this;
            f5.Show();
        }

        private void form6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 f6 = new Form9();
            f6.MdiParent = this;
            f6.Show();
        }

        private void form7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeCRUD f7 = new EmployeeCRUD();
            f7.MdiParent = this;
            f7.Show();
        }

        private void form8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentCRUD f8 = new StudentCRUD();
            f8.MdiParent = this;
            f8.Show();
        }

        private void form9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookCRUD f9 = new BookCRUD();
            f9.MdiParent = this;
            f9.Show();
        }

        private void disconnectedArchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f10 = new Form7();
            f10.MdiParent = this;
            f10.Show();
        }

        private void disconnectedArchEmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f11 = new Form8();
            f11.MdiParent = this;
            f11.Show();
        }
    }
}
