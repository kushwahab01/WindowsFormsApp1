using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Form6()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }
        private void ClearForm()
        {
            txtID.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtCompany.Clear();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "insert into ProductT values(@name,@price,@comp)";
                cmd = new SqlCommand(qry, con);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
                cmd.Parameters.AddWithValue("@comp", txtCompany.Text);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                if(result==1)
                {
                    MessageBox.Show("Record is inserted");
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
          
                string qry = "update ProductT set name=@name,price=@price, company=@company where id=@id";
               
                cmd = new SqlCommand(qry, con);
           
                cmd.Parameters.AddWithValue("@name",txtName.Text);
                cmd.Parameters.AddWithValue("@price",Convert.ToInt32(txtPrice.Text));
                cmd.Parameters.AddWithValue("@company",txtCompany.Text);
                cmd.Parameters.AddWithValue("@id",Convert.ToInt32(txtID.Text));
             
                con.Open();
             
                int result = cmd.ExecuteNonQuery(); 
                if (result == 1)
                {
                    MessageBox.Show("Record updated");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
              
                string qry = "delete from ProductT where id=@id";
                
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from ProductT where id=@id";
                cmd = new SqlCommand(qry,con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text));
                con.Open();
                dr=cmd.ExecuteReader(); 
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtName.Text=dr["name"].ToString();
                        txtPrice.Text=dr["price"].ToString();
                        txtCompany.Text=dr["company"].ToString();
                    }
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

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select* from ProductT";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    DataTable table = new DataTable();
                    table.Load(dr);
                    dataGridView1.DataSource = table;
                }
                else
                {
                    MessageBox.Show("Record not found");
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
    }
}
