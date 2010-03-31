using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_TYPE"] == null)
        {
            Response.Redirect("Logout.aspx");
        }
        txtUserName.Text = Session["USER_NAME"].ToString();
        lblName.Text = Session["NAME"].ToString();
    }

    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "SELECT USER_NAME, PASSWORD FROM MEMBER WHERE USER_NAME = '" + txtUserName.Text + "' AND PASSWORD = '" + txtPassword.Text + "'";
            SqlDataReader sdr;

            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);
            if (sdr.Read() == true)
            {
                //Update New Password.
                Session["PASSWORD"] = txtNPassword.Text;

                bool status;
                status = pro.UpdatePassword(txtUserName.Text,txtNPassword.Text);

                if (status == false)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Password updation Failed";
                    return;
                }
                lblMsg.Visible = true;
                lblMsg.Text = "Password updated.";
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Invalid Password.";
                return;
            }
            sdr.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void CancelPushButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
}
