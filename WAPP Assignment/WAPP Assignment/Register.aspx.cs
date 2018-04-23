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
        args.IsValid = (txtPassword1.Text.Length > 6 && txtPassword1.Text.Length < 12);
    }

    protected void txtPassword1_TextChanged(object sender, EventArgs e)
    {

    }



    

    protected void Button1_Click1(object sender, EventArgs e)
    {
        string dob = "1-9-1995";
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
                string query1 = "insert into Users (Username, password, email, gender, dob) values (@uname,@pword,@email,@gender,@dob)";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@uname", txtUsername.Text);
                cmd1.Parameters.AddWithValue("@pword", txtPassword1.Text);
                cmd1.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd1.Parameters.AddWithValue("@gender", rdbGender.SelectedItem.ToString());
                cmd1.Parameters.AddWithValue("@dob", dob);
                cmd1.ExecuteNonQuery();
                Response.Write("<script type=\"text/javascript\">alert('Registration successful!.');</script>");
            }
            con.Close();
        }
        catch(Exception ex)
        {
            Response.Write("Error: " + ex.ToString());
        }
    }

    protected void btnCheckAvailable_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        try
        {
            con.Open();
            string query = "select * from Users where username like @username";
            SqlCommand cmd = new SqlCommand(query, con);
            //TODO CODE HERE
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            //???
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            bool isAvailable = ((ds.Tables.Count == 0) && (ds.Tables[0].Rows.Count == 0));

            if (isAvailable)
            {
                Response.Write("<script type=\"text/javascript\">alert('Username has been taken!');</script>");
                
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Username is not taken');</script>");
                
            }

        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.ToString());
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}