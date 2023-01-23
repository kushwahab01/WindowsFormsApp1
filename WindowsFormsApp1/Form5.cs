using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void lblLoc_Click(object sender, EventArgs e)
        {

        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {

                FileStream fs = new FileStream(@"E:\SkillMine\Student.dat", FileMode.Create, FileAccess.Write);

                Student s = new Student();
                s.Sid = Convert.ToInt32(txtID.Text);
                s.Sname = txtName.Text;
                s.Percentage = Convert.ToDouble(txtPerc.Text);

                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, s);
                fs.Close();
                MessageBox.Show("Student Record Added to file");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {

                FileStream fs = new FileStream(@"E:\SkillMine\Student.dat", FileMode.Open, FileAccess.Read);

                Student s = new Student();

                BinaryFormatter binaryFormatter = new BinaryFormatter();
                s = (Student)binaryFormatter.Deserialize(fs);
                fs.Close();

                txtID.Text = s.Sid.ToString();
                txtName.Text = s.Sname;
                txtPerc.Text = s.Percentage.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXMLWrite_Click(object sender, EventArgs e)
        {
            try
            {

                FileStream fs = new FileStream(@"E:\SkillMine\StudentXML.xml", FileMode.Create, FileAccess.Write);

                Student s = new Student();
               s.Sid = Convert.ToInt32(txtID.Text);
                s.Sname = txtName.Text;
                s.Percentage = Convert.ToInt32(txtPerc.Text);

                XmlSerializer xml = new XmlSerializer(typeof(Student));
                xml.Serialize(fs, s);
                fs.Close();
                MessageBox.Show("Student record added to file");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXMLRead_Click(object sender, EventArgs e)
        {
            try
            {

                FileStream fs = new FileStream(@"E:\SkillMine\StudentXML.xml", FileMode.Open, FileAccess.Read);
                Student s = new Student();

                XmlSerializer xml = new XmlSerializer(typeof(Student));
                s = (Student)xml.Deserialize(fs);
                fs.Close();

                txtID.Text = s.Sid.ToString();
                txtName.Text = s.Sname;
                txtPerc.Text = s.Percentage.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSOAPWrite_Click(object sender, EventArgs e)
        {
            try
            {

                FileStream fs = new FileStream(@"E:\SkillMine\StudentSOAP.soap", FileMode.Create, FileAccess.Write);

                Student s = new Student();
                s.Sid = Convert.ToInt32(txtID.Text);
                s.Sname = txtName.Text;
                s.Percentage = Convert.ToInt32(txtPerc.Text);

                SoapFormatter soapFormatter = new SoapFormatter();
                soapFormatter.Serialize(fs, s);
                fs.Close();
                MessageBox.Show("Student record added to file");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            try
            {

                FileStream fs = new FileStream(@"E:\SkillMine\StudentSOAP.soap", FileMode.Open, FileAccess.Read);

                Student s = new Student();

                SoapFormatter soap = new SoapFormatter();
                s = (Student)soap.Deserialize(fs);
                fs.Close();

                txtID.Text = s.Sid.ToString();
                txtName.Text = s.Sname;
                txtPerc.Text = s.Percentage.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJSONWrite_Click(object sender, EventArgs e)
        {
            try
            {

                FileStream fs = new FileStream(@"E:\SkillMine\StudentJSON.json", FileMode.Create, FileAccess.Write);

                Student s = new Student();
                s.Sid = Convert.ToInt32(txtID.Text);
                s.Sname = txtName.Text;
                s.Percentage = Convert.ToInt32(txtPerc.Text);

                JsonSerializer.Serialize<Student>(fs, s);
                fs.Close();
                MessageBox.Show("Student record added to file");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJSONRead_Click(object sender, EventArgs e)
        {
            try
            {

                FileStream fs = new FileStream(@"E:\SkillMine\StudentJSON.json", FileMode.Open, FileAccess.Read);

                Student s = new Student();


               s = JsonSerializer.Deserialize<Student>(fs);
                fs.Close();

                txtID.Text = s.Sid.ToString();
                txtName.Text = s.Sname;
                txtPerc.Text = s.Percentage.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            txtPerc.Clear();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
