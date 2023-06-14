Imports System.Data.OleDb
Public Class Form1
    Dim username As String
    Dim password As String
    Dim conn As OleDb.OleDbConnection
    Dim cmd As OleDbCommand
    Dim reader As OleDbDataReader

    Private Sub Form1_Load(sender As Object, e As EventArgs)

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        PictureBox2.Visible = False

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'conn = New OleDbConnection(DB.connString)
        'conn.Open()
        'cmd = conn.CreateCommand()
        'cmd.CommandText = "INSERT INTO Users ([Name], [Username], [Password], [Role], [Gender], [Email], [MobileNo], [Salary]) VALUES('Basit Nazir', 'basit', '123456', 'Admin', 'Male', 'basitnazir03@yahoo.com', '+921231234567', '350000')"
        'cmd.ExecuteNonQuery()
        'conn.Close()

        Label2.Visible = False
        Label5.Visible = False
        username = TextBox1.Text
        password = TextBox2.Text
        If username = "" Then
            Label2.Text = "Username not entered"
            Label2.Visible = True
        End If
        If password = "" Then
            Label5.Text = "Password not entered"
            Label5.Visible = True
        End If

        conn = New OleDbConnection(DB.connString)
        conn.Open()
        cmd = conn.CreateCommand()
        cmd.CommandText = "Select * from Users Where Username = '" & username & "' AND Password = '" & password & "'"

        'Where(username = '" + username + "' AND Password = '" + password + "')
        reader = cmd.ExecuteReader
        If (reader.Read()) Then
            PictureBox2.Visible = True
            PictureBox2.Update()
            System.Threading.Thread.Sleep(3000)
            Me.Hide()
            Dim f As Form2 = New Form2(reader.GetValue(0), reader.GetValue(4), reader.GetValue(1))
            f.Show()
            PictureBox2.Visible = False
            TextBox1.Text = ""
            TextBox2.Text = ""

        Else
            MessageBox.Show("Try Again", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        conn.Close()
    End Sub
End Class
