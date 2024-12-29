<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script type="text/jscript">
history.forward();
</script>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Faculty Feedback</title>
  

<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>
</head>
<body onunload="javascript:history.go(1)"  style="margin: 5px 0px 0px; background-color: #333333; color: #000000;">
    
        <table width="80%" height="100%" align="center" cellpadding="0" cellspacing="0" 
            border="0" style="background-color: #FFD99F"> 
            <tr>
                <td style="height: 285px" align="left" valign="top">
                <form id="form1" runat="server"  style="background-color: #802263">
    <div style="text-align: left; background-color: #FFD99F;">
    <table style="width:auto;border-color:Red;"  border="0" id="TABLE1" onclick="return TABLE1_onclick()" >
        <tr>
            <td colspan="3" valign="middle">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Website_2.jpg" Width="100%" /></td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center" valign="middle">
                <span style="font-size: 14pt; font-family: Trebuchet MS">
                </span></td>
        </tr>
          <tr>
          <td style="width: 269px;" valign="middle">
              <strong><span style="color: #336666; text-decoration: underline;">
                  <asp:Label ID="Label2" runat="server" Font-Names="Verdana" Font-Size="Small" ForeColor="#400000"
                      Text="Faculty Name:" Width="172px"></asp:Label></span></strong></td>
          <td style="width: 1262px" valign="middle">
              <asp:Label ID="FName" runat="server" Font-Bold="True" Text="Label" ForeColor="Maroon" Font-Names="Verdana" Font-Size="Small"></asp:Label></td>
              <td style="width: 1262px" valign="middle">
                  <asp:Label ID="Label1" runat="server" Width="79px" Font-Names="Verdana" Font-Size="Small" ForeColor="Maroon"></asp:Label></td>
            </tr>       
          <tr>
          <td style="width: 269px; height: 23px;" valign="middle">
              <strong><span style="color: #336666; text-decoration: underline;">
                  <asp:Label ID="Label3" runat="server" Font-Names="Verdana" Font-Size="Small" ForeColor="#400000"
                      Text="Subject Name:" Width="129px"></asp:Label></span></strong></td>
          <td style="width: 1262px; height: 23px;" valign="middle">
              <asp:Label ID="SName" runat="server" Font-Bold="True" Text="Label" Font-Names="Verdana" Font-Size="Small" ForeColor="Maroon"></asp:Label></td>
              <td>
                  <asp:Button ID="Button1" runat="server" Height="29px" onclick="Button1_Click1" 
                      Text="Skip" Width="90px" BackColor="#FFC977" BorderStyle="Solid" 
                      Font-Bold="True" />
                  </td>
          </tr>
          
    </table>       
    <br />
       
    <table style="border-color:Red;" cellpadding="5" border="0">
          <asp:Repeater ID="RepeaterQuestion" runat="server" 
              DataSourceID="QuestionSqlDataSource" 
            >
                <HeaderTemplate>
                  <tr>
                    <td align="center" style="text-decoration: underline;color: #333333 ;font-style:oblique ;";><strong>Sr.No</strong>
                    </td >
                    <td align="left" style="text-decoration: underline;color: #333333;width:500; font-style:oblique"><strong>Question </strong> 
                    </td><%--<td> Option : 1  
                    </td><td> Option : 2  
                    </td><td> Option : 3  
                    </td><td> Option : 4  
                   
                 </td>--%>
                 </tr>
                </HeaderTemplate>
                  <ItemTemplate>
                  
                 
              <tr >
                    <td align="center"> 
                           <asp:Label ID="Question_IDLabel" Font-Bold="True" Text='<%# Eval("Question_id") %> ' runat="server"  />
                    </td>
                    <td   style="width:auto ">   
                            <asp:Label ID="LabelQuestion" Font-Bold="True" width="500px" Text='<%# Eval("Question") %> ' ForeColor="#333333"    runat="server" />
                    </td>
                    <td></td>
              </tr>
              <tr>
                    <td>
                   </td>
                   <td>
                          <asp:RadioButton id="RadioButtonrdbtnOption_1" Width="150px" Text='<%# Eval("Option_1") %> ' GroupName="grpOption" runat="server" />
                          <asp:RadioButton id="RadioButtonrdbtnOption_2" Width="150px" Text='<%# Eval("Option_2") %> ' GroupName="grpOption" runat="server" />
                          <asp:RadioButton id="RadioButton1" Width="150px"  Text='<%# Eval("Option_3") %> ' GroupName="grpOption" runat="server" />
                          
                  </td>
                          
                          <td></td>
               </tr>
            
             </ItemTemplate>
          
          </asp:Repeater>
          <tr align="center"><td align="center"><asp:Button ID="SubmitBotton" runat="server" 
                  OnClick="Button1_Click" Text="Submit" Font-Bold="True" Height="30px" 
                  Width="88px" BackColor="#FFC977" BorderStyle="Solid"  /></td></tr>
     </table>
     <br />
     
              <asp:SqlDataSource ID="QuestionSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:FeedBackConnectionString2 %>"
            SelectCommand="SELECT * FROM [Question_Master]" InsertCommand="INSERT INTO FeedbackEntry(Class, Branch, Faculty_id, Q_id, Feedback) VALUES (03, CE, 01,@Q_id,@Feedback)">
          <InsertParameters>
              <asp:Parameter Name="Q_id" />
              <asp:Parameter Name="Feedback" />
          </InsertParameters>
            </asp:SqlDataSource>
        &nbsp; &nbsp;&nbsp;
                 
            <asp:SqlDataSource ID="FacultySqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:FeedbackConnectionString2 %>"
            SelectCommand="SELECT * FROM [Faculty_Master]"></asp:SqlDataSource>
                
            <asp:SqlDataSource ID="SubjectSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:FeedbackConnectionString2 %>"
            SelectCommand="SELECT * FROM [Subject_Master]"></asp:SqlDataSource>
        &nbsp;
      
     </div>
    </form>  
                
                </td>
            </tr>
        </table>
   
</body>
</html>
