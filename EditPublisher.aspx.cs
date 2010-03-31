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

public partial class EditPublisher : System.Web.UI.Page
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
                
                string sql = "SELECT Publisher_ID FROM Publisher WHERE STATUS = 'A'";
                SqlDataReader sdr;
                Profile pro = new Profile();
                sdr = pro.ReturnMDetails(sql);

                while (sdr.Read())
                {
                    lstid.Items.Add(sdr["Publisher_ID"].ToString().Trim());
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
        txtPName.Text = "";
        txtPYear.Text = "";
        txtPHouse.Text = "";
        txtPEdition.Text = "";
        txtAdd.Text = "";
        txtPhone.Text = "";
        txtFax.Text = "";
        txtemail.Text = "";
        chkStatus.Checked = false;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        Profile pro = new Profile();

        try
        {
            if (lstid.SelectedItem.ToString() == "")
            {
                lblEMsg.Text = "Please select Publisher ID";
                lblEMsg.Visible = true;
            }
            else
            {
                bool status;
                status = pro.DeletePublisher(lstid.SelectedItem.ToString());

                if (status == false)
                {
                    lblEMsg.Visible = true;
                    lblEMsg.Text = "Publisher deletion Failed";
                }
                lblEMsg.Visible = true;
                lblEMsg.Text = "Publisher deleted.";

                lstid.Items.Clear();

                //Load all the Publisher First.
                string sql = "SELECT Publisher_ID FROM Publisher where Status = 'A'";
                SqlDataReader sdr;

                sdr = pro.ReturnMDetails(sql);

                while (sdr.Read())
                {
                    lstid.Items.Add(sdr["Publisher_ID"].ToString().Trim());
                }
                sdr.Close();
                txtPName.Text = "";
                txtPYear.Text = "";
                txtPHouse.Text = "";
                txtPEdition.Text = "";
                txtAdd.Text = "";
                txtPhone.Text = "";
                txtFax.Text = "";
                txtemail.Text = "";
                chkStatus.Checked = true;
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        string[] Pub;
        Profile pro = new Profile();
        try
        {
            if (lstid.SelectedItem.Text == "")
            {
                lblEMsg.Text = "Please select Publisher ID";
                lblEMsg.Visible = true;
            }
            else
            {
                Pub = new string[15];

                Pub[0] = lstid.Text;
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
                    Pub[9] = "D";
                }

                bool status;
                status = pro.UpdatePublisher(Pub);

                if (status == false)
                {
                    lblEMsg.Visible = true;
                    lblEMsg.Text = "Publisher updation Failed";
                }
                lblEMsg.Visible = true;
                lblEMsg.Text = "Publisher updated.";

                //Load all the Category First.
                string sql = "SELECT Publisher_ID FROM Publisher";
                SqlDataReader sdr;
                sdr = pro.ReturnMDetails(sql);
                lstid.Items.Clear();
                while (sdr.Read())
                {
                    lstid.Items.Add(sdr["Publisher_ID"].ToString().Trim());
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
                lblEMsg.Text = "Please select the Publisher";
                return;
            }
            string sql = "SELECT Publisher_Name, Publishing_Year, Publishing_House, Publisher_Edition, Address, Phone, Fax, EMail, Status FROM Publisher WHERE Publisher_ID = '" + lstid.SelectedItem.ToString() + "'";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);

            if (sdr.Read() == true)
            {
                txtPName.Text = sdr["Publisher_Name"].ToString().Trim();
                txtPYear.Text = sdr["Publishing_Year"].ToString().Trim();
                txtPHouse.Text = sdr["Publishing_House"].ToString().Trim();
                txtPEdition.Text = sdr["Publisher_Edition"].ToString().Trim();
                txtAdd.Text = sdr["Address"].ToString().Trim();
                txtPhone.Text = sdr["Phone"].ToString().Trim();
                txtFax.Text = sdr["Fax"].ToString().Trim();
                txtemail.Text = sdr["EMail"].ToString().Trim();
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
