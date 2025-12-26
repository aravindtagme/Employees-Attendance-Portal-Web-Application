using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace Employees_Attendance
{
    public partial class Attendance : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("Login.aspx");

        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT EmpId, EmpName FROM Employees WHERE Department=@dept", con);
                cmd.Parameters.AddWithValue("@dept", ddlDept.SelectedValue);
                con.Open();
                ddlEmployees.DataSource = cmd.ExecuteReader();
                ddlEmployees.DataTextField = "EmpName";
                ddlEmployees.DataValueField = "EmpId";
                ddlEmployees.DataBind();
                ddlEmployees.Items.Insert(0, new ListItem("-- Select Employee --", "0"));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlEmployees.SelectedValue == "0") return;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Attendance (EmpId, Status, AttDate) VALUES (@id, @s, GETDATE())", con);
                cmd.Parameters.AddWithValue("@id", ddlEmployees.SelectedValue);
                cmd.Parameters.AddWithValue("@s", ddlStatus.SelectedValue);
                con.Open();
                cmd.ExecuteNonQuery();
                lblMsg.Text = "✅ Attendance saved successfully";
            }
        }

    }
}