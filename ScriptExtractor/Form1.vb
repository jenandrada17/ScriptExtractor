Imports System.IO
Imports OfficeOpenXml

Public Class Form1
    Private HT As New Hashtable
    Private savePath As String = Nothing

    Private Sub btnBrowseData_Click(sender As Object, e As EventArgs) Handles btnBrowseData.Click
        If Not fbdBackup.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        txtPath.Text = fbdBackup.SelectedPath
    End Sub

    Private Sub btnExtract_Click(sender As Object, e As EventArgs) Handles btnExtract.Click
        If txtQuery.Text = "" Then Exit Sub
        If txtPath.Text = "" Then Exit Sub

        btnExtract.Enabled = False
        HT.Clear()
        ProcessDirectory(txtPath.Text)
        LoadQuery()
        btnExtract.Enabled = True
    End Sub

    Private Sub LoadQuery()
        Using ds As DataSet = LoadSQL(txtQuery.Text)
            If ds.Tables(0).Rows.Count > 0 Then

                sfdPath.FileName = $"Extracted{Now:MMddyyHHmmss}.xlsx"
                Dim path As String = $"{savePath}\{sfdPath.FileName}"

                If Not Directory.Exists(savePath) Then Directory.CreateDirectory(savePath)

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial

                Using package As New ExcelPackage(New FileInfo(path))
                    Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("Sheet1")

                    For colIndex As Integer = 1 To ds.Tables(0).Columns.Count
                        worksheet.Cells(1, colIndex).Value = ds.Tables(0).Columns(colIndex - 1).ColumnName
                    Next

                    progressBarStart(ds.Tables(0).Rows.Count)
                    For rowIndex As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        For colIndex As Integer = 1 To ds.Tables(0).Columns.Count
                            worksheet.Cells(rowIndex + 2, colIndex).Value = ds.Tables(0).Rows(rowIndex)(colIndex - 1)
                        Next

                        AppProgressBar.Value += 1
                    Next

                    package.Save()
                    progressBarEnd()
                    MsgBox("Successfully Extracted!", MsgBoxStyle.Information)
                End Using
            End If
        End Using
    End Sub

    Public Sub ProcessDirectory(ByVal targetDirectory As String)
        Dim fileEntries As String() = Directory.GetFiles(targetDirectory, "*.FDB")

        Dim fileName As String
        For Each fileName In fileEntries
            ProcessFile(fileName)

        Next fileName
        Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
        Dim subdirectory As String
        For Each subdirectory In subdirectoryEntries
            ProcessDirectory(subdirectory)
        Next
    End Sub

    Public Sub ProcessFile(ByVal path As String)
        HT.Add(path, path)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtQuery.ScrollBars = ScrollBars.Vertical
        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Script Extracted"
        If Directory.Exists(path) Then
            savePath = path
        Else
            Directory.CreateDirectory(path)
            savePath = path
        End If
    End Sub

    Friend Sub progressBarStart(ByVal objectt As Integer)
        AppProgressBar.Maximum = objectt
        AppProgressBar.Visible = True
    End Sub

    Friend Sub progressBarEnd()
        AppProgressBar.Value = 0
        AppProgressBar.Maximum = 1000
        AppProgressBar.Visible = False
    End Sub
End Class
