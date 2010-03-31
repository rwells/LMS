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

public partial class Search : System.Web.UI.Page
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
                
                string sql = "SELECT Distinct Book_Title FROM Book_Master Where Status = 'A'";
                SqlDataReader sdr;
                Profile pro = new Profile();
                sdr = pro.ReturnMDetails(sql);
                lstBook.Items.Clear();
                lstBook.Items.Add("");
                while (sdr.Read())
                {
                    lstBook.Items.Add(sdr["Book_Title"].ToString().Trim());
                }
                sdr.Close();

                sql = "SELECT DISTINCT BM.BOOK_ID AS 'Book ID', BM.BOOK_TITLE AS 'Book Title', A.AUTHOR_NAME AS 'Author Name', P.PUBLISHER_NAME AS 'Pulisher Name', ";
                sql = sql + "P.PUBLISHING_YEAR AS 'Publishing Year', P.PUBLISHING_HOUSE AS 'Publishing House', P.PUBLISHER_EDITION AS 'Publisher Edition', C.CATEGORY_NAME AS 'Category Name', ";
                sql = sql + "S.SUPPLIER_NAME AS 'Supplier Name', BM.ISBN, BM.PRICE FROM BOOK_MASTER BM INNER JOIN AUTHOR A ON BM.AUTHOR_ID = A.AUTHOR_ID ";
                sql = sql + "INNER JOIN PUBLISHER P ON BM.PUBLISHER_ID = P.PUBLISHER_ID INNER JOIN CATEGORY C ON BM.CATEGORY_ID = C.CATEGORY_ID ";
                sql = sql + "INNER JOIN SUPPLIER S ON BM.SUPPLIER_ID = S.SUPPLIER_ID WHERE BM.BOOK_TITLE IS NULL ORDER BY BM.BOOK_ID";

                ReadBook(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    protected void lstBook_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string sql = "SELECT DISTINCT BM.BOOK_ID AS 'Book ID', BM.BOOK_TITLE AS 'Book Title', A.AUTHOR_NAME AS 'Author Name', P.PUBLISHER_NAME AS 'Pulisher Name', ";
            sql = sql + "P.PUBLISHING_YEAR AS 'Publishing Year', P.PUBLISHING_HOUSE AS 'Publishing House', P.PUBLISHER_EDITION AS 'Publisher Edition', C.CATEGORY_NAME AS 'Category Name', ";
            sql = sql + "S.SUPPLIER_NAME AS 'Supplier Name', BM.ISBN, BM.PRICE FROM BOOK_MASTER BM INNER JOIN AUTHOR A ON BM.AUTHOR_ID = A.AUTHOR_ID ";
            sql = sql + "INNER JOIN PUBLISHER P ON BM.PUBLISHER_ID = P.PUBLISHER_ID INNER JOIN CATEGORY C ON BM.CATEGORY_ID = C.CATEGORY_ID ";
            sql = sql + "INNER JOIN SUPPLIER S ON BM.SUPPLIER_ID = S.SUPPLIER_ID WHERE BM.BOOK_TITLE = '" + lstBook.SelectedItem.Text + "' ORDER BY BM.BOOK_ID";

            ReadBook(sql);
         }
         catch (Exception ex)
         {
            throw ex;
         }
    }
    
    private void ReadBook(string sql)
    {
        try
        {
            string connStr = ConfigurationManager.ConnectionStrings["LibraryConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

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
