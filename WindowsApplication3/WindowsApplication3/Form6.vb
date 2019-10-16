Public Class Form6

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.Text = "KVB" Then
            ListBox2.Visible = True
            ListBox2.Items.Add("SANKARANKOVIL")
            ListBox2.Items.Add("THANJAI")
            ListBox2.Items.Add("MADURAI")
            ListBox2.Items.Add("DINDUGAL")
            ListBox2.Items.Add("KOVILPATTI")

        End If
        If ListBox1.Text = "IOB" Then
            ListBox2.Visible = True
            ListBox2.Items.Add("CHENNAI")
            ListBox2.Items.Add("COIMBATORE")
            ListBox2.Items.Add("DELHI")
            ListBox2.Items.Add("MUMBAI")
            ListBox2.Items.Add("ASSAM")

        End If
        If ListBox1.Text = "ICICI" Then
            ListBox2.Visible = True
            ListBox2.Items.Add("OOTY")
            ListBox2.Items.Add("CALCUTA")
            ListBox2.Items.Add("BIHAR")
            ListBox2.Items.Add("NEPAL")
            ListBox2.Items.Add("BHUTAN")

        End If
        If ListBox1.Text = "SBI" Then
            ListBox2.Visible = True
            ListBox2.Items.Add("VALLIYOOR")
            ListBox2.Items.Add("BANGALORE")
            ListBox2.Items.Add("TIRUNELVELI")
            ListBox2.Items.Add("TENKASI")
            ListBox2.Items.Add("VKPUTHUR")

        End If
        Label5.Visible = True
        Label5.Text = ListBox1.Text
    End Sub

    

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label5.Visible = False
        Label6.Visible = False
        ListBox2.Visible = False
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        Label6.Visible = True
        Label6.Text = ListBox2.Text
    End Sub
End Class