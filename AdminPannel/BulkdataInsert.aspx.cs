using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace AdminPannel
{
    public partial class BulkdataInsert : System.Web.UI.Page
    {
        String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\atanu\source\repos\AdminPannel\AdminPannel\App_Data\Database1.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateData();
            }
        }

        private void PopulateData()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Contacts", sqlCon);
                sqlCon.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btnAddrow_Click(object sender, EventArgs e)
        {
            AddRows();
        }

        private void AddRows()
        {
            List<int> NoOfRows = new List<int>();
            int rows = 0;
            int.TryParse(NoOfRow.Text.Trim(), out rows);
            for(int i=0; i<rows; i++)
            {
                NoOfRows.Add(i);
            }
            gvContacts.DataSource = NoOfRows;
            gvContacts.DataBind();
            if(gvContacts.Rows.Count >0)
            {
                Panel1.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<? xml version=\"1.0\" ?>");
            sb.AppendLine("     <contacts>");

            TextBox txtFullName;
            TextBox txtEmail;
            TextBox txtPhone;

            foreach(GridViewRow row in gvContacts.Rows)
            {
                txtFullName = (TextBox)row.FindControl("txtFullName");
                txtEmail = (TextBox)row.FindControl("txtEmail");
                txtPhone = (TextBox)row.FindControl("txtPhone");

                if(txtFullName == null || txtEmail == null || txtPhone == null)
                {
                    return;
                }

                if(string.IsNullOrEmpty(txtEmail.Text.Trim())
                   || string.IsNullOrEmpty(txtEmail.Text.Trim())
                   || string.IsNullOrEmpty(txtPhone.Text.Trim()))
                {
                    lblmsg.Text = "All fields are Required";
                    return;
                }
                else
                {
                    sb.AppendLine("     <contacts>");
                    sb.AppendLine("     <E_Name>" + txtFullName.Text.Trim() + "     </E_Name>");
                    sb.AppendLine("     <E_Email>" + txtEmail.Text.Trim() + "     </E_Email>");
                    sb.AppendLine("     <E_Phone>" + txtPhone.Text.Trim() + "     </E_Phone>");

                    sb.AppendLine("     </contacts>");

                }
            }

            sb.AppendLine("     </contacts>");

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ContactDetailsInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                byte[] barray = Encoding.UTF8.GetBytes(Convert.ToString(sb));
                cmd.Parameters.AddWithValue("@XMLData", barray);
                con.Open();
                int affrow = cmd.ExecuteNonQuery();
                if(affrow > 0 )
                {
                    lblmsg.Text = "you have inserted " + affrow + " row successfully .";
                    AddRows();
                }
            }
        }
    }
}