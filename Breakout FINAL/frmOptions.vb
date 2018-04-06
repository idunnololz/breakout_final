Public Class frmOptions

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = frmGame.Top + frmGame.Height / 2 - Me.Height / 2
        Me.Left = frmGame.Left + frmGame.Width / 2 - Me.Width / 2

        If frmGame.locked = True Then
            lstDifficulty.Enabled = False
        Else
            cmdUnlock.Text = "Lock"
        End If
        txtMaxSpeed.Text = frmGame.maxSpeed
        txtStartLives.Text = frmGame.startLives
        txtStartSpeed.Text = frmGame.ballStartSpeed
        Select Case frmGame.gameDifficulty
            Case 0
                lstDifficulty.Text = "Custom"
            Case 1
                lstDifficulty.Text = "Easy"
                txtMaxSpeed.Text = 10
                txtStartLives.Text = 8
                txtStartSpeed.Text = 4
            Case 2
                lstDifficulty.Text = "Normal"
                txtMaxSpeed.Text = 12
                txtStartLives.Text = 5
                txtStartSpeed.Text = 5
            Case 3
                lstDifficulty.Text = "Hard"
                txtMaxSpeed.Text = 14
                txtStartLives.Text = 3
                txtStartSpeed.Text = 6
            Case 4
                lstDifficulty.Text = "Crazy"
                txtMaxSpeed.Text = 16
                txtStartLives.Text = 2
                txtStartSpeed.Text = 8
        End Select
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        frmGame.maxSpeed = Int(txtMaxSpeed.Text)
        frmGame.startLives = Int(txtStartLives.Text)
        frmGame.ballStartSpeed = Int(txtStartSpeed.Text)
        If Int(txtStartLives.Text) > 50 Then
            frmGame.startLives = 50
        End If
        If Int(txtMaxSpeed.Text) > 40 Then
            frmGame.maxSpeed = 40
        End If
        If Int(txtStartSpeed.Text) > 20 Then
            frmGame.ballStartSpeed = 20
        End If
        Call frmGame.SaveConfigurations()
        Me.Close()
    End Sub
    Private Sub lstDifficulty_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDifficulty.SelectedIndexChanged
        If lstDifficulty.Text = "Custom" Then
            txtMaxSpeed.Enabled = True
            txtStartLives.Enabled = True
            txtStartSpeed.Enabled = True
        Else
            txtMaxSpeed.Enabled = False
            txtStartLives.Enabled = False
            txtStartSpeed.Enabled = False
        End If
        If lstDifficulty.Text = "Easy" Then
            txtMaxSpeed.Text = 10
            txtStartLives.Text = 8
            txtStartSpeed.Text = 4
            frmGame.gameDifficulty = 1
        ElseIf lstDifficulty.Text = "Normal" Then
            txtMaxSpeed.Text = 12
            txtStartLives.Text = 5
            txtStartSpeed.Text = 5
            frmGame.gameDifficulty = 2
        ElseIf lstDifficulty.Text = "Hard" Then
            txtMaxSpeed.Text = 14
            txtStartLives.Text = 3
            txtStartSpeed.Text = 6
            frmGame.gameDifficulty = 3
        ElseIf lstDifficulty.Text = "Crazy" Then
            txtMaxSpeed.Text = 16
            txtStartLives.Text = 2
            txtStartSpeed.Text = 8
            frmGame.gameDifficulty = 4
        Else
            frmGame.gameDifficulty = 0
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmGame.clearhighscore()
    End Sub

    Private Sub cmdUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnlock.Click
        If cmdUnlock.Text = "Lock" Then
            frmGame.locked = True
            lstDifficulty.Enabled = False
            frmGame.menuDifficulty.Enabled = False
            cmdUnlock.Text = "Unlock"
        Else
            frmUnlock.Show()
        End If
    End Sub
End Class