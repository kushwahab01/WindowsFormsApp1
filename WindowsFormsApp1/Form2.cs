using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
               
                FileStream fs = new FileStream(@"E:\SkillMine\Employee.dat", FileMode.Create, FileAccess.Write);
            
                Employee emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(txtID.Text);
                emp.EmployeeName = txtName.Text;
                emp.EmployeeSalary = Convert.ToInt32(txtSalary.Text);
             
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, emp);
                fs.Close();
                MessageBox.Show("Employee record added to file");
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
                
                FileStream fs = new FileStream(@"E:\SkillMine\Employee.dat", FileMode.Open, FileAccess.Read);
           
                Employee emp = new Employee();
             
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                emp = (Employee)binaryFormatter.Deserialize(fs);
                fs.Close();

                txtID.Text = emp.EmployeeId.ToString();
                txtName.Text = emp.EmployeeName;
                txtSalary.Text = emp.EmployeeSalary.ToString();
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
             
                FileStream fs = new FileStream(@"E:\SkillMine\EmployeeSOAP.soap", FileMode.Create, FileAccess.Write);
     
                Employee emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(txtID.Text);
                emp.EmployeeName = txtName.Text;
                emp.EmployeeSalary = Convert.ToInt32(txtSalary.Text);
          
                SoapFormatter soapFormatter = new SoapFormatter();
                soapFormatter.Serialize(fs, emp);
                fs.Close();
                MessageBox.Show("Employee record added to file");
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
           
                FileStream fs = new FileStream(@"E:\SkillMine\EmployeeSOAP.soap", FileMode.Open, FileAccess.Read);
             
                Employee emp = new Employee();
             
                SoapFormatter soap = new SoapFormatter();
                emp = (Employee)soap.Deserialize(fs);
                fs.Close();

                txtID.Text = emp.EmployeeId.ToString();
                txtName.Text = emp.EmployeeName;
                txtSalary.Text = emp.EmployeeSalary.ToString();
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

                FileStream fs = new FileStream(@"E:\SkillMine\EmployeeXML.xml", FileMode.Create, FileAccess.Write);

                Employee emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(txtID.Text);
                emp.EmployeeName = txtName.Text;
                emp.EmployeeSalary = Convert.ToInt32(txtSalary.Text);

                XmlSerializer xml = new XmlSerializer(typeof(Employee));
                xml.Serialize(fs, emp);
                fs.Close();
                MessageBox.Show("Employee record added to file");
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

                FileStream fs = new FileStream(@"E:\SkillMine\EmployeeXML.xml", FileMode.Open, FileAccess.Read);

                Employee emp = new Employee();

                XmlSerializer xml = new XmlSerializer(typeof(Employee));
                emp = (Employee)xml.Deserialize(fs);
                fs.Close();

                txtID.Text = emp.EmployeeId.ToString();
                txtName.Text = emp.EmployeeName;
                txtSalary.Text = emp.EmployeeSalary.ToString();
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
       
                FileStream fs = new FileStream(@"E:\SkillMine\EmployeeJSON.json", FileMode.Create, FileAccess.Write);
            
                Employee emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(txtID.Text);
                emp.EmployeeName = txtName.Text;
                emp.EmployeeSalary = Convert.ToInt32(txtSalary.Text);
     
                JsonSerializer.Serialize<Employee>(fs, emp);
                fs.Close();
                MessageBox.Show("Employee record added to file");
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
         
                FileStream fs = new FileStream(@"E:\SkillMine\EmployeeJSON.json", FileMode.Open, FileAccess.Read);
          
                Employee emp = new Employee();
       

                emp = JsonSerializer.Deserialize<Employee>(fs);
                fs.Close();

                txtID.Text = emp.EmployeeId.ToString();
                txtName.Text = emp.EmployeeName;
                txtSalary.Text = emp.EmployeeSalary.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
