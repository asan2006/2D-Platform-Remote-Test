Module Module_Pci8158TrMoveFor2Axis
    Const card8158 As Short = 0

    ' winmm.dll is better than dateTime in the donet framwork
    Private Declare Function timeGetTime Lib "winmm.dll" Alias "timeGetTime" () As Long

    ' QueryPerformance as the more accurate timer
    Declare Function QueryPerformanceCounter Lib "Kernel32" (ByRef x As Long) As Short
    Declare Function QueryPerformanceFrequency Lib "Kernel32" (ByRef x As Long) As Short


    Public Enum M_MODE
        VELOCITY
        POSITION
    End Enum
    ''' <summary>
    ''' initial 8158 card
    ''' </summary>
    Sub initial_PCI8158()
        Dim card8158 As Short = 0
        Dim result As Short = B_8158_initial(card8158, 0)
        If result <> 0 Then
            MsgBox("initial 8158 card failed")
            Exit Sub
        End If
        'set axis num 0
        B_8158_set_pls_outmode(0, 4)
        B_8158_set_move_ratio(0, 1)
        B_8158_set_servo(0, 1)
        'configure the input mode of external feedback pulse
        B_8158_set_pls_iptmode(0, 2, 0)
        'set counter input source
        B_8158_set_feedback_src(0, 0)

        'set axis num 1
        'set palse out mode
        B_8158_set_pls_outmode(1, 0)
        B_8158_set_alm(1, 1, 0)
        B_8158_set_inp(1, 0, 1)
        B_8158_set_move_ratio(1, 0)

    End Sub
    ''' <summary>
    ''' only for e-teknet 2D platform motion control
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Sub Start_2Axis_tr_move(ByVal axis As Short, ByVal dist() As Double, ByVal strVal() As Double, ByVal maxVal() As Double, ByVal Tacc() As Double, ByVal Tdec() As Double)
        'axis=0 , only axis 0 is selected;
        'axis=1 , only axis 1 is selected;
        'axis=2 , both axis selected.
        Dim axisArray(1) As Short
        axisArray(0) = 0
        axisArray(1) = 1

        'mm/s to palse
        dist(0) = dist(0) * 1000
        strVal(0) = strVal(0) * 1000
        maxVal(0) = maxVal(0) * 1000
        'deg/s to palse
        dist(1) = dist(1) * 18000 / 360
        strVal(1) = strVal(1) * 18000 / 360
        maxVal(1) = maxVal(1) * 18000 / 360

        If axis = 0 Then
            ' only linear motion
            B_8158_start_tr_move(0, dist(0), strVal(0), maxVal(0), Tacc(0), Tdec(0))
        ElseIf axis = 1 Then
            ' only rotary motion
            B_8158_start_tr_move(1, dist(1), strVal(1), maxVal(1), Tacc(1), Tdec(1))
        Else
            ' two axis motion start at the sime time
            B_8158_set_tr_move_all(2, axisArray(0), dist(0), strVal(0), maxVal(0), Tacc(0), Tdec(0))
            B_8158_start_move_all(0)
        End If

    End Sub

    Sub Start_1Axis_tv_move(ByVal axisNo As Short, ByVal strVel As Double, ByVal maxVel As Double, ByVal Tacc As Double, ByVal TUnif As Double, ByVal Tdec As Double)
        Dim slpTime As Double = Tacc * 1000 + TUnif * 1000
        Select Case axisNo
            Case 1
                'deg/s to palse
                strVel = strVel * 18000 / 360
                maxVel = maxVel * 18000 / 360
            Case Else
                'mm/s to palse
                strVel = strVel * 1000
                maxVel = maxVel * 1000
        End Select
        B_8158_tv_move(axisNo, strVel, maxVel, Tacc)
        B_8158_set_motion_int_factor(axisNo, 0)     'waitting for inturrupt
        B_8158_int_control(card8158, 0)
        'sleep unit as millisecond
        System.Threading.Thread.Sleep(slpTime)

        'stop axis with decelerate instead of immediately
        'WARNING: when Tdec is 1 seconde, the decelerate time actully is 0.5 seconde, half if the special value , 
        'I have not get this reason, if necssary ,connect supplier to get the answer .
        B_8158_sd_stop(axisNo, Tdec * 2)
    End Sub

    Sub Start_1Axis_tr_move(ByVal axisNo As Short, ByVal dist As Double, ByVal strVel As Double, ByVal maxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
        Select Case axisNo
            Case 1
                'deg/s to palse
                dist = dist * 18000 / 360
                strVel = strVel * 18000 / 360
                maxVel = maxVel * 18000 / 360
            Case Else
                'mm/s to palse
                dist = dist * 1000
                strVel = strVel * 1000
                maxVel = maxVel * 1000
        End Select

        B_8158_start_tr_move(axisNo, dist, strVel, maxVel, Tacc, Tdec)
    End Sub

    Function isStopMotion() As Boolean
        Dim bolStop As Boolean
        bolStop = True
        For i = 0 To 1
            If B_8158_motion_done(i) <> 0 Then
                bolStop = False
                Exit For
            End If
        Next
        Return bolStop
    End Function
    Function isStopAxe0() As Boolean
        'Linear aixs
        Dim bolStop As Boolean
        bolStop = True
        Dim i = 0
        If B_8158_motion_done(i) <> 0 Then
            bolStop = False
        End If
        Return bolStop
    End Function
    Function isStopAxe1() As Boolean
        'Rotation aixs
        Dim bolStop As Boolean
        bolStop = True
        Dim i = 1
        If B_8158_motion_done(i) <> 0 Then
            bolStop = False
        End If
        Return bolStop
    End Function

    Function CurLPos() As Double
        Dim pos As Double
        B_8158_get_position(0, pos)
        Return Pluse2MM(pos)
    End Function

    Function CurRPos() As Double
        Dim pos As Double
        B_8158_get_position(1, pos)
        Return Pluse2deg(pos)
    End Function

    Sub ResetLPos()
        B_8158_set_position(0, 0)
    End Sub

    Sub ResetRPos()
        B_8158_set_position(1, 0)
    End Sub

    Function CurSpeed() As Double()
        Dim speed(1) As Double
        B_8158_get_current_speed(0, speed(0))
        B_8158_get_current_speed(1, speed(1))
        speed(0) = speed(0) / 1000
        speed(1) = speed(1) / 18000 * 360
        Return speed
    End Function


    Function Pluse2MM(ByVal pluse As Double) As Double
        Dim mm As Double = pluse / 1000
        Return mm
    End Function

    Function MM2Pluse(ByVal mm As Double) As Double
        Dim pluse As Double = mm * 1000
        Return pluse
    End Function

    Function Pluse2deg(ByVal pluse As Double) As Double
        Dim deg As Double = pluse / 18000 * 360
        Return deg
    End Function
    Function FeedbackSpeed(ByRef preTime As Long, ByRef prePos As Double) As Double
        Dim nowTime As Long = timeGetTime
        Dim curPos As Double
        'get the value of the feedback position counter
        B_8158_get_position(0, curPos)
        Dim speedPluse As Double = (curPos - prePos) / (nowTime - preTime) * 1000
        Dim speedFeedback As Double = Pluse2MM(speedPluse)
        preTime = nowTime
        prePos = curPos
        Return speedFeedback
    End Function

    Function FeedbackSpeed2(ByRef preCount As Long, ByRef prePos As Long, ByVal freq As Long) As Double
        Dim nowCount As Long
        Dim curPos As Double

        QueryPerformanceCounter(nowCount)
        B_8158_get_position(0, curPos)
        Dim speedPluse As Double = (curPos - prePos) / ((nowCount - preCount) / freq)
        Dim speedFeedback As Double = Pluse2MM(speedPluse)
        preCount = nowCount
        prePos = curPos
        Return speedFeedback
    End Function

End Module
