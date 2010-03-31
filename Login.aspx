<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Library Management System.</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="1" cellspacing="1" style="border-left-color: Black; border-bottom-color: Black;
            width: 976px; border-top-style: groove; border-top-color: Black; border-right-style: groove;
            border-left-style: groove; height: 564px; border-right-color:Black ; border-bottom-style: groove">
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
                <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse">
                    <tr>
                        <td style="width: 387px; height: 156px" bgcolor="Silver">
                            <table border="0" cellpadding="0" bgcolor="#ffffcc">
                                <tr>
                                    <td align="center" colspan="2" style="font-weight: bold; color: white; background-color: #6b696b" bgcolor="#ffffcc">
                                        Sign In to Library Management System</td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 77px">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label></td>
                                    <td style="width: 294px" align="left">
                                        <asp:TextBox ID="UserName" runat="server" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            Font-Size="Smaller" ToolTip="Please enter User Name." ValidationGroup="Login1">Please enter User Name.</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 77px">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label></td>
                                    <td style="width: 294px" align="left">
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            Font-Size="Smaller" ToolTip="Please enter Password." ValidationGroup="Login1">Please enter Password.</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color: red">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        <asp:Label ID="lblErrorMsg" runat="server" Visible="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" OnClick="LoginButton_Click"
                                            Text="Sign In" ValidationGroup="Login1" />
                                    </td>
                                </tr>
                            </table>
                            &nbsp;&nbsp;
                            <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="Red" Text="Don't have an account: "></asp:Label>
                            &nbsp;
                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="~/Member.aspx">Sign Up....</asp:HyperLink>
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
