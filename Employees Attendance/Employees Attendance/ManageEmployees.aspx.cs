using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Employees_Attendance
{
    public partial class ManageEmployees : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("Login.aspx");
            if (!IsPostBack) LoadEmployees();
        }

        private void LoadEmployees()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", con);
                con.Open();
                gvEmployees.DataSource = cmd.ExecuteReader();
                gvEmployees.DataBind();
            }
        }

        // CREATE: Add Employee
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Employees (EmpName, Department) VALUES (@n, @d)", con);
                cmd.Parameters.AddWithValue("@n", txtEmpName.Text);
                cmd.Parameters.AddWithValue("@d", ddlDept.SelectedValue);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            txtEmpName.Text = "";
            LoadEmployees();
        }

        // UPDATE: Edit Employee Name or Dept
        protected void gvEmployees_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);
            string name = ((TextBox)gvEmployees.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
            string dept = ((TextBox)gvEmployees.Rows[e.RowIndex].Cells[1].Controls[0]).Text;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Employees SET EmpName=@n, Department=@d WHERE EmpId=@id", con);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@d", dept);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            gvEmployees.EditIndex = -1;
            LoadEmployees();
        }

        // DELETE: Remove Employee
        protected void gvEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE EmpId=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LoadEmployees();
        }

        protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e) { gvEmployees.EditIndex = e.NewEditIndex; LoadEmployees(); }
        protected void gvEmployees_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) { gvEmployees.EditIndex = -1; LoadEmployees(); }

    }
}