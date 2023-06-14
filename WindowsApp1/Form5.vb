Imports System.Data.OleDb
Imports System.Diagnostics.Eventing
Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Form5
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Dim id As Integer
    Dim role, PaName As String
    Dim conn As OleDb.OleDbConnection
    Dim cmd As OleDbCommand
    Dim reader As OleDbDataReader

    Public Sub New(Pid As Integer, Prole As String, Pname As String)
        id = Pid
        role = Prole
        PaName = Pname
        ' This call is required by the designer.
        InitializeComponent()
        If role <> "Admin" Then
            AppointmentsToolStripMenuItem.Visible = False
            RegisterPatientToolStripMenuItem.Visible = False
            PatientsToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
        End If
        ' Add any initialization after the InitializeComponent() call.
        conn = New OleDbConnection(DB.connString)
        conn.Open()
        cmd = conn.CreateCommand()
        cmd.CommandText = "Select * from Users Where Id = " & id & ""
        reader = cmd.ExecuteReader
        reader.Read()
        Label11.Text = reader.GetValue(1)
        Label12.Text = reader.GetValue(2)
        Label13.Text = reader.GetValue(3)
        Label14.Text = reader.GetValue(4)
        Label15.Text = reader.GetValue(6)
        Label16.Text = reader.GetValue(5)
        Label17.Text = reader.GetValue(8)
        Label18.Text = reader.GetValue(7)
        conn.Close()
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

    Private Sub BookAppointmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BookAppointmentToolStripMenuItem.Click
        Me.Close()
        Dim f As Form6 = New Form6(id, role, PaName)
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

    Private Sub PatientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PatientsToolStripMenuItem.Click
        Me.Close()
        Dim f As Form7 = New Form7(id, role, PaName)
        f.Show()
    End Sub
End Class