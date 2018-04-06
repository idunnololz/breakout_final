<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGame
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ballInteract = New System.Windows.Forms.Timer(Me.components)
        Me.timerFPS = New System.Windows.Forms.Timer(Me.components)
        Me.timerStart = New System.Windows.Forms.Timer(Me.components)
        Me.timerPause = New System.Windows.Forms.Timer(Me.components)
        Me.GameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GameLevelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GameToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.lblFPS = New System.Windows.Forms.Label
        Me.lblBallProperties = New System.Windows.Forms.Label
        Me.Pad = New System.Windows.Forms.PictureBox
        Me.cmdStart = New System.Windows.Forms.Button
        Me.cmdTryAgain = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdReset = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.menuNewGame = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator
        Me.menuFullScreenMode = New System.Windows.Forms.ToolStripMenuItem
        Me.menuPause = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ReturnToMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator
        Me.menuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.menuLevel = New System.Windows.Forms.ToolStripMenuItem
        Me.menuDifficulty = New System.Windows.Forms.ToolStripMenuItem
        Me.menuEasy = New System.Windows.Forms.ToolStripMenuItem
        Me.menuNormal = New System.Windows.Forms.ToolStripMenuItem
        Me.menuHard = New System.Windows.Forms.ToolStripMenuItem
        Me.menuCrazy = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.menuInstructions = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator
        Me.menuAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.recStatus = New System.Windows.Forms.Panel
        Me.txtAnnouncement = New System.Windows.Forms.TextBox
        Me.lblHighscore = New System.Windows.Forms.Label
        Me.lblLives = New System.Windows.Forms.Label
        Me.lblScore = New System.Windows.Forms.Label
        Me.PlayField = New System.Windows.Forms.PictureBox
        Me.lblBlocksDestoryed = New System.Windows.Forms.Label
        Me.timerOther = New System.Windows.Forms.Timer(Me.components)
        Me.cmdResume = New System.Windows.Forms.Button
        Me.lblClick = New System.Windows.Forms.Label
        CType(Me.Pad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.recStatus.SuspendLayout()
        CType(Me.PlayField, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ballInteract
        '
        Me.ballInteract.Interval = 1
        '
        'timerFPS
        '
        Me.timerFPS.Interval = 500
        '
        'timerStart
        '
        Me.timerStart.Interval = 1
        '
        'timerPause
        '
        Me.timerPause.Enabled = True
        '
        'GameToolStripMenuItem
        '
        Me.GameToolStripMenuItem.Name = "GameToolStripMenuItem"
        Me.GameToolStripMenuItem.Size = New System.Drawing.Size(32, 19)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(181, 6)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GameLevelToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'GameLevelToolStripMenuItem
        '
        Me.GameLevelToolStripMenuItem.Name = "GameLevelToolStripMenuItem"
        Me.GameLevelToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.GameLevelToolStripMenuItem.Text = "Game Level"
        '
        'GameToolStripMenuItem1
        '
        Me.GameToolStripMenuItem1.Name = "GameToolStripMenuItem1"
        Me.GameToolStripMenuItem1.Size = New System.Drawing.Size(170, 22)
        Me.GameToolStripMenuItem1.Text = "Game Instructions"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(167, 6)
        '
        'lblFPS
        '
        Me.lblFPS.AutoSize = True
        Me.lblFPS.BackColor = System.Drawing.Color.Transparent
        Me.lblFPS.ForeColor = System.Drawing.Color.Red
        Me.lblFPS.Location = New System.Drawing.Point(9, 33)
        Me.lblFPS.Name = "lblFPS"
        Me.lblFPS.Size = New System.Drawing.Size(27, 13)
        Me.lblFPS.TabIndex = 5
        Me.lblFPS.Text = "FPS"
        Me.lblFPS.Visible = False
        '
        'lblBallProperties
        '
        Me.lblBallProperties.AutoSize = True
        Me.lblBallProperties.BackColor = System.Drawing.Color.Transparent
        Me.lblBallProperties.ForeColor = System.Drawing.Color.Red
        Me.lblBallProperties.Location = New System.Drawing.Point(483, 33)
        Me.lblBallProperties.Name = "lblBallProperties"
        Me.lblBallProperties.Size = New System.Drawing.Size(97, 13)
        Me.lblBallProperties.TabIndex = 6
        Me.lblBallProperties.Text = "X, Y, Slope, Speed"
        Me.lblBallProperties.Visible = False
        '
        'Pad
        '
        Me.Pad.BackColor = System.Drawing.Color.Transparent
        Me.Pad.Image = Global.Breakout_FINAL.My.Resources.Resources.Pad
        Me.Pad.Location = New System.Drawing.Point(275, 328)
        Me.Pad.Name = "Pad"
        Me.Pad.Size = New System.Drawing.Size(60, 20)
        Me.Pad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pad.TabIndex = 7
        Me.Pad.TabStop = False
        Me.Pad.Visible = False
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(277, 177)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(75, 23)
        Me.cmdStart.TabIndex = 8
        Me.cmdStart.Text = "Start!"
        Me.cmdStart.UseVisualStyleBackColor = True
        Me.cmdStart.Visible = False
        '
        'cmdTryAgain
        '
        Me.cmdTryAgain.Location = New System.Drawing.Point(277, 177)
        Me.cmdTryAgain.Name = "cmdTryAgain"
        Me.cmdTryAgain.Size = New System.Drawing.Size(75, 23)
        Me.cmdTryAgain.TabIndex = 9
        Me.cmdTryAgain.Text = "Try Again"
        Me.cmdTryAgain.UseVisualStyleBackColor = True
        Me.cmdTryAgain.Visible = False
        '
        'cmdNext
        '
        Me.cmdNext.Location = New System.Drawing.Point(277, 177)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(75, 23)
        Me.cmdNext.TabIndex = 10
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        Me.cmdNext.Visible = False
        '
        'cmdReset
        '
        Me.cmdReset.Location = New System.Drawing.Point(277, 177)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(75, 23)
        Me.cmdReset.TabIndex = 11
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        Me.cmdReset.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3, Me.EditToolStripMenuItem1, Me.HelpToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(629, 24)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuNewGame, Me.ToolStripMenuItem5, Me.menuFullScreenMode, Me.menuPause, Me.ToolStripSeparator1, Me.ReturnToMenuToolStripMenuItem, Me.ToolStripMenuItem6, Me.menuExit})
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(46, 20)
        Me.ToolStripMenuItem3.Text = "Game"
        '
        'menuNewGame
        '
        Me.menuNewGame.Name = "menuNewGame"
        Me.menuNewGame.Size = New System.Drawing.Size(174, 22)
        Me.menuNewGame.Text = "New Game"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(171, 6)
        '
        'menuFullScreenMode
        '
        Me.menuFullScreenMode.Enabled = False
        Me.menuFullScreenMode.Name = "menuFullScreenMode"
        Me.menuFullScreenMode.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.menuFullScreenMode.Size = New System.Drawing.Size(174, 22)
        Me.menuFullScreenMode.Text = "Full Screen Mode"
        '
        'menuPause
        '
        Me.menuPause.Enabled = False
        Me.menuPause.Name = "menuPause"
        Me.menuPause.ShortcutKeyDisplayString = "P"
        Me.menuPause.Size = New System.Drawing.Size(174, 22)
        Me.menuPause.Text = "Pause"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(171, 6)
        '
        'ReturnToMenuToolStripMenuItem
        '
        Me.ReturnToMenuToolStripMenuItem.Name = "ReturnToMenuToolStripMenuItem"
        Me.ReturnToMenuToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.ReturnToMenuToolStripMenuItem.Text = "Return to menu"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(171, 6)
        '
        'menuExit
        '
        Me.menuExit.Name = "menuExit"
        Me.menuExit.ShortcutKeyDisplayString = "Esc"
        Me.menuExit.Size = New System.Drawing.Size(174, 22)
        Me.menuExit.Text = "Exit"
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuLevel, Me.menuDifficulty})
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem1.Text = "Edit"
        '
        'menuLevel
        '
        Me.menuLevel.Enabled = False
        Me.menuLevel.Name = "menuLevel"
        Me.menuLevel.ShortcutKeys = System.Windows.Forms.Keys.F10
        Me.menuLevel.Size = New System.Drawing.Size(154, 22)
        Me.menuLevel.Text = "Game Level"
        '
        'menuDifficulty
        '
        Me.menuDifficulty.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuEasy, Me.menuNormal, Me.menuHard, Me.menuCrazy})
        Me.menuDifficulty.Name = "menuDifficulty"
        Me.menuDifficulty.Size = New System.Drawing.Size(154, 22)
        Me.menuDifficulty.Text = "Game Difficulty"
        '
        'menuEasy
        '
        Me.menuEasy.Name = "menuEasy"
        Me.menuEasy.Size = New System.Drawing.Size(107, 22)
        Me.menuEasy.Text = "Easy"
        '
        'menuNormal
        '
        Me.menuNormal.Name = "menuNormal"
        Me.menuNormal.Size = New System.Drawing.Size(107, 22)
        Me.menuNormal.Text = "Normal"
        '
        'menuHard
        '
        Me.menuHard.Name = "menuHard"
        Me.menuHard.Size = New System.Drawing.Size(107, 22)
        Me.menuHard.Text = "Hard"
        '
        'menuCrazy
        '
        Me.menuCrazy.Name = "menuCrazy"
        Me.menuCrazy.Size = New System.Drawing.Size(107, 22)
        Me.menuCrazy.Text = "Crazy"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuInstructions, Me.ToolStripMenuItem4, Me.menuAbout})
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem1.Text = "Help"
        '
        'menuInstructions
        '
        Me.menuInstructions.Name = "menuInstructions"
        Me.menuInstructions.Size = New System.Drawing.Size(161, 22)
        Me.menuInstructions.Text = "Game Instructions"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(158, 6)
        '
        'menuAbout
        '
        Me.menuAbout.Name = "menuAbout"
        Me.menuAbout.Size = New System.Drawing.Size(161, 22)
        Me.menuAbout.Text = "About"
        '
        'recStatus
        '
        Me.recStatus.Controls.Add(Me.txtAnnouncement)
        Me.recStatus.Location = New System.Drawing.Point(-1, 354)
        Me.recStatus.Name = "recStatus"
        Me.recStatus.Size = New System.Drawing.Size(635, 22)
        Me.recStatus.TabIndex = 14
        '
        'txtAnnouncement
        '
        Me.txtAnnouncement.BackColor = System.Drawing.Color.White
        Me.txtAnnouncement.ForeColor = System.Drawing.Color.Black
        Me.txtAnnouncement.Location = New System.Drawing.Point(176, 1)
        Me.txtAnnouncement.Name = "txtAnnouncement"
        Me.txtAnnouncement.ReadOnly = True
        Me.txtAnnouncement.Size = New System.Drawing.Size(283, 20)
        Me.txtAnnouncement.TabIndex = 0
        Me.txtAnnouncement.TabStop = False
        '
        'lblHighscore
        '
        Me.lblHighscore.AutoSize = True
        Me.lblHighscore.Location = New System.Drawing.Point(79, 358)
        Me.lblHighscore.Name = "lblHighscore"
        Me.lblHighscore.Size = New System.Drawing.Size(72, 13)
        Me.lblHighscore.TabIndex = 17
        Me.lblHighscore.Text = "High Score: 0"
        '
        'lblLives
        '
        Me.lblLives.AutoSize = True
        Me.lblLives.Location = New System.Drawing.Point(581, 358)
        Me.lblLives.Name = "lblLives"
        Me.lblLives.Size = New System.Drawing.Size(44, 13)
        Me.lblLives.TabIndex = 16
        Me.lblLives.Text = "Lives: 0"
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.Location = New System.Drawing.Point(5, 358)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(47, 13)
        Me.lblScore.TabIndex = 15
        Me.lblScore.Text = "Score: 0"
        '
        'PlayField
        '
        Me.PlayField.BackColor = System.Drawing.Color.Transparent
        Me.PlayField.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PlayField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PlayField.Enabled = False
        Me.PlayField.Location = New System.Drawing.Point(-1, 24)
        Me.PlayField.Name = "PlayField"
        Me.PlayField.Size = New System.Drawing.Size(632, 330)
        Me.PlayField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PlayField.TabIndex = 18
        Me.PlayField.TabStop = False
        '
        'lblBlocksDestoryed
        '
        Me.lblBlocksDestoryed.AutoSize = True
        Me.lblBlocksDestoryed.BackColor = System.Drawing.Color.Transparent
        Me.lblBlocksDestoryed.ForeColor = System.Drawing.Color.Red
        Me.lblBlocksDestoryed.Location = New System.Drawing.Point(272, 33)
        Me.lblBlocksDestoryed.Name = "lblBlocksDestoryed"
        Me.lblBlocksDestoryed.Size = New System.Drawing.Size(90, 13)
        Me.lblBlocksDestoryed.TabIndex = 20
        Me.lblBlocksDestoryed.Text = "Blocks Destroyed"
        Me.lblBlocksDestoryed.Visible = False
        '
        'timerOther
        '
        Me.timerOther.Enabled = True
        Me.timerOther.Interval = 10
        '
        'cmdResume
        '
        Me.cmdResume.Location = New System.Drawing.Point(208, 49)
        Me.cmdResume.Name = "cmdResume"
        Me.cmdResume.Size = New System.Drawing.Size(213, 23)
        Me.cmdResume.TabIndex = 21
        Me.cmdResume.Text = "Press P to resume or click here!"
        Me.cmdResume.UseVisualStyleBackColor = True
        Me.cmdResume.Visible = False
        '
        'lblClick
        '
        Me.lblClick.AutoSize = True
        Me.lblClick.Location = New System.Drawing.Point(279, 112)
        Me.lblClick.Name = "lblClick"
        Me.lblClick.Size = New System.Drawing.Size(71, 13)
        Me.lblClick.TabIndex = 22
        Me.lblClick.Text = "Click To Start"
        Me.lblClick.Visible = False
        '
        'frmGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Breakout_FINAL.My.Resources.Resources.blueBG
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(629, 376)
        Me.Controls.Add(Me.lblClick)
        Me.Controls.Add(Me.cmdResume)
        Me.Controls.Add(Me.lblBlocksDestoryed)
        Me.Controls.Add(Me.lblHighscore)
        Me.Controls.Add(Me.lblLives)
        Me.Controls.Add(Me.lblScore)
        Me.Controls.Add(Me.recStatus)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cmdReset)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdTryAgain)
        Me.Controls.Add(Me.cmdStart)
        Me.Controls.Add(Me.Pad)
        Me.Controls.Add(Me.lblBallProperties)
        Me.Controls.Add(Me.lblFPS)
        Me.Controls.Add(Me.PlayField)
        Me.Cursor = System.Windows.Forms.Cursors.Cross
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmGame"
        Me.Text = "Breakout"
        CType(Me.Pad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.recStatus.ResumeLayout(False)
        Me.recStatus.PerformLayout()
        CType(Me.PlayField, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ballInteract As System.Windows.Forms.Timer
    Friend WithEvents timerFPS As System.Windows.Forms.Timer
    Friend WithEvents timerStart As System.Windows.Forms.Timer
    Friend WithEvents timerPause As System.Windows.Forms.Timer
    Friend WithEvents GameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblFPS As System.Windows.Forms.Label
    Friend WithEvents lblBallProperties As System.Windows.Forms.Label
    Friend WithEvents Pad As System.Windows.Forms.PictureBox
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents cmdTryAgain As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GameLevelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GameToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuFullScreenMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuPause As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuLevel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuInstructions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents recStatus As System.Windows.Forms.Panel
    Friend WithEvents lblHighscore As System.Windows.Forms.Label
    Friend WithEvents lblLives As System.Windows.Forms.Label
    Friend WithEvents lblScore As System.Windows.Forms.Label
    Friend WithEvents PlayField As System.Windows.Forms.PictureBox
    Friend WithEvents menuNewGame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblBlocksDestoryed As System.Windows.Forms.Label
    Friend WithEvents txtAnnouncement As System.Windows.Forms.TextBox
    Friend WithEvents timerOther As System.Windows.Forms.Timer
    Friend WithEvents cmdResume As System.Windows.Forms.Button
    Friend WithEvents menuDifficulty As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEasy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuNormal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuHard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCrazy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReturnToMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblClick As System.Windows.Forms.Label
End Class
