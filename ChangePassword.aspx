<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="ChangePassword.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Library Management System.</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        &nbsp;</div>
        <div style="text-align: center">
            <table cellpadding="1" cellspacing="1" style="border-left-color: #ffcccc; border-bottom-color: #ffcccc;
                width: 976px; border-top-style: groove; border-top-color: #ffcccc; border-right-style: groove;
                border-left-style: groove; height: 564px; border-right-color: #ffcccc; border-bottom-style: groove">
                <tr>
                    <td bgcolor="#ffffcc" rowspan="3" style="width: 115px">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Book3.JPG" Width="113px" /></td>
                    <td align="center" colspan="2" style="font-weight: bolder; vertical-align: super;
                        color: #cc00ff; font-family: 'Times New Roman'; height: 56px; background-color: pink;
                        text-align: center" valign="middle">
                        &nbsp;<asp:Image ID="Image3" runat="server" Height="70px" ImageUrl="~/Images/Book4.JPG"
                            Width="60px" />LIBRARY MANAGEMENT SYSTEM<asp:Image ID="Image2" runat="server" Height="70px"
                                ImageUrl="~/Images/Search1.jpeg" Width="60px" /></td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="height: 293px">
                    <table border="0" cellpadding="1" cellspacing="0" style="width: 591px; border-collapse: collapse">
                        <tr>
                            <td style="width: 579px">
                                <table border="0" cellpadding="1" style="background-color: #ffffcc" cellspacing="1">
                                    <tr>
                                        <td align="center" colspan="2" style="font-weight: bold; color: #00ff99; font-family: 'Times New Roman'; background-color: #663333;" bgcolor="#ffffcc">
                                            Change Your Password</td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 159px; background-color: #ffffcc;">
                                            <asp:Label ID="Label1" runat="server" Text="User Name:"></asp:Label></td>
                                        <td align="left" style="width: 378px">
                                            <asp:TextBox ID="txtUserName" runat="server" ReadOnly="True" Width="140px"></asp:TextBox>
                                            <asp:Label ID="lblName" runat="server" Text="Label" Width="156px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 159px">
                                            <asp:Label ID="CurrentPasswordLabel" runat="server">Password:</asp:Label></td>
                                        <td align="left" style="width: 378px">
                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
                                                ID="CurrentPasswordRequired" runat="server" ControlToValidate="txtPassword"
                                                ErrorMessage="Password is required." ToolTip="Please enter Password." ValidationGroup="ChangePassword1">Please enter Password.</asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 159px">
                                            <asp:Label ID="NewPasswordLabel" runat="server">New Password:</asp:Label></td>
                                        <td align="left" style="width: 378px">
                                            <asp:TextBox ID="txtNPassword" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
                                                ID="NewPasswordRequired" runat="server" ControlToValidate="txtNPassword" ErrorMessage="New Password is required."
                                                ToolTip="please enter New password." ValidationGroup="ChangePassword1">Please enter New password.</asp:RequiredFieldValidator>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            &nbsp;<asp:Label ID="ConfirmNewPasswordLabel" runat="server">Confirm New Password:</asp:Label><asp:TextBox
                                                ID="txtCNPassword" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="txtCNPassword"
                                                    ErrorMessage="Please enter Confirm New Password." ToolTip="Please enter Confirm New Password."
                                                    ValidationGroup="ChangePassword1">Please enter Confirm New Password.</asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color: red">
                                            &nbsp;<asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="txtNPassword"
                                                ControlToValidate="txtCNPassword" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry."
                                                ValidationGroup="ChangePassword1">The Confirm New Password must match the New Password entry.</asp:CompareValidator>
                                            <asp:Label ID="lblMsg" runat="server" Text="..." Visible="False"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 159px">
                                            &nbsp;</td>
                                        <td style="width: 378px" align="left">
                                            <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                                                Text="Change Password" ValidationGroup="ChangePassword1" OnClick="ChangePasswordPushButton_Click" />
                                            &nbsp; 
                                            <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                                Text="Cancel" OnClick="CancelPushButton_Click" />
                                        </td>
                                    </tr>
                                </table>
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
            &nbsp;&nbsp;</div>
    </form>
</body>
</html>
