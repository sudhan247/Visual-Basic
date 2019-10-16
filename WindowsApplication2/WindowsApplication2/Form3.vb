Imports System.Data.SqlClient
Public Class Form3

    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim rd As SqlDataReader
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection
        com = New SqlCommand
        con.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=student;Integrated Security=True"
        con.Open()
        com.Connection = con
        com.CommandText = "select * from sudhan,sudhank where sudhan.regno=sudhank.regno"
        z.Items.Clear()
        rd = com.ExecuteReader
        While rd.Read
            z.Items.Add(rd.GetString(0))
        End While
        rd.Close()
    End Sub

    Private Sub z_SelectedIndexChanged(sender As Object, e As EventArgs) Handles z.SelectedIndexChanged
        com.CommandText = "select sudhan.name,address,phone,tamil,english,maths,science,social,total,avg,class from sudhan,sudhank where sudhan.regno=sudhank.regno and sudhan.regno='" & z.SelectedItem & "'"
        rd = com.ExecuteReader
        If rd.Read Then
            Label1.Text = rd.GetString(0)
            Label14.Text = rd.GetString(1)
            Label15.Text = rd.GetString(2)
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
End Class