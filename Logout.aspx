<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logout.aspx.cs" Inherits="Logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Library Management System.</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="1" cellspacing="1" style="border-left-color: Black; border-bottom-color:Black;
            width: 976px; border-top-style: groove; border-top-color:Black; border-right-style: groove;
            border-left-style: groove; height: 564px; border-right-color:Black; border-bottom-style: groove">
            <tr>
                <td bgcolor="Black" rowspan="3" style="width: 115px">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Book3.JPG" Width="0px" /></td>
                <td align="center" colspan="2" style="font-weight: bolder; vertical-align: super;
                    color: White; font-family: 'Times New Roman'; height: 56px; background-color: Black;
                    text-align: center" valign="middle">
                    &nbsp;<asp:Image ID="Image3" runat="server" Height="0px" ImageUrl="~/Images/Book4.JPG"
                        Width="0px" />LIBRARY MANAGEMENT SYSTEM<asp:Image ID="Image2" runat="server" Height="0px"
                            ImageUrl="~/Images/Search1.jpeg" Width="0px" /></td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="height: 293px">
                    <asp:Panel ID="Panel1" runat="server" BackColor="DimGray" BorderColor="Red" BorderStyle="Solid"
                        Height="50px" HorizontalAlign="Center" Width="230px">
                        <asp:Label ID="Label1" runat="server" BorderStyle="Double" Font-Bold="True" Font-Names="Times New Roman"
                            Font-Size="Medium" ForeColor="White" Text="You have been logged out..."></asp:Label>&nbsp;<br />
                        <asp:HyperLink ID="HLogin" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Times New Roman"
                            Font-Size="Small" ForeColor="White" NavigateUrl="~/Login.aspx">Login Back..</asp:HyperLink></asp:Panel>
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
