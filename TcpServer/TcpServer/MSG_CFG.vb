Public Class MSG_CFG
    Private strMSG As String
    Private strData() As String
    Public ReadOnly isLinearMotion As Boolean
    Public ReadOnly L_delayTime As Double
    Public ReadOnly L_accTime As Double
    Public ReadOnly L_decTime As Double
    Public ReadOnly L_maxSpeed As Double
    Public ReadOnly L_unifTime As Double
    Public ReadOnly isRotMotion As Boolean
    Public ReadOnly R_delayTime As Double
    Public ReadOnly R_accTime As Double
    Public ReadOnly R_decTime As Double
    Public ReadOnly R_maxSpeed As Double
    Public ReadOnly R_dist As Double
    Public ReadOnly isDAQ2005 As Boolean
    Public ReadOnly scanIntervals As Integer
    Public ReadOnly dataSize As Integer
    Public ReadOnly numOfAve As Integer
    Public ReadOnly expConditions As String
    Public ReadOnly fileToSave As String

    Sub New(str As String)
        strMSG = str
        strData = strMSG.Split(",")
        For Each s As String In strData
            Dim r As String() = s.Split(":")
            Select Case r(0)
                Case "isLinearMotion"
                    isLinearMotion = CBool(r(1))
                Case "L_delayTime"
                    L_delayTime = CDbl(r(1))
                Case "L_accTime"
                    L_accTime = CDbl(r(1))
                Case "L_decTime"
                    L_decTime = CDbl(r(1))
                Case "L_maxSpeed"
                    L_maxSpeed = CDbl(r(1))
                Case "L_unifTime"
                    L_unifTime = CDbl(r(1))
                Case "isRotMotion"
                    isRotMotion = CBool(r(1))
                Case "R_delayTime"
                    R_delayTime = CDbl(r(1))
                Case "R_accTime"
                    R_accTime = CDbl(r(1))
                Case "R_decTime"
                    R_decTime = CDbl(r(1))
                Case "R_maxSpeed"
                    R_maxSpeed = CDbl(r(1))
                Case "R_dist"
                    R_dist = CDbl(r(1))
                Case "isDAQ2005"
                    isDAQ2005 = CBool(r(1))
                Case "scanIntervals"
                    scanIntervals = CInt(r(1))
                Case "dataSize"
                    dataSize = CInt(r(1))
                Case "numOfAve"
                    numOfAve = CInt(r(1))
                Case "expConditions"
                    expConditions = CStr(r(1))
                Case "fileToSave"
                    fileToSave = CStr(r(1))
                Case Else

            End Select
        Next
    End Sub

    Public ReadOnly Property info As String
        Get
            Dim sb As New System.Text.StringBuilder
            For Each s As String In strData
                sb.AppendLine(s)
            Next
            Return sb.ToString
        End Get
    End Property

End Class
