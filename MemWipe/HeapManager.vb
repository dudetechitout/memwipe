Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Module HeapManager
    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Function GetProcessHeap() As IntPtr
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Function HeapCompact(ByVal hHeap As IntPtr, ByVal dwFlags As UInteger) As Boolean
    End Function

    ''' <summary>
    ''' Compacts the process heap memory to reduce fragmentation.
    ''' </summary>
    Public Sub CompactHeap()
        Try
            Dim processHeap As IntPtr = GetProcessHeap()
            If processHeap = IntPtr.Zero Then
                Throw New System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error())
            End If

            If HeapCompact(processHeap, 0) Then
                'MessageBox.Show("Heap compacted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'MessageBox.Show("Heap compaction failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            'MessageBox.Show($"An error occurred while compacting the heap: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module
