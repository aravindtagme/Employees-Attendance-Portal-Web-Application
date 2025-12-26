<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageEmployees.aspx.cs" Inherits="Employees_Attendance.ManageEmployees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h3>Add New Staff</h3>
        <asp:TextBox ID="txtEmpName" runat="server" placeholder="Employee Name" CssClass="input" />
        <asp:DropDownList ID="ddlDept" runat="server" CssClass="input">
            <asp:ListItem>IT</asp:ListItem>
            <asp:ListItem>HR</asp:ListItem>
            <asp:ListItem>Helpdesk</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnAdd" runat="server" Text="Add Employee" CssClass="btn" OnClick="btnAdd_Click" />
    </div>
    <div class="card" style="max-width:800px;">
        <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False" DataKeyNames="EmpId" 
            OnRowEditing="gvEmployees_RowEditing" OnRowUpdating="gvEmployees_RowUpdating" 
            OnRowDeleting="gvEmployees_RowDeleting" OnRowCancelingEdit="gvEmployees_RowCancelingEdit">
            <Columns>
                <asp:BoundField DataField="EmpName" HeaderText="Name" />
                <asp:BoundField DataField="Department" HeaderText="Department" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
