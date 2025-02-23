Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.IO

Module WorkingSetCleaner
    ' Import EmptyWorkingSet for working set memory cleaning
    <DllImport("psapi.dll")>
    Private Function EmptyWorkingSet(hProcess As IntPtr) As Boolean
    End Function

    ' Clean working set memory
    Public Sub CleanWorkingSetMemory()
        Try
            For Each proc As Process In Process.GetProcesses()
                Try
                    ' Skip system-critical processes and handle only accessible processes
                    If Not proc.HasExited AndAlso proc.ProcessName <> "Idle" AndAlso proc.ProcessName <> "System" Then
                        EmptyWorkingSet(proc.Handle)
                    End If
                Catch ex As UnauthorizedAccessException
                    ' Ignore Access Denied errors
                Catch ex As Exception
                    ' Log other exceptions for debugging (optional)
                    ' Debug.WriteLine($"Error processing {proc.ProcessName}: {ex.Message}")
                End Try
            Next
            'MessageBox.Show("Working set memory cleaned successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            'MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Module
