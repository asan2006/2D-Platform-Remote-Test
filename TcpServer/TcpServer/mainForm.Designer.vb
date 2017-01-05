<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboIpList = New System.Windows.Forms.ComboBox()
        Me.nmPort = New System.Windows.Forms.NumericUpDown()
        Me.btnListen = New System.Windows.Forms.Button()
        Me.txtReceive = New System.Windows.Forms.TextBox()
        CType(Me.nmPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ip:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Port:"
        '
        'cboIpList
        '
        Me.cboIpList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIpList.FormattingEnabled = True
        Me.cboIpList.Location = New System.Drawing.Point(53, 6)
        Me.cboIpList.Name = "cboIpList"
        Me.cboIpList.Size = New System.Drawing.Size(149, 20)
        Me.cboIpList.TabIndex = 1
        '
        'nmPort
        '
        Me.nmPort.Location = New System.Drawing.Point(54, 29)
        Me.nmPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nmPort.Name = "nmPort"
        Me.nmPort.Size = New System.Drawing.Size(69, 21)
        Me.nmPort.TabIndex = 2
        Me.nmPort.Value = New Decimal(New Integer() {51127, 0, 0, 0})
        '
        'btnListen
        '
        Me.btnListen.Location = New System.Drawing.Point(127, 29)
        Me.btnListen.Name = "btnListen"
        Me.btnListen.Size = New System.Drawing.Size(75, 23)
        Me.btnListen.TabIndex = 3
        Me.btnListen.Text = "Listen"
        Me.btnListen.UseVisualStyleBackColor = True
        '
        'txtReceive
        '
        Me.txtReceive.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReceive.Location = New System.Drawing.Point(0, 57)
        Me.txtReceive.Multiline = True
        Me.txtReceive.Name = "txtReceive"
        Me.txtReceive.Size = New System.Drawing.Size(519, 396)
        Me.txtReceive.TabIndex = 4
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 454)
        Me.Controls.Add(Me.txtReceive)
        Me.Controls.Add(Me.btnListen)
        Me.Controls.Add(Me.nmPort)
        Me.Controls.Add(Me.cboIpList)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "mainForm"
        Me.Text = "TcpServer"
        CType(Me.nmPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboIpList As ComboBox
    Friend WithEvents nmPort As NumericUpDown
    Friend WithEvents btnListen As Button
    Friend WithEvents txtReceive As TextBox
End Class
