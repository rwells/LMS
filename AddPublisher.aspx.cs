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

public partial class AddPublisher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_TYPE"] == null)
        {
            Response.Redirect("Logout.aspx");
        }
        if (Page.IsPostBack == false)
        {
            ReadPublisher();
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
        string[] Pub;
        try
        {
            string sql = "SELECT COUNT(*) FROM Publisher WHERE Publisher_NAME = '" + txtPName.Text + "' And Publishing_Year ='" + txtPYear.Text + "' And Publisher_Edition = '" + txtPEdition.Text + "' And Status = 'A'" ;
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);

            sdr.Read();
            int RegNo = (int)sdr[0];
            if (RegNo > 0)
            {
                lblEMsg.Text = "Publisher Name already exists.";
                lblEMsg.Visible = true;
                sdr.Close();
                return;
            }
            else
            {
                Pub = new string[15];

                Pub[0] = txtPublisher.Text;
                Pub[1] = txtPName.Text;
                Pub[2] = txtPYear.Text;
                Pub[3] = txtPHouse.Text;
                Pub[4] = txtPEdition.Text;
                Pub[5] = txtAdd.Text;
                Pub[6] = txtPhone.Text;
                Pub[7] = txtFax.Text;
                Pub[8] = txtemail.Text;
                if (chkStatus.Checked == true)
                {
                    Pub[9] = "A";
                }
                else
                {
                    Pub[9] = "I";
                }

                bool status;
                status = pro.AddPublisher(Pub);

                if (status == false)
                {
                    lblEMsg.Visible = true;
                    lblEMsg.Text = "Publisher creation Failed";
                }
                lblEMsg.Visible = true;
                lblEMsg.Text = "Publisher added.";
                ReadPublisher();
                txtPName.Text = "";
                txtPYear.Text = "";
                txtPHouse.Text = "";
                txtPEdition.Text = "";
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
    private void ReadPublisher()
    {
        try
        {
            string sql = "SELECT COUNT(*) FROM Publisher";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);

            sdr.Read();
            int Pub = (int)sdr[0] + 1;
            if (Pub < 10)
            {
                txtPublisher.Text = string.Format("P000{0}", Pub);
            }
            else if (Pub > 10 && Pub < 100)
            {
                txtPublisher.Text = string.Format("P00{0}", Pub);
            }
            else
            {
                txtPublisher.Text = string.Format("S0{0}", Pub);
            }
            sdr.Close();
            return;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtPName.Text = "";
        txtPYear.Text = "";
        txtPHouse.Text = "";
        txtPEdition.Text = "";
        txtAdd.Text = "";
        txtPhone.Text = "";
        txtFax.Text = "";
        txtemail.Text = "";
        chkStatus.Checked = false;
        lblEMsg.Visible = false;
    }
}
