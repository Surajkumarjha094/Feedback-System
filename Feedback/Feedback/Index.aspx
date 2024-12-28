<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script type="text/jscript">
history.forward();

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Feedback Login</title>
 
    <style type="text/css">
        .style2
        {
            height: 34px;
        }
        .style3
        {
            height: 321px;
        }
    </style>
 
</head>
<body bgcolor="White" style="color: #000000" >
    <form id="form1" runat="server" style="background-color: #802263">
    <div style="margin: 0px; background-color: #333333">
        <table style="width: 83%; height: 591px; background-color: #FFD99F;" 
            align="center">
            <tr>
                <td style="border: 0px hidden #000000; background-color: #FFD99F; font-weight: bold; font-style: normal; height: 22px; width: 810px; text-align: center;" 
                    class="style2">
                    <div style="text-align: left">
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Website_2.jpg" Height="171px" Width="100%" /></td>
                            </tr>
                        </table>
                    </div>
                    <%# DateTime.Now %>
                    <span style="font-size: 14pt; color: #330000; font-family: Trebuchet MS">
                        <span style="color: cornflowerblue">
                            <br />
                        </span></span></td>
            </tr>
            <tr>
                <td style="border: 0px hidden #000000; background-color: #FFD99F; font-weight: bold; font-style: normal; height: 321px; width: 810px;" 
                    align ="center" valign ="top" class="style3">
                    &nbsp;<asp:Login ID="Login1" runat="server" BackColor="Moccasin" BorderColor="#FFE0C0" BorderPadding="4" BorderStyle="Outset" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="Black" Height="217px">
                        <LayoutTemplate>
                            <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse">
                                <tr>
                                    <td style="border: thick solid #000000; height: 213px; background-color: #FFD99F; font-weight: bold; font-style: normal;">
                                        <table border="0" cellpadding="0">
                                            <tr>
                                                <td align="center" colspan="2">
                                                    Log In</td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User 
                                                    Name:</asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="UserName" runat="server" align="left" Width="150px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label></td>
                                                <td align="left">
                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="150px" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" style="height: 19px" align="left">
                                                    <asp:Label ID="Label1" runat="server" Text="Semester"></asp:Label></td>
                                                <td colspan="2" style="height: 19px" align="left">
                                                    <asp:DropDownList ID="Sem" runat="server" CausesValidation="True" Width="157px">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem Value="1">1st</asp:ListItem>
                                                        <asp:ListItem Value="2">2nd</asp:ListItem>
                                                        <asp:ListItem Value="3">3rd</asp:ListItem>
                                                        <asp:ListItem Value="4">4TH</asp:ListItem>
                                                        <asp:ListItem Value="5">5th</asp:ListItem>
                                                        <asp:ListItem Value="6">6TH</asp:ListItem>
                                                    </asp:DropDownList>&nbsp;
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                        runat="server" ControlToValidate="Sem" Display="Dynamic" ErrorMessage="*" ValidationGroup="Login1"></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" colspan="1" style="height: 22px" >
                                                    <asp:Label ID="Label2" runat="server" Text="Branch"></asp:Label></td>
                                                <td align="left" valign="top" colspan="2" style="height: 22px" >
                                                    <asp:DropDownList ID="Branch" runat="server" CausesValidation="True" 
                                                        Width="157px">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem Value="SCE1">SSPC-CE</asp:ListItem>
                                                        <asp:ListItem Value="NCE1">NPC-CE</asp:ListItem>
                                                        <asp:ListItem Value="SCV1">SSPC-CIVIL</asp:ListItem>
                                                        <asp:ListItem Value="NCV1">NPC-CIVIL</asp:ListItem>
                                                        <asp:ListItem Value="SEC1">SSPC-ECI</asp:ListItem>
                                                        <asp:ListItem Value="SEC2">SSPC-ECII</asp:ListItem>
                                                        <asp:ListItem Value="NEC1">NPC-ECI</asp:ListItem>
                                                        <asp:ListItem Value="NEC2">NPC-ECII</asp:ListItem>
                                                        <asp:ListItem Value="SEE1">SSPC-EEI</asp:ListItem>
                                                        <asp:ListItem Value="SEE2">SSPC-EEII</asp:ListItem>
                                                        <asp:ListItem Value="NEE1">NPC-EE</asp:ListItem>
                                                        <asp:ListItem Value="SME1">SSPC-MEI</asp:ListItem>
                                                        <asp:ListItem Value="SME2">SSPC-MEII</asp:ListItem>
                                                        <asp:ListItem Value="NME1">NPC-MEI</asp:ListItem>
                                                        <asp:ListItem Value="NME2">NPC-MEII</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Branch"
                                                        Display="Dynamic" ErrorMessage="*" ValidationGroup="Login1"></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." Visible="False" />
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="height: 19px" valign="middle">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                                                        ValidationGroup="Login1" OnClick="LoginButton_Click" BackColor="#FFD99F" 
                                                        BorderStyle="Solid" Font-Bold="True" Font-Names="Verdana" Width="131px" /></td>
                                            </tr>
                                        </table>
                                        </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                        <TextBoxStyle Font-Size="0.8em" />
                        <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"
                            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                    </asp:Login>
                    <br />
                    <br style="border: 0px hidden #000000; height: 213px; background-color: #FFD99F; font-weight: bold; font-style: normal;" />
                    <br style="background-color: #2D0000" />
                    <br style="border-style: solid; border-width: thick; height: 213px; background-color: #FFB13E; font-weight: bold; font-style: normal;" />
                    <br style="border: thick solid #000000; height: 213px; background-color: #FFF5E8; font-weight: bold; font-style: normal;" />
                    <br style="border-style: solid; border-width: thick; height: 213px; background-color: #FFB13E; font-weight: bold; font-style: normal;" />
                    <br style="border-style: solid; border-width: thick; height: 213px; background-color: #FFB13E; font-weight: bold; font-style: normal;" />
           
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
