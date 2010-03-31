<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Library Management System.</title>
</head>
<body bottommargin="10">
    <form id="form1" runat="server">
    <div>
    
    </div>
        <div style="text-align: center">
            <table cellpadding="1" cellspacing="1" style="border-left-color:Black; border-bottom-color:Black;
                width: 976px; border-top-style: groove; border-top-color:Black ; border-right-style: groove;
                border-left-style: groove; height: 581px; border-right-color:Black; border-bottom-style: groove">
                <tr>
                    <td bgcolor="Black" rowspan="3" style="width: 109px">
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                        Font-Size="X-Small" ForeColor="Blue" Text="Welcome" Width="96px"></asp:Label><br />
                                    <asp:Label ID="lblName" runat="server" Font-Size="XX-Small" ForeColor="Blue" Text="Label"
                                        Width="100px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                        <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                            Font-Size="X-Small" ForeColor="#00C0C0" NavigateUrl="~/ChangePassword.aspx">Change Password.</asp:HyperLink></td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    <asp:HyperLink ID="HLogout" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                        Font-Size="X-Small" ForeColor="Red" NavigateUrl="~/Logout.aspx">Logout.</asp:HyperLink></td>
                            </tr>
                        </table>
                        <br />
                        &nbsp;
                        <br />
                        <div style="text-align: left">
                            <asp:Panel ID="Panel1" runat="server" BorderStyle="None" ForeColor="PowderBlue"
                                Height="40px" HorizontalAlign="Center" Width="110px">
                                <table>
                                    <tr>
                                        <td style="width: 100px">
                        <asp:HyperLink ID="HEditProfile" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/EditProfile.aspx">Edit Profile</asp:HyperLink></td>
                                    </tr>
                                </table>
                        <asp:HyperLink ID="HSearch" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/Search.aspx">Search Book</asp:HyperLink></asp:Panel>
                            &nbsp;</div>
                        <asp:Panel ID="Panel2" runat="server" BorderColor="PowderBlue" BorderStyle="None"
                            Height="20px" Width="110px" HorizontalAlign="Center">
                                        <asp:HyperLink ID="HCheckedInBooks" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/CheckedIn.aspx">Cheked In Books</asp:HyperLink></asp:Panel>
                        <asp:Panel ID="Panel3" runat="server" BorderColor="PowderBlue" BorderStyle="None"
                            Height="40px" HorizontalAlign="Center" Width="110px">
                            <table>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:HyperLink ID="HAddCategory" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/AddCategory.aspx">Add Category</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:HyperLink ID="HEditCategory" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/Category.aspx">Edit Category</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:HyperLink ID="HAddPublisher" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/AddPublisher.aspx">Add Publisher</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:HyperLink ID="HEditPublisher" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/EditPublisher.aspx">Edit Publisher</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:HyperLink ID="HAddSupplier" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/AddSupplier.aspx">Add Supplier</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:HyperLink ID="HEditSupplier" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/EditSupplier.aspx">Edit Supplier</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:HyperLink ID="HAddNook" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/AddBook.aspx">Add Book</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:HyperLink ID="HEditBooks" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/EditBook.aspx">Edit Book</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:HyperLink ID="HAddAuthor" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/AddAuthor.aspx">Add Author</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:HyperLink ID="HEditAuthor" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/EditAuthor.aspx">Edit Author</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/IssueBook.aspx">Issue Book</asp:HyperLink></td>
                                </tr>
                            </table>
                                        <asp:HyperLink ID="HRBook" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/ReturnBook.aspx">Return Book</asp:HyperLink></asp:Panel>
                        <br />
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Book3.JPG" Width="0px" /><br />
                    </td>
                    <td align="left" colspan="2" style="font-weight: bolder; vertical-align: super;
                        color:white; font-family: 'Times New Roman'; height: 56px; background-color:black;
                        text-align: center" valign="middle">
                        &nbsp;<asp:Image ID="Image3" runat="server" Height="0px" ImageUrl="~/Images/Book4.JPG"
                            Width="0px" />LIBRARY MANAGEMENT SYSTEM<asp:Image ID="Image2" runat="server" Height="0px"
                                ImageUrl="~/Images/Search1.jpeg" Width="0px" /></td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="height: 320px" valign="middle">
                        <br />
                        <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/logo.jpg" /><br />
                    </td>
                </tr>
                <tr>
                    <td style="height: 123px" colspan="2">
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
