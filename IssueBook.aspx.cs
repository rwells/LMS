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

public partial class IssueBook : System.Web.UI.Page
{
    bool status = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_TYPE"] == null)
        {
            Response.Redirect("Logout.aspx");
        }
        if (Page.IsPostBack == false)
        {
            ReadBook();
            txtIDate.Text = DateTime.Now.ToShortDateString();
            if (Session["USER_TYPE"].ToString() == "A")
            {
                Panel2.Visible = false;
            }
            else
            {
                Panel3.Visible = false;
                //HSMember.Visible = false;
            }
        }
    }

    protected void LstBook_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        /*if (status == false)
        {
            btnGo_Click(sender, e);
            status = true;
        }*/
        //if (Page.IsPostBack == false)
        //{
            try
            {
                status = true;
                string Author, Publisher, Category, Supplier;
                int AQuantity = 0;

                if (LstBook.SelectedItem.ToString() == "")
                {
                    lblEMsg.Visible = true;
                    lblEMsg.Text = "Please select the Book";
                    return;
                }
                string sql = "SELECT Book_Title, Author_ID, Publisher_ID, Category_ID, Supplier_ID, Quantity, Price FROM Book_Master WHERE Book_ID = '" + LstBook.SelectedItem.ToString() + "' And Status = 'A'";
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

                    AQuantity = Convert.ToInt32(sdr["Quantity"]);
                    txtPrice.Text = sdr["Price"].ToString().Trim();

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
                    //sdr.Close;

                    //Get Supplier Name
                    sql = "Select Distinct Supplier_Name From Supplier Where Supplier_ID = '" + Supplier + "'";
                    sdr = pro.ReturnMDetails(sql);
                    if (sdr.Read() == true)
                    {
                        txtSup.Text = sdr["Supplier_Name"].ToString().Trim();
                    }
                    //sdr.Close;

                    sql = "Select Count(1) From Book_Transaction Where Book_ID = '" + LstBook.SelectedItem.Text + "' And Actual_Return_Date Is Null";
                    sdr = pro.ReturnMDetails(sql);
                    if (sdr.Read() == true)
                    {
                        AQuantity -= (int)sdr[0];
                    }
                }
                sdr.Close();
                txtQuantity.Text = Convert.ToString(AQuantity);
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
       // }
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        DropDownList1.Text = "";
        LstBook.Text = "";
        txtBTitle.Text = "";
        txtAuthor.Text = "";
        txtPub.Text = "";
        txtCat.Text = "";
        txtSup.Text = "";
        txtQuantity.Text = "";
        txtPrice.Text = "";
        txtRDate.Text = "";
        Label9.Text = "";
    }
    protected void btnCal_Click(object sender, EventArgs e)
    {
        //btnCal.Visible = false;
        Calendar1.Visible = true;
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        if (Convert.ToDateTime(txtIDate.Text) > Convert.ToDateTime(Calendar1.SelectedDate.ToString()))
        {
            lblEMsg.Visible = true;
            lblEMsg.Text = "Return date should be greater then Issue Date.";
            return;
        }
        txtRDate.Text = Calendar1.SelectedDate.ToShortDateString();
        Calendar1.Visible = false;
        //btnIssue.Focus();
    }
    private void ReadBook()
    {
        try
        {
            SqlDataReader sdr;
            Profile pro = new Profile();

            string sql = "SELECT Distinct Member_ID FROM Member where Status = 'A'";
            sdr = pro.ReturnMDetails(sql);

            DropDownList1.Items.Add("");
            while (sdr.Read())
            {
                DropDownList1.Items.Add(sdr["Member_ID"].ToString().Trim());
            }
            sdr.Close();

            sql = "SELECT Distinct Book_ID FROM Book_Master where Status = 'A'";
            sdr = pro.ReturnMDetails(sql);

            LstBook.Items.Add("");
            while (sdr.Read() )
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        Label9.Visible = false;
        try
        {
            if (DropDownList1.SelectedItem.ToString() == "")
            {
                lblEMsg.Visible = true;
                lblEMsg.Text = "Please select the Member";
                return;
            }
            string sql = "SELECT First_Name, Middle_Name, Last_Name FROM Member WHERE Member_ID = '" + DropDownList1.SelectedItem.ToString() + "' And Status = 'A'";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);
            if (sdr.Read() == true)
            {
                Label9.Visible = true;
                Label9.Text = sdr["First_Name"].ToString().Trim() + " " + sdr["Middle_Name"].ToString().Trim() + " " + sdr["Last_Name"].ToString().Trim();
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
    protected void btnIssue_Click(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        string[] iBook;
        try
        {
            SqlDataReader sdr;
            Profile pro = new Profile();

            int aQty = Convert.ToInt32(txtQuantity.Text.ToString());
            if (aQty == 0)
            {
                lblEMsg.Visible = true;
                lblEMsg.Text = "This book is Out of stock, please select a different book.";
                return;
            }
            
            string sql = "SELECT Count(1) FROM Book_Transaction WHERE Book_ID = '" + LstBook.SelectedItem.Text + "' And Member_ID = '" + DropDownList1.SelectedItem.Text  + "' And Actual_Return_Date Is Null";
            sdr = pro.ReturnMDetails(sql);
            sdr.Read();
            int iB = (int)sdr[0];
            if (iB > 0)
            {
                lblEMsg.Visible = true;
                lblEMsg.Text = "This book is already issued, please select a different book.";
                return;
            }
            sdr.Close();

            //Insert the data.
            iBook = new string[4];

            iBook[0] = LstBook.SelectedItem.Text;
            iBook[1] = DropDownList1.SelectedItem.Text;
            iBook[2] = txtIDate.Text;
            iBook[3] = txtRDate.Text;
            
            bool status;
            status = pro.IssueBook(iBook);

            if (status == false)
            {
                lblEMsg.Visible = true;
                lblEMsg.Text = "Book Issuing Failed";
            }
            lblEMsg.Visible = true;
            lblEMsg.Text = "Book Issued.";
            DropDownList1.Text = "";
            LstBook.Text = "";
            txtBTitle.Text = "";
            txtAuthor.Text = "";
            txtPub.Text = "";
            txtCat.Text = "";
            txtSup.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
            txtRDate.Text = "";
            Label9.Text = "";
            return;
        }
        catch (Exception ex)
        {
            lblEMsg.Visible = true;
            lblEMsg.Text = ex.Message;
        }

    }
}
