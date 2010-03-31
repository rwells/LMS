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

public partial class AddBook : System.Web.UI.Page
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        string[] Book;
        string Author_ID, Publisher_ID, Category_ID, Supplier_ID;
        try
        {
            string sql;
            SqlDataReader sdr;
            Profile pro = new Profile();

            //Retrieve Author ID.
            sql = "SELECT Author_ID FROM Author WHERE Author_Name = '" + LstAuthor.SelectedItem.Text + "'";
            sdr = pro.ReturnMDetails(sql);
            if (sdr.Read() == true)
            {
                Author_ID = sdr["Author_ID"].ToString().Trim();
            }
            else
            {
                Author_ID = "";
            }
            sdr.Close();

            //Retrieve Publisher ID.
            sql = "SELECT Publisher_ID FROM Publisher WHERE Publisher_Name = '" + LstPublisher.SelectedItem.Text + "'";
            sdr = pro.ReturnMDetails(sql);
            if (sdr.Read() == true)
            {
                Publisher_ID = sdr["Publisher_ID"].ToString().Trim();
            }
            else
            {
                Publisher_ID = "";
            }
            sdr.Close();

            //Retrieve Category ID.
            sql = "SELECT Category_ID FROM Category WHERE Category_Name = '" + LstCategory.SelectedItem.Text + "'";
            sdr = pro.ReturnMDetails(sql);
            if (sdr.Read() == true)
            {
                Category_ID = sdr["Category_ID"].ToString().Trim();
            }
            else
            {
                Category_ID = "";
            }
            sdr.Close();

            //Retrieve Supplier ID.
            sql = "SELECT Supplier_ID FROM Supplier WHERE Supplier_Name = '" + LstSupplier.SelectedItem.Text + "'";
            sdr = pro.ReturnMDetails(sql);
            if (sdr.Read() == true)
            {
                Supplier_ID = sdr["Supplier_ID"].ToString().Trim();
            }
            else
            {
                Supplier_ID= "";
            }
            sdr.Close();

            sql = "SELECT COUNT(*) FROM Book_Master WHERE Book_Title = '" + txtBTitle.Text + "' And Author_ID ='" + Author_ID + "' And Publisher_ID = '" + Publisher_ID + "' And Status = 'A'";
            sdr = pro.ReturnMDetails(sql);

            sdr.Read();
            int RegNo = (int)sdr[0];
            if (RegNo > 0)
            {
                lblEMsg.Text = "Book Name already exists.";
                lblEMsg.Visible = true;
                sdr.Close();
                return;
            }
            else
            {
                Book = new string[15];

                Book[0] = txtBook.Text;
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
                    Book[10] = "I";
                }

                bool status;
                status = pro.Books(Book,"AddBook");

                if (status == false)
                {
                    lblEMsg.Visible = true;
                    lblEMsg.Text = "Book creation Failed";
                }
                lblEMsg.Visible = true;
                lblEMsg.Text = "Book added.";
                ReadBook();
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
    private void ReadBook()
    {
        try
        {
            string sql = "SELECT COUNT(*) FROM Book_Master";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);

            sdr.Read();
            int Book = (int)sdr[0] + 1;
            if (Book < 10)
            {
                txtBook.Text = string.Format("B000{0}", Book);
            }
            else if (Book >= 10 && Book < 100)
            {
                txtBook.Text = string.Format("B00{0}", Book);
            }
            else
            {
                txtBook.Text = string.Format("B0{0}", Book);
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
}
