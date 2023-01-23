using System;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"E:\Dept.dat", FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(Convert.ToInt32(txtID.Text));
                bw.Write(txtName.Text);
                bw.Write(txtLoc.Text);
                bw.Close();
                fs.Close();
                MessageBox.Show("Data saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"E:\Dept.dat", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                txtID.Text = br.ReadInt32().ToString();
                txtName.Text = br.ReadString();
                txtLoc.Text = br.ReadString();
                MessageBox.Show("Open Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            string path = @"E:\Skillmine1";
            try
            {
                if (Directory.Exists(path)) 
                {
                    MessageBox.Show("Directory is already exist");
                }
                else
                {
                    Directory.CreateDirectory(path);
                    MessageBox.Show("Directory is created");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            string path = @"E:Skillmine1.txt";
            try
            {
                if(File.Exists(path))
                {
                    MessageBox.Show("File already exist");
                }
                else
                {
                    File.Create(path);
                    MessageBox.Show("File Created Successfully");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string path = @"E:\Skillmine1";
            try
            {
                if(Directory.Exists(path))
                {
                    Directory.Delete(path);
                    MessageBox.Show("Directory deleted successfully");
                }
                else
                {
                    MessageBox.Show("Does not exist");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                }
    }
}
