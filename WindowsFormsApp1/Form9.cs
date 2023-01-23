using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form9 : Form
    {
        SqlConnection con;
        SqlDataAdapter adapter;
        SqlCommandBuilder sqlCommandBuilder;
        DataSet ds;
        public Form9()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }
        private DataSet GetAll()
        {
            adapter = new SqlDataAdapter("select * from stud", con);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            sqlCommandBuilder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "Student");
            return ds;
        }
        private void ClearForm()
        {
            txtROllNo.Clear();
            txtName.Clear();
            txtGender.Clear();
            txtPerc.Clear();
            txtStream.Clear();
            txtAge.Clear();
        }
        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                DataRow row = ds.Tables["Student"].NewRow();
                row["name"] = txtName.Text;
                row["stream"] = txtStream.Text;
                row["perc"] = txtPerc.Text;
                row["age"] = txtAge.Text;
                row["gender"] = txtGender.Text;
                ds.Tables["Student"].Rows.Add(row);
                int result = adapter.Update(ds.Tables["Student"]);
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
                DataRow row = ds.Tables["Student"].Rows.Find(txtROllNo.Text);

                if (row != null)
                {
                    row["name"] = txtName.Text;
                    row["stream"] = txtStream.Text;
                    row["perc"] = txtPerc.Text;
                    row["age"] = txtAge.Text;
                    row["gender"] = txtGender.Text;
                    int result = adapter.Update(ds.Tables["Student"]);
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
                DataRow row = ds.Tables["Student"].Rows.Find(txtROllNo.Text);

                if (row != null)
                {
                    txtName.Text = row["name"].ToString();
                    txtStream.Text = row["stream"].ToString();
                    txtPerc.Text = row["perc"].ToString();
                    txtAge.Text = row["age"].ToString();
                    txtGender.Text = row["gender"].ToString();
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
                DataRow row = ds.Tables["Student"].Rows.Find(txtROllNo.Text);

                if (row != null)
                {
                    row.Delete();
                    int result = adapter.Update(ds.Tables["Student"]);
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
                dataGridView1.DataSource = ds.Tables["Student"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
