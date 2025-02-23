Imports System.IO
Imports System.Windows.Forms

Module TempFileCleaner
    Public Sub ClearTempFiles()
        Try
            Dim tempPath = Path.GetTempPath() ' Get the system's temporary folder path
            Dim tempFiles = Directory.GetFiles(tempPath) ' Get all files in the temp folder
            Dim tempDirs = Directory.GetDirectories(tempPath) ' Get all directories in the temp folder

            ' Delete files
            For Each tmpFile In tempFiles
                Try
                    File.Delete(tmpFile) ' Correctly delete the file
                Catch ex As Exception
                    ' Ignore file deletion errors
                End Try
            Next

            ' Delete directories
            For Each tmpDir In tempDirs
                Try
                    Directory.Delete(tmpDir, True) ' Correctly delete the directory and its contents
                Catch ex As Exception
                    ' Ignore directory deletion errors
                End Try
            Next

            ' Notify the user of success
            'MessageBox.Show("Temporary files cleared successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            ' Notify the user of an error
            'MessageBox.Show($"An error occurred while clearing temporary files: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module
