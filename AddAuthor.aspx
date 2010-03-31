<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAuthor.aspx.cs" Inherits="AddAuthor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Library Management System.</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="1" cellspacing="1" style="border-left-color: #ffcccc; border-bottom-color: #ffcccc;
            width: 976px; border-top-style: groove; border-top-color: #ffcccc; border-right-style: groove;
            border-left-style: groove; height: 542px; border-right-color: #ffcccc; border-bottom-style: groove">
            <tr>
                <td bgcolor="#ffffcc" rowspan="3" style="width: 115px">
                    <br />
                    <br />
                    <div style="text-align: left">
                        <asp:Panel ID="Panel1" runat="server" BorderStyle="Double" ForeColor="PowderBlue"
                            Height="40px" HorizontalAlign="Center" Width="110px">
                            <table>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:HyperLink ID="HHPage" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/Home.aspx">Home Page</asp:HyperLink></td>
                                </tr>
                                <tr style="font-size: 12pt">
                                    <td style="width: 100px">
                                        <asp:HyperLink ID="HEditProfile" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/EditProfile.aspx">Edit Profile</asp:HyperLink></td>
                                </tr>
                            </table>
                                        <asp:HyperLink ID="HSearch" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                            Font-Size="Small" ForeColor="Blue" NavigateUrl="~/Search.aspx">Search Book</asp:HyperLink></asp:Panel>
                        <asp:Panel ID="Panel2" runat="server" BorderColor="PowderBlue" BorderStyle="Double"
                            Height="20px" HorizontalAlign="Center" Width="110px">
                            <asp:HyperLink ID="HCheckedInBooks" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                Font-Size="Small" ForeColor="Blue" NavigateUrl="~/CheckedIn.aspx">Cheked In Books</asp:HyperLink></asp:Panel>
                    <asp:Panel ID="Panel3" runat="server" BorderColor="PowderBlue" BorderStyle="Double"
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
                    &nbsp;
                    <br />
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Book3.JPG" Width="113px" /><br />
                </div>
                </td>
                <td align="center" colspan="2" style="font-weight: bolder; vertical-align: super;
                    color: #cc00ff; font-family: 'Times New Roman'; height: 56px; background-color: pink;
                    text-align: center" valign="middle">
                    &nbsp;<asp:Image ID="Image3" runat="server" Height="70px" ImageUrl="~/Images/Book4.JPG"
                        Width="60px" />LIBRARY MANAGEMENT SYSTEM<asp:Image ID="Image2" runat="server" Height="70px"
                            ImageUrl="~/Images/Search1.jpeg" Width="60px" /></td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="height: 403px">
                    <table cellpadding="1" cellspacing="1">
                        <tr>
                            <td align="center" colspan="3" style="font-weight: bold; vertical-align: middle;
                                color: #00ff99; border-top-style: outset; font-family: 'Times New Roman'; border-right-style: outset;
                                border-left-style: outset; background-color: #663333; text-align: center; border-bottom-style: outset">
                                Add Author</td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 153px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:Label ID="Label10" runat="server" Text="Author ID:"></asp:Label></td>
                            <td align="left" style="width: 192px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:TextBox ID="txtAuthor" runat="server" ReadOnly="True" Width="200px"></asp:TextBox></td>
                            <td style="width: 207px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 153px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:Label ID="UserNameLabel" runat="server">Author Name:</asp:Label></td>
                            <td style="width: 192px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                                <asp:TextBox ID="txtAName" runat="server" MaxLength="50" ValidationGroup="Login1"
                                    Width="200px"></asp:TextBox></td>
                            <td align="left" style="width: 207px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtAName"
                                    ToolTip="Author Name is required." ValidationGroup="Login1">Author Name is required.</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 153px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:Label ID="PasswordLabel" runat="server">Author Address:</asp:Label></td>
                            <td style="width: 192px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                                <asp:TextBox ID="txtAdd" runat="server" MaxLength="200" TextMode="MultiLine" ValidationGroup="Login1"
                                    Width="200px"></asp:TextBox></td>
                            <td align="left" style="width: 207px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtAdd"
                                    ToolTip="Author Address is required." ValidationGroup="Login1">Author Address is required.</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 153px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:Label ID="Label1" runat="server" Text="Phone#: "></asp:Label></td>
                            <td align="left" style="width: 192px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" ValidationGroup="Login1"
                                    Width="200px"></asp:TextBox></td>
                            <td align="left" style="width: 207px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPhone"
                                    ErrorMessage="RegularExpressionValidator" ValidationExpression="\d[0-9]*" ValidationGroup="Login1">Please enter valid Phone No.</asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 153px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:Label ID="Label2" runat="server" Text="Fax:"></asp:Label></td>
                            <td align="left" style="width: 192px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:TextBox ID="txtFax" runat="server" MaxLength="10" ToolTip="Login1" Width="200px"></asp:TextBox></td>
                            <td align="left" style="width: 207px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 153px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:Label ID="Label3" runat="server" Text="E Mail ID"></asp:Label></td>
                            <td align="left" style="width: 192px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:TextBox ID="txtemail" runat="server" MaxLength="20" ValidationGroup="Login1"
                                    Width="200px"></asp:TextBox></td>
                            <td align="left" style="width: 207px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail"
                                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="Login1">Enter a Valid E-mail.</asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 153px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:Label ID="ConfirmPasswordLabel" runat="server">Status:</asp:Label></td>
                            <td align="left" style="width: 192px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:CheckBox ID="chkStatus" runat="server" Checked="True" Text="Status" ValidationGroup="Login1" /></td>
                            <td align="left" style="width: 207px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                &nbsp;<asp:Label ID="lblEMsg" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                                    Font-Size="Medium" ForeColor="Red" Visible="False" Width="455px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 153px; color: #0000cc; font-family: 'Times New Roman';
                                height: 26px; background-color: #ffffcc">
                            </td>
                            <td style="width: 192px; color: #0000cc; font-family: 'Times New Roman'; height: 26px;
                                background-color: #ffffcc">
                                <asp:Button ID="btnAdd" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                    Font-Size="Small" ForeColor="Blue" OnClick="btnAdd_Click" Text="Add..." ValidationGroup="Login1" />&nbsp;<asp:Button
                                        ID="btnClear" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Small"
                                        ForeColor="Blue" OnClick="btnClear_Click" Text="Clear" /></td>
                            <td style="width: 207px; color: #0000cc; font-family: 'Times New Roman'; height: 26px;
                                background-color: #ffffcc">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 123px">
                </td>
                <td style="width: 755px; height: 123px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
