Module Module_2DPlatform
    Const card8158 As Short = 0
    Const card2005 As Short = 0

    'preTime/prePos used to calc feedback speed
    'Dim preTime As DateTime
    Dim preTime As Long = 0
    Dim prePosT As Double = 0
    Dim preCount As Long
    Dim prePos As Double = 0
    Dim CPUfreq As Long

    Dim isLinearMotion As Boolean = False
    Dim isRotMotion As Boolean = False
    Dim isDaqEnable As Boolean = False
    Dim aveNum As Integer
    Dim expInfo As String
    Dim fileName As String
    Dim xlsHeader() As String

    'unit by second
    Dim TDuration As Double = 0
    'control the decode/incode data acquire is continue or over ???
    Dim motionStatus As Boolean = False

    Dim LstrVel As Double
    Dim LmaxVel As Double
    Dim LTacc As Double
    Dim LTdec As Double
    Dim LTUnif As Double
    Dim LTdelay As Double
    Dim RstrVel As Double
    Dim RmaxVel As Double
    Dim RTacc As Double
    Dim RTdec As Double
    Dim RTUnif As Double
    Dim RDist As Double
    Dim axis As Short

    Dim motionMode As M_MODE
    'targetPos is used for velocity motion mode to stop motion at target position
    Dim targetPos As Double

    Dim MotionThread As System.Threading.Thread
    'MotionThread.IsBackground = True
    Dim motionDirect As Boolean = True  'when value is true ,motion speed is positive;else is negative

    Sub Control_2DPlatform(ByVal cfg As MSG_CFG)

        'initial preCount , CPUfreq , prePos
        'intial preCount after start 2005 card
        'QueryPerformanceCounter(preCount)
        QueryPerformanceFrequency(CPUfreq)
        B_8158_get_position(0, prePos)

        isLinearMotion = cfg.isLinearMotion
        isRotMotion = cfg.isRotMotion
        isDaqEnable = cfg.isDAQ2005

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'daq2005     
        Dim ScanIntrv As Integer = cfg.scanIntervals
        Dim ScanCount As Integer = cfg.dataSize
        Dim ADChanCount As Integer = 4
        If isDaqEnable Then

            'Always creat *.dat file
            StartDAQ(card2005, ScanIntrv, ScanCount, ADChanCount, "DAT", cfg.fileToSave)

        End If

        'intial preCount after start 2005 card
        QueryPerformanceCounter(preCount)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'pci-8158
        LstrVel = 0
        LmaxVel = cfg.L_maxSpeed
        LTacc = cfg.L_accTime
        LTdec = cfg.L_decTime
        LTUnif = cfg.L_unifTime
        LTdelay = cfg.L_delayTime
        RstrVel = 0
        RmaxVel = cfg.R_maxSpeed
        RTacc = cfg.R_accTime
        RTdec = cfg.R_decTime
        RDist = cfg.R_dist

        If isLinearMotion Then
            'Linear Motion mode
            axis = 0
        End If

        If isRotMotion Then
            'Rotation Motion mode
            axis = 1
        End If

        If isLinearMotion And isRotMotion Then
            'both axis select , mixed motion mode
            axis = 2
        End If

        motionMode = M_MODE.VELOCITY
        If LmaxVel > 0 Then
            motionDirect = True
        Else
            motionDirect = False
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'avoid invoke method
        aveNum = cfg.numOfAve
        expInfo = cfg.expConditions
        fileName = cfg.fileToSave
        xlsHeader = {"CH1", "CH2", "CH3", "CH4"}
        MotionThread = New System.Threading.Thread(AddressOf MotionStart)
        'set threading apartment state as sta mode , so can handle the xlsx file for the data to store
        MotionThread.SetApartmentState(Threading.ApartmentState.STA)
        MotionThread.Start()
    End Sub

    Private Sub MotionStart()
        motionStatus = True         'Begin to move , and bengin to acquire decode data

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'pci-8158
        'Before motion begin , it is will be keep null status for some seconds. 
        'Before motion begin , it is will be keep null status for 1 second. detail at "修改需求文档20131206.docx"
        System.Threading.Thread.Sleep(1000)
        Dim LdelayTime As Double = LTdelay * 1000
        ' VELOCITY MOTION MODE ONLY FIT AXIS
        Select Case axis
            Case 0
                Start_1Axis_tv_move(axis, LstrVel, LmaxVel, LTacc, LTUnif, LTdec)
            Case 1
                Start_1Axis_tr_move(axis, RDist, RstrVel, RmaxVel, RTacc, RTdec)
            Case 2
                'rotate first, then linear motion
                Start_1Axis_tr_move(1, RDist, RstrVel, RmaxVel, RTacc, RTdec)
                System.Threading.Thread.Sleep(LTdelay)
                Start_1Axis_tv_move(0, LstrVel, LmaxVel, LTacc, LTUnif, LTdec)
        End Select

        'waitting for axis stop motion
        'System.Threading.Thread.Sleep(1000)
        While Not isStopMotion()
            System.Threading.Thread.Sleep(50)
        End While

        motionStatus = False        'Move is over , and stop to acquire decode data

        'clear daq-2005 card async buffer
        ClearDaq2005Async(card2005)

        If isDaqEnable Then
            'SAVE DATA AND SOME INFO

            dataToXLSX(xlsHeader, InBuf, aveNum, expInfo, fileName)
        End If
    End Sub
    ''' <summary>
    ''' 暂停运动
    ''' </summary>
    Sub Stop_2DPlatform()
        If axis = 2 Then
            B_8158_stop_move_all(0)
        Else
            'single axis motion stop
            B_8158_emg_stop(axis)
        End If
        'Update Motion Status
        motionStatus = False
        'debug code
        'Timer1.Enabled = False
    End Sub
    ''' <summary>
    ''' 释放资源
    ''' </summary>
    Sub Release_2DPlatform()
        Stop_2DPlatform()

        If Not IsNothing(MotionThread) Then
            Try
                MotionThread.Abort()
            Catch ex As Exception

            End Try
        End If

        B_8158_close()
        D2K_Release_Card(card2005)
    End Sub
End Module
