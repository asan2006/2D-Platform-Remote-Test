Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class mainForm
    'TCP监听服务
    Dim tcplisener As TcpListener
    'TCP监听信号
    Public tcpClientConnected As New ManualResetEvent(False)
    '监听状态
    Dim isListen As Boolean = False
    Public Delegate Sub updateTxt(text As String)
    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Dim ipHostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName)
        For Each ip As IPAddress In ipHostEntry.AddressList
            If ip.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                cboIpList.Items.Add(ip.ToString)
            End If
        Next
        cboIpList.SelectedIndex = 0
    End Sub

    Private Sub btnListen_Click(sender As Object, e As EventArgs) Handles btnListen.Click
        If Not isListen Then
            StartTcpServer()
            btnListen.Text = "Stop"
        Else
            StopTcpServer()
            btnListen.Text = "Listen"
        End If
        cboIpList.Enabled = Not isListen
        nmPort.Enabled = Not isListen
    End Sub

    Private Sub StopTcpServer()
        Try
            'UpdateTxtReceive(Thread.CurrentThread.Name)
            tcplisener.Stop()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        isListen = False
    End Sub

    Private Sub StartTcpServer()
        tcplisener = New TcpListener(IPAddress.Parse(cboIpList.SelectedItem.ToString()), CInt(nmPort.Value))
        tcplisener.Start()
        Dim t As Thread = New Thread(AddressOf DoBeginAcceptTcpClient)
        '设置为后台线程
        t.IsBackground = True
        t.Start()
        'DoBeginAcceptTcpClient(tcplisener)
        isListen = True

    End Sub

    ' Accept one client connection asynchronously.
    Private Sub DoBeginAcceptTcpClient()
        While True
            ' Set the event to nonsignaled state.
            tcpClientConnected.Reset()

            ' Accept the connection. 
            ' BeginAcceptSocket() creates the accepted socket.
            tcplisener.BeginAcceptTcpClient(New AsyncCallback(AddressOf DoAcceptTcpClientCallback), tcplisener)

            ' Wait until a connection is made and processed before 
            ' continuing.
            tcpClientConnected.WaitOne()
        End While

    End Sub 'DoBeginAcceptTcpClient

    Private Sub DoAcceptTcpClientCallback(ar As IAsyncResult)
        ' Get the listener that handles the client request.
        Dim listener As TcpListener = CType(ar.AsyncState, TcpListener)
        If Not listener.Server.IsBound Then
            Exit Sub
        End If
        ' End the operation and display the received data on 
        ' the console.
        Dim client As TcpClient = listener.EndAcceptTcpClient(ar)

        ' Process the connection here. (Add the client to a
        ' server table, read data, etc.)
        Dim bytes(client.ReceiveBufferSize) As Byte
        client.GetStream.Read(bytes, 0, client.ReceiveBufferSize)

        '更新收到的信息
        Dim MSG As New MSG_CFG(Encoding.ASCII.GetString(bytes))
        UpdateTxtReceive(Now.ToString)
        UpdateTxtReceive(MSG.info)

        '继续监听客户端连接
        tcpClientConnected.Set()
        ' Signal the calling thread to continue.
    End Sub

    Private Sub UpdateTxtReceive(str As String)
        If txtReceive.InvokeRequired Then
            Dim d As New updateTxt(AddressOf UpdateTxtReceive)
            txtReceive.Invoke(d, New Object() {[str]})
        Else
            txtReceive.AppendText(str + vbCrLf)
        End If
    End Sub
End Class
