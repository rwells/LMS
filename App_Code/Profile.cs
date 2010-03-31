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

/// <summary>
/// Summary description for Profile
/// </summary>
public class Profile
{
	public Profile()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public  bool AddProfile(string[] Pro)
    {
        bool status =false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("MemberInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Member_ID", SqlDbType.NChar, 10, "Member_ID");
                cmd.Parameters.Add("@User_Name", SqlDbType.NChar, 20, "User_Name");
                cmd.Parameters.Add("@Password", SqlDbType.NChar, 20, "Password");
                cmd.Parameters.Add("@First_Name", SqlDbType.NChar, 30, "First_Name");
                cmd.Parameters.Add("@Middle_Name", SqlDbType.NChar, 20, "Middle_Name");
                cmd.Parameters.Add("@Last_Name", SqlDbType.NChar, 20, "Last_Name");
                cmd.Parameters.Add("@Address", SqlDbType.NChar, 200, "Address");
                cmd.Parameters.Add("@E_Mail_ID", SqlDbType.NChar, 100, "E_Mail_ID");
                cmd.Parameters.Add("@Land_Line", SqlDbType.Char, 10, "Land_Line");
                cmd.Parameters.Add("@Mobile", SqlDbType.Char, 10, "Mobile");
                cmd.Parameters.Add("@Sex", SqlDbType.Char, 2, "Sex");
                cmd.Parameters.Add("@Security_Q", SqlDbType.NChar, 100, "Security_Q");
                cmd.Parameters.Add("@Security_A", SqlDbType.NChar, 100, "Security_A");
                cmd.Parameters.Add("@Registration_Date", SqlDbType.DateTime);
                cmd.Parameters.Add("@Status", SqlDbType.Char, 2, "Status");
                cmd.Parameters.Add("@User_Type", SqlDbType.Char, 2, "User_Type");

                cmd.Parameters["@Member_ID"].Value = Pro[0];
                cmd.Parameters["@User_Name"].Value = Pro[1];
                cmd.Parameters["@Password"].Value = Pro[2];
                cmd.Parameters["@First_Name"].Value = Pro[3];
                cmd.Parameters["@Middle_Name"].Value = Pro[4];
                cmd.Parameters["@Last_Name"].Value = Pro[5];
                cmd.Parameters["@Address"].Value = Pro[6];
                cmd.Parameters["@E_Mail_ID"].Value = Pro[7];
                cmd.Parameters["@Land_Line"].Value = Pro[8];
                cmd.Parameters["@Mobile"].Value = Pro[9];
                cmd.Parameters["@Sex"].Value = Pro[10];
                cmd.Parameters["@Security_Q"].Value = Pro[11];
                cmd.Parameters["@Security_A"].Value = Pro[12];
                cmd.Parameters["@Registration_Date"].Value = DateTime.Now;
                cmd.Parameters["@Status"].Value = Pro[13];
                cmd.Parameters["@User_Type"].Value = Pro[14];

                cmd.ExecuteNonQuery();

                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;            
        }
        return status;
    }
    public SqlDataReader ReturnMDetails(string sql)
    {
        try
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString());
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();//CommandBehavior.CloseConnection);
                return rdr;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool UpdateProfile(string[] Pro)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateProfile", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Member_ID", SqlDbType.NChar, 10, "Member_ID");
                cmd.Parameters.Add("@User_Name", SqlDbType.NChar, 20, "User_Name");
                cmd.Parameters.Add("@Password", SqlDbType.NChar, 20, "Password");
                cmd.Parameters.Add("@First_Name", SqlDbType.NChar, 30, "First_Name");
                cmd.Parameters.Add("@Middle_Name", SqlDbType.NChar, 20, "Middle_Name");
                cmd.Parameters.Add("@Last_Name", SqlDbType.NChar, 20, "Last_Name");
                cmd.Parameters.Add("@Address", SqlDbType.NChar, 200, "Address");
                cmd.Parameters.Add("@E_Mail_ID", SqlDbType.NChar, 100, "E_Mail_ID");
                cmd.Parameters.Add("@Land_Line", SqlDbType.Char, 10, "Land_Line");
                cmd.Parameters.Add("@Mobile", SqlDbType.Char, 10, "Mobile");
                cmd.Parameters.Add("@Sex", SqlDbType.Char, 2, "Sex");
                cmd.Parameters.Add("@Security_Q", SqlDbType.NChar, 100, "Security_Q");
                cmd.Parameters.Add("@Security_A", SqlDbType.NChar, 100, "Security_A");
                cmd.Parameters.Add("@Registration_Date", SqlDbType.DateTime);
                cmd.Parameters.Add("@Status", SqlDbType.Char, 2, "Status");
                cmd.Parameters.Add("@User_Type", SqlDbType.Char, 2, "User_Type");

                cmd.Parameters["@Member_ID"].Value = Pro[0];
                cmd.Parameters["@User_Name"].Value = Pro[1];
                cmd.Parameters["@Password"].Value = Pro[2];
                cmd.Parameters["@First_Name"].Value = Pro[3];
                cmd.Parameters["@Middle_Name"].Value = Pro[4];
                cmd.Parameters["@Last_Name"].Value = Pro[5];
                cmd.Parameters["@Address"].Value = Pro[6];
                cmd.Parameters["@E_Mail_ID"].Value = Pro[7];
                cmd.Parameters["@Land_Line"].Value = Pro[8];
                cmd.Parameters["@Mobile"].Value = Pro[9];
                cmd.Parameters["@Sex"].Value = Pro[10];
                cmd.Parameters["@Security_Q"].Value = Pro[11];
                cmd.Parameters["@Security_A"].Value = Pro[12];
                cmd.Parameters["@Registration_Date"].Value = DateTime.Now;
                cmd.Parameters["@Status"].Value = Pro[13];
                cmd.Parameters["@User_Type"].Value = Pro[14];

                cmd.ExecuteNonQuery();

                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }
    public bool AddCategory(string[] Catg)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("AddCategory", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Category_ID", SqlDbType.NChar, 10, "Category_ID");
                cmd.Parameters.Add("@Category_Name", SqlDbType.NChar, 50, "Category_Name");
                cmd.Parameters.Add("@Category_Description", SqlDbType.NChar, 200, "Category_Description");
                cmd.Parameters.Add("@Status", SqlDbType.NChar, 1, "Status");

                cmd.Parameters["@Category_ID"].Value = Catg[0];
                cmd.Parameters["@Category_Name"].Value = Catg[1];
                cmd.Parameters["@Category_Description"].Value = Catg[2];
                cmd.Parameters["@Status"].Value = Catg[3];
                
                cmd.ExecuteNonQuery();
                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }
    public bool UpdateCategory(string[] Catg)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateCategory", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Category_ID", SqlDbType.NChar, 10, "Category_ID");
                cmd.Parameters.Add("@Category_Name", SqlDbType.NChar, 50, "Category_Name");
                cmd.Parameters.Add("@Category_Description", SqlDbType.NChar, 200, "Category_Description");
                cmd.Parameters.Add("@Status", SqlDbType.NChar, 1, "Status");

                cmd.Parameters["@Category_ID"].Value = Catg[0];
                cmd.Parameters["@Category_Name"].Value = Catg[1];
                cmd.Parameters["@Category_Description"].Value = Catg[2];
                cmd.Parameters["@Status"].Value = Catg[3];

                cmd.ExecuteNonQuery();

                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }
    public bool DeleteCategory(string Catg)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteCategory", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Category_ID", SqlDbType.NChar, 10, "Category_ID");
                
                cmd.Parameters["@Category_ID"].Value = Catg;
                
                cmd.ExecuteNonQuery();

                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }
    public bool AddSupplier(string[] Supp)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("AddSupplier", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Supplier_ID", SqlDbType.NChar, 10, "Supplier_ID");
                cmd.Parameters.Add("@Supplier_Name", SqlDbType.NChar, 200, "Supplier_Name");
                cmd.Parameters.Add("@Address", SqlDbType.NChar, 200, "Address");
                cmd.Parameters.Add("@Phone", SqlDbType.NChar, 10, "Phone");
                cmd.Parameters.Add("@Fax", SqlDbType.NChar, 10, "Fax");
                cmd.Parameters.Add("@Email", SqlDbType.NChar, 20, "Email");
                cmd.Parameters.Add("@Status", SqlDbType.NChar, 1, "Status");

                cmd.Parameters["@Supplier_ID"].Value = Supp[0];
                cmd.Parameters["@Supplier_Name"].Value = Supp[1];
                cmd.Parameters["@Address"].Value = Supp[2];
                cmd.Parameters["@Phone"].Value = Supp[3];
                cmd.Parameters["@Fax"].Value = Supp[4];
                cmd.Parameters["@Email"].Value = Supp[5];
                cmd.Parameters["@Status"].Value = Supp[6];

                cmd.ExecuteNonQuery();
                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }
    public bool UpdateSupplier(string[] Supp)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateSupplier", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Supplier_ID", SqlDbType.NChar, 10, "Supplier_ID");
                cmd.Parameters.Add("@Supplier_Name", SqlDbType.NChar, 200, "Supplier_Name");
                cmd.Parameters.Add("@Address", SqlDbType.NChar, 200, "Address");
                cmd.Parameters.Add("@Phone", SqlDbType.NChar, 10, "Phone");
                cmd.Parameters.Add("@Fax", SqlDbType.NChar, 10, "Fax");
                cmd.Parameters.Add("@Email", SqlDbType.NChar, 20, "Email");
                cmd.Parameters.Add("@Status", SqlDbType.NChar, 1, "Status");

                cmd.Parameters["@Supplier_ID"].Value = Supp[0];
                cmd.Parameters["@Supplier_Name"].Value = Supp[1];
                cmd.Parameters["@Address"].Value = Supp[2];
                cmd.Parameters["@Phone"].Value = Supp[3];
                cmd.Parameters["@Fax"].Value = Supp[4];
                cmd.Parameters["@Email"].Value = Supp[5];
                cmd.Parameters["@Status"].Value = Supp[6];

                cmd.ExecuteNonQuery();

                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }
    public bool DeleteSupplier(string Supp)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteSupplier", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Supplier_ID", SqlDbType.NChar, 10, "Supplier_ID");

                cmd.Parameters["@Supplier_ID"].Value = Supp;

                cmd.ExecuteNonQuery();

                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }

    public bool AddPublisher(string[] Pub)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("AddPublisher", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Publisher_ID", SqlDbType.NChar, 10, "Publisher_ID");
                cmd.Parameters.Add("@Publisher_Name", SqlDbType.NChar, 200, "Publisher_Name");
                cmd.Parameters.Add("@Publishing_Year", SqlDbType.NChar, 8, "Publishing_Year");
                cmd.Parameters.Add("@Publishing_House", SqlDbType.NChar, 50, "Publishing_House");
                cmd.Parameters.Add("@Publisher_Edition", SqlDbType.NChar, 10, "Publisher_Edition");
                cmd.Parameters.Add("@Address", SqlDbType.NChar, 200, "Address");
                cmd.Parameters.Add("@Phone", SqlDbType.NChar, 10, "Phone");
                cmd.Parameters.Add("@Fax", SqlDbType.NChar, 10, "Fax");
                cmd.Parameters.Add("@Email", SqlDbType.NChar, 20, "Email");
                cmd.Parameters.Add("@Status", SqlDbType.NChar, 1, "Status");

                cmd.Parameters["@Publisher_ID"].Value = Pub[0];
                cmd.Parameters["@Publisher_Name"].Value = Pub[1];
                cmd.Parameters["@Publishing_Year"].Value = Pub[2];
                cmd.Parameters["@Publishing_House"].Value = Pub[3];
                cmd.Parameters["@Publisher_Edition"].Value = Pub[4];
                cmd.Parameters["@Address"].Value = Pub[5];
                cmd.Parameters["@Phone"].Value = Pub[6];
                cmd.Parameters["@Fax"].Value = Pub[7];
                cmd.Parameters["@Email"].Value = Pub[8];
                cmd.Parameters["@Status"].Value = Pub[9];

                cmd.ExecuteNonQuery();
                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }
    public bool UpdatePublisher(string[] Pub)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("UpdatePublisher", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Publisher_ID", SqlDbType.NChar, 10, "Publisher_ID");
                cmd.Parameters.Add("@Publisher_Name", SqlDbType.NChar, 200, "Publisher_Name");
                cmd.Parameters.Add("@Publishing_Year", SqlDbType.NChar, 8, "Publishing_Year");
                cmd.Parameters.Add("@Publishing_House", SqlDbType.NChar, 50, "Publishing_House");
                cmd.Parameters.Add("@Publisher_Edition", SqlDbType.NChar, 10, "Publisher_Edition");
                cmd.Parameters.Add("@Address", SqlDbType.NChar, 200, "Address");
                cmd.Parameters.Add("@Phone", SqlDbType.NChar, 10, "Phone");
                cmd.Parameters.Add("@Fax", SqlDbType.NChar, 10, "Fax");
                cmd.Parameters.Add("@Email", SqlDbType.NChar, 20, "Email");
                cmd.Parameters.Add("@Status", SqlDbType.NChar, 1, "Status");

                cmd.Parameters["@Publisher_ID"].Value = Pub[0];
                cmd.Parameters["@Publisher_Name"].Value = Pub[1];
                cmd.Parameters["@Publishing_Year"].Value = Pub[2];
                cmd.Parameters["@Publishing_House"].Value = Pub[3];
                cmd.Parameters["@Publisher_Edition"].Value = Pub[4];
                cmd.Parameters["@Address"].Value = Pub[5];
                cmd.Parameters["@Phone"].Value = Pub[6];
                cmd.Parameters["@Fax"].Value = Pub[7];
                cmd.Parameters["@Email"].Value = Pub[8];
                cmd.Parameters["@Status"].Value = Pub[9];

                cmd.ExecuteNonQuery();

                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }
    public bool DeletePublisher(string Pub)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("DeletePublisher", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Publisher_ID", SqlDbType.NChar, 10, "Publisher_ID");

                cmd.Parameters["@Publisher_ID"].Value = Pub;

                cmd.ExecuteNonQuery();

                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }

    public bool AddAuthor(string[] Auth)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("AddAuthor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Author_ID", SqlDbType.NChar, 10, "Author_ID");
                cmd.Parameters.Add("@Author_Name", SqlDbType.NChar, 200, "Author_Name");
                cmd.Parameters.Add("@Address", SqlDbType.NChar, 200, "Address");
                cmd.Parameters.Add("@Phone", SqlDbType.NChar, 10, "Phone");
                cmd.Parameters.Add("@Fax", SqlDbType.NChar, 10, "Fax");
                cmd.Parameters.Add("@Email", SqlDbType.NChar, 20, "Email");
                cmd.Parameters.Add("@Status", SqlDbType.NChar, 1, "Status");

                cmd.Parameters["@Author_ID"].Value = Auth[0];
                cmd.Parameters["@Author_Name"].Value = Auth[1];
                cmd.Parameters["@Address"].Value = Auth[2];
                cmd.Parameters["@Phone"].Value = Auth[3];
                cmd.Parameters["@Fax"].Value = Auth[4];
                cmd.Parameters["@Email"].Value = Auth[5];
                cmd.Parameters["@Status"].Value = Auth[6];

                cmd.ExecuteNonQuery();
                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }
    public bool UpdateAuthor(string[] Auth)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateAuthor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Author_ID", SqlDbType.NChar, 10, "Author_ID");
                cmd.Parameters.Add("@Author_Name", SqlDbType.NChar, 200, "Author_Name");
                cmd.Parameters.Add("@Address", SqlDbType.NChar, 200, "Address");
                cmd.Parameters.Add("@Phone", SqlDbType.NChar, 10, "Phone");
                cmd.Parameters.Add("@Fax", SqlDbType.NChar, 10, "Fax");
                cmd.Parameters.Add("@Email", SqlDbType.NChar, 20, "Email");
                cmd.Parameters.Add("@Status", SqlDbType.NChar, 1, "Status");

                cmd.Parameters["@Author_ID"].Value = Auth[0];
                cmd.Parameters["@Author_Name"].Value = Auth[1];
                cmd.Parameters["@Address"].Value = Auth[2];
                cmd.Parameters["@Phone"].Value = Auth[3];
                cmd.Parameters["@Fax"].Value = Auth[4];
                cmd.Parameters["@Email"].Value = Auth[5];
                cmd.Parameters["@Status"].Value = Auth[6];

                cmd.ExecuteNonQuery();

                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }
    public bool DeleteAuthor(string Auth)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteAuthor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Author_ID", SqlDbType.NChar, 10, "Author_ID");

                cmd.Parameters["@Author_ID"].Value = Auth;

                cmd.ExecuteNonQuery();

                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }

    public bool Books(string[] Book,String SPName)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand(SPName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Book_ID", SqlDbType.NChar, 10, "Book_ID");
                cmd.Parameters.Add("@Book_Title", SqlDbType.NChar, 50, "Book_Title");
                cmd.Parameters.Add("@Author_ID", SqlDbType.NChar, 10, "Author_ID");
                cmd.Parameters.Add("@Publisher_ID", SqlDbType.NChar, 10, "Publisher_ID");
                cmd.Parameters.Add("@Category_ID", SqlDbType.NChar, 10, "Category_ID");
                cmd.Parameters.Add("@Supplier_ID", SqlDbType.NChar, 10, "Supplier_ID");
                cmd.Parameters.Add("@Key_Word", SqlDbType.NChar, 50, "Key_Word");
                cmd.Parameters.Add("@ISBN", SqlDbType.NChar, 20, "ISBN");
                cmd.Parameters.Add("@Quantity", SqlDbType.Int, 9, "Quantity");
                cmd.Parameters.Add("@Price", SqlDbType.NChar, 8, "Price");
                cmd.Parameters.Add("@Status", SqlDbType.NChar, 1, "Status");

                cmd.Parameters["@Book_ID"].Value = Book[0];
                cmd.Parameters["@Book_Title"].Value = Book[1];
                cmd.Parameters["@Author_ID"].Value = Book[2];
                cmd.Parameters["@Publisher_ID"].Value = Book[3];
                cmd.Parameters["@Category_ID"].Value = Book[4];
                cmd.Parameters["@Supplier_ID"].Value = Book[5];
                cmd.Parameters["@Key_Word"].Value = Book[6];
                cmd.Parameters["@ISBN"].Value = Book[7];
                cmd.Parameters["@Quantity"].Value = Book[8];
                cmd.Parameters["@Price"].Value = Book[9];
                cmd.Parameters["@Status"].Value = Book[10];

                cmd.ExecuteNonQuery();

                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }
    public bool DeleteBook(string Book)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteBook", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Book_ID", SqlDbType.NChar, 10, "Book_ID");

                cmd.Parameters["@Book_ID"].Value = Book;

                cmd.ExecuteNonQuery();

                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }

    public bool IssueBook(string[] Book)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("IssueBook", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Book_ID", SqlDbType.NChar, 10, "Book_ID");
                cmd.Parameters.Add("@Member_ID", SqlDbType.NChar, 10, "Member_ID");
                cmd.Parameters.Add("@Issue_Date", SqlDbType.DateTime, 8, "Issue_Date");
                cmd.Parameters.Add("@Return_Date", SqlDbType.DateTime, 8, "Return_Date");

                cmd.Parameters["@Book_ID"].Value = Book[0];
                cmd.Parameters["@Member_ID"].Value = Book[1];
                cmd.Parameters["@Issue_Date"].Value = Book[2];
                cmd.Parameters["@Return_Date"].Value = Book[3];
                
                cmd.ExecuteNonQuery();

                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }
    public bool ReturnBook(string[] Book)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("ReturnBook", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@Book_ID", SqlDbType.NChar, 10, "Book_ID");
                cmd.Parameters.Add("@Member_ID", SqlDbType.NChar, 10, "Member_ID");
                cmd.Parameters.Add("@Actual_Return_Date", SqlDbType.DateTime, 8, "Actual_Return_Date");
                cmd.Parameters.Add("@Late_Fee", SqlDbType.NChar, 8, "Late_Fee");

                cmd.Parameters["@Book_ID"].Value = Book[0];
                cmd.Parameters["@Member_ID"].Value = Book[1];
                cmd.Parameters["@Actual_Return_Date"].Value = Book[2];
                cmd.Parameters["@Late_Fee"].Value = Book[3];

                cmd.ExecuteNonQuery();

                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }
    public bool UpdatePassword(string UserName, string Password)
    {
        bool status = false;
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("UpdatePassword", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.Add("@User_Name", SqlDbType.NChar, 20, "User_Name");
                cmd.Parameters.Add("@Password", SqlDbType.NChar, 20, "Password");

                cmd.Parameters["@User_Name"].Value = UserName;
                cmd.Parameters["@Password"].Value = Password;

                cmd.ExecuteNonQuery();

                status = true;
                cn.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }
}
