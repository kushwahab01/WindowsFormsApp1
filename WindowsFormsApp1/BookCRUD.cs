using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class BookCRUD : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rd;
        public BookCRUD()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }
        private void ClearForm()
        {
            txtID.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtAuther.Clear();
            txtPublication.Clear();
            txtEdition.Clear();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "insert into NewBook values(@name,@price,@auther,@edition,@publication)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@price",Convert.ToInt32(txtPrice.Text));
                cmd.Parameters.AddWithValue("@auther",txtAuther.Text);
                cmd.Parameters.AddWithValue("@edition",txtEdition.Text);
                cmd.Parameters.AddWithValue("@publication",txtPublication.Text);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record inserted");
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "update NewBook set name=@name,price=@price,auther=@auther,edition=@edition,publication=@publication where id=@id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
                cmd.Parameters.AddWithValue("@auther",txtAuther.Text);
                cmd.Parameters.AddWithValue("@edition",txtEdition.Text);
                cmd.Parameters.AddWithValue("@publication",txtPublication.Text);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record Updated");
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select* from NewBook where id=@id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text));
                con.Open();
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        txtName.Text = rd["name"].ToString();
                        txtPrice.Text = rd["price"].ToString();
                        txtAuther.Text = rd["auther"].ToString();
                        txtEdition.Text = rd["edition"].ToString();
                        txtPublication.Text = rd["publication"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Record Not found");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                string qry = "delete from NewBook where id=@id";

                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text));
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
                string qry = "select* from NewBook";
                cmd = new SqlCommand(qry, con);
                con.Open();
                rd= cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    DataTable table = new DataTable();
                    table.Load(rd);
                    dataGridView1.DataSource = table;
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

        private void BookCRUD_Load(object sender, EventArgs e)
        {

        }
    }
}
