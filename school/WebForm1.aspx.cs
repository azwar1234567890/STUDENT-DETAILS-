using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace school
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=ITD-LIS-WS-040\\SQLEXPRESS; initial catalog=school; integrated security=true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            display();

        }

        protected void txtsubmit_Click(object sender, EventArgs e)
        {
            if(txtsubmit.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertStudentDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@std_name", txtname.Text);
                cmd.Parameters.AddWithValue("@std_sub", txtsubject.Text);
                cmd.Parameters.AddWithValue("@std_class", txtClass.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                clear();
            }
            else if (txtsubmit.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateStudentDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@std_id", ViewState["NewId"]);
                cmd.Parameters.AddWithValue("@std_name", txtname.Text);
                cmd.Parameters.AddWithValue("@std_sub", txtsubject.Text);
                cmd.Parameters.AddWithValue("@std_class", txtClass.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                clear();
            }
        }

        
         public void clear()
         {
             txtname.Text = string.Empty;
             txtsubject.Text = string.Empty;
             txtClass.Text = string.Empty;
         }
         

        public void display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DisplayStudentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            gv.DataSource = dt;
            gv.DataBind();
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "del")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteStudentDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@std_id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                display();

            }
                else if (e.CommandName == "thedit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EditStudentDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue ("@std_id", e.CommandArgument);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0][1].ToString();
                txtsubject.Text = dt.Rows[0][2].ToString();
                txtClass.Text = dt.Rows[0][3].ToString();
                txtsubmit.Text = "Update";
                ViewState["NewId"] = e.CommandArgument;
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SearchStudentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@std_name", txtsearch.Text);
            cmd.Parameters.AddWithValue("@std_sub", txtsearch.Text);
            cmd.Parameters.AddWithValue("@std_class", txtsearch.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            gv.DataSource = dt;
            gv.DataBind();
        }

        protected void btnsort_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SortStudentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@std_class",txtClass.Text );
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            gv.DataSource = dt;
            gv.DataBind();
        }
    }
}
