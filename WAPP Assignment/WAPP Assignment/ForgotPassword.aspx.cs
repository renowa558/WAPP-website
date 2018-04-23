using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string username = "";
        string password = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select username, password from Users where email=@email", con);
        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
        con.Open();
        using (SqlDataReader sdr = cmd.ExecuteReader())
        {
            if (sdr.Read())
            {
                username = sdr["username"].ToString();
                password = sdr["password"].ToString();
            }
        }
        con.Close();
        if (!string.IsNullOrEmpty(password))
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("dummyemokiet@gmail.com");
            msg.To.Add(txtEmail.Text);
            msg.Subject = "Recover your password";
            msg.Body = ("Your username: " + username + "<br/><br/>" + "Your password: " + password);
            msg.IsBodyHtml = true;

            SmtpClient smt = new SmtpClient();
            smt.Host = "smtp.gmail.com";
            System.Net.NetworkCredential ntwd = new System.Net.NetworkCredential();
            ntwd.UserName = "dummyemokiet@gmail.com";
            ntwd.Password = "Dummy123";
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntwd;
            smt.Port = 587;
            smt.EnableSsl = true;
            smt.Send(msg);
            lblMessage.ForeColor = System.Drawing.Color.ForestGreen;
            lblMessage.Text = "Username and password sent successfully";
        }
    }
}