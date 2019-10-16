Imports System.Data.SqlClient
Public Class Form1
    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim rd As SqlDataReader
    Dim s, t, u, v, w, tot As Integer

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        s = Val(TextBox1.Text)
        t = Val(TextBox2.Text)
        u = Val(TextBox3.Text)
        v = Val(TextBox4.Text)
        w = Val(TextBox5.Text)
        tot = s + t + u + v + w
        avg = tot / 5
        If avg > 70 Then
            no = "FIRST"
        ElseIf avg > 50 Then
            no = "SECOND"
        Else
            no = "THIRD"
        End If
        com.CommandText = "update john set tamil='" & TextBox1.Text & "',english='" & TextBox2.Text & "',maths='" & TextBox3.Text & "',science='" & TextBox4.Text & "',social='" & TextBox5.Text & "',total='" & tot & "',avg='" & avg & "',class='" & no & "'where regno='" & ComboBox1.SelectedItem & "'"
        com.ExecuteNonQuery()
        MsgBox("RECORD UPDATED")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        com.CommandText = "delete john where regno='" & ComboBox1.SelectedIndex & "'"
        com.ExecuteNonQuery()
        MsgBox("RECORD DELETED")
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
    End Sub

    Private Sub INSERTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INSERTToolStripMenuItem.Click
        ComboBox1.Enabled = True
    End Sub

    Private Sub VIEWToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VIEWToolStripMenuItem.Click
        Form2.Show()

        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("PLEASE FILL ALL THE DETAILS")
            Exit Sub
        End If
        s = Val(TextBox1.Text)
        t = Val(TextBox2.Text)
        u = Val(TextBox3.Text)
        v = Val(TextBox4.Text)
        w = Val(TextBox5.Text)
        tot = s + t + u + v + w
        avg = tot / 5
        If avg > 70 Then
            no = "FIRST"
        ElseIf avg > 50 Then
            no = "SECOND"
        Else
            no = "THIRD"
        End If
        com.CommandText = "insert into john values('" & ComboBox1.SelectedItem & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & tot & "','" & avg & "','" & no & "')"
        com.ExecuteNonQuery()
        MsgBox("SUCCESS")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        com.CommandText = "select * from deepak where regno='" & ComboBox1.SelectedItem & "'"
        rd = com.ExecuteReader
        If rd.Read Then
            Label11.Text = rd.GetString(1)
            Label12.Text = rd.GetString(2)
            Label13.Text = rd.GetString(3)
            Label14.Text = rd.GetString(4)
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
        End If
        rd.Close()
    End Sub

    Dim avg As Double
    Dim no As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection
        com = New SqlCommand
        con.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=student;Integrated Security=True"
        con.Open()
        com.Connection = con
        com.CommandText = "select regno from deepak"
        rd = com.ExecuteReader
        While rd.Read
            ComboBox1.Items.Add(rd.GetString(0))
        End While
        rd.Close()
    End Sub
End Class
