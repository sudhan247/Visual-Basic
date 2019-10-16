Imports System.Data.SqlClient

Public Class Form1
    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim rd As SqlDataReader
    Private Sub clean()
        a.Clear()
        b.Clear()
        c.Clear()
        d.Clear()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection
        com = New SqlCommand
        con.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=student;Integrated Security=True"
        con.Open()
        com.Connection = con
    End Sub

    Private Sub INSERTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INSERTToolStripMenuItem.Click
        Button1.Visible = True
        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = False

        z.Visible = False
        a.Visible = True
        Call clean()
    End Sub

    Private Sub VIEWToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VIEWToolStripMenuItem.Click
        Button1.Visible = False
        Button2.Visible = True
        Button3.Visible = True
        z.Visible = True
        a.Visible = False
        Call clean()
        z.Items.Clear()
        com.CommandText = "select * from sudhan"
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
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        com.CommandText = "delete sudhan where regno='" & z.SelectedIndex & "'"
        com.ExecuteNonQuery()
        MsgBox("RECORD DELETED")
        Call clean()
        z.Items.Remove(z.SelectedItem)
    End Sub

    Private Sub z_SelectedIndexChanged(sender As Object, e As EventArgs) Handles z.SelectedIndexChanged
        com.CommandText = "select * from sudhan where regno='" & z.SelectedItem & "'"
        rd = com.ExecuteReader
        If rd.Read Then
            b.Text = rd.GetString(1)
            c.Text = rd.GetString(2)
            d.Text = rd.GetString(3)
            If a.Text = "" Then
                Button4.Visible = False
            End If
            Button4.Visible = True
        End If
        rd.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        com.CommandText = "update sudhan set b='" & b.Text & "',address='" & c.Text & "',phone='" & d.Text & "'where regno='" & z.SelectedItem & "'"
        com.ExecuteNonQuery()
        MsgBox("RECORD UPDATED")

    End Sub


    Private Sub DETAILSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DETAILSToolStripMenuItem.Click
        Form3.Show()

    End Sub

End Class
