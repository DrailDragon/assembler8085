Public Class Help

    Private Sub Help_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Mnemonic_DataBaseDataSet2.conversion' table. You can move, or remove it, as needed.
        Me.ConversionTableAdapter.Fill(Me.Mnemonic_DataBaseDataSet2.conversion)

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class