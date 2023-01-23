using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form8 : Form
    {
        SqlConnection con;
        SqlDataAdapter adapter;
        SqlCommandBuilder sqlCommandBuilder;
        DataSet ds;

        public Form8()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }
        private DataSet GetAll()
        {
            adapter = new SqlDataAdapter("select * from Employee", con);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            sqlCommandBuilder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "Employee");
            return ds;
        }
        private void ClearForm()
        {
            txtID.Clear();
            txtName.Clear();
            txtSalary.Clear();
            txtDepartment.Clear();
            txtAge.Clear();
        }
        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                DataRow row = ds.Tables["Employee"].NewRow();
                row["ename"] = txtName.Text;
                row["deptname"] = txtDepartment.Text;
                row["salary"] = txtSalary.Text;
                row["age"] = txtAge.Text;
                ds.Tables["Employee"].Rows.Add(row);
                int result = adapter.Update(ds.Tables["Employee"]);
                if (result == 1)
                {
                    MessageBox.Show("Record inserted..");
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                DataRow row = ds.Tables["Employee"].Rows.Find(txtID.Text);

                if (row != null)
                {
                    row["ename"] = txtName.Text;
                    row["deptname"] = txtDepartment.Text;
                    row["salary"] = txtSalary.Text;
                    row["age"] = txtAge.Text;
                    int result = adapter.Update(ds.Tables["Employee"]);
                    if (result == 1)
                    {
                        MessageBox.Show("Record updated..");
                        ClearForm();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                DataRow row = ds.Tables["Employee"].Rows.Find(txtID.Text);

                if (row != null)
                {
                    txtName.Text = row["ename"].ToString();
                    txtDepartment.Text= row["deptname"].ToString();
                    txtSalary.Text= row["salary"].ToString();
                    txtAge.Text = row["age"].ToString();
                }
                else
                {
                    MessageBox.Show("Record not found..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                DataRow row = ds.Tables["Employee"].Rows.Find(txtID.Text);

                if (row != null)
                {
                    row.Delete();
                    int result = adapter.Update(ds.Tables["Employee"]);
                    if (result == 1)
                    {
                        MessageBox.Show("Record deleted..");
                        ClearForm();
                    }
                }
                else
                {
                    MessageBox.Show("Record not found..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                dataGridView1.DataSource = ds.Tables["Employee"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
