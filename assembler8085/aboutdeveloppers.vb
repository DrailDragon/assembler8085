Public Class aboutdeveloppers

    Private Sub aboutdeveloppers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AboutDeveloppers_Timer.Enabled = True
        developper_info_lbl.Left = Me.Width - 100
    End Sub

    Private Sub aboutdeveloppers_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Main_Form.Show()
        AboutDeveloppers_Timer.Enabled = False
    End Sub

    Private Sub AboutDeveloppers_Timer_Tick(sender As System.Object, e As System.EventArgs) Handles AboutDeveloppers_Timer.Tick
        developper_info_lbl.Left -= 1
        If developper_info_lbl.Left = -(Me.Width - 250) Then

            Me.Close()
            'Main_Form.Show()

        End If
    End Sub
End Class