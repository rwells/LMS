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

public partial class EditSupplier : System.Web.UI.Page
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
                string sql = "SELECT Supplier_ID FROM Supplier WHERE STATUS = 'A'";
                SqlDataReader sdr;
                Profile pro = new Profile();
                sdr = pro.ReturnMDetails(sql);

                while (sdr.Read())
                {
                    lstid.Items.Add(sdr["Supplier_ID"].ToString().Trim());
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
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtSName.Text = "";
        txtAdd.Text = "";
        txtPhone.Text = "";
        txtFax.Text = "";
        txtEmail.Text = "";
        chkStatus.Checked = false;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        Profile pro = new Profile();

        try
        {
            if (lstid.SelectedItem.Text == "")
            {
                lblEMsg.Text = "Please select Supplier ID";
                lblEMsg.Visible = true;
            }
            else
            {
                bool status;
                status = pro.DeleteSupplier(lstid.SelectedItem.Text);

                if (status == false)
                {
                    lblEMsg.Visible = true;
                    lblEMsg.Text = "Supplier deletion Failed";
                }
                lblEMsg.Visible = true;
                lblEMsg.Text = "Supplier deleted.";
                lstid.Items.Clear();

                //Load all the Category First.
                string sql = "SELECT Supplier_ID FROM Supplier Where Status ='A'";
                SqlDataReader sdr;

                sdr = pro.ReturnMDetails(sql);

                while (sdr.Read())
                {
                    lstid.Items.Add(sdr["Supplier_ID"].ToString().Trim());
                }
                sdr.Close();
                txtSName.Text = "";
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        string[] Supp;
        Profile pro = new Profile();
        try
        {
            if (lstid.SelectedItem.Text == "")
            {
                lblEMsg.Text = "Please select Supplier ID";
                lblEMsg.Visible = true;
            }
            else
            {
                Supp = new string[15];

                Supp[0] = lstid.Text;
                Supp[1] = txtSName.Text;
                Supp[2] = txtAdd.Text;
                Supp[3] = txtPhone.Text;
                Supp[4] = txtFax.Text;
                Supp[5] = txtEmail.Text;
                if (chkStatus.Checked == true)
                {
                    Supp[6] = "A";
                }
                else
                {
                    Supp[6] = "I";
                }

                bool status;
                status = pro.UpdateSupplier(Supp);

                if (status == false)
                {
                    lblEMsg.Visible = true;
                    lblEMsg.Text = "Supplier updation Failed";
                }
                lblEMsg.Visible = true;
                lblEMsg.Text = "Supplier updated.";

                //Load all the Category First.
                string sql = "SELECT Supplier_ID FROM Supplier";
                SqlDataReader sdr;
                sdr = pro.ReturnMDetails(sql);
                lstid.Items.Clear();
                while (sdr.Read())
                {
                    lstid.Items.Add(sdr["Supplier_ID"].ToString().Trim());
                }
                sdr.Close();
                return;
                //txtCName.Text = "";
                //txtcDesc.Text = "";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    protected void lstid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            status = true;
            if (lstid.SelectedItem.ToString() == "")
            {
                lblEMsg.Visible = true;
                lblEMsg.Text = "Please select the Supplier";
                return;
            }
            string sql = "SELECT Supplier_Name, Address, Phone, Fax, EMail, Status FROM Supplier WHERE Supplier_ID = '" + lstid.SelectedItem.ToString() + "'";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);

            if (sdr.Read() == true)
            {
                txtSName.Text = sdr["Supplier_Name"].ToString().Trim();
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
