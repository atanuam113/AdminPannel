using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace AdminPannel
{
    public partial class Index : System.Web.UI.Page
    {
        String connectionString = @"Data Source=DESKTOP-539AVIS\SQLEXPRESS;Integrated Security=true;Initial Catalog=EmployeeDetails";
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateData();
                InitialRow();
            }
        }


        private void InitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("txtFullName", typeof(string)));
            dt.Columns.Add(new DataColumn("txtEmail", typeof(string)));
            dt.Columns.Add(new DataColumn("txtPhone", typeof(string)));

            dr = dt.NewRow();
            dr["txtFullName"] = string.Empty;
            dr["txtEmail"] = string.Empty;
            dr["txtPhone"] = string.Empty;
            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;
            gvContacts.DataSource = dt;
            gvContacts.DataBind();
        }

        //Show Data From database
        private void PopulateData()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Emp_Contact_Details", sqlCon);
                sqlCon.Open();
                DataTable dt1 = new DataTable();
                dt1.Load(cmd.ExecuteReader());
                ViewState["CurrentTable"] = dt1;
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                
            }
        }


        //private void AddRows()
        //{
        //    List<int> NoOfRows = new List<int>();
        //    //int rows;
        //    ////String CurrentRowNumber = gvContacts.Rows[e.RowIndex].FindControl("")
        //    //String RowNo = gvContacts.SelectedIndex.ToString();
        //    //String rn = gvContacts.SelectedRow.RowIndex.ToString();
        //    ////int.TryParse(RowNo.Text.Trim(), out rows);
        //    //rows = Int32.Parse(rn);
        //    //for (int i = 1; i < 2; i++)
        //    //{
        //    //    NoOfRows.Add(i);
        //    //}
        //    gvContacts.DataSource = NoOfRows;
        //    gvContacts.DataBind();
        //    ViewState["CurrentTable"] = NoOfRows;

        //    //if (gvContacts.Rows.Count > 0)
        //    //{
        //    //    Panel1.Visible = true;
        //    //}
        //    //else
        //    //{
        //    //    Panel1.Visible = false;
        //    //}
        //    //classvariable = rows;
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);
            TextBox txtFullName;
            TextBox txtEmail;
            TextBox txtPhone;
            int NoOfRows = 1;
            foreach (GridViewRow row in gvContacts.Rows)
            {
                txtFullName = (TextBox)row.FindControl("txtFullName");
                txtEmail = (TextBox)row.FindControl("txtEmail");
                txtPhone = (TextBox)row.FindControl("txtPhone");

                if (txtFullName == null || txtEmail == null || txtPhone == null)
                {
                    return;
                }

                if (string.IsNullOrEmpty(txtEmail.Text.Trim())
                   || string.IsNullOrEmpty(txtEmail.Text.Trim())
                   || string.IsNullOrEmpty(txtPhone.Text.Trim()))
                {
                    lblmsg.Text = "All fields are Required";
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert_Bulk_Data", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@E_Name", txtFullName.Text.ToString());
                    cmd.Parameters.AddWithValue("@E_Email", txtEmail.Text.ToString());
                    cmd.Parameters.AddWithValue("@E_Phone", txtPhone.Text.ToString());
       
                    cmd.ExecuteNonQuery();
                   
                    SetToEmptyGridView();
                    InitialRow();
                    PopulateData();
                    
                    con.Close();

                }
                NoOfRows++;
            }
            
            Response.Redirect("Index.aspx");
            lblmsg.ForeColor = System.Drawing.Color.Blue;
            lblmsg.Text = "you have inserted  row successfully .";
        }
        //Clear DataTable from Gridview
        private void SetToEmptyGridView()
        {
           DataTable dt = (DataTable)ViewState["CurrentTable"];
            ViewState["CurrentTable"] = null;
            gvContacts.DataSource = null;
            gvContacts.DataBind();
        }


        //Login Out Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
     

        //protected void AddRow_Click()
        //{
        //    Int32 index = gvContacts.Rows.Count;
        //    List<int> Allrows = new List<int>();
        //    for(int i=0;i<= index;i++)
        //    {
        //        Allrows.Add(i);
        //    }
        //    gvContacts.DataSource = Allrows;
        //    gvContacts.DataBind();
        //    if (gvContacts.Rows.Count > 0)
        //    {
        //        Panel1.Visible = true;
                
        //    }
        //    else
        //    {
        //        Panel1.Visible = false;
        //    }
        //    SetPreviousData();
        //}

        protected void gvContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //AddRow_Click();
            AddNewRow_Click();
        }

        private void AddNewRow_Click()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)

            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)

                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)

                    {

                        //extract the TextBox values

                        TextBox box1 = (TextBox)gvContacts.Rows[rowIndex].Cells[0].FindControl("txtFullName");

                        TextBox box2 = (TextBox)gvContacts.Rows[rowIndex].Cells[1].FindControl("txtEmail");

                        TextBox box3 = (TextBox)gvContacts.Rows[rowIndex].Cells[2].FindControl("txtPhone");



                        drCurrentRow = dtCurrentTable.NewRow();

                        //drCurrentRow["SlNo"] = i + 1;



                        dtCurrentTable.Rows[i - 1]["txtFullName"] = box1.Text;

                        dtCurrentTable.Rows[i - 1]["txtEmail"] = box2.Text;

                        dtCurrentTable.Rows[i - 1]["txtPhone"] = box3.Text;
                        rowIndex++;

                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable"] = dtCurrentTable;



                    gvContacts.DataSource = dtCurrentTable;

                    gvContacts.DataBind();

                }

            }

            else

            {

                Response.Write("ViewState is null");

            }
            //Set Previous Data on Postbacks

            SetPreviousData();
        }

        private void SetPreviousData()

        {

            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)

            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];

                if (dt.Rows.Count > 0)

                {

                    for (int i = 1; i <= dt.Rows.Count; i++)

                    {

                        TextBox box1 = (TextBox)gvContacts.Rows[rowIndex].Cells[0].FindControl("txtFullName");

                        TextBox box2 = (TextBox)gvContacts.Rows[rowIndex].Cells[1].FindControl("txtEmail");

                        TextBox box3 = (TextBox)gvContacts.Rows[rowIndex].Cells[2].FindControl("txtPhone");

                        box1.Text = dt.Rows[i - 1]["txtFullName"].ToString();

                        box2.Text = dt.Rows[i - 1]["txtEmail"].ToString();

                        box3.Text = dt.Rows[i - 1]["txtPhone"].ToString();

                        rowIndex++;

                    }

                }

            }

        }



    }
}