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

public partial class AddAuthor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_TYPE"] == null)
        {
            Response.Redirect("Logout.aspx");
        }

        if (Page.IsPostBack == false)
        {
            ReadAuthor();
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
        string[] Auth;
        try
        {
            string sql = "SELECT COUNT(*) FROM Author WHERE Author_NAME = '" + txtAName.Text + "' And Status = 'A'";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);

            sdr.Read();
            int RegNo = (int)sdr[0];
            if (RegNo > 0)
            {
                lblEMsg.Text = "Author Name already exists.";
                lblEMsg.Visible = true;
                sdr.Close();
                return;
            }
            else
            {
                Auth = new string[15];

                Auth[0] = txtAuthor.Text;
                Auth[1] = txtAName.Text;
                Auth[2] = txtAdd.Text;
                Auth[3] = txtPhone.Text;
                Auth[4] = txtFax.Text;
                Auth[5] = txtemail.Text;
                if (chkStatus.Checked == true)
                {
                    Auth[6] = "A";
                }
                else
                {
                    Auth[7] = "I";
                }

                bool status;
                status = pro.AddAuthor(Auth);

                if (status == false)
                {
                    lblEMsg.Visible = true;
                    lblEMsg.Text = "Author creation Failed";
                }
                lblEMsg.Visible = true;
                lblEMsg.Text = "Author added.";
                ReadAuthor();
                txtAName.Text = "";
                txtAdd.Text = "";
                txtPhone.Text = "";
                txtFax.Text = "";
                txtemail.Text = "";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtAName.Text = "";
        txtAdd.Text = "";
        txtPhone.Text = "";
        txtFax.Text = "";
        txtemail.Text = "";
        chkStatus.Checked = false;
        lblEMsg.Visible = false;
    }
    private void ReadAuthor()
    {
        try
        {
            string sql = "SELECT COUNT(*) FROM Author";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);

            sdr.Read();
            int Auth = (int)sdr[0] + 1;
            if (Auth < 10)
            {
                txtAuthor.Text = string.Format("A000{0}", Auth);
            }
            else if (Auth >= 10 && Auth < 100)
            {
                txtAuthor.Text = string.Format("S00{0}", Auth);
            }
            else
            {
                txtAuthor.Text = string.Format("S0{0}", Auth);
            }
            sdr.Close();
            return;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
