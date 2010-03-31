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

public partial class CheckedIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_TYPE"] == null)
        {
            Response.Redirect("Logout.aspx");
        }
        if (Page.IsPostBack == false)
        {
            if (Session["USER_TYPE"].ToString() == "A")
            {
                Panel2.Visible = false;
            }
            else
            {
                Panel3.Visible = false;
            }
            try
            {

                string connStr = ConfigurationManager.ConnectionStrings["LibraryConn"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                /*string sql = "SELECT DISTINCT BT.BOOK_ID, BM.BOOK_TITLE, A.AUTHOR_NAME, P.PUBLISHER_NAME, P.PUBLISHING_YEAR, P.PUBLISHING_HOUSE, P.PUBLISHER_EDITION, C.CATEGORY_NAME, "; 
                sql = sql + "S.SUPPLIER_NAME, BT.ISSUE_DATE, BT.RETURN_DATE, BT.ACTUAL_RETURN_DATE, BT.LATE_FEE FROM BOOK_TRANSACTION BT INNER JOIN BOOK_MASTER BM ON BT.BOOK_ID = BM.BOOK_ID ";
                sql = sql + "INNER JOIN AUTHOR A ON BM.AUTHOR_ID = A.AUTHOR_ID INNER JOIN PUBLISHER P ON BM.PUBLISHER_ID = P.PUBLISHER_ID INNER JOIN CATEGORY C ON BM.CATEGORY_ID = C.CATEGORY_ID ";
                sql = sql + "INNER JOIN SUPPLIER S ON BM.SUPPLIER_ID = S.SUPPLIER_ID WHERE BT.MEMBER_ID = 'M0002' ORDER BY BT.BOOK_ID";*/
                string sql = "SELECT DISTINCT BT.BOOK_ID AS 'Book ID', BM.BOOK_TITLE AS 'Book Tite' , A.AUTHOR_NAME AS 'Author Name', ";
                sql = sql + "P.PUBLISHER_NAME AS 'Publisher Name', BT.ISSUE_DATE AS 'Issue Date', BT.RETURN_DATE AS 'Return Date', ";
                sql = sql + "BT.ACTUAL_RETURN_DATE AS 'Actual Return Date', BT.LATE_FEE AS 'Late Fee' FROM BOOK_TRANSACTION BT INNER JOIN ";
                sql = sql + "BOOK_MASTER BM ON BT.BOOK_ID = BM.BOOK_ID INNER JOIN AUTHOR A ON BM.AUTHOR_ID = A.AUTHOR_ID ";
                sql = sql + "INNER JOIN PUBLISHER P ON BM.PUBLISHER_ID = P.PUBLISHER_ID WHERE BT.MEMBER_ID = '" + Session["MEMBER_ID"].ToString() + "' ORDER BY BT.BOOK_ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //Fill Dataet
                DataSet ds = new DataSet();
                adp.Fill(ds, "Book_Transaction");

                gvBook.DataSource = ds;
                gvBook.DataBind();

                adp.Dispose();
                cmd.Cancel();
                conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
