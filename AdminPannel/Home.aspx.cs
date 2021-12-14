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
    public partial class Home : System.Web.UI.Page
    {
        String connectionString = @"Data Source=DESKTOP-539AVIS\SQLEXPRESS;Integrated Security=true;Initial Catalog=EmployeeDetails";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                PopulateGridview();
            }
        }
        void PopulateGridview()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM EmployeePersonalDetails", sqlCon);
                sqlDa.Fill(dtbl);

            }
            if (dtbl.Rows.Count > 0)
            {
                EmpPersonalDetails.DataSource = dtbl;
                EmpPersonalDetails.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                EmpPersonalDetails.DataSource = dtbl;
                EmpPersonalDetails.DataBind();
                EmpPersonalDetails.Rows[0].Cells.Clear();
                EmpPersonalDetails.Rows[0].Cells.Add(new TableCell());
                EmpPersonalDetails.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                EmpPersonalDetails.Rows[0].Cells[0].Text = "No Data Found ..!";
                EmpPersonalDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;

            }
        }

        protected void EmpPersonalDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO EmployeePersonalDetails (FirstName,LastName,Email,PhoneNumber) VALUES (@FirstName,@LastName,@Email,@PhoneNumber)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@FirstName", (EmpPersonalDetails.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@LastName", (EmpPersonalDetails.FooterRow.FindControl("txtLastNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Email", (EmpPersonalDetails.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@PhoneNumber", (EmpPersonalDetails.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        PopulateGridview();
                        lblSuccessMessage.Text = "New Record Added";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }

        }

        protected void EmpPersonalDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            EmpPersonalDetails.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void EmpPersonalDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            EmpPersonalDetails.EditIndex = -1;
            PopulateGridview();
        }

        protected void EmpPersonalDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE EmployeePersonalDetails SET FirstName=@FirstName,LastName=@LastName,Email=@Email,PhoneNumber=@PhoneNumber WHERE EmployeeId = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@FirstName", (EmpPersonalDetails.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", (EmpPersonalDetails.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", (EmpPersonalDetails.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@PhoneNumber", (EmpPersonalDetails.Rows[e.RowIndex].FindControl("txtPhoneNumber") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(EmpPersonalDetails.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    EmpPersonalDetails.EditIndex = -1;
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Updated";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void EmpPersonalDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM EmployeePersonalDetails WHERE EmployeeId = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(EmpPersonalDetails.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            Session["User"] = null;
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}