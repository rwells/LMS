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

public partial class NewAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_TYPE"] == null)
        {
            Response.Redirect("Logout.aspx");
        }
        if (this.IsPostBack == false)
        {
            txtReg.Text = (string)Session["MEMBER_ID"];
            UserName.Text = (string)Session["USER_NAME"];
            Password.Text = (string)Session["PASSWORD"];
            ConfirmPassword.Text = (string)Session["PASSWORD"];

            try
            {
                string sql = "SELECT USER_NAME, PASSWORD, FIRST_NAME, MIDDLE_NAME, LAST_NAME, ADDRESS, E_MAIL_ID, LAND_LINE, MOBILE, SEX, SECURITY_Q, SECURITY_A FROM MEMBER WHERE MEMBER_ID = '" + txtReg.Text + "'";
                SqlDataReader sdr;

                Profile pro = new Profile();
                sdr = pro.ReturnMDetails(sql);
                if (sdr.Read() == true)
                {
                    UserName.Text = sdr["USER_NAME"].ToString().Trim();
                    Password.Text = sdr["PASSWORD"].ToString().Trim();
                    ConfirmPassword.Text = sdr["PASSWORD"].ToString().Trim();
                    txtFName.Text = sdr["FIRST_NAME"].ToString().Trim();
                    txtMName.Text = sdr["MIDDLE_NAME"].ToString().Trim();
                    txtLName.Text = sdr["LAST_NAME"].ToString().Trim();
                    txtAddress.Text = sdr["ADDRESS"].ToString().Trim();
                    Email.Text = sdr["E_MAIL_ID"].ToString().Trim();
                    txtLline.Text = sdr["LAND_LINE"].ToString().Trim();
                    txtMobile.Text = sdr["MOBILE"].ToString().Trim();
                    if (sdr["SEX"].ToString().Trim() == "M")
                    {
                        optMale.Checked = true;
                    }
                    else
                    {
                        optFemale.Checked = true;
                    }
                    Question.Text = sdr["SECURITY_Q"].ToString().Trim();
                    Answer.Text = sdr["SECURITY_A"].ToString().Trim();
                }
                sdr.Close();
            }
            catch (Exception err)
            {
                throw err;
            }
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string[] MProfile;
            lblEMsg.Visible = false;

            Profile pro = new Profile();
            
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
            if (Session["USER_TYPE"].ToString() == "A")
            {
                MProfile[14] = "A";
            }
            else
            {
                MProfile[14] = "M";
            }

            bool status;
            status = pro.UpdateProfile(MProfile);

            if (status == false)
            {
                lblEMsg.Visible = true;
                lblEMsg.Text = "User updation Failed";
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
