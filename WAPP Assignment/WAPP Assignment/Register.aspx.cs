using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Register : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void CustomValidator1_ServerValidate1(object source, ServerValidateEventArgs args)
    {
        if (txtPassword1.Text.Length > 6 && txtPassword1.Text.Length < 12)
        {
            args.IsValid = true;
        }
        else
            args.IsValid = false;
    }

    protected void txtPassword1_TextChanged(object sender, EventArgs e)
    {

    }



    

    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string dob = TextBox1.Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                con.Open();
                string query = "select count(*) from Users where Username ='" + txtUsername.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                if (check > 0)
                {
                    Response.Write("<script type=\"text/javascript\" > alert('This username already exists.');</script>");

                }
                else
                {

                    string query1 = "insert into Users (Username, password, email, gender, dob, usertype) values (@uname,@pword,@email,@gender,@dob,@utype)";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.Parameters.AddWithValue("@uname", txtUsername.Text);
                    cmd1.Parameters.AddWithValue("@pword", txtPassword1.Text);
                    cmd1.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd1.Parameters.AddWithValue("@gender", rdbGender.SelectedItem.ToString());
                    cmd1.Parameters.AddWithValue("@dob", dob);
                    cmd1.Parameters.AddWithValue("@utype", "user");
                    cmd1.ExecuteNonQuery();
                    Response.Write("<script type=\"text/javascript\">alert('Registration successful!.');</script>");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }
        }
    }

    protected void btnCheckAvailable_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
        string query = "select count(*) from Users where Username ='" + txtUsername.Text + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
        lblUnameAvailable.Visible = true;
        if (check > 0)
        {
            
            lblUnameAvailable.ForeColor = System.Drawing.Color.Red;
            lblUnameAvailable.Text = "Username is taken!";
        }
        else
        {
            lblUnameAvailable.ForeColor = System.Drawing.Color.ForestGreen;
            lblUnameAvailable.Text = "Username is available!";
        }
        con.Close();
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}