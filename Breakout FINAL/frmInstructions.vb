Public Class frmInstructions

    Private Sub frmInstructions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = frmGame.Top + frmGame.Height / 2 - Me.Height / 2
        Me.Left = frmGame.Left + frmGame.Width / 2 - Me.Width / 2
    End Sub
End Class