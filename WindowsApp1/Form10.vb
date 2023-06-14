Imports System.Data.OleDb
Imports System.Diagnostics.Eventing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status

Public Class Form10

    Dim conn As OleDbConnection
    Dim cmd As OleDbCommand
    Dim reader As OleDbDataReader

    Dim id As Integer
    Dim role, PaName As String
    Dim PatientID As Integer

    Public Sub New(Pid As Integer, Prole As String, Pname As String)
        id = Pid
        role = Prole
        PaName = Pname
        InitializeComponent()
        Label9.Visible = False
        Label10.Visible = False
        Label16.Visible = False
        TextBox4.Text = ""
        TextBox7.Text = ""
        TextBox9.Text = ""
        TextBox11.Text = ""
        TextBox5.Text = "0"
        TextBox6.Text = "0"
        TextBox8.Text = "0"
        TextBox10.Text = "0"
        If role <> "Admin" Then
            AppointmentsToolStripMenuItem.Visible = False
            RegisterPatientToolStripMenuItem.Visible = False
            PatientsToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
        End If
        Panel2.Visible = False
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click
        Panel2.Visible = False
    End Sub

    Private Sub ProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProfileToolStripMenuItem.Click
        Me.Close()
        Dim f As Form5 = New Form5(id, role, PaName)
        f.Show()
    End Sub

    Private Sub DashboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashboardToolStripMenuItem.Click
        Me.Close()
        Dim f As Form2 = New Form2(id, role, PaName)
        f.Show()
    End Sub

    Private Sub RegisterPatientToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterPatientToolStripMenuItem.Click
        Me.Close()
        Dim f As Form3 = New Form3(id, role, PaName)
        f.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Close()
        Dim f As Form4 = New Form4(id, role, PaName)
        f.Show()
    End Sub

    Private Sub RegisterEmployeesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterEmployeesToolStripMenuItem.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub BookAppointmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BookAppointmentToolStripMenuItem.Click
        Me.Close()
        Dim f As Form6 = New Form6(id, role, PaName)
        f.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label10.Text = ""
        Label9.Visible = False
        Label10.Visible = False
        Label16.Visible = False
        Label26.Text = ""
        Label27.Text = ""
        Label28.Text = ""
        Label29.Text = ""
        Label30.Text = ""
        Label31.Text = ""
        Label32.Text = ""
        Label33.Text = ""
        Panel2.Visible = False
        If TextBox1.Text = "" Then
            Label9.Visible = True
        End If


        If TextBox2.Text = "" Then
            Label10.Text = "Patient Id not entered"
            Label10.Visible = True
        Else
            conn = New OleDbConnection(DB.connString)
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandText = "Select * from Patients Where Id = " & TextBox2.Text & ""
            reader = cmd.ExecuteReader
            If (reader.Read()) Then
                PatientID = TextBox2.Text
            Else
                Label10.Text = "Patient not Exist"
                Label10.Visible = True
            End If
            reader.Close()
            conn.Close()
        End If

        If TextBox3.Text = "" Then
            Label16.Visible = True
        End If

        If TextBox1.Text = "" Then
            Label6.Visible = True
        End If

        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And Label10.Text <> "Patient not Exist" Then
            conn = New OleDbConnection(DB.connString)
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandText = "INSERT INTO Reports ([PatientId], [ReportName], [DateTimeGenerated], [ReportResult], [field1], [data1], [field2], [data2], [field3], [data3], [field4], [data4], [Payment]) VALUES(" & PatientID & ", '" & TextBox1.Text & "', '" & DateTime.Today & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', " & TextBox5.Text & ", '" & TextBox7.Text & "', " & TextBox6.Text & ", '" & TextBox9.Text & "', " & TextBox8.Text & ", '" & TextBox11.Text & "', " & TextBox10.Text & ", 1000)"
            cmd.ExecuteNonQuery()
            conn.Close()

            Label34.Text = TextBox1.Text
            Label38.Text = PatientID
            Label35.Text = DateTime.Today
            Label36.Text = TextBox3.Text
            If TextBox4.Text <> " " Then
                Label26.Text = TextBox4.Text
                Label30.Text = TextBox5.Text
            End If
            If TextBox7.Text <> " " Then
                Label27.Text = TextBox7.Text
                Label31.Text = TextBox6.Text
            End If
            If TextBox9.Text <> " " Then
                Label28.Text = TextBox9.Text
                Label32.Text = TextBox8.Text
            End If
            If TextBox11.Text <> " " Then
                Label29.Text = TextBox11.Text
                Label33.Text = TextBox10.Text
            End If
            Panel2.Visible = True

        End If
    End Sub
End Class