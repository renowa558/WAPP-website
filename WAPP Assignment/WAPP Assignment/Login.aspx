<%@ Page Title="" Language="C#" MasterPageFile="MP.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
            text-align: left;
        }
        .auto-style2 {
            height: 35px;
            text-align: left;
        }
        .auto-style3 {
            margin-left: 388;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <h1>Login</h1>
    <table class="w-100">
        <tr>
            <td class="auto-style2">
                <p>
                    Username</p>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtUsername" runat="server" OnTextChanged="txtUsername_TextChanged" CssClass="auto-style3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-left">Password</td>
            <td class="text-left">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" OnTextChanged="txtPassword_TextChanged"></asp:TextBox>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Forgot Password?</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">
                <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [username], [password] FROM [Users]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

