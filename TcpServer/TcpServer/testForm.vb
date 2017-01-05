Public Class testForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim s As String = "isLinearMotion:0,L_delayTime:1,L_accTime:0.1,L_decTime:0.2,L_maxSpeed:60,L_unifTime:0.2,isRotMotion:0,R_delayTime:0,R_accTime:0.1,R_decTime:0.1,R_maxSpeed:60,R_dist:60,isDAQ2005:0,scanIntervals:200,dataSize:100000,numOfAve:100,expConditions:,fileToSave:ADLINKDaq"
        Dim msg As New MSG_CFG(s)
        'TextBox1.AppendText(msg.isLinearMotion.ToString + vbCrLf)
        'TextBox1.AppendText(msg.L_delayTime.ToString + vbCrLf)
        'TextBox1.AppendText(msg.L_accTime.ToString + vbCrLf)
        'TextBox1.AppendText(msg.L_decTime.ToString + vbCrLf)
        'TextBox1.AppendText(msg.L_maxSpeed.ToString + vbCrLf)
        'TextBox1.AppendText(msg.L_unifTime.ToString + vbCrLf)
        'TextBox1.AppendText(msg.isRotMotion.ToString + vbCrLf)
        'TextBox1.AppendText(msg.R_delayTime.ToString + vbCrLf)
        'TextBox1.AppendText(msg.R_accTime.ToString + vbCrLf)
        'TextBox1.AppendText(msg.R_decTime.ToString + vbCrLf)
        'TextBox1.AppendText(msg.R_maxSpeed.ToString + vbCrLf)
        'TextBox1.AppendText(msg.R_dist.ToString + vbCrLf)
        'TextBox1.AppendText(msg.isDAQ2005.ToString + vbCrLf)
        'TextBox1.AppendText(msg.scanIntervals.ToString + vbCrLf)
        'TextBox1.AppendText(msg.dataSize.ToString + vbCrLf)
        'TextBox1.AppendText(msg.numOfAve.ToString + vbCrLf)
        'TextBox1.AppendText(msg.expConditions.ToString + vbCrLf)
        'TextBox1.AppendText(msg.fileToSave.ToString + vbCrLf)
        TextBox1.AppendText(Now.ToString + vbCrLf)
        TextBox1.AppendText(msg.info)
        'MsgBox(msg.isLinearMotion)
    End Sub
End Class