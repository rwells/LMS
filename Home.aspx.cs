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

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_TYPE"] == null)
        {
            Response.Redirect("Logout.aspx");
        }

        if (Session["USER_TYPE"].ToString() == "A")
        {
            Panel2.Visible = false;
            lblName.Text = (string)Session["USER_NAME"].ToString();
        }
        else
        {
            Panel3.Visible = false;
            //HSMember.Visible = false;
            lblName.Text = (string)Session["NAME"].ToString();
        }
    }
    
}
