Imports System.Data.SqlClient
Imports System.Data


Partial Class FwiseReport
    Inherits System.Web.UI.Page
    Dim Con As SqlConnection
    Dim Cmd As SqlCommand
    Dim rd As SqlDataReader
    Dim AdptResult As SqlDataAdapter
    Dim AdptSCode As SqlDataAdapter
    Dim dtResult As New DataTable
    Dim dtSCode As New DataTable
    Dim dtCal As New DataTable
    Dim dtAll As New DataTable
    Dim TempDt2 As New DataTable
    Dim TbRow As TableRow
    Dim TbCell As TableCell
    Dim Ta As Table

    Dim connstr As String = ConfigurationManager.ConnectionStrings("FeedBackConnectionString2").ToString()

    'Dim connstr As String = "Data Source=HBPATEL;Initial Catalog=Feedback;User ID=sa;Password=safeedback"

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged


    End Sub

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Admin") = Nothing Then

            Response.Redirect("../index.aspx")

            'ElseIf Session("admin") = "admingen" Then
            '    'branch0.items.clear()
            '    'branch0.items.insert(0, "sgen")
            '    'branch0.items(0).value = "sgn"

            '    'branch0.items.insert(1, "ngn")
            '    'branch0.items(1).value = "ngn"
            '    DropDownList2.Items.Clear()
            '    DropDownList2.Items.Insert(0, "SGN")
            '    DropDownList2.Items(0).Value = "SGN"

            '    DropDownList2.Items.Insert(1, "NGN")
            '    DropDownList2.Items(1).Value = "NGN"

            'ElseIf Session("admin") = "admince" Then
            '    DropDownList2.Items.Clear()
            '    DropDownList2.Items.Insert(0, "SSPC-CE")
            '    DropDownList2.Items(0).Value = "SCE"

            '    DropDownList2.Items.Insert(1, "NPC-CE")
            '    DropDownList2.Items(1).Value = "NCE"

            'ElseIf Session("admin") = "adminec" Then
            '    DropDownList2.Items.Clear()
            '    DropDownList2.Items.Insert(0, "SSPC-EC")
            '    DropDownList2.Items(0).Value = "SEC"

            '    DropDownList2.Items.Insert(1, "NPC-EC")
            '    DropDownList2.Items(1).Value = "NEC"
            'ElseIf Session("admin") = "adminme" Then
            '    DropDownList2.Items.Clear()
            '    DropDownList2.Items.Insert(0, "SSPC-ME")
            '    DropDownList2.Items(0).Value = "SME"

            '    DropDownList2.Items.Insert(1, "NPC-ME")
            '    DropDownList2.Items(1).Value = "NME"
            'ElseIf Session("admin") = "adminee" Then
            '    DropDownList2.Items.Clear()
            '    DropDownList2.Items.Insert(0, "SSPC-EE")
            '    DropDownList2.Items(0).Value = "SEE"

            '    DropDownList2.Items.Insert(1, "NPC-EE")
            '    DropDownList2.Items(1).Value = "NEE"
            'Else
        End If

        TempDt2.Columns.Add("Faculty Code")
        TempDt2.Columns.Add("Faculty Name")
        TempDt2.Columns.Add("Subject Code")
        TempDt2.Columns.Add("Subject Name")
        TempDt2.Columns.Add("A")
        TempDt2.Columns.Add("B")
        TempDt2.Columns.Add("C")
        'TempDt2.Columns.Add("D")
        TempDt2.Columns.Add("No.Votes")
        TempDt2.Columns("No.Votes").DataType = Type.GetType("System.Int32")
        TempDt2.Columns.Add("PI")



        Dim i As Int32 = 0
        Dim j As Int32 = 0
        Dim NoA, NoB, NoC As Int32
        Dim PI As Double
        Dim TotalQ As Int32 = 0
        Dim Con As New SqlConnection(connstr)
        Cmd = New SqlCommand("Select count(*) From Question_Master", Con)
        Try
            Con.Open()
            TotalQ = Cmd.ExecuteScalar()
            Con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        dtCal.Columns.Add("Faculty Code")
        dtCal.Columns.Add("Faculty Name")
        dtCal.Columns.Add("Subject Code")
        dtCal.Columns.Add("Subject Name")
        dtCal.Columns.Add("A")
        dtCal.Columns.Add("B")
        dtCal.Columns.Add("C")
        'dtCal.Columns.Add("D")
        dtCal.Columns.Add("No.Votes")
        dtCal.Columns("No.Votes").DataType = Type.GetType("System.Int32")
        dtCal.Columns.Add("PI")
        ''For Overall Calculations
        dtAll.Columns.Add("FacultyCode")
        dtAll.Columns.Add("FacultyName")
        dtAll.Columns.Add("PI")
        dtAll.Columns.Add("Count")
        dtAll.Columns("Count").DataType = Type.GetType("System.Int32")
        dtAll.Columns("Count").DefaultValue = 0
        dtAll.Columns(2).DataType = Type.GetType("System.Double")
        dtAll.Columns(2).DefaultValue = 0
        dtAll.PrimaryKey = New DataColumn() {dtAll.Columns(0)}
        dtAll.Columns(0).Unique = True
        dtAll.Columns(0).AllowDBNull = True
        Con = New SqlConnection(connstr)
        AdptSCode = New SqlDataAdapter("Select * from Faculty_Subject ", Con)
        Try
            AdptSCode.Fill(dtSCode)
            While i < dtSCode.Rows.Count
                NoA = 0
                NoB = 0
                NoC = 0

                j = 0
                dtResult.Rows.Clear()
                AdptResult = New SqlDataAdapter("Select * from FeedbackStatus Where Faculty_Code = '" & dtSCode.Rows(i).Item("Faculty_Code") & "' and Subject_Code = '" & dtSCode.Rows(i).Item("Subject_Code") & "'", Con)
                AdptResult.Fill(dtResult)
                While j < dtResult.Rows.Count
                    If (dtResult.Rows(j).Item("Grade") = "A") Then
                        NoA = NoA + 1
                    ElseIf (dtResult.Rows(j).Item("Grade") = "B") Then
                        NoB = NoB + 1
                    ElseIf (dtResult.Rows(j).Item("Grade") = "C") Then
                        NoC = NoC + 1

                    End If
                    j = j + 1
                End While
                PI = Convert.ToDouble(((NoA * 10) + (NoB * 7) + (NoC * 4)) / dtResult.Rows.Count)
                'If (PI = 0) Then
                '    PI = 0
                'End If
                Con = New SqlConnection(connstr)
                Cmd = New SqlCommand("Select Subject_Title From Subject_Master where Subject_Code='" & dtSCode.Rows(i).Item("Subject_Code") & "'", Con)
                Dim Temp As String = ""
                If Con.State = ConnectionState.Open Then
                    Con.Close()
                Else
                    Con.Open()
                    rd = Cmd.ExecuteReader
                    If rd.Read Then
                        Temp = rd.Item(0)
                    End If
                    Con.Close()
                End If
                Con = New SqlConnection(connstr)
                Cmd = New SqlCommand("Select Faculty_Name From Faculty_Master where Faculty_Code = '" & dtSCode.Rows(i).Item("Faculty_Code") & "'", Con)
                Dim TempFName As String = ""

                If Con.State = ConnectionState.Open Then
                    Con.Close()
                Else
                    Con.Open()
                    rd = Cmd.ExecuteReader
                    If rd.Read Then
                        TempFName = rd.Item(0)
                    End If
                    Con.Close()
                End If
                Dim arList As New ArrayList()
                dtCal.Rows.Add.Item(0) = dtSCode.Rows(i).Item("Faculty_Code")
                dtCal.Rows(i).Item(1) = TempFName
                dtCal.Rows(i).Item(2) = dtSCode.Rows(i).Item("Subject_Code")
                dtCal.Rows(i).Item(3) = Temp
                dtCal.Rows(i).Item(4) = NoA
                dtCal.Rows(i).Item(5) = NoB
                dtCal.Rows(i).Item(6) = NoC
                'dtCal.Rows(i).Item(7) = NoD
                dtCal.Rows(i).Item(7) = CInt(dtResult.Rows.Count / TotalQ)
                dtCal.Rows(i).Item(8) = PI

                If dtAll.Rows.Contains(dtSCode.Rows(i).Item("Faculty_Code")) Then
                    dtAll.Rows(dtAll.Rows.IndexOf(dtAll.Rows.Find(dtSCode.Rows(i).Item("Faculty_Code")))).Item("PI") += PI
                    dtAll.Rows(dtAll.Rows.IndexOf(dtAll.Rows.Find(dtSCode.Rows(i).Item("Faculty_Code")))).Item("Count") += 1
                Else
                    dtAll.Rows.Add.Item("FacultyCode") = dtSCode.Rows(i).Item("Faculty_Code")
                    dtAll.Rows(dtAll.Rows.Count - 1).Item("FacultyName") = TempFName
                    dtAll.Rows(dtAll.Rows.Count - 1).Item("PI") += PI
                    dtAll.Rows(dtAll.Rows.Count - 1).Item("Count") += 1
                End If
                i = i + 1
            End While
            i = 0
            While i < dtAll.Rows.Count

                dtAll.Rows(i).Item("PI") /= dtAll.Rows(i).Item("Count")
                dtAll.Rows(i).Item("PI") = String.Format("{0:N}", dtAll.Rows(i).Item("PI"))
                i = i + 1
            End While


            If IsPostBack = False Then
                GridView1.DataSource = dtAll
                GridView1.DataBind()
                GridView1.PageIndex = 0
                Session.Add("Dt", dtAll)
            End If
            'GridView1.DataSource = Session("Dt")
            'GridView1.DataBind()
            'GridView1.PageIndex = 0

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub

    

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Session.Add("ReportName", "Faculty")

        TempDt2.Clear()
       
        Dim i As Int32 = 0
        Dim j As Int32 = 0
        While j < dtCal.Rows.Count

            If dtCal.Rows(j).Item(0).ToString() = DropDownList1.SelectedValue.Trim() Then
                
                TempDt2.Rows.Add.Item(0) = dtCal.Rows(j).Item(0)
                TempDt2.Rows(i).Item(1) = dtCal.Rows(j).Item(1)
                TempDt2.Rows(i).Item(2) = dtCal.Rows(j).Item(2)
                TempDt2.Rows(i).Item(3) = dtCal.Rows(j).Item(3)
                TempDt2.Rows(i).Item(4) = dtCal.Rows(j).Item(4)
                TempDt2.Rows(i).Item(5) = dtCal.Rows(j).Item(5)
                TempDt2.Rows(i).Item(6) = dtCal.Rows(j).Item(6)
                'TempDt2.Rows(i).Item(7) = dtCal.Rows(j).Item(7)
                TempDt2.Rows(i).Item(7) = dtCal.Rows(j).Item(7)
                TempDt2.Rows(i).Item(8) = dtCal.Rows(j).Item(8)
                TempDt2.Rows(i).Item(7) = TempDt2.Rows(i).Item(7)
                TempDt2.Rows(i).Item(8) = String.Format("{0:N}", Convert.ToDouble(TempDt2.Rows(i).Item(8)))

                i = i + 1
            End If
            j = j + 1
        End While
        Session.Add("Dt", TempDt2)
        GridView1.DataSource = TempDt2
        GridView1.DataBind()
        GridView1.PageIndex = 0
        ShowByGrid()

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Session.Add("ReportName", "Class")


        Dim ClassName As String


        ' If Branch.SelectedItem.Value.Contains("2") Then
        ' ClassName = Branch.SelectedValue
        'Else
        ClassName = Branch.SelectedValue + Sem.SelectedValue

        'End If

        Dim TempDt As New DataTable

        TempDt.Clear()
        TempDt.Columns.Add("Faculty Code")
        TempDt.Columns.Add("Faculty Name")
        TempDt.Columns.Add("Subject Code")
        TempDt.Columns.Add("Subject Name")
        TempDt.Columns.Add("A")
        TempDt.Columns.Add("B")
        TempDt.Columns.Add("C")
        'TempDt.Columns.Add("D")
        TempDt.Columns.Add("No.Votes")
        dtCal.Columns("No.Votes").DataType = Type.GetType("System.Int32")
        TempDt.Columns.Add("PI")

        Dim i As Int32 = 0
        Dim j As Int32 = 0
        While j < dtCal.Rows.Count

            If ClassName.Contains(dtCal.Rows(j).Item(2).ToString().Substring(0, 5)) Then
                TempDt.Rows.Add.Item(0) = dtCal.Rows(j).Item(0)
                TempDt.Rows(i).Item(1) = dtCal.Rows(j).Item(1)
                TempDt.Rows(i).Item(2) = dtCal.Rows(j).Item(2)
                TempDt.Rows(i).Item(3) = dtCal.Rows(j).Item(3)
                TempDt.Rows(i).Item(4) = dtCal.Rows(j).Item(4)
                TempDt.Rows(i).Item(5) = dtCal.Rows(j).Item(5)
                TempDt.Rows(i).Item(6) = dtCal.Rows(j).Item(6)
                'TempDt.Rows(i).Item(7) = dtCal.Rows(j).Item(7)
                TempDt.Rows(i).Item(7) = dtCal.Rows(j).Item(7)
                TempDt.Rows(i).Item(8) = dtCal.Rows(j).Item(8)

                TempDt.Rows(i).Item(7) = TempDt.Rows(i).Item(7)
                TempDt.Rows(i).Item(8) = String.Format("{0:N}", Convert.ToDouble(TempDt.Rows(i).Item(8)))

                i = i + 1
            End If
            j = j + 1
        End While
        Session.Add("Dt", TempDt)
        GridView1.DataSource = TempDt
        GridView1.DataBind()
        GridView1.PageIndex = 0
    End Sub

    

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataSource = dtAll
        GridView1.DataBind()


    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        'GridView1.PageIndex = e.NewSelectedIndex
        'GridView1.DataSource = dtAll
        'GridView1.DataBind()
    End Sub

    Public Sub ShowByGrid()
        Dim Adpt As New SqlDataAdapter("SELECT DISTINCT Subject_Code, Faculty_Code FROM FeedbackStatus WHERE Faculty_Code ='" & DropDownList1.SelectedValue & "' ", connstr)
        Dim Dt As New DataTable
        Dim Dt2 As New DataTable
        Dim i As Integer = 0
        Dim Data As New DataTable
        Data.Columns.Add("Grade")
        Data.Columns.Add("1")
        Data.Columns("1").DefaultValue = 0
        Data.Columns.Add("2")
        Data.Columns("2").DefaultValue = 0
        Data.Columns.Add("3")
        Data.Columns("3").DefaultValue = 0
        Data.Columns.Add("4")
        Data.Columns("4").DefaultValue = 0
        Data.Columns.Add("5")
        Data.Columns("5").DefaultValue = 0
        Data.Columns.Add("6")
        Data.Columns("6").DefaultValue = 0
        Data.Columns.Add("7")
        Data.Columns("7").DefaultValue = 0
        'Data.Columns.Add("8")
        'Data.Columns("8").DefaultValue = 0
        'Data.Columns.Add("9")
        'Data.Columns("9").DefaultValue = 0
        'Data.Columns.Add("10")
        'Data.Columns("10").DefaultValue = 0
        'Data.Columns.Add("11")
        'Data.Columns("11").DefaultValue = 0
        Data.Columns.Add("Total")
        Data.Columns("Total").DefaultValue = 0
        

        Try
            Adpt.Fill(Dt)
            While i < Dt.Rows.Count
                Dt2.Clear()
                Data.Clear()
                Data.Rows.Add.Item("Grade") = "A"
                Data.Rows.Add.Item("Grade") = "B"
                Data.Rows.Add.Item("Grade") = "C"
                'Data.Rows.Add.Item("Grade") = "D"
                Dim Adpt2 As New SqlDataAdapter("SELECT Faculty_Code, Subject_Code, Question_ID, Grade, COUNT(Grade) AS Count FROM FeedbackStatus GROUP BY Question_ID, Grade, Faculty_Code, Subject_Code, Faculty_Code HAVING      (Subject_Code = '" & Dt.Rows(i).Item(0) & "') AND (Faculty_Code = '" & DropDownList1.SelectedValue & "') ORDER BY Grade", connstr)
                Adpt2.Fill(Dt2)
                Dim j As Integer = 0
                While j < Dt2.Rows.Count
                    If Dt2.Rows(j).Item("Grade") = "A" Then
                        Data.Rows(0).Item(Dt2.Rows(j).Item("Question_ID").ToString) = CInt(Data.Rows(0).Item(Dt2.Rows(j).Item("Question_ID").ToString)) + CInt(Dt2.Rows(j).Item("Count"))
                        Data.Rows(0).Item("Total") = CInt(Data.Rows(0).Item("Total")) + CInt(Dt2.Rows(j).Item("Count"))
                    ElseIf Dt2.Rows(j).Item("Grade") = "B" Then
                        Data.Rows(1).Item(Dt2.Rows(j).Item("Question_ID").ToString) = CInt(Data.Rows(1).Item(Dt2.Rows(j).Item("Question_ID").ToString)) + CInt(Dt2.Rows(j).Item("Count"))
                        Data.Rows(1).Item("Total") = CInt(Data.Rows(1).Item("Total")) + CInt(Dt2.Rows(j).Item("Count"))
                    ElseIf Dt2.Rows(j).Item("Grade") = "C" Then
                        Data.Rows(2).Item(Dt2.Rows(j).Item("Question_ID").ToString) = CInt(Data.Rows(2).Item(Dt2.Rows(j).Item("Question_ID").ToString)) + CInt(Dt2.Rows(j).Item("Count"))
                        Data.Rows(2).Item("Total") = CInt(Data.Rows(2).Item("Total")) + CInt(Dt2.Rows(j).Item("Count"))
                        'ElseIf Dt2.Rows(j).Item("Grade") = "D" Then
                        '    Data.Rows(3).Item(Dt2.Rows(j).Item("Question_ID").ToString) = CInt(Data.Rows(3).Item(Dt2.Rows(j).Item("Question_ID").ToString)) + CInt(Dt2.Rows(j).Item("Count"))
                        '    Data.Rows(3).Item("Total") = CInt(Data.Rows(3).Item("Total")) + CInt(Dt2.Rows(j).Item("Count"))
                    End If


                    j = j + 1
                End While
                Dim Ta As New Table()
                


                Dim Dg As New GridView
                Dg.CellPadding = 4
                Dg.AutoGenerateColumns = True
                Dg.ForeColor = Drawing.Color.Black
                Dg.RowStyle.BackColor = Drawing.Color.White
                Dg.DataSource = Data
                Dg.DataBind()
                Dim row() As DataRow = TempDt2.Select("[Subject Code] ='" & Dt.Rows(i).Item("Subject_Code") & "'")
                Dim SubjectName As String = row(0).Item("Subject Name")
                Ta = New Table
                Dim Blab As New Label
                Blab.Height = 20
                Blab.Text = ""
                TbRow = New TableRow()
                TbCell = New TableCell()
                TbCell.Font.Bold = True
                TbCell.Text = "Subject Code:" & Dt2.Rows(i).Item("Subject_Code") & "&nbsp;Subject Name :" & SubjectName & "&nbsp;PI :" & row(0).Item("PI")
                TbRow.Cells.Add(TbCell)
                Ta.Rows.Add(TbRow)
                TbRow = New TableRow()
                TbCell = New TableCell()
                TbCell.Controls.Add(Dg)
                TbRow.Cells.Add(TbCell)
                Ta.Rows.Add(TbRow)
                Panel1.Controls.Add(Blab)
                Panel1.Controls.Add(Ta)


                

                i = i + 1
            End While

        Catch ex As Exception

        End Try


    End Sub

    
    
    
    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting

    End Sub

    Protected Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted

    End Sub

   

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
       

        TempDt2.Clear()

        Dim i As Int32 = 0
        Dim j As Int32 = 0
        While j < dtCal.Rows.Count

            If Branch1.SelectedValue.Contains(dtCal.Rows(j).Item(0).ToString().Substring(0, 3)) Then

                TempDt2.Rows.Add.Item(0) = dtCal.Rows(j).Item(0)
                TempDt2.Rows(i).Item(1) = dtCal.Rows(j).Item(1)
                TempDt2.Rows(i).Item(2) = dtCal.Rows(j).Item(2)
                TempDt2.Rows(i).Item(3) = dtCal.Rows(j).Item(3)
                TempDt2.Rows(i).Item(4) = dtCal.Rows(j).Item(4)
                TempDt2.Rows(i).Item(5) = dtCal.Rows(j).Item(5)
                TempDt2.Rows(i).Item(6) = dtCal.Rows(j).Item(6)
                'TempDt2.Rows(i).Item(7) = dtCal.Rows(j).Item(7)
                TempDt2.Rows(i).Item(7) = dtCal.Rows(j).Item(7)
                TempDt2.Rows(i).Item(8) = dtCal.Rows(j).Item(8)
                TempDt2.Rows(i).Item(7) = TempDt2.Rows(i).Item(7)
                TempDt2.Rows(i).Item(8) = String.Format("{0:N}", Convert.ToDouble(TempDt2.Rows(i).Item(8)))

                i = i + 1
            End If
            j = j + 1
        End While
        Session.Add("Dt", TempDt2)
        GridView1.DataSource = TempDt2
        GridView1.DataBind()
        GridView1.PageIndex = 0

        ShowByGrid()

    End Sub

    Protected Sub GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PageIndexChanged
       
    End Sub
End Class
