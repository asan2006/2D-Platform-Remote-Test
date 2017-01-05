Imports System.Text

Module Module_OtherFun

    Sub WriteInfoToTxt(ByVal MotionInfo As String)

        If Not IO.Directory.Exists("C:\MotionParameter\") Then
            IO.Directory.CreateDirectory("C:\MotionParameter\")
        End If

        Dim nowTime As Date = Now
        Dim strNow As String = Format(Now, "yyyyMMddhhmmss")
        Dim strFileName As String = "C:\MotionParameter\" & strNow & ".txt"
        Dim sw As New IO.StreamWriter(strFileName, False)
        sw.WriteLine("Time:" & nowTime)
        sw.WriteLine(MotionInfo)
        sw.Close()
    End Sub

    ''' <summary>
    ''' import data from memory to xlsx file
    ''' </summary>
    ''' <param name="xlsHeader">xlsHeader length is 4 and refer the four AD channel</param>
    ''' <param name="dataBuf">InBuf as in daq2005 from D2K_AI_ContBufferSetup function</param>
    ''' <param name="aveNum">aveNum is use for calc average filter</param>
    ''' <param name="experimentalCondition"></param>
    ''' <param name="filename">select xlsx file to store data</param>
    ''' <remarks></remarks>
    ''' 

    Sub dataToXLSX(ByVal xlsHeader() As String, ByVal dataBuf() As UShort, ByVal aveNum As Integer, ByVal experimentalCondition As String, ByVal filename As String, Optional ByVal StrChartRange As String = Nothing)

        'initial ScanCount and ADChanCount
        Dim ADChanCount As Integer = 4
        Dim ScanCount As Integer = dataBuf.GetLength(0) / ADChanCount

        'dim a stringBuilder to store the data string after average
        Dim sb As StringBuilder = New StringBuilder
        sb.Clear()
        'append xls headed to string builder
        sb.AppendLine(xlsHeader(0) + vbTab + xlsHeader(1) + vbTab + xlsHeader(2) + vbTab + xlsHeader(3))

        Dim voltage(ScanCount - 1, ADChanCount - 1) As Double
        Dim i As Integer = 0
        While i < dataBuf.GetLength(0)
            voltage(i / 4, 0) = Digital2Voltage(dataBuf(i))
            voltage(i / 4, 1) = Digital2Voltage(dataBuf(i + 1))
            voltage(i / 4, 2) = Digital2Voltage(dataBuf(i + 2))
            voltage(i / 4, 3) = Digital2Voltage(dataBuf(i + 3))
            i = i + 4
        End While
        Dim aveData(,) As Double = Average(voltage, aveNum)

        For j = 0 To aveData.GetLength(0) - 1
            For k = 0 To aveData.GetLength(1) - 1
                sb.Append(aveData(j, k).ToString + vbTab)
            Next
            sb.AppendLine()
        Next
        SaveToXls(sb.ToString, experimentalCondition, filename, StrChartRange)

    End Sub


    Function Digital2Voltage(ByVal data As UShort) As Double
        'use AD_B_10_V  as voltage input range
        Dim vMax As Double = 10
        Dim vMin As Double = -10

        ' here is 65536 instead of 65535
        ' detail is refered at "DAQ-2000Series_Manual_5.pdf" page42 "4.2 D/A Conversion"
        Dim v As Double = data / (2 ^ 16) * (vMax - vMin) + vMin
        Return v
    End Function

    Private Function Average(ByVal a(,) As Double, ByVal aveNum As Integer) As Double(,)

        If aveNum < 1 Then
            MsgBox("average num must be a positive number , pls check it!!!")
            Return Nothing
        Else
            Dim ave(a.GetLength(0) / aveNum - 1, a.GetLength(1) - 1) As Double
            Dim sum(a.GetLength(1) - 1) As Double
            For index = 0 To sum.Length - 1
                sum(index) = 0
            Next
            Dim i As Integer = 0
            Dim k As Integer = 0
            Dim l As Integer = a.GetLength(0)
            While l - i > 0

                For j = 0 To a.GetLength(1) - 1
                    sum(j) = sum(j) + a(i, j)
                Next

                i = i + 1

                If i Mod aveNum = 0 Then
                    For index = 0 To a.GetLength(1) - 1
                        'here data uint by millvolt instead of voltage...
                        ave(k, index) = sum(index) / aveNum * 1000
                    Next
                    k = k + 1
                    'sum set zero
                    For index = 0 To sum.Length - 1
                        sum(index) = 0
                    Next
                End If
            End While
            Return ave
        End If
    End Function

    Private Sub SaveToXls(ByVal StrData As String, ByVal StrExpCondition As String, ByVal StrFileName As String, Optional ByVal StrChartRange As String = Nothing)

        If String.IsNullOrEmpty(StrData) Or String.IsNullOrEmpty(StrFileName) Then
            Return
        Else
            Try
                Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
                xlApp.DefaultFilePath = ""
                xlApp.SheetsInNewWorkbook = 1
                Dim xlBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add(True)
                Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlBook.Worksheets.Add()

                System.Windows.Forms.Clipboard.SetDataObject(StrData)
                xlSheet.Paste()

                '------------------------------------------------------------------------------
                ' here experimental conditions content will write in excel file at cell("W1")
                System.Windows.Forms.Clipboard.SetDataObject(StrExpCondition)
                xlSheet.Range("W1").PasteSpecial()

                '------------------------------------------------------------------------------

                If StrChartRange <> "" Then
                    LineChart(xlSheet, xlSheet.Range(StrChartRange))
                End If

                'here avoid the data overwrite alert info
                xlApp.DisplayAlerts = False
                'xlApp.AlertBeforeOverwriting = False
                'here avoid the defalt excel path is windows/system32

                'Use it more than office 2007 version, And add the Extension name ".xlsx"
                StrFileName = System.IO.Path.GetFullPath(StrFileName) & ".xlsx"
                xlBook.SaveAs(StrFileName)

                'Release excel application
                xlBook.Close()
                xlApp.Quit()
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlSheet)
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlBook)
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlApp)
                xlSheet = Nothing
                xlBook = Nothing
                xlApp = Nothing
                GC.Collect()
            Catch ex As Exception
                MessageBox.Show("Can't creat excel object, confirm your computer has installed the excel...")
            End Try
        End If

    End Sub

    Private Sub LineChart(ByVal xlSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal oRange As Microsoft.Office.Interop.Excel.Range)
        Dim oShape As Microsoft.Office.Interop.Excel.Shape = xlSheet.Shapes.AddChart(Microsoft.Office.Interop.Excel.XlChartType.xlLine)
        Dim oChart As Microsoft.Office.Interop.Excel.Chart = oShape.Chart
        oChart.SetSourceData(oRange)
    End Sub
End Module
