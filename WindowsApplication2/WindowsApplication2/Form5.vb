Imports System.Data.SqlClient
Public Class Form5
    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim rd As SqlDataReader
    Dim s, t, u, v, w, tot As Integer

    Private Sub VIEWToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VIEWToolStripMenuItem.Click
        Button1.Visible = False
        Button2.Visible = True
        Button3.Visible = True
        Button5.Visible = True
        GroupBox1.Visible = False
        GroupBox2.Visible = True
        z.Visible = True
        a.Visible = False
        Call clean()
        z.Items.Clear()
        com.CommandText = "select * from sudhan,sudhank where sudhan.regno=sudhank.regno"
        rd = com.ExecuteReader
        While rd.Read
            z.Items.Add(rd.GetString(0))
        End While
        rd.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If a.Text = "" Or b.Text = "" Or c.Text = "" Or d.Text = "" Then
            MsgBox("PLEASE FILL ALL THE DETAILS")
            Exit Sub


        End If
        com.CommandText = "insert into sudhan values('" & a.Text & "','" & b.Text & "','" & c.Text & "','" & d.Text & "')"
        com.ExecuteNonQuery()

        MsgBox("SUCCESS")
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()

        GroupBox1.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        com.CommandText = "delete sudhan where regno='" & z.SelectedIndex & "'"
        com.ExecuteNonQuery()
        MsgBox("RECORD DELETED")
        Call clean()
        z.Items.Remove(z.SelectedItem)
    End Sub

    Private Sub z_SelectedIndexChanged(sender As Object, e As EventArgs) Handles z.SelectedIndexChanged
        GroupBox1.Visible = False
        GroupBox2.Visible = True
        com.CommandText = "select sudhan.name,address,phone,tamil,english,maths,science,social,total,avg,class from sudhan,sudhank where sudhan.regno=sudhank.regno and sudhan.regno='" & z.SelectedItem & "'"
        rd = com.ExecuteReader
        If rd.Read Then
            b.Text = rd.GetString(0)
            c.Text = rd.GetString(1)
            d.Text = rd.GetString(2)
            Label16.Text = rd.GetString(3)
            Label17.Text = rd.GetString(4)
            Label18.Text = rd.GetString(5)
            Label19.Text = rd.GetString(6)
            Label20.Text = rd.GetString(7)
            Label21.Text = rd.GetString(8)
            Label22.Text = rd.GetString(9)
            Label23.Text = rd.GetString(10)
        End If
        rd.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        com.CommandText = "update sudhan set name='" & b.Text & "',address='" & c.Text & "',phone='" & d.Text & "'where regno='" & z.SelectedItem & "'"
        com.ExecuteNonQuery()
        MsgBox("RECORD UPDATED")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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
        com.CommandText = "insert into sudhank values('" & a.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & tot & "','" & avg & "','" & no & "')"
        com.ExecuteNonQuery()
        MsgBox("SUCCESS")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        GroupBox2.Visible = False
        GroupBox1.Visible = True
        Button4.Visible = False
        Button6.Visible = True
        Label27.Visible = True
        ComboBox1.Visible = True
        com.CommandText = "select * from sudhan"
        rd = com.ExecuteReader
        While rd.Read
            ComboBox1.Items.Add(rd.GetString(0))
        End While
        rd.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
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
        com.CommandText = "insert into sudhank values('" & ComboBox1.SelectedItem & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & tot & "','" & avg & "','" & no & "')"
        com.ExecuteNonQuery()
        MsgBox("UPDATED")
    End Sub



    Private Sub INSERTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INSERTToolStripMenuItem.Click
        Button1.Visible = True
        Button2.Visible = False
        Button3.Visible = False
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        z.Visible = False
        a.Visible = True
        Label27.Visible = False
        ComboBox1.Visible = False
        Button6.Visible = False
        Button5.Visible = False
        Call clean()
    End Sub

    Dim avg As Double
    Dim no As String
    Private Sub clean()
        a.Clear()
        b.Clear()
        c.Clear()
        d.Clear()


    End Sub
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection
        com = New SqlCommand
        con.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=student;Integrated Security=True"
        con.Open()
        com.Connection = con
    End Sub
End Class