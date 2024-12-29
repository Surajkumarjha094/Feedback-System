using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
      DataTable dt=null;
      Int32 i = 0;
     Boolean flag=false;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack == false)
        {
            dt = new DataTable();
    
           
            try
            {

                String conn = ConfigurationManager.ConnectionStrings["FeedBackConnectionString2"].ToString();
                SqlConnection Con = new SqlConnection(conn);
                String className = Session["ClassName"].ToString() + "%";
                
                String Str = "SELECT Faculty_Master.Faculty_Code, Faculty_Master.Faculty_Name, Faculty_Subject.Subject_Code, Subject_Master.Subject_Title FROM Faculty_Master INNER JOIN Faculty_Subject ON Faculty_Master.Faculty_Code = Faculty_Subject.Faculty_Code INNER JOIN Subject_Master ON Faculty_Subject.Subject_Code = Subject_Master.Subject_Code ";
                SqlDataAdapter Adpt = new SqlDataAdapter(Str + "Where Faculty_Subject.Subject_Code like '" + className + "'", Con);
                //if(dt.Rows.Count != 0)
                //{
                //    dt =null;
                ////    i = 0;
                //}
                Adpt.Fill(dt);

                String incompletedQuery = "SELECT IPAddress,max(seq_no)as last_seq_no from IncompletedFeedback WHERE (IPAddress = '" + Request.UserHostAddress + "') group by IPAddress";
                SqlDataAdapter incompletedAdpt = new SqlDataAdapter(incompletedQuery, Con);
                DataTable incompletedFeedback = new DataTable();
                incompletedAdpt.Fill(incompletedFeedback);
                
                if (incompletedFeedback.Rows.Count > 0)
                {
                    i = Int32.Parse(incompletedFeedback.Rows[0]["last_seq_no"].ToString());
                }

                // GridView1.DataSource = dt;
                //   GridView1.DataBind();
                Session.Add("dt", dt);
                Session.Add("i", i);
             //   Session.Add("flag", flag);

            }
            catch (Exception ex)
            {
                Response.Write(ex);
                Response.Redirect("index.aspx");

            }
        }
        else
        {
            dt= (DataTable)Session["dt"];
            i=(Int32 )Session["i"];
         //  flag= (Boolean )Session ["flag"];

        }
       
        if (i < dt.Rows.Count)
        {
            String className = Session["ClassName"].ToString();
            Label1.Text = "[" + (i+1) + " of " + dt.Rows.Count +"]"  ; 
            FName.Text = dt.Rows[i]["Faculty_Name"].ToString();
            SName.Text = dt.Rows[i]["Subject_Title"].ToString();
            //if (className == "ME7" && (dt.Rows[i]["Subject_Code"].ToString() == "ME705" || dt.Rows[i]["Subject_Code"].ToString() == "ME706"))
            //{
            //    Button1.Visible = true;
            //}
            //else if (className == "EC7" && (dt.Rows[i]["Subject_Code"].ToString() == "EC706" || dt.Rows[i]["Subject_Code"].ToString() == "EC707"))
            //{
            //    Button1.Visible = true;
            //}
            //else if (className == "EE7" && (dt.Rows[i]["Subject_Code"].ToString() == "EE704" || dt.Rows[i]["Subject_Code"].ToString() == "EE705"))
            //{
            //    Button1.Visible = true;
                 
            //}

            //else
            //{
            //    Button1.Visible = true;
            //}
            
        }
        else {
            string ip = Request.UserHostAddress;
            String incomleteQuery = "delete from IncompletedFeedback where IPAddress = '" + ip + "'";
            QuestionSqlDataSource.DeleteCommand = incomleteQuery;
            QuestionSqlDataSource.Delete();


            Session.Clear();
            Response.Redirect("Index.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        flag = false;
        string inst = "";
       
          foreach (RepeaterItem ri in RepeaterQuestion.Items)
        {
            Label  Q_idLabel = (Label)ri.Controls[1];
            Label Quetion = (Label)ri.Controls[3];
            RadioButton Option_1 = (RadioButton )ri.Controls[5];
            RadioButton Option_2 = (RadioButton)ri.Controls[7];
            RadioButton Option_3 = (RadioButton)ri.Controls[9];
            //RadioButton Option_4 = (RadioButton)ri.Controls[11];
         
            int Q_id = Convert.ToInt32(Q_idLabel.Text);
            String Feedback = null;
            if (Option_1.Checked == true)
            {
                //Feedback = Option_1.Text;
                Feedback = "A";
            }
            else if (Option_2.Checked == true)
            {
             //   Feedback = Option_2.Text;
                Feedback = "B";
            }
            else if (Option_3.Checked == true)
            {
                //   Feedback = Option_3.Text;
                Feedback = "C";
            }
           
            else
            {
                Response.Write("<span style=\"color: #ff0000\">Please,Fill all Quetions?????????????????????????</span>");
                flag = true;
                break;
            }
            string ip = Request.UserHostAddress;
            string st = DateTime.Now.Month + "/" +DateTime.Now.Day +"/"+ DateTime.Now.Year + " " + DateTime.Now.Hour +":"+DateTime.Now.Minute+":"+ DateTime.Now.Second  ;
              //inst  += "INSERT INTO FeedbackStatus(Faculty_Code,Subject_Code,Question_ID,Grade,IPAddress,STime) VALUES ('" + dt.Rows[i]["Faculty_Code"].ToString() + "','" + dt.Rows[i]["Subject_Code"].ToString() + "'," + Q_id + ",'" + Feedback + "','" + ip+ "','" +st +"');" ;
            inst += "INSERT INTO FeedbackStatus(Faculty_Code, Subject_Code, Question_ID, Grade, IPAddress, STime, Incompleted_ID) (SELECT '" + dt.Rows[i]["Faculty_Code"].ToString() + "','" + dt.Rows[i]["Subject_Code"].ToString() + "'," + Q_id + ",'" + Feedback + "','" + ip + "','" + st + "', IDENT_CURRENT('IncompletedFeedback') IdentityInTable);";
        }
       
        if (flag == false)
        {

            //QuestionSqlDataSource.InsertCommand = inst;
             //QuestionSqlDataSource.Insert();
             i++;
             string ip = Request.UserHostAddress;
             string st = DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
         
            String incomleteQuery = "insert into IncompletedFeedback (IPAddress,seq_no,Fill_Time) values('"+ip+"',"+i+",'"+st +"');";
             QuestionSqlDataSource.InsertCommand = incomleteQuery + inst ;
             QuestionSqlDataSource.Insert();
             Session["i"] = (Int32)i;
             Page_Load(sender, e);
        }
       
     
    }
    

    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            //QuestionSqlDataSource.InsertCommand = inst;
            //QuestionSqlDataSource.Insert();
            i++;
            Session["i"] = (Int32)i;
            Page_Load(sender, e);
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }


    }
}
