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

public partial class AddCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_TYPE"] == null)
        {
            Response.Redirect("Logout.aspx");
        }
        if (Page.IsPostBack == false)
        {
            ReadCategory();
        }
        if (Session["USER_TYPE"].ToString() == "A")
        {
            Panel2.Visible = false;
        }
        else
        {
            Panel3.Visible = false;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtCName.Text = "";
        txtcDesc.Text = "";
        chkStatus.Checked = false;
        lblEMsg.Visible = false;
    }
    private void ReadCategory()
    {
        try
        {
            string sql = "SELECT COUNT(*) FROM CATEGORY";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);

            sdr.Read();
            int Cate = (int)sdr[0] + 1;
            if (Cate < 10)
            {
                txtCategory.Text = string.Format("C000{0}", Cate);
            }
            else if (Cate > 10 && Cate < 100)
            {
                txtCategory.Text = string.Format("C00{0}", Cate);
            }
            else
            {
                txtCategory.Text = string.Format("C0{0}", Cate);
            }
            sdr.Close();
            return;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lblEMsg.Visible = false;
        string[] Catg;
        try
        {
            string sql = "SELECT COUNT(*) FROM CATEGORY WHERE CATEGORY_NAME = '" + txtCName.Text + "' And Status = 'A'";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);

            sdr.Read();
            int RegNo = (int)sdr[0];
            if (RegNo > 0)
            {
                lblEMsg.Text = "Category Name already exists.";
                lblEMsg.Visible = true;
                sdr.Close();
                return;
            }
            else
            {
                Catg = new string[15];

                Catg[0] = txtCategory.Text;
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
                status = pro.AddCategory(Catg);

                if (status == false)
                {
                    lblEMsg.Visible = true;
                    lblEMsg.Text = "Category creation Failed";
                }
                lblEMsg.Visible = true;
                lblEMsg.Text = "Category added.";
                ReadCategory();
                txtCName.Text = "";
                txtcDesc.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
    }

    
}
