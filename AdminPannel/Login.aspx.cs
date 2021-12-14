using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AdminPannel
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String LoginUser = txtusername.Text.Trim();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-539AVIS\SQLEXPRESS;Initial Catalog=EmployeeDetails;Integrated Security=true ");
            SqlCommand sqlcmd = new SqlCommand("SELECT COUNT(*) FROM SignUpDetails WHERE  UserName= '" + txtusername.Text + "' AND Password='" + txtpassword.Text +"'",con);
            con.Open();
            int tmp = Convert.ToInt32(sqlcmd.ExecuteScalar().ToString());
            con.Close();
            if(tmp == 1)
            {
                Session["User"] = LoginUser;
                Response.Redirect("Home.aspx");
            }
            else
            {
                txterroemsg.ForeColor = System.Drawing.Color.Red;
                txterroemsg.Text = "Your Username or password is Invalid";
            }
        }
    }
}