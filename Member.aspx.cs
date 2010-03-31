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
//using System.Data;
using System.Data.SqlClient;

public partial class Member : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM MEMBER";
                SqlDataReader sdr;
                Profile pro = new Profile();
                sdr = pro.ReturnMDetails(sql);

                sdr.Read();
                int RegNo = (int)sdr[0] + 1;
                if (RegNo < 10)
                {
                    txtReg.Text = string.Format("M000{0}", RegNo);
                }
                else if (RegNo > 10 && RegNo < 100)
                {
                    txtReg.Text = string.Format("M00{0}", RegNo);
                }
                else
                {
                    txtReg.Text = string.Format("M0{0}", RegNo);
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
        UserName.Text = "";
        Password.Text = "";
        ConfirmPassword.Text = "";
        txtFName.Text = "";
        txtMName.Text = "";
        txtLName.Text = "";
        txtAddress.Text = "";
        Email.Text = "";
        txtLline.Text = "";
        txtMobile.Text = "";
        optMale.Checked = true;
        optFemale.Checked = false;
        Question.Text = "";
        Answer.Text = "";
    }
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        try
        {
            string[] MProfile;
            lblEMsg.Visible = false;

            string sql = "SELECT COUNT(*) FROM MEMBER WHERE USER_NAME = '" + UserName.Text + "'";
            SqlDataReader sdr;
            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);

            sdr.Read();
            int RegNo = (int)sdr[0];
            if (RegNo > 0)
            {
                lblEMsg.Text = "User account already exists";
                lblEMsg.Visible = true;
                sdr.Close();
                return;
            }
            sdr.Close();

            sql = "SELECT COUNT(*) FROM MEMBER";
            sdr = pro.ReturnMDetails(sql);
            sdr.Read();
            RegNo = (int)sdr[0] + 1;
            if (RegNo < 10)
            {
                txtReg.Text = string.Format("M000{0}", RegNo);
            }
            else if (RegNo > 10 && RegNo < 100)
            {
                txtReg.Text = string.Format("M00{0}", RegNo);
            }
            else
            {
                txtReg.Text = string.Format("M0{0}", RegNo);
            }
            sdr.Close();

            MProfile = new string[15];

            MProfile[0] = txtReg.Text;
            MProfile[1] = UserName.Text;
            MProfile[2] = Password.Text;
            MProfile[3] = txtFName.Text;
            MProfile[4] = txtMName.Text;
            MProfile[5] = txtLName.Text;
            MProfile[6] = txtAddress.Text;
            MProfile[7] = Email.Text;
            MProfile[8] = txtLline.Text;
            MProfile[9] = txtMobile.Text;
            if (optMale.Checked == true)
            {
                MProfile[10] = "M";
            }
            else
            {
                MProfile[10] = "F";
            }
            MProfile[11] = Question.Text;
            MProfile[12] = Answer.Text;
            MProfile[13] = "A";
            MProfile[14] = "M";

            bool status;
            status = pro.AddProfile(MProfile);

            if (status == false)
            {
                lblEMsg.Visible = true;
                lblEMsg.Text = "User creation Failed";
            }
            else
            {
                Session["MEMBER_ID"] = MProfile[0];
                Session["USER_NAME"] = MProfile[1];
                Session["PASSWORD"] = MProfile[2];
                Session["NAME"] = MProfile[3] + " " + MProfile[4] + " " + MProfile[5];
                Session["STATUS"] = MProfile[13];
                Session["USER_TYPE"] = MProfile[14];
                Response.Redirect("Home.aspx");
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
