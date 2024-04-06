Imports FirebirdSql.Data.FirebirdClient
Imports System.Configuration
Imports System.Threading

Module database

    Friend ReadOnly _config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
    Friend cs As FbConnectionStringBuilder
    Public con As FbConnection
    Public readerCon As FbConnection
    Friend conStr As String = String.Empty

    Friend Function LoadSQL(ByVal mySql As String, Optional ByVal tblName As String = "QuickSQL") As DataSet
        Dim da As FbDataAdapter
        Dim ds As New DataSet, fillData As String = tblName
        Try
            DbOpen() 'open the database.

            Try
                da = New FbDataAdapter(mySql, con)
                da.Fill(ds, fillData)
            Catch ex As Exception

                MsgBox(ex.ToString)

            End Try

            DbClose()

            Return ds
        Catch ex As FbException
            Console.WriteLine(">>>>>" & mySql)
            MessageBox.Show($"[{ex.ErrorCode.ToString}] - {ex.Message}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Log_Report("LoadSQL - " & ex.ToString)
            ds = Nothing
            Return ds
        End Try
    End Function

    Public Sub DbClose()
        con.Close()
    End Sub

    Public Sub DbOpen()

        Try
            conStr = ConfigurationManager.ConnectionStrings("FbConString").ConnectionString.ToString
            con = New FbConnection(conStr)
            con.Open()
        Catch ex As FbException
            MsgBox(ex.ErrorCode & vbCrLf & ex.Message.ToString, vbCritical, "Connecting Error")
            con.Dispose()
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.HResult & vbCrLf & ex.Message.ToString, vbCritical, "Connecting Error")
            con.Dispose()
            Exit Sub
        End Try

    End Sub
End Module
