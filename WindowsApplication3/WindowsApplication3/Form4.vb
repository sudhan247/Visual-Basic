Public Class Form4

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox2.Items.Clear()

        If ComboBox1.Text = "TAMIL NADU" Then
            ComboBox2.Items.Add("SANKAI")
            ComboBox2.Items.Add("THANJAI")
            ComboBox2.Items.Add("MADURAI")
        End If
        If ComboBox1.Text = "KERALA" Then
            ComboBox2.Items.Add("a")
            ComboBox2.Items.Add("b")
            ComboBox2.Items.Add("c")
        End If
        If ComboBox1.Text = "KARNATAKA" Then
            ComboBox2.Items.Add("1")
            ComboBox2.Items.Add("2")
            ComboBox2.Items.Add("3")
        End If
        Label5.Visible = True
        Label5.Text = ComboBox1.Text
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Label6.Visible = True
        Label6.Text = ComboBox2.Text
    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label5.Visible = False
        Label6.Visible = False


    End Sub
End Class