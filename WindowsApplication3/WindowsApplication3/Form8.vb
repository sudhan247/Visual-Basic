Public Class Form8
    Dim ques(3, 3), a(3, 1) As String
    Dim i As Integer = -1

    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Visible = False
        Button1.Visible = False

        ques(0, 0) = "which is our country?"
        ques(0, 1) = "india"
        ques(0, 2) = "england"
        ques(0, 3) = "europe"
        ques(1, 0) = "which is our state?"
        ques(1, 1) = "tamilnadu"
        ques(1, 2) = "kerala"
        ques(1, 3) = "karnataka"
        ques(2, 0) = "which is our district?"
        ques(2, 1) = "tirunelveli"
        ques(2, 2) = "chennai"
        ques(2, 3) = "coimbatore"
        a(0, 0) = "india"
        a(1, 0) = "tamilnadu"
        a(2, 0) = "tirunelveli"
        Timer1.Enabled = True

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        i = i + 1
        If i = 3 Then
            Timer1.Enabled = False
            Button1.Visible = True
            Label1.Visible = True

        Else
            Timer1.Enabled = True
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            TextBox1.Text = ques(i, 0)
            RadioButton1.Text = ques(i, 1)
            RadioButton2.Text = ques(i, 2)
            RadioButton3.Text = ques(i, 3)

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim j As Integer
        Dim c As Integer = 0
        For j = 0 To 2
            If (a(j, 0) = a(j, 1)) Then
                c += 1
            End If
        Next
        Label1.Text = c
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        a(i, 1) = RadioButton1.Text

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        a(i, 1) = RadioButton2.Text
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        a(i, 1) = RadioButton3.Text
    End Sub
End Class