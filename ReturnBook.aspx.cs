using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class ReceiptBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_TYPE"] == null)
        {
            Response.Redirect("Logout.aspx");
        }
        if (Page.IsPostBack == false)
        {
            ReadBook();
            txtARDate.Text = DateTime.Now.ToShortDateString();
             if (Session["USER_TYPE"].ToString() == "A")
             {
                 Panel2.Visible = false;
             }
             else
             {
                 Panel3.Visible = false;
             }
        }
    }
   
    protected void LstBook_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        try
        {
            string Author, Publisher, Category, Supplier;
            
            if (LstBook.SelectedItem.ToString() == "")
            {
                lblEMsg.Visible = true;
                lblEMsg.Text = "Please select the Book";
                return;
            }
            string sql = "SELECT Book_Title, Author_ID, Publisher_ID, Category_ID, Supplier_ID FROM Book_Master WHERE Book_ID = '" + LstBook.SelectedItem.ToString() + "' And Status = 'A'";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);

            if (sdr.Read() == true)
            {
                txtBTitle.Text = sdr["Book_Title"].ToString().Trim();

                Author = sdr["Author_ID"].ToString().Trim();
                Publisher = sdr["Publisher_ID"].ToString().Trim();
                Category = sdr["Category_ID"].ToString().Trim();
                Supplier = sdr["Supplier_ID"].ToString().Trim();

                //Get Author Name.
                sql = "Select Distinct Author_Name From Author Where Author_ID = '" + Author + "'";
                sdr = pro.ReturnMDetails(sql);
                if (sdr.Read() == true)
                {
                    txtAuthor.Text = sdr["Author_Name"].ToString().Trim();
                }
                //sdr.Close;

                //Get Publisher_Name
                sql = "Select Distinct Publisher_Name From Publisher Where Publisher_ID = '" + Publisher + "'";
                sdr = pro.ReturnMDetails(sql);
                if (sdr.Read() == true)
                {
                    txtPub.Text = sdr["Publisher_Name"].ToString().Trim();
                }
                //sdr.Close;

                //Get Category Name
                sql = "Select Distinct Category_Name From Category Where Category_ID = '" + Category + "'";
                sdr = pro.ReturnMDetails(sql);
                if (sdr.Read() == true)
                {
                    txtCat.Text = sdr["Category_Name"].ToString().Trim();
                }
                
                //Get Supplier Name
                sql = "Select Distinct Supplier_Name From Supplier Where Supplier_ID = '" + Supplier + "'";
                sdr = pro.ReturnMDetails(sql);
                if (sdr.Read() == true)
                {
                    txtSup.Text = sdr["Supplier_Name"].ToString().Trim();
                }
            }
            sdr.Close();

            //Get Issue Date & Return Date.
            DateTime rDate, arDate;
            sql = "SELECT Issue_Date, Return_Date FROM Book_Transaction WHERE Member_ID = '" + lstMember.SelectedItem.ToString() + "' And Book_ID = '" + LstBook.SelectedItem.Text + "' And Actual_Return_Date is Null";
            sdr = pro.ReturnMDetails(sql);
            if (sdr.Read() == true)
            {
                txtIDate.Text = sdr["Issue_Date"].ToString().Trim();
                txtRDate.Text = sdr["Return_Date"].ToString().Trim();
                rDate = Convert.ToDateTime(sdr["Return_Date"].ToString().Trim());
                
                arDate = Convert.ToDateTime(txtARDate.Text);
                if (rDate < arDate)
                {

                    TimeSpan dDiff;
                    dDiff = arDate.Subtract(rDate);
                    txtLFee.Text = Convert.ToString(Convert.ToInt32(dDiff.Days) * 10);
                }
                else
                {
                    txtLFee.Text = "0";
                }
            }
            sdr.Close();
            
            //Check if any book is issued for this member.
            sql = "SELECT Count(1) FROM Book_Transaction WHERE Member_ID = '" + lstMember.SelectedItem.ToString() + "' And Book_ID = '" + LstBook.SelectedItem.Text + "' And Actual_Return_Date is Null";
            sdr = pro.ReturnMDetails(sql);
            sdr.Read();
            int iB = (int)sdr[0];
            if (iB == 0)
            {
                lblEMsg.Visible = true;
                lblEMsg.Text = "No Book is issued for this member, please select the correct member";
                return;
            }
            sdr.Close();
            return;
        }
        catch (NullReferenceException nex)
        {
            lblEMsg.Visible = true;
            lblEMsg.Text = "Please select the Book";
            return;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        lstMember.Text = "";
        LstBook.Text = "";
        txtBTitle.Text = "";
        txtAuthor.Text = "";
        txtPub.Text = "";
        txtCat.Text = "";
        txtSup.Text = "";
        txtIDate.Text = "";
        txtRDate.Text = "";
        lblName.Text = "";
        lblEMsg.Text = "";
    }
    protected void lstMember_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        lblName.Visible = false;
        try
        {
            if (lstMember.SelectedItem.ToString() == "")
            {
                lblEMsg.Visible = true;
                lblEMsg.Text = "Please select the Member";
                return;
            }
            string sql = "SELECT First_Name, Middle_Name, Last_Name FROM Member WHERE Member_ID = '" + lstMember.SelectedItem.ToString() + "' And Status = 'A'";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);
            if (sdr.Read() == true)
            {
                lblName.Visible = true;
                lblName.Text = sdr["First_Name"].ToString().Trim() + " " + sdr["Middle_Name"].ToString().Trim() + " " + sdr["Last_Name"].ToString().Trim();
            }
            sdr.Close();

            //Check if any book is issued for this member.
            sql = "SELECT Count(1) FROM Book_Transaction WHERE Member_ID = '" + lstMember.SelectedItem.ToString() + "' And Actual_Return_Date is Null";
            sdr = pro.ReturnMDetails(sql);
            sdr.Read();
            int iB = (int)sdr[0];
            if (iB == 0)
            {
                lblEMsg.Visible = true;
                lblEMsg.Text = "No Book is issued for this member, please select the correct member";
                lstMember.Text = "";
                lblName.Text = "";
                return;
            }
            sdr.Close();
            return;
        }
        catch (NullReferenceException nex)
        {
            lblEMsg.Visible = true;
            lblEMsg.Text = "Please select the Member";
            return;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void ReadBook()
    {
        try
        {
            SqlDataReader sdr;
            Profile pro = new Profile();

            string sql = "SELECT Distinct Member_ID FROM Member where Status = 'A'";
            sdr = pro.ReturnMDetails(sql);

            lstMember.Items.Add("");
            while (sdr.Read())
            {
                lstMember.Items.Add(sdr["Member_ID"].ToString().Trim());
            }
            sdr.Close();

            sql = "SELECT Distinct Book_ID FROM Book_Master where Status = 'A'";
            sdr = pro.ReturnMDetails(sql);

            LstBook.Items.Add("");
            while (sdr.Read())
            {
                LstBook.Items.Add(sdr["Book_ID"].ToString().Trim());
            }
            sdr.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        string[] iBook;
        try
        {
            SqlDataReader sdr;
            Profile pro = new Profile();

            //Check if any book is issued for this member.
            string sql = "SELECT Count(1) FROM Book_Transaction WHERE Member_ID = '" + lstMember.SelectedItem.ToString() + "' And Book_ID = '" + LstBook.SelectedItem.Text + "' And Actual_Return_Date is Null";
            sdr = pro.ReturnMDetails(sql);
            sdr.Read();
            int iB = (int)sdr[0];
            if (iB == 0)
            {
                lblEMsg.Visible = true;
                lblEMsg.Text = "No Book is issued for this member, please select the correct member";
                return;
            }
            sdr.Close();

            //Insert the data.
            iBook = new string[4];

            iBook[0] = LstBook.SelectedItem.Text;
            iBook[1] = lstMember.SelectedItem.Text;
            iBook[2] = txtARDate.Text;
            iBook[3] = txtLFee.Text;

            bool status;
            status = pro.ReturnBook(iBook);

            if (status == false)
            {
                lblEMsg.Visible = true;
                lblEMsg.Text = "Book Returning Failed";
            }
            lblEMsg.Visible = true;
            lblEMsg.Text = "Book Returned.";
            lstMember.Text = "";
            LstBook.Text = "";
            txtBTitle.Text = "";
            txtAuthor.Text = "";
            txtPub.Text = "";
            txtCat.Text = "";
            txtSup.Text = "";
            txtRDate.Text = "";
            txtIDate.Text = "";
            lblName.Text = "";
            txtLFee.Text = "";
            return;
        }
        catch (Exception ex)
        {
            lblEMsg.Visible = true;
            lblEMsg.Text = ex.Message;
        }

    }
}
