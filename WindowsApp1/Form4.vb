Imports System.Data.OleDb
Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status

Public Class Form4
    Dim id As Integer
    Dim Parole, PaName As String

    Dim FName, UName, Pass, Role, Email, gender, MobileNo, Salary As String
    Dim conn As OleDb.OleDbConnection
    Dim cmd As OleDbCommand

    Dim reader As OleDbDataReader
    Public Sub New(Pid As Integer, Prole As String, Pname As String)
        id = Pid
        Parole = Prole
        PaName = Pname
        ' This call is required by the designer.

        InitializeComponent()
        If Parole <> "Admin" Then
            AppointmentsToolStripMenuItem.Visible = False
            RegisterPatientToolStripMenuItem.Visible = False
            PatientsToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
        End If
        Label11.Visible = False
        Label12.Visible = False
        Label13.Visible = False
        Label14.Visible = False
        Label15.Visible = False
        Label16.Visible = False
        Label17.Visible = False
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProfileToolStripMenuItem.Click
        Me.Close()
        Dim f As Form5 = New Form5(id, Parole, PaName)
        f.Show()
    End Sub

    Private Sub DashboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashboardToolStripMenuItem.Click
        Me.Close()
        Dim f As Form2 = New Form2(id, Parole, PaName)
        f.Show()
    End Sub

    Private Sub RegisterPatientToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterPatientToolStripMenuItem.Click
        Me.Close()
        Dim f As Form3 = New Form3(id, Parole, PaName)
        f.Show()
    End Sub

    Private Sub BookAppointmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BookAppointmentToolStripMenuItem.Click
        Me.Close()
        Dim f As Form6 = New Form6(id, Parole, PaName)
        f.Show()
    End Sub

    Private Sub PatientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PatientsToolStripMenuItem.Click
        Me.Close()
        Dim f As Form7 = New Form7(id, Parole, PaName)
        f.Show()
    End Sub
    Private Sub AppointmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AppointmentsToolStripMenuItem.Click
        Me.Close()
        Dim f As Form8 = New Form8(id, Parole, PaName)
        f.Show()
    End Sub

    Private Sub ViewPatientHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewPatientHistoryToolStripMenuItem.Click
        Me.Close()
        Dim f As Form9 = New Form9(id, Parole, PaName)
        f.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label11.Visible = False
        Label12.Visible = False
        Label13.Visible = False
        Label14.Visible = False
        Label15.Visible = False
        Label16.Visible = False
        Label17.Visible = False

        FName = TextBox1.Text
        UName = TextBox2.Text
        Pass = TextBox5.Text
        Role = ComboBox1.Text
        Email = TextBox6.Text
        If (RadioButton1.Checked = True) Then
            gender = "Male"
        ElseIf RadioButton2.Checked = True Then
            gender = "Female"
        Else
            gender = "Other"
        End If
        MobileNo = TextBox4.Text
        Salary = TextBox3.Text

        If (FName = "") Then
            Label11.Visible = True
        End If
        If (UName = "") Then
            Label12.Visible = True
        End If
        If (Pass = "") Then
            Label13.Visible = True
        End If
        If (Role = "") Then
            Label14.Visible = True
        End If
        If (Email = "") Then
            Label15.Visible = True
        End If
        If (Salary = "") Then
            Label16.Visible = True
        End If
        If (MobileNo = "") Then
            Label17.Visible = True
        End If

        If FName <> "" And UName <> "" And Pass <> "" And Email <> "" And Role <> "" And Salary <> "" And MobileNo <> "" Then
            conn = New OleDbConnection(DB.connString)
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandText = "INSERT INTO Users ([Name], [Username], [Password], [Gender], [Role], [Email] , [Salary], [MobileNo]) VALUES('" & FName & "', '" & UName & "', '" & Pass & "', '" & gender & "', '" & Role & "', '" & Email & "', '" & Salary & "', '" & MobileNo & "')"
            cmd.ExecuteNonQuery()
            conn.Close()
        End If
    End Sub
End Class