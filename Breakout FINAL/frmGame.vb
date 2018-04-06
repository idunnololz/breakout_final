' ______________________________________________________________________________
'
'                Copyright ©2008 Gary Guo All Rights Reserved  
' ______________________________________________________________________________

' Product:  Breakout Video game
' Release:  Beta 
' Platform: Windows XP , Windows Vista
' Date:     Jan 18, 2009

' TERMS OF USE:
' This program is free software. Redistribution in the form of source code or compiled application, 
' strictly for non-profit purposes, with or without modification is permitted. 
' The author accepts no liability for anything that may result from the usage of 
' this product. This notice must not be removed or altered in any way whatsoever. 
'
'*******************************************************************************
'IMPORTANT: THE USE OF SMALLEND IS COPYRIGHTED AND YES SMALLEND IS A WORD!!!!!!
'*******************************************************************************
' ______________________________________________________________________________

Imports System.IO
Public Class frmGame

    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short
    Private Declare Function ShowCursor Lib "user32" (ByVal bShow As Long) As Long
    Private Declare Function EnumDisplaySettings Lib "user32" Alias "EnumDisplaySettingsA" (ByVal lpszDeviceName As Integer, ByVal iModeNum As Integer, ByRef lpDevMode As DEVMODE) As Boolean
    Private Declare Function ChangeDisplaySettings Lib "user32" Alias "ChangeDisplaySettingsA" (ByRef lpDevMode As DEVMODE, ByVal dwflags As Integer) As Integer
    Private Const ENUM_CURRENT_SETTINGS As Integer = -1&
    Private Const CCDEVICENAME As Short = 32
    Private Const CCFORMNAME As Short = 32
    Private Const DM_BITSPERPEL = &H60000
    Private Const DM_PELSWIDTH As Integer = &H80000
    Private Const DM_PELSHEIGHT As Integer = &H100000
    Private Const DM_DISPLAYFREQUENCY As Integer = &H400000

    Dim aiPad As PictureBox
    Dim copy, numOfBalls, primeBall, ballz, he, blocksDestroyed, winnumreq, startnum As Integer
    Dim x(9), y(9) As Double
    Dim block(100) As Button
    Dim powerupPic(9, 40) As PictureBox
    Dim picCannon As PictureBox
    Dim powerup(9) As Integer
    Dim ball(9) As PictureBox
    Dim CannonActivate As Integer
    Dim fps As Integer
    Dim numNorm, numS, numM, numSlow, numFast, numExpand, numShrink, numC, numFire, numL, numSticky, numShield As Integer
    Dim cannonshot As PictureBox
    Dim shotnum As Integer
    Dim life As Integer
    Dim powerups As Integer
    Dim fireBall As Integer
    Dim stickyP As PictureBox
    Dim stickyPadEnabled As Integer
    Dim ballStickCount As Integer
    Dim ballstuck As Integer
    Dim ballstuckposition As Single
    Dim score As Integer
    Dim fullscreenalt As Integer
    Dim padsections As Integer
    Dim ballpos As Integer
    Dim highScore As Integer
    Dim blockbreak(9) As Integer
    Dim slope As Single
    Dim ballSpeed As Single
    Dim blockdestroyed As Integer = 0
    Dim hitsideR, hitsideL As Integer
    Dim degree, randomAngle As Single
    Dim ScrnRes As System.Drawing.Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
    Dim picBreakout As PictureBox
    Dim picNewgame As PictureBox
    Dim picHowTo As PictureBox
    Dim picOptions As PictureBox
    Dim picAbout As PictureBox
    Dim picExit As PictureBox
    Dim fileDate As DateTime
    Dim fileName As String
    Dim shieldThickness As Integer
    Dim shield As PictureBox
    Dim hitTop As Integer
    Dim hitBottom As Integer
    Dim aiBotEnabled As Boolean
    Dim objFSO As Object

    Public locked As Boolean = True
    Public level As Integer
    Public maxSpeed As Integer = 12
    Public ballStartSpeed As Integer = 5
    Public startLives As Integer = 5
    Public gameDifficulty As Integer
    Public pause As Integer
    Private Structure DEVMODE

        <VBFixedString(CCDEVICENAME), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=CCDEVICENAME)> Public dmDeviceName As String
        Dim dmSpecVersion As Short
        Dim dmDriverVersion As Short
        Dim dmSize As Short
        Dim dmDriverExtra As Short
        Dim dmFields As Integer
        Dim dmOrientation As Short
        Dim dmPaperSize As Short
        Dim dmPaperLength As Short
        Dim dmPaperWidth As Short
        Dim dmScale As Short
        Dim dmCopies As Short
        Dim dmDefaultSource As Short
        Dim dmPrintQuality As Short
        Dim dmColor As Short
        Dim dmDuplex As Short
        Dim dmYResolution As Short
        Dim dmTTOption As Short
        Dim dmCollate As Short
        <VBFixedString(CCFORMNAME), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=CCFORMNAME)> Public dmFormName As String
        Dim dmUnusedPadding As Short
        Dim dmBitsPerPel As Integer
        Dim dmPelsWidth As Integer
        Dim dmPelsHeight As Integer
        Dim dmDisplayFlags As Integer
        Dim dmDisplayFrequency As Integer

    End Structure
    Public Sub powerupInteract()
        'Powerup movement
        Dim x, y As Integer
        For x = 0 To 9
            For y = 0 To (powerup(x) - 1)
                powerupPic(x, y).Top += 4   'Move powerups
                If Pad.Right >= powerupPic(x, y).Left And Pad.Bottom >= powerupPic(x, y).Top And Pad.Left <= powerupPic(x, y).Right And Pad.Top < powerupPic(x, y).Bottom Then
                    txtAnnouncement.BackColor = Color.Red
                    'If pad touches a powerup
                    Select Case x   'Select powerup type
                        Case 0
                            multiball() 'Add another ball into play
                            txtAnnouncement.Text = "Multiball Powerup Acquired!"
                        Case 1
                            If Pad.Width < 85 Then          'Check pad's length 
                                Pad.Width = Pad.Width + 10  'Increase pad length
                                txtAnnouncement.Text = "Your pad has been lengthened!"
                            End If
                        Case 2
                            If Pad.Width > 30 Then          'Check pad's length
                                Pad.Width = Pad.Width - 10  'Decrease pad length
                                txtAnnouncement.Text = "Your pad has been smallend"
                            End If
                        Case 3
                            If CannonActivate <> 1 Then     'Check if powerup is already enabled
                                cannon()                    'Enables cannon powerup
                            End If
                            txtAnnouncement.Text = "Cannon activated! Click to shoot lasers"
                        Case 4
                            slowdown()                      'Slow down ball
                            txtAnnouncement.Text = "Ball speed decreased!"
                        Case 5
                            speedup()                       'Speed up ball
                            txtAnnouncement.Text = "Ball speed increased!"
                        Case 6
                            life += 1                       'Add a life
                            txtAnnouncement.Text = "Lives Increased!"
                        Case 7
                            fireBall = 1                    'Enable fireball powerup
                            For xx = 0 To numOfBalls
                                ball(xx).Image = My.Resources.FireBall  'Redraw all balls
                            Next
                            txtAnnouncement.Text = "Fireball powerup activated! Ball is now able to go through blocks!"
                        Case 8
                            If stickyPadEnabled <> 1 Then   'Check if powerup is already enabled
                                stickypad()                 'Enabled stick pad powerup
                            End If
                            txtAnnouncement.Text = "Sticky Pad Activated! Balls with now stick to pad!"
                        Case 9
                            shield.Visible = True

                            If shieldThickness < 3 Then
                                shieldThickness += 1
                            End If
                            shieldhit()
                            txtAnnouncement.Text = "Shield Activated!"
                    End Select
                    powerupPic(x, y).Top = 600
                    powerups -= 1
                ElseIf powerupPic(x, y).Top > PlayField.Bottom And powerupPic(x, y).Top < 500 Then
                    powerupPic(x, y).Top = 600 'Makes the power up disappear when it reaches the bottom of the field
                    powerups -= 1   'Subtract from the number of power ups dropping on the screen
                End If
            Next
        Next
    End Sub
    Private Sub shieldhit()
        Select Case shieldThickness
            Case 0
                shield.Visible = False
            Case 1
                shield.BackColor = Color.Yellow
            Case 2
                shield.BackColor = Color.Orange
            Case 3
                shield.BackColor = Color.Red
        End Select
    End Sub
    Public Sub drawShield()
        shield = New PictureBox
        With shield
            .Location = New System.Drawing.Point(PlayField.Left, recStatus.Top - 5)
            .Size = New System.Drawing.Size(PlayField.Width, 3)
            .SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            shield.BackColor = Color.Yellow
            .Visible = False
            Me.Controls.Add(shield)
        End With
        shield.BringToFront()
    End Sub
    Public Sub stickypad()
        'Draws the new pad
        Pad.Image = My.Resources.stickyPad
        Pad.Size = New System.Drawing.Size(Pad.Width, 20)
        Pad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Controls.Add(Pad)
        stickyPadEnabled = 1    'Enable sticky pad powerup
        ballStickCount = 0      'Resets the # of balls stuck to the pad
    End Sub
    Public Sub slowdown()
        For xx = 0 To numOfBalls    'Slows down all balls
            x(xx) /= 1.3
            y(xx) /= 1.3
        Next
    End Sub
    Public Sub speedup()
        For xx = 0 To numOfBalls    'Speeds up all balls
            x(xx) *= 1.3
            y(xx) *= 1.3
        Next
    End Sub
    Public Sub cannon()
        'Draws the cannon
        picCannon = New System.Windows.Forms.PictureBox
        picCannon.Image = My.Resources.Cannon
        picCannon.Location = New System.Drawing.Point(300, Pad.Top - 20)
        picCannon.Size = New System.Drawing.Size(13, 25)
        picCannon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        picCannon.Visible = True
        picCannon.BackColor = Color.Transparent
        Me.Controls.Add(picCannon)
        CannonActivate = 1  'Enabale cannon powerup
        shotnum = 0         'Reset the number of cannonshots
    End Sub
    Public Sub ballinter()
        For xx = 0 To numOfBalls
            If y(xx) < 0.5 And y(xx) > -0.5 And ball(xx).Visible = True Then 'Stops the ball from going at a too steep angle
                y(xx) = 1
            End If

            If ballStickCount <> 1 Or stickyPadEnabled <> 1 Or xx <> ballstuck Then
                'If ball is not stuck to paddle then move the ball
                ball(xx).Left = ball(xx).Left + x(xx)
                ball(xx).Top = ball(xx).Top + y(xx)
            End If

            If ball(xx).Top <= PlayField.Top Then
                If aiBotEnabled = False Then
                    'If the ball goes out of the form then
                    score += 10         'Add 10 points to the score
                    ball(xx).Top = PlayField.Top + 1   'Relocate the ball to somewhere inside the form
                    y(xx) = y(xx) * -1  'Reverse ball's y movement
                Else
                    If life <> 0 Then
                        ballInteract.Enabled = False
                        saveHighScore()
                        MsgBox("You WIN. The password to unlocking game is smallend! SMALLEND IS A WORD!")
                        reloadMenu()
                    End If
                    End If
            End If
                If ball(xx).Left < PlayField.Left Then
                    'If the ball's left is below 0
                    If xx <> ballstuck Then 'Check if the ball is stuck to the pad
                        score += 20         'Add 20 points to score
                    End If
                    ball(xx).Left = PlayField.Left + 1
                    x(xx) = x(xx) * -1
                End If
                If ball(xx).Right > PlayField.Right Then
                    'If the ball's right is below 0
                    If xx <> ballstuck Then 'Check if the ball is stuck to the pad
                        score += 20         'Add 20 points to score
                    End If
                    ball(xx).Left = PlayField.Right - ball(xx).Width - 1
                    x(xx) = x(xx) * -1
                End If
                If ball(xx).Top >= PlayField.Bottom Then
                    'If the ball hit the bottom
                    ballz -= 1  'Decrease the balls count
                    If ballz = 0 Then   'If there are no more balls in play then
                    If life = 1 Then    'If there is only one life left then...
                        life -= 1
                        Me.Text = "Game Over"   'Set the forms caption to read 'Game Over'
                        cmdReset.Visible = True         'Make the reset buttone visible
                        resetpad()                      'Resets the pad to the normal size and disables sticky pad
                        saveHighScore()
                    Else
                        cannonshot.Visible = False
                        lblLives.Text = "Lives: " & life
                        cmdTryAgain.Visible = True
                        ballInteract.Enabled = False
                        timerStart.Enabled = False
                        If CannonActivate = 1 Then      'If the cannon power up is active
                            picCannon.Visible = False   'Hide the cannon
                            CannonActivate = 0          'Disable the cannon powerup
                        End If
                        ball(xx).Visible = False
                        fireBall = 0
                        life -= 1
                    End If
                    Else    'If there are still more balls in play then
                        x(xx) = 0                   'Stop ball's movement
                        y(xx) = 0
                        ball(xx).Visible() = False  'Make ball invisible
                        ball(xx).Top = -50          'Move ball out of the form
                        ball(xx).Left = -50

                        If xx = primeBall Then      'If the ball removed was the primary ball
                            Try
                                Do While ball(copy).Visible = False
                                    'Make another ball that is still in play the primary ball
                                    copy += 1
                                    primeBall = copy
                                Loop
                            Catch
                                primeBall = 0
                            End Try
                        End If
                    End If
                End If

                If shield.Visible = True And ball(xx).Bottom > shield.Top Then
                    shieldThickness -= 1
                    shieldhit()
                    y(xx) = y(xx) * -1  'Reverse ball's y movement
                End If

                blockbreak(xx) = 1

                ballpos = ball(xx).Left + ball(xx).Width / 2 'Gets the x cordinate of the ball

                If ball(xx).Top + ball(xx).Height >= Pad.Top And ball(xx).Top < Pad.Bottom - 7 And ball(xx).Left + ball(xx).Width >= Pad.Left And ball(xx).Left <= Pad.Left + Pad.Width Then
                    'If ball(xx)(xx) hits front of pad

                If Math.Abs(x(xx)) + Math.Abs(y(xx)) > maxSpeed Then        'If the ball's speed is too great then...
                    If Math.Abs(x(xx)) > maxSpeed / 2 Then        'Checks the x axis speed
                        x(xx) = x(xx) / 2            'And modifies it to a slower speed
                    ElseIf Math.Abs(y(xx)) > maxSpeed > maxSpeed / 2 Then    'Checks the y axis speed
                        y(xx) = y(xx) / 2            'And modifies it to a slower speed
                    End If
                End If

                    ballSpeed = Math.Abs(x(xx)) + Math.Abs(y(xx))

                    If ballStickCount = 0 And stickyPadEnabled = 1 Then 'if no balls are stuck to the pad and stickypad power up is enabled then...

                        ballStickCount = 1 'Records that 1 ball is stuck to the pad
                        ballstuck = xx     'records which ball is stuck
                        ballstuckposition = ball(ballstuck).Left - Pad.Left 'records where the ball was stuck at

                        ballstick()

                    End If
                    score += 30

                    ballSpeed += 0.2

                    If Math.Abs(Val(x(xx))) <= 0.8 Then 'Prevents repeated ball movement patterns
                        x(xx) = 2
                    ElseIf (ball(xx).Left + ball(xx).Width / 2) < (Pad.Left + Pad.Width / 2) Then
                        'if the ball(xx)(xx) is to the left
                        'of the pads centre then
                        slope = ((ball(xx).Left + ball(xx).Width / 2) - Pad.Left) / (Pad.Width / 2) ' Collision Left half of Bar
                        If slope < 0.3 Then slope = 0.3 'If the ball lands too close to left border of the pad, use 0.2
                        y(xx) = -1 * (slope * ballSpeed)    'Get new y Speed
                        x(xx) = ballSpeed + y(xx)           'Get new x Speed
                        If x(xx) > 0 Then                   'if ball is going right
                            x(xx) = x(xx) * -1.05           'make it go left
                        End If
                    Else                    'the ball(xx)(xx) must be on the right of the pad
                        slope = (Pad.Right - (ball(xx).Left + ball(xx).Width / 2)) / (Pad.Width / 2) ' Collision Left half of Bar
                        If slope < 0.3 Then slope = 0.3 'If the ball lands too close to right border of the pad, use 0.2
                        y(xx) = -1 * (slope * ballSpeed)    'Get new y Speed
                        x(xx) = ballSpeed + y(xx)           'Get new x Speed
                        If x(xx) < 0 Then                   'if ball is going left
                            x(xx) = x(xx) * -1.05           'make it go right
                        End If
                    End If

                    ball(xx).Top = Pad.Top - ball(xx).Height - 1


                End If

                If stickyPadEnabled = 1 And ballStickCount = 1 And xx = ballstuck Then
                    'If sticky pad is enabled and a ball hits the pad
                    ballstick() 'Make the ball stuck to the pad
                End If

                If aiBotEnabled = True Then
                    ballSpeed = Math.Abs(x(xx)) + Math.Abs(y(xx))
                    If ball(xx).Top <= aiPad.Bottom And ball(xx).Bottom >= aiPad.Top And ball(xx).Right >= aiPad.Left And ball(xx).Left <= aiPad.Right Then
                        ball(xx).Top = aiPad.Bottom + 1
                    If Math.Abs(x(xx)) + Math.Abs(y(xx)) > maxSpeed Then        'If the ball's speed is too great then...
                        If x(xx) > maxSpeed / 2 Then        'Checks the x axis speed
                            x(xx) = maxSpeed / 2            'And modifies it to a slower speed
                        ElseIf y(xx) > maxSpeed / 2 Then    'Checks the y axis speed
                            y(xx) = maxSpeed / 2            'And modifies it to a slower speed
                        End If
                    End If
                        If (ball(xx).Left + ball(xx).Width / 2) < (aiPad.Left + aiPad.Width / 2) Then
                            'if the ball(xx)(xx) is to the left
                            'of the pads centre then
                            slope = ((ball(xx).Left + ball(xx).Width / 2) - aiPad.Left) / (aiPad.Width / 2) ' Collision Left half of Bar
                            If slope < 0.3 Then slope = 0.3 'If the ball lands too close to left border of the pad, use 0.2
                            y(xx) = (slope * ballSpeed)    'Get new y Speed
                            x(xx) = ballSpeed + y(xx)           'Get new x Speed
                            If x(xx) > 0 Then                   'if ball is going right
                                x(xx) = x(xx) * -1.05           'make it go left
                            End If
                        Else                    'the ball(xx)(xx) must be on the right of the pad
                            slope = (aiPad.Right - (ball(xx).Left + ball(xx).Width / 2)) / (aiPad.Width / 2) ' Collision Left half of Bar
                            If slope < 0.3 Then slope = 0.3 'If the ball lands too close to right border of the pad, use 0.2
                            y(xx) = (slope * ballSpeed)    'Get new y Speed
                            x(xx) = ballSpeed + y(xx)           'Get new x Speed
                            If x(xx) < 0 Then                   'if ball is going left
                                x(xx) = x(xx) * -1.05           'make it go right
                            End If
                        End If
                    End If
                    Call aiMove()
                End If

                For b = 0 To (winnumreq - 1)
                    If Not ((ball(xx).Left + x(xx) > block(b).Right) Or _
                        (ball(xx).Top + y(xx) > block(b).Bottom) Or _
                        (ball(xx).Bottom + y(xx) < block(b).Top) Or _
                        (ball(xx).Right + x(xx) < block(b).Left)) Then
                        'Detect if the ball will go inside/hit a block
                        If ball(xx).Left >= block(b).Right Then

                            ball(xx).Left = block(b).Right + 1
                            hitsideL = block(b).Right

                        ElseIf ball(xx).Right <= block(b).Left Then

                            ball(xx).Left = block(b).Left - ball(xx).Width - 1
                            hitsideR = block(b).Left - ball(xx).Width

                        ElseIf ball(xx).Top >= block(b).Bottom Then

                            ball(xx).Top = block(b).Bottom
                            hitBottom = block(b).Bottom

                        ElseIf ball(xx).Bottom <= block(b).Top Then

                            ball(xx).Top = block(b).Top - ball(xx).Height
                            hitTop = block(b).Top

                        End If
                    End If
                    If ((hitsideR = block(b).Left - ball(xx).Width And hitsideL = block(b).Right) Or _
                    (ball(xx).Left <= block(b).Right And ball(xx).Right >= block(b).Left) And _
                    ball(xx).Bottom >= block(b).Top And ball(xx).Top <= block(b).Bottom) Or _
                    (cannonshot.Right > block(b).Left And cannonshot.Left < block(b).Right And _
                     cannonshot.Top <= block(b).Bottom) Then
                        'If the ball/cannonshot hits a block then...

                        If (cannonshot.Right > block(b).Left And cannonshot.Left < block(b).Right And _
                        cannonshot.Top <= block(b).Bottom) Then
                            shotnum = 0
                            cannonshot.Visible = False
                        End If

                        Dim it As Integer ' Function of block and destroyed block count

                        For it = 0 To numNorm                                 'Function of normal block
                            If aiBotEnabled = False Then
                                blocksDestroyed += blocknorm(block(it))
                            End If
                        Next

                        For it = (numNorm + 1) To (numS + numNorm)                'Function of multiball block
                            blocksDestroyed += blockS(block(it))
                        Next

                        For it = (numNorm + numS + 1) To (numNorm + numS + numExpand)  'Function of expand pad block
                            blocksDestroyed += blockExpand(block(it))
                        Next

                        For it = (numNorm + numS + numExpand + 1) To (numNorm + numS + numExpand + numShrink)   'Function of shorten block
                            blocksDestroyed += blockShrink(block(it))
                        Next

                        For it = (numNorm + numS + numExpand + 1 + numShrink) To (numNorm + numS + numExpand + numShrink + numC)    'Function of cannon block
                            blocksDestroyed += blockC(block(it))
                        Next

                        For it = (numNorm + numS + numExpand + 1 + numShrink + numC) To (numNorm + numS + numExpand + numShrink + numC + numFast) 'Function of fastball block
                            blocksDestroyed += BlockFast(block(it))
                        Next

                        For it = (numNorm + numS + numExpand + 1 + numShrink + numC + numFast) To (numNorm + numS + numExpand + numShrink + numC + numFast + numSlow) 'Function of slow ball block
                            blocksDestroyed += BlockSlow(block(it))
                        Next

                        For it = (numNorm + numS + numExpand + 1 + numShrink + numC + numFast + numSlow) To (numNorm + numS + numExpand + numShrink + numC + numFast + numSlow + numFire) 'Function of fireball block
                            blocksDestroyed += blockFire(block(it))
                        Next

                        For it = (numNorm + numS + numExpand + 1 + numShrink + numC + numFast + numSlow + numFire) To (numNorm + numS + numExpand + numShrink + numC + numFast + numSlow + numFire + numL) 'Function of life block
                            blocksDestroyed += blockL(block(it))
                        Next

                        For it = (numNorm + numS + numExpand + 1 + numShrink + numC + numFast + numSlow + numFire + numL) To (numNorm + numS + numExpand + numShrink + numC + numFast + numSlow + numFire + numL + numSticky) 'Function of sticky pad block
                            blocksDestroyed += blockSticky(block(it))
                        Next

                        For it = (numNorm + numS + numExpand + 1 + numShrink + numC + numFast + numSlow + numFire + numL + numSticky) To (numNorm + numS + numExpand + numShrink + numC + numFast + numSlow + numFire + numL + numSticky + numShield) 'Function of metal block
                            blocksDestroyed += blockShield(block(it))
                        Next

                        For it = (numNorm + numS + numExpand + 1 + numShrink + numC + numFast + numSlow + numFire + numL + numSticky + numShield) To (numShield + numNorm + numS + numExpand + numShrink + numC + numFast + numSlow + numFire + numL + numSticky + numM) 'Function of metal block
                            blocksDestroyed += blockm(block(it))
                        Next
                    End If
                Next
        Next
    End Sub
    Private Sub aiMove()
        For xx = 0 To numOfBalls
            If ball(xx).Top < Me.Height / 2 Then
                If ball(xx).Left > aiPad.Right Then
                    aiPad.Left += 15
                ElseIf ball(xx).Right < aiPad.Left Then
                    aiPad.Left -= 15
                End If
            Else
                If aiPad.Left < 280 Then
                    aiPad.Left += 10
                ElseIf aiPad.Right > 350 Then
                    aiPad.Left -= 10
                End If
            End If
        Next
    End Sub
    Private Sub ballstick()
        'Force ball to stick to pad
        ball(ballstuck).Left = Pad.Left + ballstuckposition
        ball(ballstuck).Top = Pad.Top - ball(ballstuck).Height - 1
    End Sub

    Public Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadmenu()              'Load game menu
        LoadConfigurations()    'Load game configurations
        If locked = True Then
            menuDifficulty.Enabled = False
        End If
		me.text = "Breakout"
    End Sub
    Public Sub Createball()
        'Creates a ball
        ball(0) = New PictureBox
        ball(0).Image = My.Resources.ball
        ball(0).SizeMode = PictureBoxSizeMode.Zoom
        ball(0).BackColor = Color.Transparent
        ball(0).Location = New System.Drawing.Point(312, Pad.Top - 22)
        ball(0).Name = "ball(0)"
        ball(0).Size = New System.Drawing.Size(15, 15)
        ball(0).Enabled = False
        Me.Controls.Add(ball(0))
    End Sub
    Private Sub PaintBlocks()
        Dim X As Integer ' Paints all the block on a level

        For X = 0 To numNorm     'Draw normal block
            With block(X)
                .Size = New System.Drawing.Size(70, 15)
                If .FlatStyle = FlatStyle.Standard Then
                    .FlatStyle = FlatStyle.Flat
                Else
                    .FlatStyle = FlatStyle.Standard
                    .Enabled = False
                End If
                .FlatAppearance.BorderSize = 0
                .Image = My.Resources.BlockNorm
                Me.Controls.Add(block(X))
            End With
        Next
        For X = (numNorm + 1) To (numNorm + numS + numExpand + numShrink + numC + numFast + numSlow + numFire + numL + numSticky + numM + numShield)
            'Draw special blocks
            With block(X)
                .Size = New System.Drawing.Size(70, 15)
                .Visible = True
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderSize = 0
                .Image = My.Resources.BlockS
                Me.Controls.Add(block(X))
            End With
        Next
        For X = (numNorm + numS + numExpand + 1 + numShrink + numC + numFast + numSlow + numFire + numL + numSticky + numShield) To (numNorm + numS + numExpand + numShrink + numC + numFast + numSlow + numFire + numL + numSticky + numM + numShield)
            'Draw metal block
            With block(X)
                .Size = New System.Drawing.Size(70, 15)
                .Visible = True
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderSize = 0
                .Image = My.Resources.metalBlock
                Me.Controls.Add(block(X))
            End With
        Next
    End Sub
    Private Sub blockDes()
        'All block destoryed

        If powerups = 0 Then    'Check if any power ups are still dropping
            x(0) = 0    'Sets x speed of the primary ball as 0 and stops ball
            y(0) = 0    'Sets y speed of the primary ball as 0 and stops ball
            lvlclear()
            For xx = 1 To numOfBalls    'Stops all other balls
                x(xx) = 0
                y(xx) = 0
            Next
            If CannonActivate = 1 Then  'CHeck if cannon powerup is enabled
                'Disable cannon powerup
                CannonActivate = 0
                picCannon.Visible = False   'Make cannon invisible
                cannonshot.Left = -20       'Move cannon out of the form
            End If
            cmdNext.Visible = True  'Make the "next level" button visible
            startnum = 0    'Glues ball onto the pad

            timerStart.Enabled = True   'Start start timer
        End If

    End Sub
    Public Sub resetAll()
        'Resets values for most of the active variables
        Dim x As Integer
        blocksDestroyed = 0
        numOfBalls = 0
        numOfBalls = 0
        For x = 0 To 9
            powerup(x) = 0
        Next
        If CannonActivate = 1 Then
            CannonActivate = 0
            picCannon.Visible = False
        End If
        fireBall = 0
        numNorm = 0
        numS = 0
        numSlow = 0
        numFast = 0
        numFire = 0
        numL = 0
        numSticky = 0
        numM = 0
        numExpand = 0
        numShrink = 0
        numC = 0
        numShield = 0
        shieldThickness = 0
        shield.Visible = False
    End Sub
    Private Sub resetpad() '
        ' Resets pad
        stickyPadEnabled = 0    'Disable stick pad power up
        Pad.Image = My.Resources.Pad  'Resets image of the pad
        Pad.Size = New System.Drawing.Size(60, 20)  'Resets size of the pad
    End Sub
    Public Sub lvl()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''LEVELS''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'generates breakout levels based on the value of variable "level"
        Dim z As Integer
        Select Case level

            Case 1
                Me.BackgroundImage = My.Resources.blueBG
                winnumreq = 14
                numNorm = 13
                z = 0
                For xx = 0 To numNorm
                    he = 100

                    If xx > 6 Then
                        he = 130
                        z = 7
                    End If
                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + 60 + (xx - z) * 70, he + PlayField.Top)
                Next

            Case 2
                winnumreq = 22 'states how many block must b destroyed before the next stage button pops up
                z = 0
                numNorm = 20
                numS = 1

                For xx = 0 To numNorm
                    he = 100

                    If xx > 6 Then
                        he = 130
                        z = 7
                    End If
                    If xx > 13 Then
                        he = 160
                        z = 14
                    End If
                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + 60 + (xx - z) * 70, he + PlayField.Top)
                Next

                For s = numNorm + 1 To numS + numNorm
                    block(s) = New Button()
                    block(s).Location = New System.Drawing.Point(PlayField.Left + 300, 10 + PlayField.Top)
                Next

            Case 3
                Dim he2 As Integer
                winnumreq = 27 'states how many block must b destroyed before the next stage button pops up
                numNorm = 21
                he = 15
                numFast = 4
                numFire = 1
                For xx = 0 To numNorm

                    he2 = xx \ 2 + 1
                    block(xx) = New Button()
                    If xx Mod 2 = 0 Then
                        block(xx).Location = New System.Drawing.Point(PlayField.Left + 50, 20 + he * he2 + PlayField.Top)
                    Else
                        block(xx).Location = New System.Drawing.Point(PlayField.Left + PlayField.Width - 70 - 50, 20 + he * he2 + PlayField.Top)
                    End If
                Next

                For s = numNorm + 1 To numFast + numNorm
                    he = 70
                    z = s
                    If s > 23 Then
                        he = 140
                        z -= 2
                    End If
                    block(s) = New Button()
                    block(s).Location = New System.Drawing.Point(PlayField.Left + PlayField.Width / 2 - 140 + 70 * (z - 21), he + PlayField.Top)
                Next
                For s = numNorm + numFast + 1 To numFast + numNorm + numFire
                    block(s) = New Button()
                    block(s).Location = New System.Drawing.Point(PlayField.Left + PlayField.Width / 2 - 35, 100 + PlayField.Top)
                Next

            Case 4
                Dim he2, he3 As Integer
                winnumreq = 24 'states how many block must b destroyed before the next stage button pops up
                numShrink = 23
                he = 15
                For xx = 0 To numShrink
                    he3 = xx
                    If xx > 7 Then
                        he3 = xx - 8
                    End If
                    If xx > 15 Then
                        he3 = xx - 16
                    End If

                    he2 = xx \ 2 + 1
                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + 50 + he3 * 70, 20 + he * he2 + PlayField.Top)
                Next

            Case 5
                Dim he2, he3 As Integer
                winnumreq = 24 'states how many block must b destroyed before the next stage button pops up
                numNorm = 23
                he = 15
                For xx = 0 To numNorm
                    he3 = xx
                    If xx > 7 Then
                        he3 = xx - 8
                    End If
                    If xx > 15 Then
                        he3 = xx - 16
                    End If

                    he2 = xx \ 2 + 1
                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + 50 + he3 * 70, 20 + he * he2 + PlayField.Top)
                    block(xx).Enabled = False
                Next
            Case 6
                Dim he2, he3 As Integer
                winnumreq = 38 'states how many block must b destroyed before the next stage button pops up
                numNorm = 33
                numSticky = 2
                he = 15
                numExpand = 1
                numL = 1
                For xx = 0 To 4
                    he3 = xx
                    he2 = xx

                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + he3 * 70, 20 + he2 * 15 + PlayField.Top + 150)
                    block(xx).Enabled = False
                    block(xx).Enabled = False
                Next

                For xx = 5 To 8
                    he3 = xx
                    he2 = xx

                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + he3 * 70, 20 + 4 * 15 - 15 * (he2 - 4) + PlayField.Top + 150)
                    block(xx).Enabled = False
                Next

                he = 15
                For xx = 9 To 13
                    he3 = xx
                    he2 = xx

                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + (he3 - 9) * 70, 20 + (he2 - 10) * 15 + PlayField.Top + 120)
                    block(xx).Enabled = False
                Next

                For xx = 14 To 17
                    he3 = xx
                    he2 = xx

                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + (he3 - 9) * 70, 20 + 4 * 15 - 15 * (he2 - 12) + PlayField.Top + 120)
                    block(xx).Enabled = False
                Next

                z = 18
                For xx = 18 To numNorm
                    he = 25

                    If xx > 25 Then
                        he = 100
                        z = 26
                    End If
                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + 40 + (xx - z) * 70, he + PlayField.Top)
                    block(xx).Enabled = False
                Next

                For xx = numNorm + 1 To numNorm + numExpand

                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + PlayField.Width / 2 - 35, PlayField.Top + 120)


                Next

                For xx = numNorm + 1 + numExpand To numNorm + numL + numExpand

                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + PlayField.Width / 2 - 35, PlayField.Top + 50)


                Next


                For xx = numNorm + 1 + numL + numExpand To numNorm + numSticky + numL + numExpand

                    If xx = 37 Then
                        he2 = 524
                    End If

                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + he2, PlayField.Top + 220)


                Next
            Case 7
                Dim he2, he3 As Integer
                winnumreq = 24 'states how many block must b destroyed before the next stage button pops up
                numM = 23
                he = 15
                For xx = 0 To numM
                    he3 = xx
                    If xx > 7 Then
                        he3 = xx - 8
                    End If
                    If xx > 15 Then
                        he3 = xx - 16
                    End If

                    he2 = xx \ 2 + 1
                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + 50 + he3 * 70, 20 + he * he2 + PlayField.Top)
                Next
                block(0) = New Button()
                block(0).Location = New System.Drawing.Point(PlayField.Left + 50, 20 + PlayField.Top)
                block(0).FlatStyle = FlatStyle.System
            Case 8
                Dim x, y As Integer
                winnumreq = 38
                numNorm = 35
                numC = 2
                For xx = 0 To numNorm
                    x = (xx \ 9 + 1) * 40
                    y = xx
                    If xx > 8 Then
                        y = xx - 9
                    End If
                    If xx > 17 Then
                        y = xx - 18
                    End If
                    If xx > 26 Then
                        y = xx - 27
                    End If
                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + y * 70, x + PlayField.Top)
                    block(xx).Enabled = False
                Next
                For xx = numNorm + 1 To numNorm + numC
                    If xx = 37 Then
                        y = 7
                    Else
                        y = 1
                    End If
                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + y * 70, 200 + PlayField.Top)
                Next
            Case 9
                Dim x, y As Integer
                winnumreq = 61
                numNorm = 53
                numL = 1
                numShield = 4
                numSlow = 2
                For xx = 0 To numNorm
                    x = (xx \ 9 + 1) * 15
                    y = xx
                    If xx > 8 Then
                        y = xx - 9
                    End If
                    If xx > 17 Then
                        y = xx - 18
                    End If
                    If xx > 26 Then
                        y = xx - 27
                    End If
                    If xx > 35 Then
                        y = xx - 36
                    End If
                    If xx > 44 Then
                        y = xx - 45
                    End If
                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + y * 70, x + PlayField.Top)
                    block(xx).Enabled = False
                    block(xx).FlatStyle = FlatStyle.System
                Next
                block(56) = New Button()
                block(56).Location = New System.Drawing.Point(PlayField.Left + PlayField.Width / 2 - 45, 150 + PlayField.Top)
                For xx = 57 To 60
                    block(xx) = New Button()
                    block(xx).Location = New System.Drawing.Point(PlayField.Left + (xx - 57) * 70 + PlayField.Width / 2 - 140, 170 + PlayField.Top)
                Next

                block(54) = New Button()
                block(54).Location = New System.Drawing.Point(PlayField.Left + PlayField.Width / 2 - 210, 170 + PlayField.Top)
                block(55) = New Button()
                block(55).Location = New System.Drawing.Point(PlayField.Left + PlayField.Width / 2 + 140, 170 + PlayField.Top)
            Case 10
                aiBot()
        End Select
        PaintBlocks()   'Draw blocks and fill in other missing controls
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''END LEVELS''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub
    Private Sub aibot()
        aiPad = New System.Windows.Forms.PictureBox
        aiPad.Image = My.Resources.Pad2  'Resets image of the pad
        aiPad.Size = New System.Drawing.Size(60, 20)  'Resets size of the pad
        aiPad.Location = New System.Drawing.Point(Me.Width / 2 - 30, MenuStrip1.Top + 40)
        aiPad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        aiPad.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(aiPad)    'Display new pad
        aiBotEnabled = True
    End Sub
    Private Sub multiball()
        'Creates another ball

        ball(numOfBalls + 1) = New PictureBox
        ball(numOfBalls + 1).Image = My.Resources.ball
        ball(numOfBalls + 1).SizeMode = PictureBoxSizeMode.Zoom
        ball(numOfBalls + 1).BackColor = Color.Transparent
        ball(numOfBalls + 1).Location = New System.Drawing.Point(ball(primeBall).Location.X, ball(primeBall).Location.Y)
        ball(numOfBalls + 1).Size = New System.Drawing.Size(15, 15)
        ball(numOfBalls + 1).Enabled = False

        'assigns speed of multiballs
        x(numOfBalls + 1) = ballStartSpeed / 2
        y(numOfBalls + 1) = ballStartSpeed / 2

        ball(numOfBalls + 1).Visible = True
        Me.Controls.Add(ball(numOfBalls + 1))  'Displays new ball
        numOfBalls += 1
        If fireBall <> 0 Then   ' If the power up "Fire ball" is already put into effect then...
            For xx = 0 To numOfBalls
                ball(xx).Image = My.Resources.FireBall 'Changes the image of the new ball
            Next
        End If
        ballz += 1  'Adds 1 to the number of balls in play

    End Sub
    Private Sub timerFPS_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerFPS.Tick
        lblFPS.Text = fps & " " & slope
        fps = 0
        lblBallProperties.Text = Math.Round(x(primeBall), 2) & ", " & Math.Round(y(primeBall), 2) & ", " & Math.Round(y(primeBall) / x(primeBall), 1) & ", " & Math.Abs(y(primeBall)) + Math.Abs(x(primeBall))
        lblBlocksDestoryed.Text = blocksDestroyed
    End Sub
    Public Sub paused()
        If pause = 0 Then                   'Check if its already paused
            ballInteract.Enabled = False    'If not then disable the main timer
            menuPause.Text = "Resume"       'Change text of the pause item to resume
            pause = 1                       'Confirms that it is paused
            cmdResume.Visible = True        'Make the resume button visible
        Else
            'If its already paused then
            menuPause.Text = "Pause"        'change text of menu item to resume
            pause = 0                       'Confirms that it is not paused
            ballInteract.Enabled = True     'Starts main timer
            cmdResume.Visible = False       'Removes the resume button
        End If
    End Sub
    Function blocknorm(ByVal b As Object) As Object 'Normal block
        For xx = 0 To numOfBalls 'For multiple balls
            If ((hitsideR = b.Left - ball(xx).Width And hitsideL = b.Right) Or _
            (ball(xx).Left <= b.Right And ball(xx).Right >= b.Left) And _
            ball(xx).Bottom >= b.Top And ball(xx).Top <= b.Bottom And blockbreak(xx) <> 0) Or _
            (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
             cannonshot.Top <= b.Bottom) Then
                'If the ball/laser hits the block
                blockbreak(xx) = 0
                If Not (fireBall = 1 Or (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
                cannonshot.Top <= b.Bottom)) Then
                    'Check whether the ball hit the block or the laser
                    If (hitsideR = b.Left - ball(xx).Width) Or (b.right = hitsideL) Then
                        'Check which side the ball hit the block
                        x(xx) *= -1             'Reverse ball's x movement
                    Else
                        y(xx) = y(xx) * -1      'Reverse ball's y movement
                    End If
                    hitsideL = 0                'Resets the ball collision detection
                    hitsideR = 0
                    If b.flatstyle = FlatStyle.Standard Then
                        b.flatstyle = FlatStyle.Flat       'Make block flat
                        score += 200            'Add 200 points
                    ElseIf b.enabled = False Then   'Check if the block is enabled or not
                        b.enabled = True        'If not, make it enabled
                        score += 100            'Add 100 points
                    Else
                        b.top = -200            'If block enabled, destroy the block
                        score += 100            'Add 100 points

                        Return 1                'Return value that 1 block has been destroyed
                    End If
                Else
                    'If the block was destroyed by a laser
                    score += 100                'Add 100 points
                    b.top = -200                'Destory the block

                    hitsideL = 0                'Resets the ball collision detection
                    hitsideR = 0

                    Return 1                    'Return value that 1 block has been destroyed
                End If
            End If
        Next
        Return 0
    End Function
    Function blockS(ByVal b As Object) As Object 'block containing multiball power up
        For xx = 0 To numOfBalls
            If ((hitsideR = b.Left - ball(xx).Width And hitsideL = b.Right) Or _
            (ball(xx).Left <= b.Right And ball(xx).Right >= b.Left) And _
            ball(xx).Bottom >= b.Top And ball(xx).Top <= b.Bottom And blockbreak(xx) <> 0) Or _
            (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
             cannonshot.Top <= b.Bottom) Then
                'If the ball/laser hits the block
                blockbreak(xx) = 0
                score += 100                'Add 100 points

                If Not (fireBall = 1 Or (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
                cannonshot.Top <= b.Bottom)) Then
                    If (hitsideR = b.Left - ball(xx).Width) Or (b.right = hitsideL) Then
                        'Check which side the ball hit the block
                        x(xx) = x(xx) * -1  'Reverse ball's x movement
                    Else
                        y(xx) = y(xx) * -1  'Reverse ball's y movement
                    End If
                End If

                createPowerup(b, 0)         'Creates a specific powerup

                hitsideL = 0                'Resets the ball collision detection
                hitsideR = 0

                b.top = -200                'Destroys the block

                Return 1                    'Return value that 1 block has been destroyed

            End If
        Next
        Return 0
    End Function
    Function blockExpand(ByVal b As Object) As Object 'block containing pad up power up
        For xx = 0 To numOfBalls
            If ((hitsideR = b.Left - ball(xx).Width And hitsideL = b.Right) Or _
            (ball(xx).Left <= b.Right And ball(xx).Right >= b.Left) And _
            ball(xx).Bottom >= b.Top And ball(xx).Top <= b.Bottom And blockbreak(xx) <> 0) Or _
            (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
             cannonshot.Top <= b.Bottom) Then

                blockbreak(xx) = 0
                score += 100

                If Not (fireBall = 1 Or (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
                cannonshot.Top <= b.Bottom)) Then
                    If (hitsideR = b.Left - ball(xx).Width) Or (b.right = hitsideL) Then
                        x(xx) = x(xx) * -1
                    Else
                        y(xx) = y(xx) * -1
                    End If
                End If

                createPowerup(b, 1)

                hitsideL = 0
                hitsideR = 0

                b.top = -200

                Return 1
            End If
        Next
        Return 0
    End Function
    Function blockShrink(ByVal b As Object) As Object 'block containing shortened pad power up
        For xx = 0 To numOfBalls
            If ((hitsideR = b.Left - ball(xx).Width And hitsideL = b.Right) Or _
            (ball(xx).Left <= b.Right And ball(xx).Right >= b.Left) And _
            ball(xx).Bottom >= b.Top And ball(xx).Top <= b.Bottom And blockbreak(xx) <> 0) Or _
            (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
             cannonshot.Top <= b.Bottom) Then

                blockbreak(xx) = 0
                score += 100

                If Not (fireBall = 1 Or (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
                cannonshot.Top <= b.Bottom)) Then
                    If (hitsideR = b.Left - ball(xx).Width) Or (b.right = hitsideL) Then
                        x(xx) = x(xx) * -1
                    Else
                        y(xx) = y(xx) * -1
                    End If
                End If

                createPowerup(b, 2)

                hitsideL = 0
                hitsideR = 0

                b.top = -200

                Return 1
            End If
        Next
        Return 0
    End Function
    Function blockm(ByVal b As Object) As Object 'metal block (undestructable under normal circumstances)
        For xx = 0 To numOfBalls
            If ((hitsideR = b.Left - ball(xx).Width And hitsideL = b.Right) Or _
            (ball(xx).Left <= b.Right And ball(xx).Right >= b.Left) And _
            ball(xx).Bottom >= b.Top And ball(xx).Top <= b.Bottom And blockbreak(xx) <> 0) Or _
            (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
             cannonshot.Top <= b.Bottom) Then

                blockbreak(xx) = 0

                If (hitsideR = b.Left - ball(xx).Width) Or (b.right = hitsideL) Then
                    x(xx) = x(xx) * -1
                Else
                    y(xx) = y(xx) * -1
                End If

                If Not (fireBall = 1 Or (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
                cannonshot.Top <= b.Bottom)) Then
                    score += 100
                Else
                    b.top = -200
                    score += 500
                End If
                If hitBottom = b.Bottom Then
                    ball(xx).Top = b.Bottom + 1

                ElseIf hitTop = b.Top Then
                    ball(xx).Top = b.Top - ball(xx).Height - 1
                ElseIf hitsideR = b.Left - ball(xx).Width Then
                    ball(xx).Left = b.Left - ball(xx).Width - 1
                ElseIf hitsideL = b.right Then
                    ball(xx).Left = b.right + 1
                End If

                hitBottom = 0
                hitTop = 0
                hitsideL = 0
                hitsideR = 0

            ElseIf cannonshot.Right > b.left And cannonshot.Left < b.right And cannonshot.Top <= b.bottom Then
                score = score + 100

                shotnum = 0
                cannonshot.Visible = False

                Return 1
            End If
        Next
        Return 0
    End Function
    Function blockC(ByVal b As Object) As Object 'Block containing cannon power up
        For xx = 0 To numOfBalls
            If ((hitsideR = b.Left - ball(xx).Width And hitsideL = b.Right) Or _
            (ball(xx).Left <= b.Right And ball(xx).Right >= b.Left) And _
            ball(xx).Bottom >= b.Top And ball(xx).Top <= b.Bottom And blockbreak(xx) <> 0) Or _
            (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
             cannonshot.Top <= b.Bottom) Then
                blockbreak(xx) = 0
                score += 100

                If Not (fireBall = 1 Or (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
                cannonshot.Top <= b.Bottom)) Then
                    If (hitsideR = b.Left - ball(xx).Width) Or (b.right = hitsideL) Then
                        x(xx) = x(xx) * -1
                    Else
                        y(xx) = y(xx) * -1
                    End If
                End If

                createPowerup(b, 3)

                hitsideL = 0
                hitsideR = 0

                b.top = -200
                Return 1

            End If
        Next
        Return 0
    End Function
    Function BlockSlow(ByVal b As Object) As Object 'block containing slow-ball power up
        For xx = 0 To numOfBalls
            If ((hitsideR = b.Left - ball(xx).Width And hitsideL = b.Right) Or _
            (ball(xx).Left <= b.Right And ball(xx).Right >= b.Left) And _
            ball(xx).Bottom >= b.Top And ball(xx).Top <= b.Bottom And blockbreak(xx) <> 0) Or _
            (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
             cannonshot.Top <= b.Bottom) Then

                blockbreak(xx) = 0
                score += 100

                If Not (fireBall = 1 Or (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
                cannonshot.Top <= b.Bottom)) Then
                    If (hitsideR = b.Left - ball(xx).Width) Or (b.right = hitsideL) Then
                        x(xx) = x(xx) * -1
                    Else
                        y(xx) = y(xx) * -1
                    End If
                End If
                createPowerup(b, 4)

                b.top = -200

                hitsideL = 0
                hitsideR = 0

                Return 1

            End If
        Next
        Return 0
    End Function
    Function BlockFast(ByVal b As Object) As Object 'block containing fast-ball power up
        For xx = 0 To numOfBalls
            If ((hitsideR = b.Left - ball(xx).Width And hitsideL = b.Right) Or _
            (ball(xx).Left <= b.Right And ball(xx).Right >= b.Left) And _
            ball(xx).Bottom >= b.Top And ball(xx).Top <= b.Bottom And blockbreak(xx) <> 0) Or _
            (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
             cannonshot.Top <= b.Bottom) Then

                blockbreak(xx) = 0
                score += 100

                If Not (fireBall = 1 Or (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
                cannonshot.Top <= b.Bottom)) Then
                    If (hitsideR = b.Left - ball(xx).Width) Or (b.right = hitsideL) Then
                        x(xx) = x(xx) * -1
                    Else
                        y(xx) = y(xx) * -1
                    End If
                End If
                createPowerup(b, 5)

                b.top = -200

                hitsideL = 0
                hitsideR = 0

                Return 1

            End If
        Next
        Return 0
    End Function
    Function blockL(ByVal b As Object) As Object 'block containing life up power up
        For xx = 0 To numOfBalls
            If ((hitsideR = b.Left - ball(xx).Width And hitsideL = b.Right) Or _
            (ball(xx).Left <= b.Right And ball(xx).Right >= b.Left) And _
            ball(xx).Bottom >= b.Top And ball(xx).Top <= b.Bottom And blockbreak(xx) <> 0) Or _
            (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
             cannonshot.Top <= b.Bottom) Then

                blockbreak(xx) = 0
                score += 100

                If Not (fireBall = 1 Or (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
                cannonshot.Top <= b.Bottom)) Then
                    If (hitsideR = b.Left - ball(xx).Width) Or (b.right = hitsideL) Then
                        x(xx) = x(xx) * -1
                    Else
                        y(xx) = y(xx) * -1
                    End If
                End If
                createPowerup(b, 6)
                b.top = -200

                hitsideL = 0
                hitsideR = 0

                Return 1

            End If
        Next
        Return 0
    End Function
    Function blockFire(ByVal b As Object) As Object 'block containing fireball power up
        For xx = 0 To numOfBalls
            If ((hitsideR = b.Left - ball(xx).Width And hitsideL = b.Right) Or _
            (ball(xx).Left <= b.Right And ball(xx).Right >= b.Left) And _
            ball(xx).Bottom >= b.Top And ball(xx).Top <= b.Bottom And blockbreak(xx) <> 0) Or _
            (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
             cannonshot.Top <= b.Bottom) Then

                blockbreak(xx) = 0
                score += 100

                If Not (fireBall = 1 Or (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
                cannonshot.Top <= b.Bottom)) Then
                    If (hitsideR = b.Left - ball(xx).Width) Or (b.right = hitsideL) Then
                        x(xx) = x(xx) * -1
                    Else
                        y(xx) = y(xx) * -1
                    End If
                End If
                createPowerup(b, 7)

                b.top = -200

                hitsideL = 0
                hitsideR = 0

                Return 1
            End If
        Next
        Return 0
    End Function
    Function blockSticky(ByVal b As Object) As Object 'block containing stickypad power up
        For xx = 0 To numOfBalls
            If ((hitsideR = b.Left - ball(xx).Width And hitsideL = b.Right) Or _
            (ball(xx).Left <= b.Right And ball(xx).Right >= b.Left) And _
            ball(xx).Bottom >= b.Top And ball(xx).Top <= b.Bottom And blockbreak(xx) <> 0) Or _
            (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
             cannonshot.Top <= b.Bottom) Then

                blockbreak(xx) = 0
                score += 100

                If Not (fireBall = 1 Or (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
                cannonshot.Top <= b.Bottom)) Then
                    If (hitsideR = b.Left - ball(xx).Width) Or (b.right = hitsideL) Then
                        x(xx) = x(xx) * -1
                    Else
                        y(xx) = y(xx) * -1
                    End If
                End If
                createPowerup(b, 8)
                b.top = -200

                hitsideL = 0
                hitsideR = 0

                Return 1
            End If
        Next
        Return 0
    End Function
    Function blockShield(ByVal b As Object) As Object 'block containing stickypad power up
        For xx = 0 To numOfBalls
            If ((hitsideR = b.Left - ball(xx).Width And hitsideL = b.Right) Or _
            (ball(xx).Left <= b.Right And ball(xx).Right >= b.Left) And _
            ball(xx).Bottom >= b.Top And ball(xx).Top <= b.Bottom And blockbreak(xx) <> 0) Or _
            (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
             cannonshot.Top <= b.Bottom) Then

                blockbreak(xx) = 0
                score += 100

                If Not (fireBall = 1 Or (cannonshot.Right > b.Left And cannonshot.Left < b.Right And _
                cannonshot.Top <= b.Bottom)) Then
                    If (hitsideR = b.Left - ball(xx).Width) Or (b.right = hitsideL) Then
                        x(xx) = x(xx) * -1
                    Else
                        y(xx) = y(xx) * -1
                    End If
                End If
                createPowerup(b, 9)
                b.top = -200

                hitsideL = 0
                hitsideR = 0

                Return 1
            End If
        Next
        Return 0
    End Function
    Public Sub ChangeScrnRes(ByVal Width As Integer, ByVal Height As Integer)
        'Change display mode
        Dim DevM As New DEVMODE
        Dim i As Integer

        i = EnumDisplaySettings(0, 0, DevM)             'Retreives current monitor settings

        With DevM
            .dmFields = DM_PELSWIDTH Or DM_PELSHEIGHT
            .dmPelsWidth = Width
            .dmPelsHeight = Height
            .dmBitsPerPel = 24
        End With

        i = ChangeDisplaySettings(DevM, 0)
        i = EnumDisplaySettings(0, 0, DevM)

    End Sub
    Private Sub windowredesign()
        'Redesigns window to suit Full Screen Mode or Windowed Mode

        ball(0).Top = Pad.Top  'Temperaraly removes the ball from block collision while the level redesigns

        'Rearrange next button
        cmdNext.Top = Me.Height / 2 - cmdNext.Height / 2
        cmdNext.Left = Me.Width / 2 - cmdNext.Width / 2

        'Rearrange start button
        cmdStart.Top = Me.Height / 2 - cmdStart.Height / 2
        cmdStart.Left = Me.Width / 2 - cmdStart.Width / 2

        'Rearrange reset button
        cmdReset.Top = Me.Height / 2 - cmdReset.Height / 2
        cmdReset.Left = Me.Width / 2 - cmdReset.Width / 2

        'Rearrange try again button
        cmdTryAgain.Top = Me.Height / 2 - cmdTryAgain.Height / 2
        cmdTryAgain.Left = Me.Width / 2 - cmdTryAgain.Width / 2

        txtAnnouncement.Top = 1
        txtAnnouncement.Left = Me.Width / 2 - txtAnnouncement.Width / 2

        lblClick.Top = PlayField.Top + 80
        lblClick.Left = Me.Width / 2 - lblClick.Width / 2

        recStatus.Width = Me.Width
        recStatus.Left = 0
        If fullscreenalt = 0 Then
            recStatus.Top = 355
        Else
            recStatus.Top = Me.Height - recStatus.Height
        End If
        lblScore.Top = recStatus.Top + 3
        lblLives.Top = recStatus.Top + 3
        lblHighscore.Top = recStatus.Top + 3
        lvlclear()
        'Redraws the level
        lvl()
    End Sub
    Public Sub lvlclear()
        For xx = 0 To winnumreq - 1
            block(xx).Dispose()
        Next
        If aiBotEnabled = True Then
            aiPad.Visible = False
        End If
    End Sub
    Private Sub changedisplay()
        Me.WindowState = FormWindowState.Normal

        ' Hide border and maximize the screen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle

        ' Restore screen resolution
        Call ChangeScrnRes(ScrnRes.Width, ScrnRes.Height)
    End Sub
    Private Sub frmBreakout_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Call changedisplay()
        saveHighScore()
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        For xx = 1 To numOfBalls
            ball(xx).Enabled = False
            ball(xx).Visible = False
            x(xx) = 0
            y(xx) = 0
        Next
        resetAll()
        If stickyPadEnabled = 1 Then
            resetpad()
        End If
        numOfBalls = 0
        cmdNext.Visible = False
        cmdStart.Visible = True
        ball(0).Top = Pad.Top - 20
        ball(0).Visible = True
        ball(0).Image = My.Resources.ball
        level += 1
        lvl()
        ballz = 1

        Pad.Width = 60
    End Sub

    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        primeBall = 0
        cmdStart.Visible = False
        timerStart.Enabled = True
        startnum = 0
        powerup(0) = 0
        numOfBalls = 0
        numOfBalls = 0
        If CannonActivate = 1 Then
            CannonActivate = 0
            picCannon.Visible = False
        End If
        Randomize(randomAngle)
        lblClick.Visible = True
    End Sub
    Private Sub cmdTryAgain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTryAgain.Click
        Createball()
        ball(0).Left = 312 'reset the balls position
        ball(0).Top = Pad.Top - 20
        x(0) = 0
        y(0) = 0
        startnum = 0
        timerStart.Enabled = True
        cmdTryAgain.Visible = False

        ballz = 1
        numOfBalls = 0
        ball(0).Visible() = True
        resetpad()
    End Sub
    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click
        score = 0
        lblScore.Text = "Score: " & score   'Refresh score
        life = startLives
        lblLives.Text = "Lives: " & life    'Refresh lives
        cmdReset.Visible = False
        resetAll()
        lvlclear()
        lvl()

        Createball()
        ball(0).Left = 312 'reset the balls position
        ball(0).Top = Pad.Top - 20
        x(0) = 0
        y(0) = 0
        startnum = 0
        timerStart.Enabled = True
        ballz = 1
        numOfBalls = 0
        ball(0).Visible() = True
        resetpad()
    End Sub
    Private Sub menuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuExit.Click
        If menuFullScreenMode.Text <> "Full Screen Mode" Then
            Call changedisplay()
        End If
        Me.Dispose()
    End Sub
    Private Sub menuPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuPause.Click
        paused()
    End Sub
    Private Sub BallInteract_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ballInteract.Tick
        fps += 1    'Add 1 to fps counter

        PlayField.SendToBack()

        ballinter()

        If CannonActivate = 1 Then
            picCannon.Left = Pad.Left + Pad.Width \ 2 - picCannon.Width \ 2       'make cannon pic follow pad
            If shotnum = 1 Then
                cannonshot.Top -= 10
                If cannonshot.Top < 0 Then
                    shotnum = 0
                    cannonshot.Visible = False
                End If
            End If
        End If
        If powerups > 0 Then
            powerupInteract()
        End If

        If blocksDestroyed = winnumreq - numM Then
            blockDes()
        End If

        lblScore.Text = "Score: " & score   'show the score on label
        Me.Text = "Score: " & score        'show the score as our forms caption
        If score > highScore Then
            highScore = score
            lblHighscore.Text = "High Score: " & highScore
        End If

        lblLives.Text = "Lives: " & life

        If Pad.Left <> MousePosition.X - Me.Left - Pad.Width / 2 Then 'If the paddle is not aligned with the mouse then...
            Pad.Left = MousePosition.X - Me.Left - Pad.Width / 2
            If Pad.Left <= PlayField.Left - Pad.Width / 2 Then 'pad goes out of bounds then pad left = 0
                Pad.Left = PlayField.Left - Pad.Width / 2
            End If
            If Pad.Right >= PlayField.Right + Pad.Width / 2 Then 'same as above
                Pad.Left = PlayField.Right - Pad.Width + Pad.Width / 2
            End If
        End If
    End Sub
    Private Sub timerResume_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerPause.Tick
        If GetAsyncKeyState(System.Windows.Forms.Keys.P) < 0 and ActiveForm Is Me And picNewgame.Visible = False Then
                paused()
        End If
    End Sub

    Private Sub timerStart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerStart.Tick
        ballInteract.Enabled = False
        If GetAsyncKeyState(System.Windows.Forms.Keys.LButton) < 0 and  ActiveForm Is Me  Then
            If cmdStart.Visible = False And cmdNext.Visible = False Then
                txtAnnouncement.Text = ""
                txtAnnouncement.BackColor = Color.White
                'Random Primary Ball speed and angle
                Randomize()
                If Int(Rnd() * 1.5) = 0 Then
                    degree = -1
                Else
                    degree = 1
                End If
                Randomize()
                x(0) = (ballStartSpeed * Rnd() + 1)
                If x(0) < ballStartSpeed * 0.2 Or x(0) > ballStartSpeed * 0.8 Then
                    x(0) = ballStartSpeed / 2
                End If
                x(0) *= degree
                y(0) = -1 * (ballStartSpeed - (Math.Abs(x(0))))

                startnum = 1

                cmdReset.Visible = False
                ballInteract.Enabled = True
                timerStart.Enabled = False
                lblClick.Visible = False
            End If
        End If
        ball(0).Left = Pad.Left + Pad.Width / 2 - ball(0).Width / 2   'ball is set to the center of the pad
        ball(0).Top = Pad.Top - ball(0).Height    'ball is set right above the pad
        If Pad.Left <> MousePosition.X - Me.Left - Pad.Width / 2 Then 'If the paddle is not aligned with the mouse then...
            Pad.Left = MousePosition.X - Me.Left - Pad.Width / 2
            If Pad.Left <= PlayField.Left - Pad.Width / 2 Then 'pad goes out of bounds then pad left = 0
                Pad.Left = PlayField.Left - Pad.Width / 2
            End If
            If Pad.Right >= PlayField.Right + Pad.Width / 2 Then 'same as above
                Pad.Left = PlayField.Right - Pad.Width + Pad.Width / 2
            End If
        End If
    End Sub
    Private Sub menuFullScreenMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuFullScreenMode.Click
        If menuFullScreenMode.Text = "Full Screen Mode" Then
            If startnum <> 0 Then
                pause = 0
                paused()
                MsgBox("Please wait till after level completion to enter full screen mode")
                paused()
            Else
                Try
                    pause = 0
                    paused()
                    ' Set screen res to 800 x 600
                    Call ChangeScrnRes(800, 600)

                    ' Hide form border & maximize
                    Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                    Me.WindowState = FormWindowState.Maximized

                    PlayField.Left = (Me.Width / 2) - (PlayField.Width / 2)     'Center playfield horizontally
                    PlayField.Top = (Me.Height / 2) - (PlayField.Height / 2)    'Center playfield vertically

                    ' Set menu caption
                    menuFullScreenMode.Text = "Window Mode"
                    ' relocate block, ball and paddle
                    fullscreenalt = 1
                    windowredesign()
                    paused()
                Catch
                    Call changedisplay()
                    MsgBox("Error occured when trying to change to full screen mode")
                    menuFullScreenMode.Text = "Full Screen Mode"
                End Try
            End If

        Else '- Switch to windowed mode ...
            If startnum <> 0 Then
                MsgBox("Please wait till after level completion to enter full screen mode")
            Else

                Call changedisplay()

                ' Set menu caption ...
                menuFullScreenMode.Text = "Full Screen Mode"

                PlayField.Left = -1
                PlayField.Top = 24
                fullscreenalt = 0
                windowredesign()
            End If
        End If
        Pad.Top = PlayField.Top + 309
    End Sub

    Private Sub menuInstructions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuInstructions.Click
        frmInstructions.Show()
    End Sub

    Private Sub menuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuAbout.Click
        frmAbout.Show()
    End Sub

    Private Sub menuLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuLevel.Click
        frmLevel.Show()
    End Sub
    Private Sub NewGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuNewGame.Click
        newGame()
    End Sub
    Function createPowerup(ByVal b As Object, ByVal x As Integer)
        powerupPic(x, powerup(x)) = New PictureBox
        With powerupPic(x, powerup(x))
            powerups += 1
            Select Case x
                Case 0
                    .Image = My.Resources.ballmulti
                    .Size = New System.Drawing.Size(37, 37)
                Case 1
                    .Image = My.Resources.Wide
                    .Size = New System.Drawing.Size(40, 15)
                Case 2
                    .Image = My.Resources.Narrow
                    .Size = New System.Drawing.Size(40, 15)
                Case 3
                    .Image = My.Resources.C
                    .Size = New System.Drawing.Size(40, 20)
                Case 4
                    .Image = My.Resources.Slow
                    .Size = New System.Drawing.Size(30, 30)
                Case 5
                    .Image = My.Resources.fast
                    .Size = New System.Drawing.Size(30, 30)
                Case 6
                    .Image = My.Resources.Heart
                    .Size = New System.Drawing.Size(27, 23)
                Case 7
                    .Image = My.Resources.Fireball1
                    .Size = New System.Drawing.Size(20, 40)
                Case 8
                    .Image = My.Resources.slime
                    .Size = New System.Drawing.Size(25, 25)
                Case 9
                    .Image = My.Resources.shield
                    .Size = New System.Drawing.Size(25, 25)
            End Select
            .Location = New System.Drawing.Point(b.left + b.width / 2 - 27 / 2, b.top)
            .SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            .Visible = True
            .BackColor = Color.Transparent
            Me.Controls.Add(powerupPic(x, powerup(x)))
            powerup(x) += 1
        End With
        Return 0
    End Function

    Private Sub timerOther_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerOther.Tick
        If ActiveForm Is Me Then
            If GetAsyncKeyState(System.Windows.Forms.Keys.F) < 0 Then
                If locked = False Then
                    timerFPS.Enabled = True
                    lblFPS.Visible = True
                    lblBallProperties.Visible = True
                    lblBlocksDestoryed.Visible = True
                End If
            End If
            If GetAsyncKeyState(System.Windows.Forms.Keys.Escape) < 0 Then
                If menuFullScreenMode.Text <> "Full Screen Mode" Then
                    Call changedisplay()
                End If
                Me.Dispose()
            End If

            If GetAsyncKeyState(System.Windows.Forms.Keys.LButton) <> 0 Then
                If shotnum <> 1 And CannonActivate = 1 Then

                    cannonshot = New System.Windows.Forms.PictureBox
                    cannonshot.Image = My.Resources.cannonShots
                    cannonshot.Location = New System.Drawing.Point(picCannon.Left + picCannon.Width / 2, picCannon.Top)
                    cannonshot.Size = New System.Drawing.Size(6, 30)
                    cannonshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
                    cannonshot.Visible = True
                    cannonshot.BackColor = Color.Transparent
                    Me.Controls.Add(cannonshot)
                    shotnum = 1

                End If
                If stickyPadEnabled = 1 And ballStickCount = 1 Then
                    ballStickCount = 0
                    ball(ballstuck).Top = Pad.Top - 5 - ball(ballstuck).Height
                    ballstuck = 100
                End If
            End If
        End If
    End Sub
    Private Sub loadmenu()
        'Draws menu
        Me.BackgroundImage = My.Resources.Waves                     'Set background

        'Draws Breakout title
        picBreakout = New System.Windows.Forms.PictureBox
        picBreakout.Image = My.Resources.Breakout
        picBreakout.Location = New System.Drawing.Point(31, 40)
        picBreakout.Size = New System.Drawing.Size(567, 63)
        picBreakout.SizeMode = System.Windows.Forms.ImageLayout.Stretch
        picBreakout.BackColor = Color.Transparent
        Me.Controls.Add(picBreakout)

        'Draws New Game button
        picNewgame = New System.Windows.Forms.PictureBox
        picNewgame.Image = My.Resources.newgamePic
        picNewgame.Location = New System.Drawing.Point(230, 100)
        picNewgame.Size = New System.Drawing.Size(150, 32)
        picNewgame.SizeMode = System.Windows.Forms.ImageLayout.Zoom
        Me.Controls.Add(picNewgame)

        'Draws How to Play button
        picHowTo = New System.Windows.Forms.PictureBox
        picHowTo.Image = My.Resources.howto
        picHowTo.Location = New System.Drawing.Point(230, 140)
        picHowTo.Size = New System.Drawing.Size(150, 32)
        picHowTo.SizeMode = System.Windows.Forms.ImageLayout.Zoom
        Me.Controls.Add(picHowTo)

        'Draws Options button
        picOptions = New System.Windows.Forms.PictureBox
        picOptions.Image = My.Resources.Options
        picOptions.Location = New System.Drawing.Point(230, 180)
        picOptions.Size = New System.Drawing.Size(150, 32)
        picOptions.SizeMode = System.Windows.Forms.ImageLayout.Zoom
        Me.Controls.Add(picOptions)

        'Draws About button
        picabout = New System.Windows.Forms.PictureBox
        picabout.Image = My.Resources.About
        picabout.Location = New System.Drawing.Point(230, 220)
        picabout.Size = New System.Drawing.Size(150, 32)
        picabout.SizeMode = System.Windows.Forms.ImageLayout.Zoom
        Me.Controls.Add(picAbout)

        'Draws Exit button
        picExit = New System.Windows.Forms.PictureBox
        picExit.Image = My.Resources._Exit
        picExit.Location = New System.Drawing.Point(230, 280)
        picExit.Size = New System.Drawing.Size(150, 32)
        picExit.SizeMode = System.Windows.Forms.ImageLayout.Zoom
        Me.Controls.Add(picExit)

        'Bring all buttons and graphics in front of playfield
        PlayField.SendToBack()

        'Add handlers
        AddHandler picNewgame.MouseEnter, AddressOf picNewgame_MouseEnter   'Add mouseEnter handler
        AddHandler picNewgame.Click, AddressOf picNewgame_Click             'Add click handler
        AddHandler picNewgame.MouseLeave, AddressOf picNewgame_MouseLeave   'Add mouseLeave handler
        AddHandler picHowTo.MouseEnter, AddressOf picHowTo_MouseEnter
        AddHandler picHowTo.Click, AddressOf picHowTo_Click
        AddHandler picHowTo.MouseLeave, AddressOf picHowTo_MouseLeave
        AddHandler picOptions.MouseEnter, AddressOf picOptions_MouseEnter
        AddHandler picOptions.Click, AddressOf picOptions_Click
        AddHandler picOptions.MouseLeave, AddressOf picOptions_MouseLeave
        AddHandler picabout.MouseEnter, AddressOf picAbout_MouseEnter
        AddHandler picabout.Click, AddressOf picAbout_Click
        AddHandler picabout.MouseLeave, AddressOf picAbout_MouseLeave
        AddHandler picExit.MouseEnter, AddressOf picExit_MouseEnter
        AddHandler picExit.Click, AddressOf picExit_Click
        AddHandler picExit.MouseLeave, AddressOf picExit_MouseLeave
    End Sub
    Private Sub picNewgame_Click(ByVal sender As Object, ByVal e As EventArgs)
        newGame()
    End Sub
    Private Sub picNewgame_MouseEnter(ByVal sender As Object, ByVal e As EventArgs)
        picNewgame.Image = My.Resources.newgamePic2
    End Sub
    Private Sub picNewgame_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
        picNewgame.Image = My.Resources.newgamePic
    End Sub
    Private Sub picHowTo_Click(ByVal sender As Object, ByVal e As EventArgs)
        frmInstructions.Show()
    End Sub
    Private Sub picHowTo_MouseEnter(ByVal sender As Object, ByVal e As EventArgs)
        picHowTo.Image = My.Resources.howto2
    End Sub
    Private Sub picHowTo_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
        picHowTo.Image = My.Resources.howto
    End Sub
    Private Sub picAbout_Click(ByVal sender As Object, ByVal e As EventArgs)
        frmAbout.Show()
    End Sub
    Private Sub picAbout_MouseEnter(ByVal sender As Object, ByVal e As EventArgs)
        picabout.Image = My.Resources.About2
    End Sub
    Private Sub picAbout_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
        picabout.Image = My.Resources.About
    End Sub
    Private Sub picOptions_Click(ByVal sender As Object, ByVal e As EventArgs)
        frmOptions.Show()
    End Sub
    Private Sub picOptions_MouseEnter(ByVal sender As Object, ByVal e As EventArgs)
        picOptions.Image = My.Resources.options2
    End Sub
    Private Sub picOptions_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
        picOptions.Image = My.Resources.options
    End Sub
    Private Sub picExit_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub
    Private Sub picExit_MouseEnter(ByVal sender As Object, ByVal e As EventArgs)
        picExit.Image = My.Resources.Exit2
    End Sub
    Private Sub picExit_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
        picExit.Image = My.Resources._Exit
    End Sub
    Private Sub newGame()
        'Reset everything and loads sprite
        drawShield()            'draws shield
        SaveConfigurations()    'save config

        'Hide menu and disable certain options
        menuDifficulty.Enabled = False
        picBreakout.Visible = False
        picHowTo.Visible = False
        picNewgame.Visible = False
        picOptions.Visible = False
        picAbout.Visible = False
        picExit.Visible = False
        menuFullScreenMode.Enabled = True

        If locked = False Then  'Check if game is locked
            menuLevel.Enabled = True    'If game isn't locked enable level selector
        End If

        menuPause.Enabled = True
        menuNewGame.Enabled = False
        Me.BackgroundImage = My.Resources.blueBG
        Pad.Visible = True
        cmdStart.Visible = True

        For xx = 0 To 9
            blockbreak(xx) = 1
        Next

        Pad.Top = PlayField.Top + 309
        powerups = 0
        readHighScore()

        gameDiff()

        txtAnnouncement.Text = "Welcome!"

        life = startLives
        pause = 0
        fireBall = 0
        blocksDestroyed = 0
        level = 1
        ballstuck = 100
        lblLives.Text = ("Lives: " & life)
        lblHighscore.Text = ("High Score: " & highScore)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        timerStart.Enabled = True

        Createball()    'Creates a ball

        cannonshot = New System.Windows.Forms.PictureBox
        cannonshot.Image = My.Resources.cannonShots
        cannonshot.Location = New System.Drawing.Point(-10, -10)
        cannonshot.Name = "image"
        cannonshot.Size = New System.Drawing.Size(6, 30)
        cannonshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        cannonshot.Visible = True
        cannonshot.BackColor = Color.Transparent
        Me.Controls.Add(powerupPic(1, powerup(1)))

        Me.Controls.Add(cannonshot)

        ballz = 1
        lvl()   'Creats the level
    End Sub
    Private Sub cmdResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResume.Click
        paused()
    End Sub
    Private Sub saveHighScore()
        Try
            Dim FILENAME As String = (CurDir() & "\high scores.game")
            Try
                objFSO = CreateObject("Scripting.FileSystemObject")
                Dim file2 As Object
                file2 = objFSO.GetFile(FILENAME)
                file2.delete()
            Catch
            End Try

            ' Get a StreamReader class that can be used to read the file  
            Dim objFileStream As FileStream
            objFileStream = File.Create(FILENAME)
            fileDate = FileDateTime(FILENAME)

            Dim encoder As New System.Text.ASCIIEncoding()
            Dim Str As String
            Dim encodedHighscore As String
            Dim buffer() As Byte

            ' Write high scores to file
            Str = fileDate
            Str += vbNewLine
            encodedHighscore = highScore + 10 - (highScore * 299 + 21)  'Encodes highscore

            ReDim buffer(Str.Length - 1)
            encoder.GetBytes(Str, 0, Str.Length, buffer, 0)
            objFileStream.Write(buffer, 0, buffer.Length)

            ReDim buffer(encodedHighscore.Length - 1)
            encoder.GetBytes(encodedHighscore, 0, encodedHighscore.Length, buffer, 0)
            objFileStream.Write(buffer, 0, buffer.Length)

            ' Close the stream  
            objFileStream.Close()
        Catch
            MsgBox("Error! Unable to save preferences. Please check that save file is not read only or in use")
            Exit Sub
        End Try
    End Sub
    Private Sub readHighScore()
        Try
            Dim fileName As String = (CurDir() & "\high scores.game")

            ' Get a StreamReader class that can be used to read the file  
            Dim objStreamReader As StreamReader

            Dim currentFileDate As String = FileDateTime(fileName)

            objStreamReader = File.OpenText(fileName)   'Open file

            fileDate = objStreamReader.ReadLine()

            If fileDate = currentFileDate Then          'Checks if file has been altered or not

                'Read player names & scores from file
                highScore = objStreamReader.ReadLine()
                highScore = 30 + ((highScore + 11) / -298)

                'Close the stream  
                objStreamReader.Close()
            Else
                clearHighScore()                        'Clear file
            End If
        Catch
            highScore = 0

        End Try
    End Sub
    Public Sub clearHighScore()
        highScore = 0       'Reset highscore
        'set file Dir
        Dim FILENAME As String = (CurDir() & "\high scores.game")

        Dim objFileStream As FileStream
        objFileStream = File.Create(FILENAME)   'Create file

        Dim encoder As New System.Text.ASCIIEncoding()  'Set encoder
        Dim Str As String
        Dim buffer() As Byte

        Str = (highScore + 10 - (highScore * 298 + highScore + 21)) - 30     'Encode Highscore
        Str += vbNewLine

        'Write highscore
        ReDim buffer(Str.Length - 1)
        encoder.GetBytes(Str, 0, Str.Length, buffer, 0)
        objFileStream.Write(buffer, 0, buffer.Length)

        objFileStream.Close()
    End Sub
    Private Sub gameDiff()
        'Sets the game difficulty
        If gameDifficulty = 1 Then
            maxSpeed = 10       'Set max speed of ball
            startLives = 8      'Set starting amount of lives
            ballStartSpeed = 4  'Set starting speed of ball
        ElseIf gameDifficulty = 2 Then
            maxSpeed = 12
            startLives = 5
            ballStartSpeed = 5
        ElseIf gameDifficulty = 3 Then
            maxSpeed = 14
            startLives = 3
            ballStartSpeed = 6
        ElseIf gameDifficulty = 4 Then
            maxSpeed = 16
            startLives = 2
            ballStartSpeed = 8
        End If
    End Sub

    Private Sub menuEasy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEasy.Click
        gameDifficulty = 1
    End Sub

    Private Sub menuNormal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuNormal.Click
        gameDifficulty = 2
    End Sub

    Private Sub menuHard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuHard.Click
        gameDifficulty = 3
    End Sub

    Private Sub menuCrazy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCrazy.Click
        gameDifficulty = 4
    End Sub
    Public Sub SaveConfigurations()
        Try
            Dim FILENAME As String = (CurDir() & "\config.game")
            Try
                objFSO = CreateObject("Scripting.FileSystemObject")
                Dim file2 As Object
                file2 = objFSO.GetFile(FILENAME)
                file2.delete()
            Catch
            End Try

            Dim objFileStream As FileStream
            objFileStream = File.Create(FILENAME)
            Dim Str As String = 0
            Dim buffer() As Byte
            Dim encoder As New System.Text.ASCIIEncoding()
            fileDate = FileDateTime(FILENAME)

            Str = fileDate
            Str += vbNewLine
            ReDim buffer(Str.Length - 1)
            encoder.GetBytes(Str, 0, Str.Length, buffer, 0)
            objFileStream.Write(buffer, 0, buffer.Length)

            Select Case gameDifficulty
                Case 0
                    'If game settings is set to custom then save custom settings
                    Str = "0"
                    Str += vbNewLine
                    ReDim buffer(Str.Length - 1)
                    encoder.GetBytes(Str, 0, Str.Length, buffer, 0)
                    objFileStream.Write(buffer, 0, buffer.Length)
                    Str = maxSpeed
                    Str += vbNewLine
                    ReDim buffer(Str.Length - 1)
                    encoder.GetBytes(Str, 0, Str.Length, buffer, 0)
                    objFileStream.Write(buffer, 0, buffer.Length)
                    Str = startLives
                    Str += vbNewLine
                    ReDim buffer(Str.Length - 1)
                    encoder.GetBytes(Str, 0, Str.Length, buffer, 0)
                    objFileStream.Write(buffer, 0, buffer.Length)
                    Str = ballStartSpeed
                Case 1
                    'Game set to easy 
                    Str = "1"
                Case 2
                    'Game set to normal 
                    Str = "2"
                Case 3
                    'Game set to hard
                    Str = "3"
                Case 4
                    'Game set to Crazy
                    Str = "4"
            End Select

            Str += vbNewLine

            ' Write diff level to file
            ReDim buffer(Str.Length - 1)
            encoder.GetBytes(Str, 0, Str.Length, buffer, 0)
            objFileStream.Write(buffer, 0, buffer.Length)

            Str = locked

            ' Write diff level to file
            ReDim buffer(Str.Length - 1)
            encoder.GetBytes(Str, 0, Str.Length, buffer, 0)
            objFileStream.Write(buffer, 0, buffer.Length)

            ' Close the stream  
            objFileStream.Close()
        Catch
            MsgBox("Error! Unable to save preferences. Please check that save file is not read only or in use")
            Exit Sub
        End Try
    End Sub
    Public Sub LoadConfigurations()
        fileName = (CurDir() & "\config.game")
        Dim Str As String

        ' Get a StreamReader class that can be used to read the file  
        Dim objStreamReader As StreamReader

        Try
            ' Open file
            objStreamReader = File.OpenText(fileName)

            'Difficulty setting

            ' Read line in file
            Dim currentFileDate As String = FileDateTime(fileName)
            fileDate = objStreamReader.ReadLine()
            If fileDate = currentFileDate Then
                Str = objStreamReader.ReadLine()
                If Str = 0 Then
                    gameDifficulty = Str
                    maxSpeed = objStreamReader.ReadLine()
                    startLives = objStreamReader.ReadLine()
                    ballStartSpeed = objStreamReader.ReadLine()
                ElseIf gameDifficulty <= 4 Then
                    gameDifficulty = Str
                End If
                locked = objStreamReader.ReadLine()
                If locked = True Then
                    gameDifficulty = 2
                End If
                objStreamReader.Close()
            Else
                gameDifficulty = 2
                locked = True
            End If
        Catch
            gameDifficulty = 2
            Exit Sub
        End Try
    End Sub

    Private Sub ReturnToMenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnToMenuToolStripMenuItem.Click
        Dim sure As Integer
        pause = 0
        paused()
        sure = MsgBox("Are you sure you want to exit to menu?", MsgBoxStyle.OkCancel)
        If sure <> 1 Then
            paused()
        Else
            reloadMenu()
        End If
    End Sub
    Private Sub reloadMenu()
        Dim x, y As Integer
        For x = 0 To numOfBalls
            ball(x).Visible = False
        Next
        saveHighScore()
        level = 0
        score = 0
        life = 0
        If aiBotEnabled = True Then
            aiBotEnabled = False
            aiPad.Visible = False
        End If
        For x = 0 To 9
            For y = 0 To (powerup(x) - 1)
                powerupPic(x, y).Top = 600
            Next
        Next
        resetAll()
        lvlclear()
        If locked = False Then
            menuDifficulty.Enabled = True
        End If
        picBreakout.Visible = True
        picExit.Visible = True
        picHowTo.Visible = True
        picNewgame.Visible = True
        picOptions.Visible = True
        picAbout.Visible = True
        menuFullScreenMode.Enabled = False
        menuLevel.Enabled = False
        menuPause.Enabled = False
        menuNewGame.Enabled = True
        Me.BackgroundImage = My.Resources.Waves
        Pad.Visible = False
        cmdStart.Visible = False
        cmdNext.Visible = False
        cmdTryAgain.Visible = False
        cmdResume.Visible = False
        cmdReset.Visible = False
        timerStart.Enabled = False
        ballInteract.Enabled = False
    End Sub
End Class
