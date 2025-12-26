<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="Employees_Attendance.Attendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h3>Mark Employee Attendance</h3>

        <label>Select Department:</label>
        <asp:DropDownList ID="ddlDept" runat="server" CssClass="input" AutoPostBack="true" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
            <asp:ListItem Text="-- Select Department --" Value="0" />
            <asp:ListItem>IT</asp:ListItem>
            <asp:ListItem>HR</asp:ListItem>
            <asp:ListItem>Helpdesk</asp:ListItem>
        </asp:DropDownList>

        <label>Select Employee:</label>
        <asp:DropDownList ID="ddlEmployees" runat="server" CssClass="input"></asp:DropDownList>

        <label>Status:</label>
        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="input">
            <asp:ListItem>Present</asp:ListItem>
            <asp:ListItem>Absent</asp:ListItem>
        </asp:DropDownList>

        <div class="btn-center">
            <asp:Button ID="btnSave" runat="server" Text="Save Attendance" CssClass="btn" OnClick="btnSave_Click" />
        </div>
        <asp:Label ID="lblMsg" runat="server" CssClass="success-msg"></asp:Label>
    </div>


</asp:Content>

