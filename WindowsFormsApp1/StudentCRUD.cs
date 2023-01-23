using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class StudentCRUD : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public StudentCRUD()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }
        private void ClearForm()
        {
            txtROllNo.Clear();
            txtName.Clear();
            txtStream.Clear();
            txtPerc.Clear();
            txtAge.Clear();
            txtGender.Clear();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "insert into stud values(@name,@stream,@perc,@age,@gender)";
                cmd = new SqlCommand(qry,con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@stream", txtStream.Text);
                cmd.Parameters.AddWithValue("@perc", Convert.ToInt32(txtPerc.Text));
                cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtAge.Text));
                cmd.Parameters.AddWithValue("@gender",txtGender.Text);
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
                string qry = "update stud set name=@name,stream=@stream,perc=@perc,age=@age,gender=@gender where rollno=@rollno";
                cmd = new SqlCommand(qry,con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@stream",txtStream.Text);
                cmd.Parameters.AddWithValue("@perc", Convert.ToInt32(txtPerc.Text));
                cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtAge.Text));
                cmd.Parameters.AddWithValue("@gender",txtGender.Text);
                cmd.Parameters.AddWithValue("@rollno", Convert.ToInt32(txtROllNo.Text));
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
                string qry = "select* from stud where rollno=@rollno";
                cmd = new SqlCommand(qry,con);
                cmd.Parameters.AddWithValue("@rollno",Convert.ToInt32(txtROllNo.Text));
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtName.Text = dr["name"].ToString();
                        txtStream.Text = dr["stream"].ToString();
                        txtPerc.Text = dr["perc"].ToString();
                        txtAge.Text = dr["age"].ToString();
                        txtGender.Text = dr["gender"].ToString();
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

                string qry = "delete from stud where rollno=@rollno";

                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@rollno", Convert.ToInt32(txtROllNo.Text));
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
                string qry = "select* from stud";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable table = new DataTable();
                    table.Load(dr);
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

        private void StudentCRUD_Load(object sender, EventArgs e)
        {

        }
    }
}
