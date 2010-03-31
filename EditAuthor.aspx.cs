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

public partial class EditAuthor : System.Web.UI.Page
{
    bool status = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_TYPE"] == null)
        {
            Response.Redirect("Logout.aspx");
        }
        if (Page.IsPostBack == false & status == false)
        {
            try
            {
                if (Session["USER_TYPE"].ToString() == "A")
                {
                    Panel2.Visible = false;
                }
                else
                {
                    Panel3.Visible = false;
                }
                string sql = "SELECT Author_ID FROM Author WHERE STATUS = 'A'";
                SqlDataReader sdr;
                Profile pro = new Profile();
                sdr = pro.ReturnMDetails(sql);

                while (sdr.Read())
                {
                    lstid.Items.Add(sdr["Author_ID"].ToString().Trim());
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        string[] Auth;
        Profile pro = new Profile();
        try
        {
            if (lstid.SelectedItem.Text == "")
            {
                lblEMsg.Text = "Please select Author ID";
                lblEMsg.Visible = true;
            }
            else
            {
                Auth = new string[15];

                Auth[0] = lstid.Text;
                Auth[1] = txtAName.Text;
                Auth[2] = txtAdd.Text;
                Auth[3] = txtPhone.Text;
                Auth[4] = txtFax.Text;
                Auth[5] = txtEmail.Text;
                if (chkStatus.Checked == true)
                {
                    Auth[6] = "A";
                }
                else
                {
                    Auth[6] = "I";
                }

                bool status;
                status = pro.UpdateAuthor(Auth);

                if (status == false)
                {
                    lblEMsg.Visible = true;
                    lblEMsg.Text = "Author updation Failed";
                }
                lblEMsg.Visible = true;
                lblEMsg.Text = "Author updated.";

                //Load all the Category First.
                string sql = "SELECT Author_ID FROM Author";
                SqlDataReader sdr;
                sdr = pro.ReturnMDetails(sql);
                lstid.Items.Clear();
                while (sdr.Read())
                {
                    lstid.Items.Add(sdr["Author_ID"].ToString().Trim());
                }
                sdr.Close();
                txtAName.Text = "";
                txtAdd.Text = "";
                txtPhone.Text = "";
                txtFax.Text = "";
                txtEmail.Text = "";
                chkStatus.Checked = false;
                return;
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
            if (lstid.SelectedItem.Text == "")
            {
                lblEMsg.Text = "Please select Author ID";
                lblEMsg.Visible = true;
            }
            else
            {
                bool status;
                status = pro.DeleteAuthor(lstid.SelectedItem.Text);

                if (status == false)
                {
                    lblEMsg.Visible = true;
                    lblEMsg.Text = "Author deletion Failed";
                }
                lblEMsg.Visible = true;
                lblEMsg.Text = "Author deleted.";
                lstid.Items.Clear();

                //Load all the Category First.
                string sql = "SELECT Author_ID FROM Author Where Status ='A'";
                SqlDataReader sdr;

                sdr = pro.ReturnMDetails(sql);

                while (sdr.Read())
                {
                    lstid.Items.Add(sdr["Author_ID"].ToString().Trim());
                }
                sdr.Close();
                txtAName.Text = "";
                txtAdd.Text = "";
                txtPhone.Text = "";
                txtFax.Text = "";
                txtEmail.Text = "";
                chkStatus.Checked = false;
                return;

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
        txtEmail.Text = "";
        chkStatus.Checked = false;
    }
       
    protected void lstid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            status = true;
            if (lstid.SelectedItem.ToString() == "")
            {
                lblEMsg.Visible = true;
                lblEMsg.Text = "Please select the Author";
                return;
            }
            string sql = "SELECT Author_Name, Address, Phone, Fax, EMail, Status FROM Author WHERE Author_ID = '" + lstid.SelectedItem.ToString() + "'";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);

            if (sdr.Read() == true)
            {
                txtAName.Text = sdr["Author_Name"].ToString().Trim();
                txtAdd.Text = sdr["Address"].ToString().Trim();
                txtPhone.Text = sdr["Phone"].ToString().Trim();
                txtFax.Text = sdr["Fax"].ToString().Trim();
                txtEmail.Text = sdr["EMail"].ToString().Trim();
                chkStatus.Checked = true;
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
