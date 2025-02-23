Imports System.Diagnostics

Module StandbyMemoryCleaner
    Public Sub ClearStandbyMemory()
        Try
            Dim process As New Process()
            process.StartInfo.FileName = "emptystandbylist.exe" ' Path to Empty Standby List tool
            process.StartInfo.Arguments = "standbylist"
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            process.Start()
            process.WaitForExit()
        Catch ex As Exception
            'MessageBox.Show($"An error occurred while clearing standby memory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module
