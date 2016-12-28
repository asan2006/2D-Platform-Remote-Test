Imports System.Text
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class Form1
    Dim conn As MySqlConnection = New MySqlConnection()
    Private Sub btnConn_Click(sender As Object, e As EventArgs) Handles btnConn.Click
        '默认延时60秒
        conn.ConnectionString = ConnStr() & "default command timeout=60;"
        'conn = New MySqlConnection(ConnStr() & "default command timeout=60;")
        Try
            conn.Open()
            UpdataINFO("Connect Successful!")
        Catch ex As Exception
            UpdataINFO(ex.ToString())
        End Try
    End Sub

    Private Sub btnDisconn_Click(sender As Object, e As EventArgs) Handles btnDisconn.Click
        Try
            conn.Close()
            UpdataINFO("Disconnect Successful!")
        Catch ex As Exception
            UpdataINFO(ex.ToString())
        End Try
    End Sub

    Private Sub btnBulkTest_Click(sender As Object, e As EventArgs) Handles btnBulkTest.Click
        If IsNothing(conn) Or conn.State = ConnectionState.Closed Then
            MsgBox("Please connect the database server!")
            Exit Sub
        End If

        Dim strDatabase As String = txtDatabase.Text
        Dim strTable As String = txtTable.Text

        Dim creatCmd As String = String.Format(
            "CREATE TABLE IF NOT EXISTS `{0}` ( `timer` FLOAT Not NULL , `chan1` FLOAT Not NULL , `chan2` FLOAT Not NULL ) ENGINE = MyISAM;", strTable)

        Using mycmd As MySqlCommand = New MySqlCommand(creatCmd, conn)
            mycmd.ExecuteNonQuery()
        End Using

        Dim size As Int32 = CInt(txtDataSize.Text)

        Dim timer(size) As Single
        Dim chan1(size) As Single
        Dim chan2(size) As Single

        For i = 1 To size
            timer(i) = 0.0005 * i
            chan1(i) = i
            chan2(i) = i + 1
        Next
        Dim cmd As StringBuilder = New StringBuilder(String.Format("INSERT INTO {0}(timer, chan1, chan2) VALUES ", strTable))
        cmd.AppendFormat("({0},{1},{2})", timer(1), chan1(1), chan2(1))

        If size > 1 Then
            For i = 2 To size
                cmd.AppendFormat(",({0},{1},{2})", timer(i), chan1(i), chan2(i))
            Next
            cmd.Append(";")
            UpdataINFO(String.Format("Begin insert {0} data...", size))
            Using myCmd As MySqlCommand = New MySqlCommand(cmd.ToString, conn)
                myCmd.CommandTimeout = 60
                myCmd.ExecuteNonQuery()
            End Using
        End If

        'MsgBox(cmd.ToString)
        UpdataINFO(String.Format("Insert {0} data completely!", size))

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtINFO.Clear()
    End Sub

    Private Function ConnStr() As String
        Dim strServer As String = txtServer.Text
        Dim strPort As String = txtPort.Text
        Dim strDatabase As String = txtDatabase.Text
        Dim strUsername As String = txtUsername.Text
        Dim strPassword As String = txtPassword.Text

        Return String.Format("server={0};user={1};database={2};port={3};password={4};", strServer, strUsername, strDatabase, strPort, strPassword)

    End Function

    Private Sub UpdataINFO(ByVal strInfo As String)
        txtINFO.AppendText(Now & " : " & strInfo & vbCrLf)
    End Sub

    Private Sub btnDropTable_Click(sender As Object, e As EventArgs) Handles btnDropTable.Click
        'TRUNCATE tbTest
        Dim strTable As String = txtTable.Text
        Try
            If IsNothing(conn) Or conn.State = ConnectionState.Closed Then
                MsgBox("Please connect the database server!")
                Exit Sub
            End If
            Dim strCmd As String = String.Format("TRUNCATE {0}", txtTable.Text)
            Using mycmd As MySqlCommand = New MySqlCommand(strCmd, conn)
                mycmd.ExecuteNonQuery()
            End Using
            UpdataINFO("Clear the data sucessfully!")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
