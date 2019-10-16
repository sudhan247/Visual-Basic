Public Class Form7
    Dim a, b, c, d As String
    
    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Visible = False
        Label3.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label2.Visible = True
        Label3.Visible = True

        Label3.Text = Trim(a + " " + b + " " + c + " " + d)

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub



    Private Sub CheckBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.Click
        If CheckBox2.Checked Then
            b = CheckBox2.Text

        Else
            b = " "
        End If

    End Sub

    Private Sub CheckBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
        If CheckBox1.Checked Then
            a = CheckBox1.Text
        Else
            a = ""
        End If

    End Sub

    Private Sub CheckBox3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox3.Click
        If CheckBox3.Checked Then
            c = CheckBox3.Text
        Else
            c = " "
        End If
    End Sub

    Private Sub CheckBox4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox4.Click
        If CheckBox4.Checked Then
            d = CheckBox4.Text
        Else
            d = " "
        End If
    End Sub
End Class