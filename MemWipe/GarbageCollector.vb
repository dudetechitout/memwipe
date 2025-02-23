Module GarbageCollector
    Public Sub ForceGarbageCollection()
        Try
            GC.Collect() ' Force garbage collection
            GC.WaitForPendingFinalizers() ' Wait for finalizers to finish
            GC.Collect() ' Perform garbage collection again for final cleanup
            'MessageBox.Show("Garbage collection completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            'MessageBox.Show($"An error occurred during garbage collection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module
