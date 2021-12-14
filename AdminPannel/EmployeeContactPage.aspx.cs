using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace AdminPannel
{
    public partial class EmployeeContactPage : System.Web.UI.Page
    {
        public virtual string EmptyDataText { get; set; }
        string connectionString = @"Data Source=DESKTOP-539AVIS\SQLEXPRESS;Integrated Security=true;Initial Catalog=EmployeeDetails";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    PopulateGridview();
            //}

        }
        //void PopulateGridview()
        //{
        //    DataTable dtbl = new DataTable();
        //    using (SqlConnection sqlCon = new SqlConnection(connectionString))
        //    {
        //        sqlCon.Open();
        //        SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Emp_Contact_Details", sqlCon);
        //        sqlDa.Fill(dtbl);

        //    }
        //    if (dtbl.Rows.Count > 0)
        //    {
        //        EmpInformation.DataSource = dtbl;
        //        EmpInformation.DataBind();
        //    }
        //    else
        //    {
        //        dtbl.Rows.Add(dtbl.NewRow());
        //        EmpInformation.DataSource = dtbl;
        //        //EmpInformation.DataBind();
        //        EmpInformation.Rows[0].Cells.Clear();
        //        EmpInformation.Rows[0].Cells.Add(new TableCell());
        //        EmpInformation.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
        //        EmpInformation.Rows[0].Cells[0].Text = "No Data Found ..!";
        //        EmpInformation.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;

        //    }
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in EmpInformation.Rows)
            {
                //int EmpNo = Convert.ToInt32(row.Cells[0]);
                String EmpName = (EmpInformation.FooterRow.FindControl("txtFullNameFooter") as TextBox).Text.Trim();
                //FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim()

                String EmpEmail = (EmpInformation.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim();
                String EmpPhone = (EmpInformation.FooterRow.FindControl("txtPhoneNumberFooter") as TextBox).Text.Trim();
                UpdateRow(EmpName, EmpEmail, EmpPhone);
                //;
                //sqlCmd.Parameters.AddWithValue("@Email", ;
                //sqlCmd.Parameters.AddWithValue("@PhoneNumber", (EmpPersonalDetails.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim());
            }
            EmpInformation.DataBind();
        }
        private void UpdateRow(String EmpName,String EmpEmail, String EmpPhone)
        {
            SqlConnection con = new SqlConnection(connectionString);
            String UpdateQuery = @"INSERT INTO [dbo].[Emp_Contact_Details]
           ([E_Name]
           ,[E_Email]
           ,[E_Phone]) VALUES('" + EmpName + "','" + EmpEmail + "','" + EmpPhone + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(UpdateQuery,con);
            cmd.ExecuteNonQuery();
            Label2.Text = "Data Updated successfully";

        }
    }
}