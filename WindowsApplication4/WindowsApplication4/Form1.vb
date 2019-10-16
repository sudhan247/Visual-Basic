Imports System.Data.SqlClient
Public Class Form1
    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim rd As SqlDataReader

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection
        com = New SqlCommand
        con.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=student;Integrated Security=True"
        con.Open()
        com.Connection = con
        Call setup()

        com.CommandText = "select * from deepak"
        rd = com.ExecuteReader
        While rd.Read
            ComboBox1.Items.Add(rd.GetString(0))
        End While
        rd.Close()
    End Sub
    Private Sub setup()
        With DataGridView1
            .Columns.Add("deparment", "department")
            .Columns.Add("fees", "fees")
            .Columns.Add("date", "date")
        End With
    End Sub
    Private Sub retrieve()
        DataGridView1.Rows.Clear()
        com.CommandText = "select * from sudhan where regno='" & ComboBox1.SelectedItem & "'"
        Dim i As Long = DataGridView1.RowCount

        rd = com.ExecuteReader
        While rd.Read
            With DataGridView1
                .Rows.Add(i)
                .Rows(i).Cells(0).Value = rd.GetString(1)
                .Rows(i).Cells(1).Value = rd.GetString(2)
                .Rows(i).Cells(2).Value = rd.GetValue(3)
            End With
            i += 1

        End While
        rd.Close()

    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        com.CommandText = "select * from deepak where regno='" & ComboBox1.SelectedItem & "'"
        rd = com.ExecuteReader
        Button1.Visible = True


        If rd.Read Then
            Label6.Text = rd.GetString(1)
            Label7.Text = rd.GetString(2)
            Label8.Text = rd.GetString(3)
            Label9.Text = rd.GetString(4)
        End If
        rd.Close()
        Call retrieve()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GroupBox1.Visible = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If ComboBox2.SelectedItem = "" Or TextBox1.Text = "" Then
                MsgBox("PLEASE FILL ALL THE DETAILS ")
                Exit Sub
            End If
            com.CommandText = "insert into sudhan values('" & ComboBox1.SelectedItem & "','" & ComboBox2.SelectedItem & "','" & TextBox1.Text & "','" & DateTimePicker1.Value & "')"
            com.ExecuteNonQuery()
            MsgBox("SUCESS")
            Call retrieve()


    End Sub
End Class
