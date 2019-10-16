Imports System.Data.SqlClient
Public Class Form2
    Dim con As New SqlConnection
    Dim com As New SqlCommand
    Dim rd As SqlDataReader
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection
        com = New SqlCommand
        con.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=student;Integrated Security=True"
        con.Open()
        com.Connection = con
        com.CommandText = "select * from deepak,john where deepak.regno=john.regno"
        z.Items.Clear()
        rd = com.ExecuteReader
        While rd.Read
            z.Items.Add(rd.GetString(0))
        End While
        rd.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        com.CommandText = "select deepak.name,address,phone,department,tamil,english,maths,science,social,total,avg,class from deepak,john where john.regno=deepak.regno and deepak.regno='" & z.SelectedItem & "'"
        rd = com.ExecuteReader
        If rd.Read Then
            Label1.Text = rd.GetString(0)
            Label14.Text = rd.GetString(1)
            Label15.Text = rd.GetString(2)
            Label25.Text = rd.GetString(3)
            Label16.Text = rd.GetString(4)
            Label17.Text = rd.GetString(5)
            Label18.Text = rd.GetString(6)
            Label19.Text = rd.GetString(7)
            Label20.Text = rd.GetString(8)
            Label21.Text = rd.GetString(9)
            Label22.Text = rd.GetString(10)
            Label23.Text = rd.GetString(11)
        End If
        rd.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub
End Class