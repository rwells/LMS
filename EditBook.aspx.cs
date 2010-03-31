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

public partial class EditBook : System.Web.UI.Page
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
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtBTitle.Text = "";
        LstAuthor.Text = "";
        LstCategory.Text = "";
        LstPublisher.Text = "";
        LstSupplier.Text = "";
        txtKey.Text = "";
        txtIsbn.Text = "";
        txtQuantity.Text = "";
        txtPrice.Text = "";
        chkStatus.Checked = false;
        lblEMsg.Visible = false;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        string[] Book;
        Profile pro = new Profile();
        string Author_ID, Publisher_ID, Category_ID, Supplier_ID;
        try
        {
            if (lstbook.SelectedItem.Text == "")
            {
                lblEMsg.Text = "Please select Book ID";
                lblEMsg.Visible = true;
            }
            else
            {
                string sql;
                
                //Retrieve Author ID.
                sql = "SELECT Author_ID FROM Author WHERE Author_Name = '" + LstAuthor.SelectedItem.Text + "'";
                Author_ID = ReturnData(sql);
                
                //Retrieve Publisher ID.
                sql = "SELECT Publisher_ID FROM Publisher WHERE Publisher_Name = '" + LstPublisher.SelectedItem.Text + "'";
                Publisher_ID = ReturnData(sql);
                
                //Retrieve Category ID.
                sql = "SELECT Category_ID FROM Category WHERE Category_Name = '" + LstCategory.SelectedItem.Text + "'";
                Category_ID= ReturnData(sql);
                
                //Retrieve Supplier ID.
                sql = "SELECT Supplier_ID FROM Supplier WHERE Supplier_Name = '" + LstSupplier.SelectedItem.Text + "'";
                Supplier_ID= ReturnData(sql);
                
                Book = new string[15];

                Book[0] = lstbook.SelectedItem.Text;
                Book[1] = txtBTitle.Text;
                Book[2] = Author_ID;
                Book[3] = Publisher_ID;
                Book[4] = Category_ID;
                Book[5] = Supplier_ID;
                Book[6] = txtKey.Text;
                Book[7] = txtIsbn.Text;
                Book[8] = txtQuantity.Text;
                Book[9] = txtPrice.Text;
                if (chkStatus.Checked == true)
                {
                    Book[10] = "A";
                }
                else
                {
                    Book[10] = "D";
                }

                bool status;
                status = pro.Books(Book,"UpdateBook");

                if (status == false)
                {
                    lblEMsg.Visible = true;
                    lblEMsg.Text = "Book updation Failed";
                }
                lblEMsg.Visible = true;
                lblEMsg.Text = "Book updated.";

                ReadBook();
                lstbook.Text = "";
                txtBTitle.Text = "";
                LstAuthor.Text = "";
                LstCategory.Text = "";
                LstPublisher.Text = "";
                LstSupplier.Text = "";
                txtKey.Text = "";
                txtIsbn.Text = "";
                txtQuantity.Text = "";
                txtPrice.Text = "";
                chkStatus.Checked = false;
                lblEMsg.Visible = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        Profile pro = new Profile();

        try
        {
            if (lstbook.SelectedItem.ToString() == "")
            {
                lblEMsg.Text = "Please select Book No";
                lblEMsg.Visible = true;
            }
            else
            {
                bool status;
                status = pro.DeleteBook(lstbook.SelectedItem.ToString());

                if (status == false)
                {
                    lblEMsg.Visible = true;
                    lblEMsg.Text = "Book deletion Failed";
                }
                lblEMsg.Visible = true;
                lblEMsg.Text = "Book deleted.";

                lstbook.Items.Clear();

                //Load all the Publisher First.
                string sql = "SELECT Book_ID FROM Book_Master where Status = 'A'";
                SqlDataReader sdr;
                sdr = pro.ReturnMDetails(sql);
                lstbook.Items.Add("");
                while (sdr.Read())
                {
                    lstbook.Items.Add(sdr["Book_ID"].ToString().Trim());
                }
                sdr.Close();
                txtBTitle.Text = "";
                LstAuthor.Text = "";
                LstCategory.Text = "";
                LstPublisher.Text = "";
                LstSupplier.Text = "";
                txtKey.Text = "";
                txtIsbn.Text = "";
                txtQuantity.Text = "";
                txtPrice.Text = "";
                chkStatus.Checked = false;
                lblEMsg.Visible = false;
            }
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
            string sql = "SELECT Distinct Book_ID FROM Book_Master Where Status = 'A'";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);
            lstbook.Items.Clear();
            lstbook.Items.Add("");
            while (sdr.Read())
            {
                lstbook.Items.Add(sdr["Book_ID"].ToString().Trim());
            }
            sdr.Close();

            //Retrieve Author Details
            sql = "SELECT Distinct Author_Name FROM Author Where Status = 'A'";
            sdr = pro.ReturnMDetails(sql);
            LstAuthor.Items.Clear();
            LstAuthor.Items.Add("");
            while (sdr.Read())
            {
                LstAuthor.Items.Add(sdr["Author_Name"].ToString().Trim());
            }
            sdr.Close();

            //Retrieve Publisher Details
            sql = "SELECT Distinct Publisher_Name FROM Publisher Where Status = 'A'";
            sdr = pro.ReturnMDetails(sql);
            LstPublisher.Items.Clear();
            LstPublisher.Items.Add("");
            while (sdr.Read())
            {
                LstPublisher.Items.Add(sdr["Publisher_Name"].ToString().Trim());
            }
            sdr.Close();

            //Retrieve Category Details
            sql = "SELECT Distinct Category_Name FROM Category Where Status = 'A'";
            sdr = pro.ReturnMDetails(sql);
            LstCategory.Items.Clear();
            LstCategory.Items.Add("");
            while (sdr.Read())
            {
                LstCategory.Items.Add(sdr["Category_Name"].ToString().Trim());
            }
            sdr.Close();

            //Retrieve Supplier Details
            sql = "SELECT Distinct Supplier_Name FROM Supplier Where Status = 'A'";
            sdr = pro.ReturnMDetails(sql);
            LstSupplier.Items.Clear();
            LstSupplier.Items.Add("");
            while (sdr.Read())
            {
                LstSupplier.Items.Add(sdr["Supplier_Name"].ToString().Trim());
            }
            sdr.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    protected void btnGo_Click(object sender, EventArgs e)
    {
        
    }
    private string ReturnData(string sql)
    {
        SqlDataReader sdr;
        Profile pro = new Profile();
        sdr = pro.ReturnMDetails(sql);
        if (sdr.Read() == true)
        {
            return sdr[0].ToString();
        }
        else
        {
            return "";
        }
    }
    
    protected void lstbook_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            status = true;
            string Author, Publisher, Category, Supplier;
            if (lstbook.SelectedItem.ToString() == "")
            {
                lblEMsg.Visible = true;
                lblEMsg.Text = "Please select the Book";
                return;
            }
            string sql = "SELECT Book_Title, Author_ID, Publisher_ID, Category_ID, Supplier_ID, Key_Word, ISBN, Quantity, Price, Status FROM Book_Master WHERE Book_ID = '" + lstbook.SelectedItem.ToString() + "'";
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

                txtKey.Text = sdr["Key_Word"].ToString().Trim();
                txtIsbn.Text = sdr["ISBN"].ToString().Trim();
                txtQuantity.Text = sdr["Quantity"].ToString().Trim();
                txtPrice.Text = sdr["Price"].ToString().Trim();
                chkStatus.Checked = true;

                //Get Author Name.
                sql = "Select Distinct Author_Name From Author Where Author_ID = '" + Author + "'";
                sdr = pro.ReturnMDetails(sql);
                if (sdr.Read() == true)
                {
                    LstAuthor.Text = sdr["Author_Name"].ToString().Trim();
                }
                //sdr.Close;

                //Get Publisher_Name
                sql = "Select Distinct Publisher_Name From Publisher Where Publisher_ID = '" + Publisher + "'";
                sdr = pro.ReturnMDetails(sql);
                if (sdr.Read() == true)
                {
                    LstPublisher.Text = sdr["Publisher_Name"].ToString().Trim();
                }
                //sdr.Close;

                //Get Category Name
                sql = "Select Distinct Category_Name From Category Where Category_ID = '" + Category + "'";
                sdr = pro.ReturnMDetails(sql);
                if (sdr.Read() == true)
                {
                    LstCategory.Text = sdr["Category_Name"].ToString().Trim();
                }
                //sdr.Close;

                //Get Supplier Name
                sql = "Select Distinct Supplier_Name From Supplier Where Supplier_ID = '" + Supplier + "'";
                sdr = pro.ReturnMDetails(sql);
                if (sdr.Read() == true)
                {
                    LstSupplier.Text = sdr["Supplier_Name"].ToString().Trim();
                }
                //sdr.Close;
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
}
