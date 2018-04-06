Public Class frmUnlock
    'NOTE:in the locked version of the game, the game difficulty is locked and so is the level selector and the other debugging funstions
    'Feel free to change th unlock and lock code

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        If txtPassword.Text = "smallend" Then
            frmGame.locked = False
            frmOptions.lstDifficulty.Enabled = True
            frmGame.menuDifficulty.Enabled = True
            frmOptions.cmdUnlock.Text = "Lock"
            Me.Close()
        Else
            MsgBox("Password incorrect. Please finish the game to gain password.")
            Me.Close()
        End If
    End Sub

    Private Sub frmUnlock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = frmOptions.Top + frmOptions.Height / 2 - Me.Height / 2
        Me.Left = frmOptions.Left + frmOptions.Width / 2 - Me.Width / 2
    End Sub
End Class