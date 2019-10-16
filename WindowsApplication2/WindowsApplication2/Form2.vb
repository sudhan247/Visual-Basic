Imports System.Data.SqlClient
Public Class Form2
    Dim a, b, c, d, f, t As Integer
    Dim avg As Double
    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim rd As SqlDataReader
    Dim s As String

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("PLEASE FILL ALL THE DETAILS")
            Exit Sub
        End If
        a = Val(TextBox1.Text)
        b = Val(TextBox2.Text)
        c = Val(TextBox3.Text)
        d = Val(TextBox4.Text)
        f = Val(TextBox5.Text)
        t = a + b + c + d + f
        avg = t / 5
        If avg > 70 Then
            s = "FIRST"
        ElseIf avg > 50 Then
            s = "SECOND"
        Else
            s = "THIRD"
        End If
        com.CommandText = "insert into sudhank values('" & Form1.z.SelectedItem & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & t & "','" & avg & "','" & s & "')"
        com.ExecuteNonQuery()
        MsgBox("SUCCESS")
    End Sub


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection
        com = New SqlCommand
        con.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=student;Integrated Security=True"
        con.Open()
        com.Connection = con
    End Sub

End Class