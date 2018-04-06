<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lblGameDif = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.lstDifficulty = New System.Windows.Forms.ComboBox
        Me.lblStartingSpeed = New System.Windows.Forms.Label
        Me.txtStartSpeed = New System.Windows.Forms.TextBox
        Me.txtMaxSpeed = New System.Windows.Forms.TextBox
        Me.lblMaximum = New System.Windows.Forms.Label
        Me.txtStartLives = New System.Windows.Forms.TextBox
        Me.lblStartLives = New System.Windows.Forms.Label
        Me.cmdUnlock = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(190, 317)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(271, 317)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblGameDif
        '
        Me.lblGameDif.AutoSize = True
        Me.lblGameDif.Location = New System.Drawing.Point(6, 29)
        Me.lblGameDif.Name = "lblGameDif"
        Me.lblGameDif.Size = New System.Drawing.Size(78, 13)
        Me.lblGameDif.TabIndex = 1
        Me.lblGameDif.Text = "Game Difficulty"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdUnlock)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.lstDifficulty)
        Me.GroupBox1.Controls.Add(Me.lblStartingSpeed)
        Me.GroupBox1.Controls.Add(Me.txtStartSpeed)
        Me.GroupBox1.Controls.Add(Me.txtMaxSpeed)
        Me.GroupBox1.Controls.Add(Me.lblMaximum)
        Me.GroupBox1.Controls.Add(Me.txtStartLives)
        Me.GroupBox1.Controls.Add(Me.lblStartLives)
        Me.GroupBox1.Controls.Add(Me.lblGameDif)
        Me.GroupBox1.Controls.Add(Me.cmdCancel)
        Me.GroupBox1.Controls.Add(Me.cmdOK)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 346)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Game Options"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(225, 143)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Clear High Scores"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lstDifficulty
        '
        Me.lstDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstDifficulty.FormattingEnabled = True
        Me.lstDifficulty.Items.AddRange(New Object() {"Easy", "Normal", "Hard", "Crazy", "Custom"})
        Me.lstDifficulty.Location = New System.Drawing.Point(225, 26)
        Me.lstDifficulty.Name = "lstDifficulty"
        Me.lstDifficulty.Size = New System.Drawing.Size(103, 21)
        Me.lstDifficulty.TabIndex = 10
        '
        'lblStartingSpeed
        '
        Me.lblStartingSpeed.AutoSize = True
        Me.lblStartingSpeed.Location = New System.Drawing.Point(6, 109)
        Me.lblStartingSpeed.Name = "lblStartingSpeed"
        Me.lblStartingSpeed.Size = New System.Drawing.Size(94, 13)
        Me.lblStartingSpeed.TabIndex = 8
        Me.lblStartingSpeed.Text = "Starting ball speed"
        '
        'txtStartSpeed
        '
        Me.txtStartSpeed.Enabled = False
        Me.txtStartSpeed.Location = New System.Drawing.Point(225, 106)
        Me.txtStartSpeed.Name = "txtStartSpeed"
        Me.txtStartSpeed.Size = New System.Drawing.Size(100, 20)
        Me.txtStartSpeed.TabIndex = 7
        '
        'txtMaxSpeed
        '
        Me.txtMaxSpeed.Enabled = False
        Me.txtMaxSpeed.Location = New System.Drawing.Point(225, 80)
        Me.txtMaxSpeed.Name = "txtMaxSpeed"
        Me.txtMaxSpeed.Size = New System.Drawing.Size(100, 20)
        Me.txtMaxSpeed.TabIndex = 6
        '
        'lblMaximum
        '
        Me.lblMaximum.AutoSize = True
        Me.lblMaximum.Location = New System.Drawing.Point(6, 83)
        Me.lblMaximum.Name = "lblMaximum"
        Me.lblMaximum.Size = New System.Drawing.Size(105, 13)
        Me.lblMaximum.TabIndex = 5
        Me.lblMaximum.Text = "Maximum Ball Speed"
        '
        'txtStartLives
        '
        Me.txtStartLives.Enabled = False
        Me.txtStartLives.Location = New System.Drawing.Point(225, 53)
        Me.txtStartLives.Name = "txtStartLives"
        Me.txtStartLives.Size = New System.Drawing.Size(100, 20)
        Me.txtStartLives.TabIndex = 4
        '
        'lblStartLives
        '
        Me.lblStartLives.AutoSize = True
        Me.lblStartLives.Location = New System.Drawing.Point(6, 56)
        Me.lblStartLives.Name = "lblStartLives"
        Me.lblStartLives.Size = New System.Drawing.Size(117, 13)
        Me.lblStartLives.TabIndex = 3
        Me.lblStartLives.Text = "Starting amount of lives"
        '
        'cmdUnlock
        '
        Me.cmdUnlock.Location = New System.Drawing.Point(225, 172)
        Me.cmdUnlock.Name = "cmdUnlock"
        Me.cmdUnlock.Size = New System.Drawing.Size(103, 23)
        Me.cmdUnlock.TabIndex = 12
        Me.cmdUnlock.Text = "Unlock"
        Me.cmdUnlock.UseVisualStyleBackColor = True
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 363)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmOptions"
        Me.Text = "Options"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblGameDif As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStartLives As System.Windows.Forms.TextBox
    Friend WithEvents lblStartLives As System.Windows.Forms.Label
    Friend WithEvents lblStartingSpeed As System.Windows.Forms.Label
    Friend WithEvents txtStartSpeed As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxSpeed As System.Windows.Forms.TextBox
    Friend WithEvents lblMaximum As System.Windows.Forms.Label
    Friend WithEvents lstDifficulty As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdUnlock As System.Windows.Forms.Button
End Class
