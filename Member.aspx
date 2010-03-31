<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="Member" %>

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
            border-left-style: groove; height: 529px; border-right-color: #ffcccc; border-bottom-style: groove">
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
                <td align="center" colspan="2" style="height: 276px">
                    &nbsp;<table cellpadding="1" cellspacing="1">
                        <tr>
                            <td align="center" colspan="3" style="font-weight: bold; vertical-align: middle;
                                color: #00ff99; border-top-style: outset; font-family: 'Times New Roman'; border-right-style: outset;
                                border-left-style: outset; background-color: #663333; text-align: center; border-bottom-style: outset">
                                                Sign Up for Your New Account</td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                                <asp:Label ID="Label10" runat="server" Text="Registration No:"></asp:Label></td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                                                <asp:TextBox ID="txtReg" runat="server" ReadOnly="True" Width="200px" ValidationGroup="Login1"></asp:TextBox></td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label></td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                                                <asp:TextBox ID="UserName" runat="server" Width="200px" MaxLength="20" ValidationGroup="Login1"></asp:TextBox></td>
                            <td align="left" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ToolTip="User Name is required." ValidationGroup="Login1">User Name is required.</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label></td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                                                <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="200px" ValidationGroup="Login1" MaxLength="20"></asp:TextBox></td>
                            <td align="left" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ToolTip="Password is required." ValidationGroup="Login1">Password is required.</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label></td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" Width="200px" ToolTip="Login1" MaxLength="20"></asp:TextBox></td>
                            <td align="left" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" ToolTip="Confirm Password is required."
                                                    ValidationGroup="Login1">Confirm Password is required.</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                                <asp:Label ID="Label1" runat="server" Text="First Name:"></asp:Label></td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                                                <asp:TextBox ID="txtFName" runat="server" Width="200px" ValidationGroup="Login1" MaxLength="30"></asp:TextBox></td>
                            <td align="left" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFName"
                                                    ToolTip="Please enter First Name." ValidationGroup="Login1">Please enter First Name.</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                                <asp:Label ID="Label11" runat="server" Text="Middle Name:"></asp:Label></td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                                                <asp:TextBox ID="txtMName" runat="server" Width="200px" ValidationGroup="Login1" MaxLength="20"></asp:TextBox></td>
                            <td align="left" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                                <asp:Label ID="Label12" runat="server" Text="Last Name:"></asp:Label></td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                                                <asp:TextBox ID="txtLName" runat="server" Width="200px" ValidationGroup="Login1" MaxLength="20"></asp:TextBox></td>
                            <td align="left" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtLName" ToolTip="Please enter Last Name."
                                                    ValidationGroup="Login1">Please enter Last Name.</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                                <asp:Label ID="Label4" runat="server" Text="Address:"></asp:Label></td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="200px" ValidationGroup="Login1" MaxLength="200"></asp:TextBox></td>
                            <td align="left" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddress" ToolTip="Please enter Address."
                                                    ValidationGroup="Login1">Please enter Address.</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label></td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                                                <asp:TextBox ID="Email" runat="server" Width="200px" ValidationGroup="Login1" MaxLength="100"></asp:TextBox></td>
                            <td align="left" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ToolTip="E-mail is required." ValidationGroup="Login1" Display="Dynamic">E-mail is required.</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email"
                                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="Login1">Enter a Valid E-mail.</asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                                <asp:Label ID="Label2" runat="server" Text="Land No:"></asp:Label></td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                                                <asp:TextBox ID="txtLline" runat="server" Width="200px" ValidationGroup="Login1" MaxLength="10"></asp:TextBox></td>
                            <td align="left" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLline" ValidationGroup="Login1" Display="Dynamic">Please enter Land No.</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLline"
                                    Display="Dynamic" ErrorMessage="RegularExpressionValidator" ValidationGroup="Login1" ValidationExpression="\d[0-9]*">Please enter valid Land No.</asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                                <asp:Label ID="Label3" runat="server" Text="Mobile:"></asp:Label></td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                                                <asp:TextBox ID="txtMobile" runat="server" Width="200px" ValidationGroup="Login1" MaxLength="10"></asp:TextBox></td>
                            <td align="left" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobile" ValidationGroup="Login1" Display="Dynamic">Please enter Mobile No.</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMobile"
                                    Display="Dynamic" ErrorMessage="RegularExpressionValidator" ValidationGroup="Login1" ValidationExpression="\d[0-9]*">Please enter valid Mobile No.</asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                                <asp:Label ID="Label5" runat="server" Text="Sex:"></asp:Label></td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                                                <asp:RadioButton ID="optMale" runat="server" GroupName="t1" Text="Male" ValidationGroup="Login1" Checked="True" />
                                &nbsp;
                                                <asp:RadioButton ID="optFemale" runat="server" GroupName="t1" Text="Female" ValidationGroup="Login1" /></td>
                            <td align="left" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                                <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security Question:</asp:Label></td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                                                <asp:TextBox ID="Question" runat="server" Width="200px" ValidationGroup="Login1" MaxLength="100"></asp:TextBox></td>
                            <td align="left" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question" ToolTip="Security question is required."
                                                    ValidationGroup="Login1">Security question is required.</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                                <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security Answer:</asp:Label></td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; background-color: #ffffcc">
                                                <asp:TextBox ID="Answer" runat="server" Width="200px" ValidationGroup="Login1" MaxLength="100"></asp:TextBox></td>
                            <td align="left" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer" ToolTip="Security answer is required."
                                                    ValidationGroup="Login1">Security answer is required.</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                                    ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                                    ValidationGroup="Login1" Font-Size="Smaller" Width="585px"></asp:CompareValidator></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                background-color: #ffffcc">
                                &nbsp;<asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="CustomValidator" ValidationGroup="Login1" Width="269px" Display="Dynamic"></asp:CustomValidator><asp:Label ID="lblEMsg" runat="server" ForeColor="Red" Visible="False" Width="238px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 187px; color: #0000cc; font-family: 'Times New Roman';
                                height: 26px; background-color: #ffffcc">
                            </td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; height: 26px;
                                background-color: #ffffcc">
                                <asp:Button ID="btnSignUp" runat="server" OnClick="btnSignUp_Click" Text="Sign Up"
                                    ValidationGroup="Login1" />
                                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />
                            </td>
                            <td style="width: 187px; color: #0000cc; font-family: 'Times New Roman'; height: 26px;
                                background-color: #ffffcc">
                            </td>
                        </tr>
                    </table>
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 55px">
                </td>
                <td style="width: 755px; height: 55px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
