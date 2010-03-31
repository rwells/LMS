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

public partial class Category : System.Web.UI.Page
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
                //Load all the Category First.
                string sql = "SELECT Category_ID FROM CATEGORY WHERE STATUS = 'A'";
                SqlDataReader sdr;
                Profile pro = new Profile();
                sdr = pro.ReturnMDetails(sql);

                while (sdr.Read())
                {
                    lstid.Items.Add(sdr["Category_ID"].ToString().Trim());
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
        txtCName.Text = "";
        txtcDesc.Text = "";
        chkStatus.Checked = false;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        Profile pro = new Profile();
        
        try
        {
            if (lstid.Text == "")
            {
                lblEMsg.Text = "Please select Category ID";
                lblEMsg.Visible = true;
            }
            else
            {
                bool status;
                status = pro.DeleteCategory(lstid.SelectedItem.ToString());

                if (status == false)
                {
                    lblEMsg.Visible = true;
                    lblEMsg.Text = "Category deletion Failed";
                }
                lblEMsg.Visible = true;
                lblEMsg.Text = "Category deleted.";

                lstid.Items.Clear();
                
                //Load all the Category First.
                string sql = "SELECT Category_ID FROM CATEGORY Where Status = 'A'";
                SqlDataReader sdr;
                sdr = pro.ReturnMDetails(sql);

                while (sdr.Read())
                {
                    lstid.Items.Add(sdr["Category_ID"].ToString().Trim());
                }
                sdr.Close();
                txtCName.Text = "";
                txtcDesc.Text = "";
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
        string[] Catg;
        Profile pro = new Profile();
        try
        {
            if (lstid.Text == "")
            {
                lblEMsg.Text = "Please select Category ID";
                lblEMsg.Visible = true;
            }
            else
            {
                Catg = new string[15];

                Catg[0] = lstid.Text;
                Catg[1] = txtCName.Text;
                Catg[2] = txtcDesc.Text;
                if (chkStatus.Checked == true)
                {
                    Catg[3] = "A";
                }
                else
                {
                    Catg[3] = "I";
                }

                bool status;
                status = pro.UpdateCategory(Catg);

                if (status == false)
                {
                    lblEMsg.Visible = true;
                    lblEMsg.Text = "Category updation Failed";
                }
                lblEMsg.Visible = true;
                lblEMsg.Text = "Category updated.";

                //Load all the Category First.
                /*string sql = "SELECT Category_ID FROM CATEGORY";
                SqlDataReader sdr;
                sdr = pro.ReturnMDetails(sql);
                lstid.Items.Clear();
                while (sdr.Read())
                {
                    lstid.Items.Add(sdr["Category_ID"].ToString().Trim());
                }
                sdr.Close();
                return;*/
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
                lblEMsg.Text = "Please select the Category";
                return;
            }
            string sql = "SELECT Category_Name, Category_Description, Status FROM CATEGORY WHERE Category_ID = '" + lstid.SelectedItem.ToString() + "'";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);

            if (sdr.Read() == true)
            {
                txtCName.Text = sdr["Category_Name"].ToString().Trim();
                txtcDesc.Text = sdr["Category_Description"].ToString().Trim();
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
