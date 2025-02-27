Imports OfficeOpenXml
Imports System.IO

Public Class Extractor
    Private HT As New Hashtable
    Private savePath As String = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Script Extracted"
    Private Sub btnExtract_Click(sender As Object, e As EventArgs) Handles btnExtract.Click
        If txtQuery.Text = "" Then Exit Sub

        btnExtract.Enabled = False
        HT.Clear()
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

                    For rowIndex As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        For colIndex As Integer = 1 To ds.Tables(0).Columns.Count
                            worksheet.Cells(rowIndex + 2, colIndex).Value = ds.Tables(0).Rows(rowIndex)(colIndex - 1)
                        Next
                    Next

                    package.Save()
                    MsgBox("Successfully Extracted!", MsgBoxStyle.Information)
                End Using
            End If
        End Using
    End Sub
End Class