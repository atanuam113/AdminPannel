using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace AdminPannel
{
    public partial class _Default : System.Web.UI.Page
    {
       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["User"] !=null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void txtsubmit_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-539AVIS\SQLEXPRESS;Initial Catalog=EmployeeDetails;Integrated Security=true ");

            SqlCommand sqlquery = new SqlCommand(@"INSERT INTO [dbo].[SignUpDetails]
           ([FullName]
           ,[Email]
           ,[UserName]
           ,[Password])
     VALUES
           ('"+ txtfullname.Text +"','"+ txtemail.Text +"','"+ txtusername.Text + "','"+ txtpassword.Text +"')",con);
            con.Open();
            sqlquery.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Home.aspx");
        }
    }
}