using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employees_Attendance
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT Password FROM AdminLogin WHERE Username=@u", con);
            cmd.Parameters.AddWithValue("@u", txtUser.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() && dr["Password"].ToString() == txtPass.Text)
            {
                Session["User"] = txtUser.Text; // Save session
                Response.Redirect("Attendance.aspx");
            }
            else
            {
                lblMsg.Text = "❌ Invalid credentials";
            }
            con.Close();

        }
    }
}