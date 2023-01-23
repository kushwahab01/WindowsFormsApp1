using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form10 : Form
    {
        SqlConnection con;
        SqlDataAdapter adapter;
        SqlCommandBuilder sqlCommandBuilder;
        DataSet ds;

        public Form10()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }
        private DataSet GetAll()
        {
            adapter = new SqlDataAdapter("select * from NewBook", con);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            sqlCommandBuilder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "Book");
            return ds;
        }
        private void ClearForm()
        {
            txtID.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtPublication.Clear();
            txtEdition.Clear();
            txtAuther.Clear();
        }
        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                DataRow row = ds.Tables["Book"].NewRow();
                row["name"] = txtName.Text;
                row["price"] = txtPrice.Text;
                row["auther"] = txtAuther.Text;
                row["edition"] = txtEdition.Text;
                row["publication"] = txtPublication.Text;
                ds.Tables["Book"].Rows.Add(row);
                int result = adapter.Update(ds.Tables["Book"]);
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
                DataRow row = ds.Tables["Book"].Rows.Find(txtID.Text);

                if (row != null)
                {
                    row["name"] = txtName.Text;
                    row["price"] = txtPrice.Text;
                    row["auther"] = txtAuther.Text;
                    row["edition"] = txtEdition.Text;
                    row["publication"] = txtPublication.Text;
                    int result = adapter.Update(ds.Tables["Book"]);
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
                DataRow row = ds.Tables["Book"].Rows.Find(txtID.Text);

                if (row != null)
                {
                    txtName.Text = row["name"].ToString();
                    txtPrice.Text = row["price"].ToString();
                    txtAuther.Text = row["auther"].ToString();
                    txtEdition.Text = row["edition"].ToString();
                    txtPublication.Text = row["publication"].ToString();
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
                DataRow row = ds.Tables["Book"].Rows.Find(txtID.Text);

                if (row != null)
                {
                    row.Delete();
                    int result = adapter.Update(ds.Tables["Book"]);
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
                dataGridView1.DataSource = ds.Tables["Book"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }   
}
