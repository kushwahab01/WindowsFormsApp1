using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class EmployeeCRUD : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public EmployeeCRUD()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }
        private void ClearForm()
        {
            txtID.Clear();
            txtName.Clear();
            txtDepartment.Clear();
            txtSalary.Clear();
            txtAge.Clear();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "insert into Employee values(@ename,@deptname,@salary,@age)";
                cmd=new SqlCommand(qry,con);
                cmd.Parameters.AddWithValue("@ename",txtName.Text);
                cmd.Parameters.AddWithValue("@deptname",txtDepartment.Text);
                cmd.Parameters.AddWithValue("@salary",Convert.ToInt32(txtSalary.Text));
                cmd.Parameters.AddWithValue("@age",Convert.ToInt32(txtAge.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if(result==1)
                {
                    MessageBox.Show("Record inserted");
                    ClearForm();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "update Employee set ename=@ename,deptname=@deptname,salary=@salary,age=@age where empid=@empid";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@ename", txtName.Text);
                cmd.Parameters.AddWithValue("@deptname", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@salary", Convert.ToInt32(txtSalary.Text));
                cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtAge.Text));
                cmd.Parameters.AddWithValue("@empid", Convert.ToInt32(txtID.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record Updated");
                    ClearForm();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select* from Employee where empid=@empid";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@empid", Convert.ToInt32(txtID.Text));
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtName.Text = dr["ename"].ToString();
                        txtDepartment.Text = dr["deptname"].ToString();
                        txtSalary.Text = dr["salary"].ToString();
                        txtAge.Text = dr["age"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Record Not found");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                string qry = "delete from Employee where empid=@empid";

                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@empid", Convert.ToInt32(txtID.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record deleted");
                    ClearForm();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select* from Employee";
                cmd = new SqlCommand(qry,con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable table = new DataTable();
                    table.Load(dr);
                  dataGridView1.DataSource=table;
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
