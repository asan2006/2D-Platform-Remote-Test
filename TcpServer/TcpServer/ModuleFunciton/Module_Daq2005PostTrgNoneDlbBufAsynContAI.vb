Module Module_Daq2005PostTrgNoneDlbBufAsynContAI
    ''' <summary>
    ''' Post Trigger Mode Non-double-buffered Asynchronous Continuous Analog Input Programming
    ''' </summary>
    ''' <remarks></remarks>
    ''' 

    Public InBuf() As UShort
    ''' <summary>
    ''' initial DAQ2005 card
    ''' </summary>
    Sub initial_DAQ2005()
        'set daq 2005 card register
        Dim card2005 As Short = 0
        Dim result As Short = D2K_Register_Card(DAQ_2005, card2005)
        If result < 0 Then
            Select Case result
                Case ErrorTooManyCardRegistered
                    MsgBox("ErrorTooManyCardRegistered")
                Case ErrorUnknownCardType
                    MsgBox("ErrorUnknownCardType")
                Case ErrorOpenDriverFailed
                    MsgBox("ErrorOpenDriverFailed")
                Case ErrorOpenEventFailed
                    MsgBox("ErrorOpenEventFailed")
                Case Else
                    MsgBox("Registe failed , but unknown reasons!")
                    Exit Sub
            End Select
        End If
    End Sub

    Sub StartDAQ(ByVal cardNum As Short, ByVal ScanIntrv As Integer, ByVal ScanCount As Integer, ByVal ADChanCount As Integer, ByVal scanFileFormatMode As String, Optional ByVal filename As String = Nothing)
        Dim result As Integer
        Dim BufId As Short
        Dim ReTrgCnt As Short = 0
        Dim BufAutoReset As Byte = 1
        Dim SampleIntrv As Integer
        'SampleIntrv equal to ScanIntrv
        SampleIntrv = ScanIntrv

        Dim SizePerData As Integer = 2  'unit by byte
        ReDim InBuf(ScanCount * ADChanCount - 1)

        Dim MemSize As Integer
        result = D2K_AI_InitialMemoryAllocated(cardNum, MemSize)
        If result <> NoError Then
            Select Case result
                Case ErrorInvalidCardNumber
                    MsgBox("ErrorInvalidCardNumber")
                Case ErrorCardNotRegistered
                    MsgBox("ErrorCardNotRegistered")
                Case Else
                    MsgBox("InitialMemoryAllocated failed , but unknown reasons!")
                    Exit Sub
            End Select
        End If


        If MemSize * 1024 < ScanCount * ADChanCount * SizePerData Then
            MsgBox("available memory size for analog input in the device driver is smaller than the data size specified!!")
        End If

        result = D2K_AI_CH_Config(cardNum, All_Channels, AD_B_10_V)
        If result <> NoError Then
            Select Case result
                Case ErrorInvalidCardNumber
                    MsgBox("ErrorInvalidCardNumber")
                Case ErrorCardNotRegistered
                    MsgBox("ErrorCardNotRegistered")
                Case ErrorFuncNotSupport
                    MsgBox("ErrorFuncNotSupport")
                Case Else
                    MsgBox("AI_CH_Config failed , but unknown reasons!")
                    Exit Sub
            End Select
        End If


        result = D2K_AI_AsyncDblBufferMode(cardNum, 0)
        If result <> NoError Then
            Select Case result
                Case ErrorInvalidCardNumber
                    MsgBox("ErrorInvalidCardNumber")
                Case ErrorCardNotRegistered
                    MsgBox("ErrorCardNotRegistered")
                Case ErrorFuncNotSupport
                    MsgBox("ErrorFuncNotSupport")
                Case Else
                    MsgBox("AI_CH_Config failed , but unknown reasons!")
                    Exit Sub
            End Select
        End If

        result = D2K_AI_Config(cardNum, DAQ2K_AI_ADCONVSRC_Int, DAQ2K_AI_TRGSRC_SOFT Or DAQ2K_AI_TRGMOD_POST, 0, 0, ReTrgCnt, BufAutoReset)
        If result <> NoError Then
            Select Case result
                Case ErrorInvalidCardNumber
                    MsgBox("ErrorInvalidCardNumber")
                Case ErrorCardNotRegistered
                    MsgBox("ErrorCardNotRegistered")
                Case ErrorFuncNotSupport
                    MsgBox("ErrorFuncNotSupport")
                Case Else
                    MsgBox("AI_CH_Config failed , but unknown reasons!")
                    Exit Sub
            End Select
        End If

        result = D2K_AI_ContBufferSetup(cardNum, InBuf(0), ScanCount * ADChanCount, BufId)
        If result <> NoError Then
            Select Case result
                Case ErrorInvalidCardNumber
                    MsgBox("ErrorInvalidCardNumber")
                Case ErrorCardNotRegistered
                    MsgBox("ErrorCardNotRegistered")
                Case ErrorFuncNotSupport
                    MsgBox("ErrorFuncNotSupport")
                Case ErrorTransferCountTooLarge
                    MsgBox("ErrorTransferCountTooLarge")
                Case ErrorContIoNotAllowed
                    MsgBox("ErrorContIoNotAllowed")
                Case Else
                    MsgBox("AI_ContBufferSetup failed , but unknown reasons!")
                    Exit Sub
            End Select
        End If

        ' command this if...else...endif section, and always creat the dat file
        If scanFileFormatMode = "DAT" Then
            'here use scan data to dat file
            result = D2K_AI_ContScanChannelsToFile(cardNum, ADChanCount - 1, BufId, filename, ScanCount, ScanIntrv, SampleIntrv, ASYNCH_OP)
            If result <> NoError Then
                Select Case result
                    Case ErrorInvalidCardNumber
                        MsgBox("ErrorInvalidCardNumber")
                    Case ErrorCardNotRegistered
                        MsgBox("ErrorCardNotRegistered")
                    Case ErrorFuncNotSupport
                        MsgBox("ErrorFuncNotSupport")
                    Case ErrorInvalidIoChannel
                        MsgBox("ErrorInvalidIoChannel")
                    Case ErrorInvalidSampleRate
                        MsgBox("ErrorInvalidSampleRate")
                    Case ErrorInvalidAdRange
                        MsgBox("ErrorInvalidAdRange")
                    Case ErrorTransferCountTooLarge
                        MsgBox("ErrorTransferCountTooLarge")
                    Case ErrorContIoNotAllowed
                        MsgBox("ErrorContIoNotAllowed")
                    Case ErrorOpenFile
                        MsgBox("ErrorOpenFile")
                    Case Else
                        MsgBox("AI_ContScanChannelsToFile failed , but unknown reasons!")
                        Exit Sub
                End Select
            End If
        Else
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'here use scan data to memory
            result = D2K_AI_ContScanChannels(cardNum, ADChanCount - 1, BufId, ScanCount, ScanIntrv, SampleIntrv, ASYNCH_OP)
            If result <> NoError Then
                Select Case result
                    Case ErrorInvalidCardNumber
                        MsgBox("ErrorInvalidCardNumber")
                    Case ErrorCardNotRegistered
                        MsgBox("ErrorCardNotRegistered")
                    Case ErrorFuncNotSupport
                        MsgBox("ErrorFuncNotSupport")
                    Case ErrorInvalidIoChannel
                        MsgBox("ErrorInvalidIoChannel")
                    Case ErrorInvalidSampleRate
                        MsgBox("ErrorInvalidSampleRate")
                    Case ErrorInvalidAdRange
                        MsgBox("ErrorInvalidAdRange")
                    Case ErrorTransferCountTooLarge
                        MsgBox("ErrorTransferCountTooLarge")
                    Case ErrorContIoNotAllowed
                        MsgBox("ErrorContIoNotAllowed")
                    Case ErrorLastChannelNotZero
                        MsgBox("ErrorLastChannelNotZero")
                    Case ErrorDiffRangeNotSupport
                        MsgBox("ErrorDiffRangeNotSupport")
                    Case ErrorChannelNotDescending
                        MsgBox("ErrorChannelNotDescending")
                    Case ErrorChannelNotAscending
                        MsgBox("ErrorChannelNotAscending")
                    Case Else
                        MsgBox("AI_ContScanChannel failed , but unknown reasons!")
                        Exit Sub
                End Select
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'result = D2K_AI_ContScanChannelsToFile(cardNum, ADChanCount - 1, BufId, filename, ScanCount, ScanIntrv, SampleIntrv, ASYNCH_OP)
        End If

    End Sub


    Sub ClearDaq2005Async(ByVal cardNum As Short)

        Dim result As Integer
        Dim fstop As Boolean = 0
        Dim startPos As Integer = 0
        Dim AccessCnt As Integer = 0

        While Not fstop
            D2K_AI_AsyncCheck(cardNum, fstop, AccessCnt)
        End While

        result = D2K_AI_AsyncClear(cardNum, startPos, AccessCnt)
        If result <> NoError Then
            Select Case result
                Case ErrorInvalidCardNumber
                    MsgBox("ErrorInvalidCardNumber")
                Case ErrorCardNotRegistered
                    MsgBox("ErrorCardNotRegistered")
                Case ErrorFuncNotSupport
                    MsgBox("ErrorFuncNotSupport")
                Case Else
                    MsgBox("AI_AsyncClear failed , but unknown reasons!")
                    Exit Sub
            End Select
        End If
    End Sub

End Module
