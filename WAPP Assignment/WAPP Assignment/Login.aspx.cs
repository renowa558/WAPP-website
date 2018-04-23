using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public Boolean login()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        try
        {
            con.Open();
            string query = "select * from Users where username like @username and password = @password;";
            SqlCommand cmd = new SqlCommand(query, con);
            //TODO CODE HERE
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            //???
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

            if (loginSuccessful)
            {
                Response.Write("<script type=\"text/javascript\">alert('Login success');</script>");
                return true;
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Invalid username or password');</script>");
                return false;
            }

        }

        catch (Exception ex)
        {
            Response.Write("Error: " + ex.ToString());
            return false;
        }
    }

    protected void txtPassword_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        login();
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }

    protected void txtUsername_TextChanged(object sender, EventArgs e)
    {

    }
}