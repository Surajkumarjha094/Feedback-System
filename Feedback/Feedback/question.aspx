<%@ Page Language="C#" AutoEventWireup="true" CodeFile="question.aspx.cs" Inherits="question" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Feedback Questions</title>
</head>
<body>
<form id="form1" runat="server">
 <table style="border-color:Red;" cellpadding="5" border="0">
          <asp:Repeater ID="RepeaterQuestion" runat="server" DataSourceID="QuestionSqlDataSource">
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
                            <asp:Label ID="LabelQuestion" Font-Bold="True" width="500px" Text='<%# Eval("Question") %> ' ForeColor="Black"    runat="server" />
                    </td>
                    <td></td>
              </tr>
              <tr>
                    <td>
                   </td>
                   <td>
                         
                          <asp:Label id="Label1"  Width="150px" Text='<%# "A. " + Eval("Option_1") %> ' runat="server"></asp:Label>
                          <asp:Label id="Label2"  Width="150px" Text=' <%# "B. "+Eval("Option_2") %> ' runat="server"></asp:Label>
                          <asp:Label id="Label3" Width="150px" Text='<%# "C. "+Eval("Option_3") %> ' runat="server"></asp:Label>
                          <asp:Label id="Label4" Width="150px" Text='<%# "D. "+Eval("Option_4") %> ' runat="server"></asp:Label>
                          
                  </td>
                          <td></td>
               </tr>
             <!--  <tr>
                    <td></td>
                    <td  valign="middle">  
                             <asp:RadioButton id="RadioButtonrdbtnOption_3" width="200px" Text='<%# Eval("Option_3") %> ' GroupName="grpOption" runat="server" />
                   <%-- </td>
                    <td valign="middle">  --%>
                         <asp:RadioButton id="RadioButtonrdbtnOption_4" width="200px" Text='<%# Eval("Option_4") %> ' GroupName="grpOption" runat="server" />
                    </td>
               </tr>  -->
             </ItemTemplate>
          
          </asp:Repeater>
          
     </table>

    
    <div>
        <asp:SqlDataSource ID="QuestionSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:FeedBackConnectionString2 %>"
            InsertCommand="INSERT INTO FeedbackEntry(Class, Branch, Faculty_id, Q_id, Feedback) VALUES (03, CE, 01,@Q_id,@Feedback)"
            SelectCommand="SELECT * FROM [Question_Master]">
            <InsertParameters>
                <asp:Parameter Name="Q_id" />
                <asp:Parameter Name="Feedback" />
            </InsertParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
