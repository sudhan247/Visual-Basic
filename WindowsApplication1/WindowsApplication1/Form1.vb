Imports System.Data.SqlClient
Public Class Form1
    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim rd As SqlDataReader

    Private Sub INSERTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INSERTToolStripMenuItem.Click
        a.Visible = True
        z.Visible = False
        a.Clear()
        b.Clear()
        c.Clear()
        d.Clear()
        ee.Clear()
        f.Clear()
        g.Clear()
        Button1.Text = "SAVE"
        Button1.BackColor = Color.Green

    End Sub
    Private Sub SetupDGVData()
        With DataGridView1

            .Columns.Add("regno", "regno")
            .Columns.Add("name", "name")
            .Columns.Add("age", "age")
            .Columns.Add("address", "address")
            .Columns.Add("city", "city")
            .Columns.Add("job", "job")
            .Columns.Add("phone", "phone")

        End With
    End Sub
    Private Sub RetrieveData(Optional ByVal blnSearch As Boolean = False)
        com.CommandText = "select * from hari"
        rd = com.ExecuteReader
        DataGridView1.Rows.Clear()
        Dim i As Long = DataGridView1.RowCount
            While rd.Read
                With DataGridView1
                .Rows.Add(i)
                .Rows(i).Cells(0).Value = rd.GetString(0)
                .Rows(i).Cells(1).Value = rd.GetString(1)
                .Rows(i).Cells(2).Value = rd.GetString(2)
                .Rows(i).Cells(3).Value = rd.GetString(3)
                .Rows(i).Cells(4).Value = rd.GetString(4)
                .Rows(i).Cells(5).Value = rd.GetString(5)
                .Rows(i).Cells(6).Value = rd.GetString(6)
            End With
            i += 1
        End While
        rd.Close()
    End Sub

    Private Sub VIEWToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VIEWToolStripMenuItem.Click
        z.Visible = True
        a.Visible = False
        a.Clear()
        b.Clear()
        c.Clear()
        d.Clear()
        ee.Clear()
        f.Clear()
        g.Clear()
        Button2.Visible = True

        Button1.Text = "UPDATE"
        Button2.Text = "DELETE"
        Button2.BackColor = Color.Red
        DataGridView1.Enabled = True
        Button1.BackColor = Color.Blue
        Call sudhan()
    End Sub

    Private Sub sudhan()
        com.CommandText = "select * from hari"
        rd = com.ExecuteReader
        z.Items.Clear()
        While rd.Read
            z.Items.Add(rd.GetString(0))
        End While



        rd.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con = New SqlConnection
        com = New SqlCommand
        con.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=student;Integrated Security=True"
        con.Open()
        com.Connection = con
        z.Items.Clear()
        Call SetupDGVData()
        Call RetrieveData()
    End Sub

    Private Sub z_SelectedIndexChanged(sender As Object, e As EventArgs) Handles z.SelectedIndexChanged
        com.CommandText = "select * from hari where regno='" & z.SelectedItem & "'"
        com.ExecuteNonQuery()

        Call deepak()

    End Sub
    Private Sub deepak()
        rd = com.ExecuteReader

        If rd.Read Then
            b.Text = rd.GetString(1)
            c.Text = rd.GetString(2)
            d.Text = rd.GetString(3)
            ee.Text = rd.GetString(4)
            f.Text = rd.GetString(5)
            g.Text = rd.GetString(6)
        End If
        rd.Close()
    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "SAVE" Then

            If a.Text = "" Or b.Text = "" Or c.Text = "" Or d.Text = "" Or ee.Text = "" Or f.Text = "" Or g.Text = "" Then
                MsgBox("PLEASE FILL ALL THE DETAILS")
                Exit Sub

            End If
            com.CommandText = "insert into hari values('" & a.Text & "','" & b.Text & "','" & c.Text & "','" & d.Text & "','" & ee.Text & "','" & f.Text & "','" & g.Text & "')"
            com.ExecuteNonQuery()
            MsgBox("SUCCESS")
            z.Items.Clear()
            Call RetrieveData()
            Call sudhan()

        Else
            com.CommandText = "update hari set name='" & b.Text & "',age='" & c.Text & "',address='" & d.Text & "',city='" & ee.Text & "',job='" & f.Text & "',phone='" & g.Text & "'where regno='" & z.SelectedItem & "'"
            com.ExecuteNonQuery()
            MsgBox("UPDATED")
            Call RetrieveData()
        End If
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Dim j As Integer
        j = DataGridView1.CurrentRow.Index
        z.Text = DataGridView1.Item(0, j).Value
        b.Text = DataGridView1.Item(1, j).Value
        c.Text = DataGridView1.Item(2, j).Value
        d.Text = DataGridView1.Item(3, j).Value
        ee.Text = DataGridView1.Item(4, j).Value
        f.Text = DataGridView1.Item(5, j).Value
        g.Text = DataGridView1.Item(6, j).Value
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        com.CommandText = "delete from hari where regno='" & z.SelectedItem & "'"
        com.ExecuteNonQuery()
        MsgBox("RECORD DELETED")
        z.Items.Remove(z.SelectedItem)
        a.Clear()
        b.Clear()
        c.Clear()
        d.Clear()
        ee.Clear()
        f.Clear()
        g.Clear()
        Call RetrieveData()
    End Sub
End Class
