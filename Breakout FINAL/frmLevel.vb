Public Class frmLevel
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            frmGame.level = txtLevel.Text
        Catch
            txtLevel.Text = 1
        End Try
        If frmGame.cmdNext.Visible = True Then
            MsgBox("Press next")
        Else
            frmGame.paused()
            frmGame.lvlclear()
            frmGame.resetAll()
            frmGame.lvl()
            frmGame.pause = 1
            frmGame.paused()
            Me.Close()
        End If
    End Sub

    Private Sub KeyRec_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeyRec.Tick
        If GetAsyncKeyState(System.Windows.Forms.Keys.Enter) < 0 Then
            Try
                frmGame.level = txtLevel.Text
            Catch
                txtLevel.Text = 1
            End Try
            If frmGame.cmdNext.Visible = True Then
                MsgBox("Press next")
            Else
                frmGame.paused()
                frmGame.lvlclear()
                frmGame.resetAll()
                frmGame.lvl()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub frmLevel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = frmGame.Top + frmGame.Height / 2 - Me.Height / 2
        Me.Left = frmGame.Left + frmGame.Width / 2 - Me.Width / 2
    End Sub
End Class