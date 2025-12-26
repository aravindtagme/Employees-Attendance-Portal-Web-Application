<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewAttendance.aspx.cs" Inherits="Employees_Attendance.ViewAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card" style="max-width: 900px; margin: 20px auto;">
        <h3>Attendance Report</h3>
        
        <div style="display: flex; gap: 15px; align-items: flex-end; margin-bottom: 20px;">
            <div>
                <label>Department:</label>
                <asp:DropDownList ID="ddlFilterDept" runat="server" CssClass="input" AutoPostBack="true" OnSelectedIndexChanged="ddlFilterDept_SelectedIndexChanged">
                    <asp:ListItem Text="All Departments" Value="All" />
                    <asp:ListItem>IT</asp:ListItem>
                    <asp:ListItem>HR</asp:ListItem>
                    <asp:ListItem>Helpdesk</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <label>Date:</label>
                <asp:TextBox ID="txtFilterDate" runat="server" TextMode="Date" CssClass="input"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnSearch" runat="server" Text="Filter" CssClass="btn" OnClick="btnSearch_Click" Style="width: 100px;" />
            </div>
        </div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="Id" OnRowDeleting="GridView1_RowDeleting" CssClass="table">
            <Columns>
                <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                <asp:BoundField DataField="Department" HeaderText="Department" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="AttDate" HeaderText="Date & Time" DataFormatString="{0:dd-MM-yyyy hh:mm tt}" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
