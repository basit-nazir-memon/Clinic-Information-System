Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Form6
    Dim id As Integer
    Dim role, PaName As String
    Dim conn As OleDb.OleDbConnection
    Dim cmd As OleDbCommand
    Dim cmd1 As OleDbCommand
    Dim reader As OleDbDataReader
    Dim reader1 As OleDbDataReader
    Dim doctorId As Integer

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
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        If ComboBox2.Text = "" Then
            Label8.Text = "Date and Time Not Selected"
            Label8.Visible = True
        Else
            conn = New OleDbConnection(DB.connString)
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandText = "INSERT INTO Appointments ([PatientId], [EmployeeId], [DateTime], [Status], [Payment]) VALUES(" & TextBox1.Text & ", " & doctorId & ", '" & ComboBox2.Text & "', 'Enrolled', 1000)"
            cmd.ExecuteNonQuery()
            conn.Close()
            Panel4.Visible = False
            Panel2.Visible = True
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label6.Visible = False
        Label7.Visible = False
        If TextBox1.Text = "" Then
            Label6.Text = "Patient Id not entered"
            Label6.Visible = True
        Else
            conn = New OleDbConnection(DB.connString)
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandText = "Select * from Patients Where Id = " & TextBox1.Text & ""
            reader = cmd.ExecuteReader
            If (reader.Read()) Then
                Panel2.Visible = False
                Panel3.Visible = True
                cmd1 = conn.CreateCommand()
                cmd1.CommandText = "Select * from Users Where Role = 'Doctor'"
                reader1 = cmd1.ExecuteReader
                If reader1.Read() Then
                    ComboBox1.Items.Add(reader1.GetValue(1))
                    While reader1.Read
                        ComboBox1.Items.Add(reader1.GetValue(1))
                    End While

                Else
                    Label7.Text = "No Doctor Available"
                    Label7.Visible = True
                End If
            Else
                Label6.Text = "Patient not Exist"
                Label6.Visible = True
            End If
            reader.Close()
            conn.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label6.Visible = False
        Label7.Visible = False
        If ComboBox1.Text = "" Then
            Label7.Text = "Doctor not selected"
            Label7.Visible = True
        Else
            conn = New OleDbConnection(DB.connString)
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandText = "Select id from Users Where Name = '" & ComboBox1.Text & "'"
            reader = cmd.ExecuteReader
            If reader.Read() Then
                doctorId = reader.GetValue(0)
                ComboBox1.Items.Add(DateTime.Now.ToString)
                Dim i As Integer
                i = 1
                While i <= 7
                    ComboBox2.Items.Add(DateTime.Today.AddDays(1).ToString & ", 0" & i & ": 00 PM")
                    i += 1
                End While
                Panel3.Visible = False
                Panel4.Visible = True
            Else
                Label7.Text = "Doctor not Exist"
                Label7.Visible = True
            End If
            conn.Close()

        End If
    End Sub
End Class