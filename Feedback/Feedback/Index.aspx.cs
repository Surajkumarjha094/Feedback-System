using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
        string ip = Request.UserHostAddress;
        Session.Add("ip", ip);
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        String conn = ConfigurationManager.ConnectionStrings["FeedBackConnectionString2"].ToString();
        SqlConnection Con = new SqlConnection(conn);
        SqlCommand Cmd = new SqlCommand("Select * from Login_Master where UserName= '" + Login1.UserName + "' and Password='" + Login1.Password + "' ", Con);
        SqlDataReader rd = null;
        DropDownList Sem = Login1.FindControl("Sem") as DropDownList;
        DropDownList Branch = Login1.FindControl("Branch") as DropDownList;
        Label FailureText = Login1.FindControl("FailureText") as Label;

        try
        {
            Con.Open();
            rd = Cmd.ExecuteReader();
            if (rd.Read())
            {
                if ((rd.GetString(0)).StartsWith("admin"))
                {
                    Session.Add("Admin", Login1.UserName);
                    
                    Response.Redirect("Admin/FwiseReport.aspx");
              
                }
                else
                {
                    String ClassName = Branch.SelectedValue.ToString() + Sem.SelectedValue.ToString();
                   // ClassName = Branch.SelectedValue + Sem.SelectedValue;
                    //if (Branch.SelectedItem.Value.Contains("2"))
                    //{
                    //    ClassName = Branch.SelectedValue;
                    //}
                    //else
                    //{
                    //    ClassName = Branch.SelectedValue + Sem.SelectedValue;
                    //}


                    /*
                    if (Branch.SelectedValue == "CE" && Sem.SelectedValue == "5")
                    {

                        ClassName = "CE" + "5";
                    }
                    else if (Branch.SelectedValue == "CEII" && Sem.SelectedValue == "5")
                    {
                        ClassName = "CE" + "6";
                    }
                    else if (Branch.SelectedValue == "EC" && Sem.SelectedValue == "5")
                    {
                        ClassName = "EC" + "5";
                    }
                    else if (Branch.SelectedValue == "ECII" && Sem.SelectedValue == "5")
                    {
                        ClassName = "EC" + "6";
                    }

                    else if (Branch.SelectedValue == "EC" && Sem.SelectedValue == "3")
                    {
                        ClassName = "EC" + "3";
                    }
                    else if (Branch.SelectedValue == "ECII" && Sem.SelectedValue == "3")
                    {
                        ClassName = "EC" + "4";
                    }
                     else {
                       ClassName = Branch.SelectedValue + Sem.SelectedValue;
                    }
                   */
                    // if (Branch.SelectedValue == "CE" && Sem.SelectedValue == "1") {

                    //     ClassName = "CE" + "1";
                    // }
                    // else if (Branch.SelectedValue == "CEII" && Sem.SelectedValue == "1")
                    // {
                    //     ClassName = "CE" + "2";
                    // }
                    // else if (Branch.SelectedValue == "EC" && Sem.SelectedValue == "1")
                    // {
                    //     ClassName = "EC" + "1";
                    // }
                    // else if (Branch.SelectedValue == "ECII" && Sem.SelectedValue == "1")
                    // {

                    //     ClassName = "EC" + "2";
                    // }
                    //     else {
                    //    ClassName = Branch.SelectedValue + Sem.SelectedValue;
                    //}

                    /*
                    if (Branch.SelectedValue == "CE" && Sem.SelectedValue == "3")
                    {

                        ClassName = "CE" + "3";
                    }
                    else if (Branch.SelectedValue == "CEII" && Sem.SelectedValue == "3")
                    {
                        ClassName = "CE" + "4";
                    }
                    else if (Branch.SelectedValue == "EC" && Sem.SelectedValue == "3")
                    {
                        ClassName = "EC" + "3";
                    }
                    else if (Branch.SelectedValue == "ECII" && Sem.SelectedValue == "3")
                    {
                        ClassName = "EC" + "4";
                    }
                    else {
                        ClassName = Branch.SelectedValue + Sem.SelectedValue;
                    }
                    */

                    Session.Add("ClassName", ClassName);
                    // Response.Write("window.open('Default.aspx',,,false)"); 
                    Response.Redirect("Default.aspx");


                }
            }

        }

        catch (Exception Ex)
        {
            Response.Write(Ex);

        }
        finally
        {
            try
            {
                if (rd.IsClosed == false)
                    rd.Close();
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

    }
}
