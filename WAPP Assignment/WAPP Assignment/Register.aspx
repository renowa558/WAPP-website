<%@ Page Title="" Language="C#" MasterPageFile="~/MP.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 35px;
        }
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            height: 33px;
        }
        .auto-style4 {
            height: 39px;
        }
        .auto-style5 {
            height: 117px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>&nbsp;</h1>
    <h1>Registration</h1>
    <table class="w-100">
        <tr>
            <td>Username</td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username is required" ControlToValidate="txtUsername" >*</asp:RequiredFieldValidator>
                <asp:Button ID="btnCheckAvailable" runat="server" OnClick="btnCheckAvailable_Click" Text="Check Availability" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Password</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtPassword1" TextMode="Password" runat="server" OnTextChanged="txtPassword1_TextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword1" ErrorMessage="Password is required">*</asp:RequiredFieldValidator>
&nbsp;<asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Password has incorrect length" OnServerValidate="CustomValidator1_ServerValidate1" ControlToValidate="txtPassword1">*</asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Re-type password</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtPassword2" TextMode="Password" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword1" ControlToValidate="txtPassword2" ErrorMessage="Passwords do not match!"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Email</td>
            <td class="auto-style2">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Not a valid email address!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Date of Birth</td>
            <td class="auto-style2">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Gender</td>
            <td>
                <asp:RadioButtonList ID="rdbGender" runat="server" Width="248px" BorderStyle="None">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rdbGender" ErrorMessage="Gender is required">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style5">
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="One or more fields were entered incorrectly" ForeColor="Red" />

            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">
                <asp:Button ID="btnRegister" runat="server" Height="60px" OnClick="Button1_Click1" Text="Register" />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

