<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FwiseReport.aspx.vb" Inherits="FwiseReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Feedback Analysis</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" /><style type="text/css">
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
.style2 {color: #FFFFFF; font-weight: bold; font-family: Verdana, Arial, Helvetica, sans-serif; }
.style3 {font-family: Verdana, Arial, Helvetica, sans-serif}
                                                                              .style4
                                                                              {
                                                                                  font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                  height: 37px;
                                                                              }
                                                                              .style5
                                                                              {
                                                                                  font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                  width: 102px;
                                                                                  height: 37px;
                                                                              }
                                                                              .style8
                                                                              {
                                                                                  font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                  width: 193px;
                                                                                  height: 38px;
                                                                              }
                                                                              .style9
                                                                              {
                                                                                  font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                  width: 113px;
                                                                                  height: 38px;
                                                                              }
                                                                              .style10
                                                                              {
                                                                                  font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                  font-weight: bold;
                                                                                  width: 193px;
                                                                                  height: 28px;
                                                                              }
                                                                              .style11
                                                                              {
                                                                                  font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                  height: 30px;
                                                                              }
                                                                              .style14
                                                                              {
                                                                                  font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                  height: 23px;
                                                                              }
                                                                              .style15
                                                                              {
                                                                                  font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                  width: 113px;
                                                                                  height: 28px;
                                                                              }
-->
</style></head>
<body>
    <form id="form1" runat="server" >
	<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FeedbackConnectionString2 %>"
            
        
        
        
        SelectCommand="SELECT [Faculty_Name], [Faculty_Code] FROM [Faculty_Master] WHERE ([Faculty_Code] LIKE '%' + @Faculty_Code + '%')">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList2" Name="Faculty_Code" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
       
	<table width="80%" height ="75%" border="2" align="center" cellpadding="0" cellspacing="0" bordercolor="#004080" bgcolor="#FFD99F">
        <tr style="background-color: #004080">
            <td bgcolor="burlywood" colspan="3" style="height: 20px; text-align: center;">
                <span style="font-size: 14pt; color: #330000; font-family: Trebuchet MS">
                    <asp:Image ID="Image1" runat="server" ImageAlign="Left" ImageUrl="~/Images/Website_2.jpg"
                        Width="100%" /></span></td>
        </tr>
  <tr style="background-color:#004080">
    <td bgcolor="burlywood" style="width: 261px; height: 20px;"><div align="center" class="style2">FACULTY WISE </div></td>
    <td bgcolor="burlywood" style="width: 204px; height: 20px;"><div align="center" class="style2">CLASS WISE </div></td>
    <td width="34%" bgcolor="burlywood" style="height: 20px"><div align="center" class="style2">OVERALL REPORT </div></td>
  </tr>
  <tr>
    <td align="left" valign="top" style="width: 261px; height: 106px"><table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td class="style10" style="height: 60px">
              &nbsp; <span style="font-size: 10pt; color: #330000">Department:</span>
          </td>
          <td class="style15" style="height: 60px">
              &nbsp;<asp:DropDownList ID="DropDownList2" 
                  runat="server" CausesValidation="True" 
                                                        Width="127px" AutoPostBack="True" 
                  Height="27px">
                  <asp:ListItem></asp:ListItem>
                  <asp:ListItem Value="SCE">SSPC-CE</asp:ListItem>
                  <asp:ListItem Value="NCE">NPC-CE</asp:ListItem>
                  <asp:ListItem Value="SCV">SSPC-CIVIL</asp:ListItem>
                  <asp:ListItem Value="NCV">NPC-CIVIL</asp:ListItem>
                  <asp:ListItem Value="SEC">SSPC-ECI</asp:ListItem>
                  <asp:ListItem Value="SEC">SSPC-ECII</asp:ListItem>
                  <asp:ListItem Value="NEC">NPC-ECI</asp:ListItem>
                  <asp:ListItem Value="NEC">NPC-ECII</asp:ListItem>
                  <asp:ListItem Value="SEE">SSPC-EEI</asp:ListItem>
                  <asp:ListItem Value="SEE">SSPC-EEII</asp:ListItem>
                  <asp:ListItem Value="NEE">NPC-EE</asp:ListItem>
                  <asp:ListItem Value="SME">SSPC-MEI</asp:ListItem>
                  <asp:ListItem Value="SME">SSPC-MEII</asp:ListItem>
                  <asp:ListItem Value="NME">NPC-MEI</asp:ListItem>
                  <asp:ListItem Value="NME">NPC-MEII</asp:ListItem>
                  <asp:ListItem Value="SGN">SGen</asp:ListItem>
                  <asp:ListItem Value="NGN">NGen</asp:ListItem>
              </asp:DropDownList></td>
        </tr>
        <tr>
          <td class="style8" style="height: 53px"><div align="right" style="text-align: left"><strong>&nbsp;<span style="font-size: 10pt; color: #330000">FacultyName:</span>
          </strong></div></td>
          <td class="style9" style="height: 53px"><span style="width: 100px; height: 21px">&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" datasourceid="SqlDataSource1"
            DataTextField="Faculty_Name" DataValueField="Faculty_Code" 
                  DataMember="DefaultView" Width="123px" Height="17px" >
              <asp:ListItem Selected="True"></asp:ListItem>
            </asp:DropDownList></span></td>
        </tr>
        <tr>
          <td class="style3" colspan="2" style="height: 27px">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <span style="width: 100px; height: 27px"><strong>
                &nbsp;<asp:Button ID="Button1" runat="server" Text="Display" BorderStyle="Solid" 
                  Font-Bold="True" Width="80px" Height="24px" /></strong></span></td>
        </tr>
      </table>      </td>
    <td align="left" valign="top" style="width: 204px; height: 106px">
        <table width="100%" border="0" cellpadding="0" cellspacing="0" 
            style="height: 101%">
        <tr>
          <td width="60%" class="style4" style="height: 48px"><div align="right"><strong> <span style="font-size: 10pt; color: #330000">Semester:</span>&nbsp; </strong></div></td>
          <td class="style5" style="height: 48px"><span style="width: 100px; height: 21px">
            <asp:DropDownList ID="Sem" runat="server" Height="27px" Width="128px">
              <asp:ListItem></asp:ListItem>
	            <asp:ListItem Value="1">1st Sem</asp:ListItem>
                <asp:ListItem Value="2">2nd sem</asp:ListItem>
	             <asp:ListItem Value="3">3rd Sem</asp:ListItem>
                <asp:ListItem Value="4">4th sem</asp:ListItem>
              <asp:ListItem Value="5">5th Sem</asp:ListItem>
                <asp:ListItem Value="6">6th sem</asp:ListItem>
            </asp:DropDownList>
          </span></td>
        </tr>
        <tr>
          <td class="style4" style="height: 63px"><div align="right" style="text-align: left"><strong> <span style="font-size: 10pt; color: #330000">Branch :</span> </strong></div></td>
          <td class="style5" style="height: 63px">
                                                    <asp:DropDownList ID="Branch" runat="server" CausesValidation="True" 
                                                        Width="128px" Height="27px">
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
                                                    </td>
        </tr>
        <tr>
          <td class="style3" style="height: 37px" colspan="2">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <span style="width: 112px; height: 21px"><asp:Button ID="Button2" runat="server" Text="Display" Width="80px" 
                  BorderStyle="Solid" Font-Bold="True" Height="24px" Font-Underline="False" />            
          </span></td>
        </tr>
      </table></td>
    <td style="height: 106px"><table border="0" cellspacing="0" cellpadding="0" 
            style="height: 149px; width: 90%">
        <tr>
          <td class="style11" style="height: 28px; width: 120px; text-align: left;">
              <b><span style="font-size: 10pt; color: #330000">Department:</span></b><span style="font-size: 10pt;
                  color: #330000"> </span>
          </td>
        </tr>
        <tr>
          <td class="style14" style="width: 120px">
                                                    <asp:DropDownList ID="Branch1" 
                  runat="server" CausesValidation="True" 
                                                        Width="127px" AutoPostBack="True" 
                  Height="27px">
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
                                                        <asp:ListItem Value="SGN">SGen</asp:ListItem>
                                                        <asp:ListItem Value="NGN">NGen</asp:ListItem>
                                                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
          <td class="style3" style="height: 8px; width: 120px;">
              <span style="width: 112px; height: 21px; position: relative;">&nbsp; &nbsp; &nbsp;
            <asp:Button ID="Button3" runat="server" Text="Display" Width="80px" 
                  BorderStyle="Solid" Font-Bold="True" Height="24px" />&nbsp;</span></td>
        </tr>
      </table>
                </td>
  </tr>
  <tr>
    <td height="500" colspan="3" align="center" valign="middle"><div align="center" class="style3">    <span style="margin: 0px">
    <asp:GridView ID="GridView1" runat="server"  AllowPaging="True" CellPadding="4" 
            ForeColor="Black" Font-Names="Verdana" Font-Size="Small" PageSize="20" 
            AllowSorting="True" GridLines="Vertical" Height="50px" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"> 
        <FooterStyle BackColor="#CCCC99" 
            HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <HeaderStyle BackColor="#FFD99F" Font-Bold="True" ForeColor="Maroon" 
            Width="100px" Font-Size="Medium" />
        <AlternatingRowStyle BackColor="White" ForeColor="Black" />
    </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" >
            &nbsp;</asp:Panel>
        &nbsp; &nbsp;&nbsp;
    </span></div>      </td>
    </tr>
</table>

    <div style="margin: 0px">
        <br />
        &nbsp;</div>
    </form>
</body>
</html>
