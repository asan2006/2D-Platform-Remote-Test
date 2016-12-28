<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnConn = New System.Windows.Forms.Button()
        Me.btnDisconn = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtINFO = New System.Windows.Forms.TextBox()
        Me.btnBulkTest = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTable = New System.Windows.Forms.TextBox()
        Me.txtDataSize = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnDropTable = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Port:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.txtUsername)
        Me.GroupBox1.Controls.Add(Me.txtDatabase)
        Me.GroupBox1.Controls.Add(Me.txtPort)
        Me.GroupBox1.Controls.Add(Me.txtServer)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(176, 169)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Database Configure"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(64, 138)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(104, 21)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.Text = "test"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(64, 107)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(104, 21)
        Me.txtUsername.TabIndex = 2
        Me.txtUsername.Text = "test"
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(64, 76)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(104, 21)
        Me.txtDatabase.TabIndex = 2
        Me.txtDatabase.Text = "test"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(64, 45)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(104, 21)
        Me.txtPort.TabIndex = 2
        Me.txtPort.Text = "3306"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(64, 14)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(104, 21)
        Me.txtServer.TabIndex = 2
        Me.txtServer.Text = "107.182.178.17"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Password:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Username:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Database:"
        '
        'btnConn
        '
        Me.btnConn.Location = New System.Drawing.Point(12, 187)
        Me.btnConn.Name = "btnConn"
        Me.btnConn.Size = New System.Drawing.Size(75, 23)
        Me.btnConn.TabIndex = 3
        Me.btnConn.Text = "Connect"
        Me.btnConn.UseVisualStyleBackColor = True
        '
        'btnDisconn
        '
        Me.btnDisconn.Location = New System.Drawing.Point(113, 187)
        Me.btnDisconn.Name = "btnDisconn"
        Me.btnDisconn.Size = New System.Drawing.Size(75, 23)
        Me.btnDisconn.TabIndex = 3
        Me.btnDisconn.Text = "Disconnect"
        Me.btnDisconn.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnClear)
        Me.GroupBox2.Controls.Add(Me.txtINFO)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 216)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(479, 175)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "INFO"
        '
        'txtINFO
        '
        Me.txtINFO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtINFO.Location = New System.Drawing.Point(3, 17)
        Me.txtINFO.Multiline = True
        Me.txtINFO.Name = "txtINFO"
        Me.txtINFO.Size = New System.Drawing.Size(473, 155)
        Me.txtINFO.TabIndex = 0
        '
        'btnBulkTest
        '
        Me.btnBulkTest.Location = New System.Drawing.Point(6, 169)
        Me.btnBulkTest.Name = "btnBulkTest"
        Me.btnBulkTest.Size = New System.Drawing.Size(75, 23)
        Me.btnBulkTest.TabIndex = 5
        Me.btnBulkTest.Text = "BulkTest"
        Me.btnBulkTest.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnDropTable)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtTable)
        Me.GroupBox3.Controls.Add(Me.txtDataSize)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.btnBulkTest)
        Me.GroupBox3.Location = New System.Drawing.Point(194, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(187, 198)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Bulk to mySql Test"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Table:"
        '
        'txtTable
        '
        Me.txtTable.Location = New System.Drawing.Point(74, 17)
        Me.txtTable.Name = "txtTable"
        Me.txtTable.Size = New System.Drawing.Size(100, 21)
        Me.txtTable.TabIndex = 7
        Me.txtTable.Text = "tbTest"
        '
        'txtDataSize
        '
        Me.txtDataSize.Location = New System.Drawing.Point(74, 51)
        Me.txtDataSize.Name = "txtDataSize"
        Me.txtDataSize.Size = New System.Drawing.Size(100, 21)
        Me.txtDataSize.TabIndex = 7
        Me.txtDataSize.Text = "50000"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "DataSize:"
        '
        'btnDropTable
        '
        Me.btnDropTable.Location = New System.Drawing.Point(99, 169)
        Me.btnDropTable.Name = "btnDropTable"
        Me.btnDropTable.Size = New System.Drawing.Size(75, 23)
        Me.btnDropTable.TabIndex = 9
        Me.btnDropTable.Text = "DropTable"
        Me.btnDropTable.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(404, 0)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 1
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 403)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnDisconn)
        Me.Controls.Add(Me.btnConn)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "MySqlTutorial"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtDatabase As TextBox
    Friend WithEvents txtPort As TextBox
    Friend WithEvents txtServer As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnConn As Button
    Friend WithEvents btnDisconn As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtINFO As TextBox
    Friend WithEvents btnBulkTest As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTable As TextBox
    Friend WithEvents txtDataSize As TextBox
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDropTable As Button
End Class
