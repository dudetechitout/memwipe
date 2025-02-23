Imports System.Diagnostics

Public Module DnsCacheCleaner
    ''' <summary>
    ''' Clears the DNS cache.
    ''' </summary>
    Public Sub ClearDnsCache()
        Try
            Dim process As New Process()
            process.StartInfo.FileName = "ipconfig"
            process.StartInfo.Arguments = "/flushdns"
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            process.Start()
            process.WaitForExit()
        Catch ex As Exception
            'Throw New Exception("Error clearing DNS cache.", ex)
        End Try
    End Sub
End Module
