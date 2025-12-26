<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Employees_Attendance.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login </title>
     <link href="CSS/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="login-wrapper">
    <div class="login-card">
        <h2>Admin Login</h2>
        <asp:TextBox ID="txtUser" runat="server" CssClass="input" placeholder="Username" />
        <asp:TextBox ID="txtPass" runat="server" CssClass="input" TextMode="Password" placeholder="Password" />
        <asp:Label ID="lblMsg" runat="server" CssClass="error"></asp:Label>
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
    </div>
    </div>
    </form>
</body>
</html>
