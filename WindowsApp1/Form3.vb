Imports System.Data.OleDb
Imports System.Diagnostics.Eventing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Form3
    Dim id As Integer
    Dim role, PaName As String
    Dim FName, fathername, gender, email, mobileNo As String
    Dim conn As OleDb.OleDbConnection
    Dim cmd As OleDbCommand
    Dim reader As OleDbDataReader
    Public Sub New(Pid As Integer, Prole As String, Pname As String)
        id = Pid
        role = Prole
        PaName = Pname
        ' This call is required by the designer.
        InitializeComponent()
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        If role <> "Admin" Then
            AppointmentsToolStripMenuItem.Visible = False
            RegisterPatientToolStripMenuItem.Visible = False
            PatientsToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub RegisterEmployeesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterEmployeesToolStripMenuItem.Click
        Me.Close()
        Form1.Show()
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

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Close()
        Dim f As Form4 = New Form4(id, role, PaName)
        f.Show()
    End Sub

    Private Sub ReportManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportManagementToolStripMenuItem.Click
        Me.Close()
        Dim f As Form10 = New Form10(id, role, PaName)
        f.Show()
    End Sub

    Private Sub BookAppointmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BookAppointmentToolStripMenuItem.Click
        Me.Close()
        Dim f As Form6 = New Form6(id, role, PaName)
        f.Show()
    End Sub

    Private Sub PatientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PatientsToolStripMenuItem.Click
        Me.Close()
        Dim f As Form7 = New Form7(id, role, PaName)
        f.Show()
    End Sub

    Private Sub AppointmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AppointmentsToolStripMenuItem.Click
        Me.Close()
        Dim f As Form8 = New Form8(id, role, PaName)
        f.Show()
    End Sub

    Private Sub ViewPatientHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewPatientHistoryToolStripMenuItem.Click
        Me.Close()
        Dim f As Form9 = New Form9(id, role, PaName)
        f.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False

        FName = TextBox1.Text
        fathername = TextBox2.Text
        email = TextBox3.Text
        mobileNo = TextBox4.Text
        If RadioButton1.Checked = True Then
            gender = "Male"
        ElseIf RadioButton2.Checked = True Then
            gender = "Female"
        Else
            gender = "Other"
        End If

        If (FName = "") Then
            Label9.Visible = True
        End If
        If (fathername = "") Then
            Label10.Visible = True
        End If
        If (mobileNo = "") Then
            Label11.Visible = True
        End If

        If FName <> "" And fathername <> "" And mobileNo <> "" Then
            conn = New OleDbConnection(DB.connString)
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandText = "INSERT INTO Patients ([Name], [FatherName], [Gender], [MobileNo], [Email], [DOB]) VALUES('" & FName & "', '" & fathername & "', '" & gender & "', '" & mobileNo & "', '" & email & "', '" & DateTimePicker1.ToString & "')"
            cmd.ExecuteNonQuery()
            conn.Close()
        End If
    End Sub
End Class