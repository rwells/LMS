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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        try
        {
            string strRole;

            string sql = "SELECT MEMBER_ID, USER_NAME, PASSWORD, FIRST_NAME, MIDDLE_NAME, LAST_NAME, STATUS, USER_TYPE FROM MEMBER WHERE USER_NAME = '" + UserName.Text + "' AND PASSWORD = '" + Password.Text + "'";
            SqlDataReader sdr;

            Profile pro = new Profile();
            sdr = pro.ReturnMDetails(sql);
            if (sdr.Read() == true)
            {
                FormsAuthentication.Initialize();
                if(sdr["USER_TYPE"].ToString().Trim() == "A")
                {
                    strRole = "Admin";
                }
                else
                {
                    strRole = "Member";
                }
                
                //The AddMinutes determines how long the user will be logged in after leaving
               //the site if he doesn't log off.
               //FormsAuthenticationTicket fat = new FormsAuthenticationTicket(1, UserName.Text, DateTime.Now, 
               //        DateTime.Now.AddMinutes(30), false, strRole, FormsAuthentication.FormsCookiePath);
               
                //Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, 
                //       FormsAuthentication.Encrypt(fat)));

                

                Session["MEMBER_ID"] = sdr["MEMBER_ID"].ToString().Trim();
                Session["USER_NAME"] = sdr["USER_NAME"].ToString().Trim();
                Session["PASSWORD"] = sdr["PASSWORD"].ToString().Trim();
                Session["NAME"] = sdr["FIRST_NAME"].ToString().Trim() + " " + sdr["MIDDLE_NAME"].ToString().Trim() + " " + sdr["LAST_NAME"].ToString().Trim();
                Session["STATUS"] = sdr["STATUS"].ToString().Trim();
                Session["USER_TYPE"] = sdr["USER_TYPE"].ToString().Trim();
                //Response.Redirect(FormsAuthentication.GetRedirectUrl("Home.aspx", false));
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Invalid User Name/Password.";
            }
            sdr.Close();
        }
        catch(Exception err)
        {
            lblErrorMsg.Visible = true;
            lblErrorMsg.Text = err.Message;
        }
    }
}
