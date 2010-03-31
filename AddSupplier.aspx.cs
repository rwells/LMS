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

public partial class AddSupplier : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_TYPE"] == null)
        {
            Response.Redirect("Logout.aspx");
        }
        if (Page.IsPostBack == false)
        {
            ReadSupplier();
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
        string[] Supp;
        try
        {
            string sql = "SELECT COUNT(*) FROM SUPPLIER WHERE SUPPLIER_NAME = '" + txtSName.Text + "' And Status = 'A'";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);

            sdr.Read();
            int RegNo = (int)sdr[0];
            if (RegNo > 0)
            {
                lblEMsg.Text = "Supplier Name already exists.";
                lblEMsg.Visible = true;
                sdr.Close();
                return;
            }
            else
            {
                Supp = new string[15];

                Supp[0] = txtSupplier.Text;
                Supp[1] = txtSName.Text;
                Supp[2] = txtAdd.Text;
                Supp[3] = txtPhone.Text;
                Supp[4] = txtFax.Text;
                Supp[5] = txtemail.Text;
                if (chkStatus.Checked == true)
                {
                    Supp[6] = "A";
                }
                else
                {
                    Supp[7] = "I";
                }

                bool status;
                status = pro.AddSupplier(Supp);

                if (status == false)
                {
                    lblEMsg.Visible = true;
                    lblEMsg.Text = "Supplier creation Failed";
                }
                lblEMsg.Visible = true;
                lblEMsg.Text = "Supplier added.";
                ReadSupplier();
                txtSName.Text = "";
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
    private void ReadSupplier()
    {
        try
        {
            string sql = "SELECT COUNT(*) FROM SUPPLIER";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);

            sdr.Read();
            int Supp = (int)sdr[0] + 1;
            if (Supp < 10)
            {
                txtSupplier.Text = string.Format("S000{0}", Supp);
            }
            else if (Supp > 10 && Supp < 100)
            {
                txtSupplier.Text = string.Format("S00{0}", Supp);
            }
            else
            {
                txtSupplier.Text = string.Format("S0{0}", Supp);
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
        txtSName.Text = "";
        txtAdd.Text = "";
        txtPhone.Text = "";
        txtFax.Text = "";
        txtemail.Text = "";
        chkStatus.Checked = false;
        lblEMsg.Visible = false;
    }
}
