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
    public partial class ViewAttendance : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                txtFilterDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LoadData();
            }
        }
        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = @"SELECT a.Id, e.EmpName, e.Department, a.Status, a.AttDate 
                                 FROM Attendance a 
                                 INNER JOIN Employees e ON a.EmpId = e.EmpId 
                                 WHERE 1=1";

                if (ddlFilterDept.SelectedValue != "All") query += " AND e.Department = @dept";
                if (!string.IsNullOrEmpty(txtFilterDate.Text)) query += " AND CAST(a.AttDate AS DATE) = @date";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@dept", ddlFilterDept.SelectedValue);
                cmd.Parameters.AddWithValue("@date", txtFilterDate.Text);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }

        protected void ddlFilterDept_SelectedIndexChanged(object sender, EventArgs e) => LoadData();
        protected void btnSearch_Click(object sender, EventArgs e) => LoadData();

        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Attendance WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LoadData();
        }


    }
}