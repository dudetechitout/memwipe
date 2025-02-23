Imports System.Threading
Imports Microsoft.VisualBasic.Devices
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports System.Threading.Tasks

Public Class Form1
    Private ReadOnly IniFilePath As String = Path.Combine(Application.StartupPath, "appsettings.ini")
    Private ReadOnly Ini As New IniFile(IniFilePath)

    Private systemIdleTime As TimeSpan
    Private systemIdleTimeThreshold As Integer = 300
    Private lastChecked As DateTime
    Private settingsActivated As Boolean = False
    Private wipeInterval As Integer = 0
    Private targetTime As DateTime
    Private processInterval As Integer

    Private Sub LogEvent(message As String)
        If log.ListBox1.InvokeRequired Then
            log.ListBox1.Invoke(New Action(Sub() log.ListBox1.Items.Add($"{DateTime.Now}: {message}")))
        Else
            log.ListBox1.Items.Add($"{DateTime.Now}: {message}")
        End If
    End Sub

    Public Class IniFile
        Private ReadOnly FilePath As String

        Public Sub New(ByVal iniPath As String)
            FilePath = iniPath
        End Sub

        <DllImport("kernel32.dll", SetLastError:=True)>
        Private Shared Function WritePrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Boolean
        End Function

        <DllImport("kernel32.dll", SetLastError:=True)>
        Private Shared Function GetPrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As System.Text.StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
        End Function

        Public Sub WriteValue(ByVal section As String, ByVal key As String, ByVal value As String)
            WritePrivateProfileString(section, key, value, FilePath)
        End Sub

        Public Function ReadValue(ByVal section As String, ByVal key As String, Optional ByVal defaultValue As String = "") As String
            Dim result As New System.Text.StringBuilder(255)
            GetPrivateProfileString(section, key, defaultValue, result, result.Capacity, FilePath)
            Return result.ToString()
        End Function
    End Class

    Private Sub SaveSettings()
        If Not settingsActivated Then
            Return
        End If

        Ini.WriteValue("Settings", "WipeEveryHours", BullionSlider1.Value.ToString())
        Ini.WriteValue("Settings", "FreeMemoryThreshold", BullionSlider2.Value.ToString())
        Ini.WriteValue("Settings", "WipeDNSCache", wipeDNSCache.Checked.ToString())
        Ini.WriteValue("Settings", "WipeStandbyMemory", wipeStandbyMemory.Checked.ToString())
        Ini.WriteValue("Settings", "WipeTempFiles", wipeTempFiles.Checked.ToString())
        Ini.WriteValue("Settings", "WipeSetMemory", wipeSetMemory.Checked.ToString())
        Ini.WriteValue("Settings", "WipeNetMemory", wipeNetMemory.Checked.ToString())
    End Sub

    Private Sub LoadSettings()
        If Not File.Exists(IniFilePath) Then Return

        BullionSlider1.Value = Integer.Parse(Ini.ReadValue("Settings", "WipeEveryHours", "0"))
        BullionSlider2.Value = Integer.Parse(Ini.ReadValue("Settings", "FreeMemoryThreshold", "0"))

        wipeDNSCache.Checked = Ini.ReadValue("Settings", "WipeDNSCache", "False").Trim().ToLower() = "true"
        wipeStandbyMemory.Checked = Ini.ReadValue("Settings", "WipeStandbyMemory", "False").Trim().ToLower() = "true"
        wipeTempFiles.Checked = Ini.ReadValue("Settings", "WipeTempFiles", "False").Trim().ToLower() = "true"
        wipeSetMemory.Checked = Ini.ReadValue("Settings", "WipeSetMemory", "False").Trim().ToLower() = "true"
        wipeNetMemory.Checked = Ini.ReadValue("Settings", "WipeNetMemory", "False").Trim().ToLower() = "true"

        Label1.Text = String.Format("Wipe every {0}h, while away", BullionSlider1.Value)
        Label3.Text = String.Format("Wipe when above {0}%", BullionSlider2.Value)
    End Sub

    Private isSettingsMode As Boolean = False

    Private Sub settingsButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles settingsButton.Click
        LoadSettings()

        settingsActivated = Not settingsActivated

        If isSettingsMode Then
            Me.Size = New Size(320, 473)
            BullionWindowControls1.Location = New Point(244, 1)
            BullionStatusStrip1.Size = New Size(318, 23)
            isSettingsMode = False
            BullionStatusStrip1.StatusText = "Built by Dude Tech It Out | <3 it? Support with a donation!"
        Else
            Me.Size = New Size(563, 473)
            BullionWindowControls1.Location = New Point(487, 1)
            BullionStatusStrip1.Size = New Size(561, 23)
            isSettingsMode = True
            BullionStatusStrip1.StatusText = "Built by Dude Tech It Out | <3 it? Support with a donation by clicking here!!!"
        End If
    End Sub

    Private memoryTimer As System.Windows.Forms.Timer
    Private contextRightMenu As ContextMenuStrip

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LogEvent("UI opened.")

        If Not IsUserAdmin() Then
            MessageBox.Show("This application requires administrator privileges. Please restart as an administrator.", "Admin Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Application.Exit()
        End If

        InitializeContextMenu()

        ' Assign the context menu to NotifyIcon1
        NotifyIcon1.ContextMenuStrip = contextRightMenu

        ' Initialize Timer for memory monitoring
        memoryTimer = New System.Windows.Forms.Timer()
        memoryTimer.Interval = 1000 ' Update every second
        AddHandler memoryTimer.Tick, AddressOf UpdateMemoryIcon
        memoryTimer.Start()

        ' Set the NotifyIcon properties
        NotifyIcon1.Visible = True
        NotifyIcon1.Text = "Memory Usage"
        NotifyIcon1.Icon = GenerateMemoryIcon(0) ' Initial icon

        InitializeForm()
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles NotifyIcon1.DoubleClick
        ' Show the form and taskbar icon
        Me.ShowInTaskbar = True
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.BringToFront()
    End Sub

    Private Sub InitializeContextMenu()
        contextRightMenu = New ContextMenuStrip()

        Dim wipeMenuItem As New ToolStripMenuItem("Wipe")
        AddHandler wipeMenuItem.Click, AddressOf BullionButton1_Click
        contextRightMenu.Items.Add(wipeMenuItem)

        Dim exitMenuItem As New ToolStripMenuItem("Exit")
        AddHandler exitMenuItem.Click, AddressOf ExitApplication
        contextRightMenu.Items.Add(exitMenuItem)
    End Sub

    Private isUpdating As Boolean = False

    Private Sub UpdateMemoryIcon(sender As Object, e As EventArgs)
        If isUpdating Then Exit Sub

        isUpdating = True
        Try
            NotifyIcon1.Icon = GenerateMemoryIcon(GetMemoryUsage())
        Finally
            isUpdating = False
        End Try
    End Sub

    Public Class NativeMethods
        <System.Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True)>
        Public Shared Function DestroyIcon(ByVal hIcon As IntPtr) As Boolean
        End Function
    End Class

    Private Function GenerateMemoryIcon(ByVal memoryPercentage As Integer) As Icon
        If Not Environment.UserInteractive Then
            Debug.WriteLine("Headless system detected. Returning default icon.")
            Return SystemIcons.Application
        End If

        Dim bitmap As Bitmap = Nothing
        Dim hIcon As IntPtr = IntPtr.Zero

        Try
            ' Create a new bitmap
            bitmap = New Bitmap(64, 64)

            Using g As Graphics = Graphics.FromImage(bitmap)
                g.Clear(Color.Black)

                ' Draw text to represent memory percentage
                Using font As New Font("Arial", 40, FontStyle.Bold, GraphicsUnit.Pixel)
                    Dim text As String = memoryPercentage.ToString()
                    Dim size = g.MeasureString(text, font)
                    Dim x = (bitmap.Width - size.Width) / 2
                    Dim y = (bitmap.Height - size.Height) / 2
                    g.DrawString(text, font, Brushes.White, x, y)
                End Using
            End Using

            ' Convert bitmap to icon
            hIcon = bitmap.GetHicon()
            Dim icon As Icon = Icon.FromHandle(hIcon)

            ' Clone icon to fully detach from unmanaged resources
            Return CType(icon.Clone(), Icon)

        Catch ex As Exception
            Debug.WriteLine($"Error in GenerateMemoryIcon: {ex.Message}")
            Throw
        Finally
            ' Ensure unmanaged resources are cleaned up
            If hIcon <> IntPtr.Zero Then
                NativeMethods.DestroyIcon(hIcon)
            End If

            If bitmap IsNot Nothing Then
                bitmap.Dispose()
            End If
        End Try
    End Function


    Private Sub ExitApplication(ByVal sender As Object, ByVal e As EventArgs)
        ' Clean up and exit application
        NotifyIcon1.Visible = False
        Application.Exit()
    End Sub

    Private Sub InitializeForm()
        Me.Size = New Size(320, 473)
        BullionWindowControls1.Location = New Point(244, 1)
        BullionStatusStrip1.Size = New Size(318, 23)

        memoryUsage.Interval = 100
        AddHandler memoryUsage.Tick, AddressOf UpdateMemoryUsage
        memoryUsage.Start()

        tempUsage.Interval = 100
        AddHandler tempUsage.Tick, AddressOf UpdateTempFileStorageUsage
        tempUsage.Start()

        LoadSettings()
    End Sub

    Private Sub BullionStatusStrip1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BullionStatusStrip1.Click
        Try
            Process.Start("https://www.dudetechitout.com/donate")
        Catch ex As Exception

        End Try
    End Sub

    Private wipeTriggerCount As Integer = 0
    Private lastWipeCheckTime As DateTime = DateTime.Now
    Private wipeAdjustmentThreshold As Integer = 1 ' Number of wipes before adjustment
    Private adjustmentTimeFrame As TimeSpan = TimeSpan.FromMinutes(10) ' Time frame for counting


    Public Sub UpdateMemoryUsage()
        If Me.DesignMode Then Return

        Try
            Dim computerInfo As New ComputerInfo()
            Dim totalMemoryBytes As ULong = computerInfo.TotalPhysicalMemory
            Dim availableMemoryBytes As ULong = computerInfo.AvailablePhysicalMemory

            Dim totalMemoryGB As Double = totalMemoryBytes / (1024 * 1024 * 1024)
            Dim availableMemoryGB As Double = availableMemoryBytes / (1024 * 1024 * 1024)
            Dim usedMemoryGB As Double = totalMemoryGB - availableMemoryGB
            Dim usedMemoryPercentage As Double = 100 - ((availableMemoryBytes / totalMemoryBytes) * 100)

            totalMemoryGB = Math.Round(totalMemoryGB, 2)

            Dim percentageUsed As Double = (usedMemoryGB / totalMemoryGB) * 100

            If percentageUsed > 60 Then
                BullionCurvedProgressBar1.ProgressBarColorStart = Color.FromArgb(255, 69, 58)
                BullionCurvedProgressBar1.ProgressBarColorEnd = Color.FromArgb(178, 34, 34)
            ElseIf percentageUsed > 35 Then
                BullionCurvedProgressBar1.ProgressBarColorStart = Color.FromArgb(255, 223, 0)
                BullionCurvedProgressBar1.ProgressBarColorEnd = Color.FromArgb(255, 193, 7)
            Else
                BullionCurvedProgressBar1.ProgressBarColorStart = Color.FromArgb(144, 238, 144)
                BullionCurvedProgressBar1.ProgressBarColorEnd = Color.FromArgb(34, 139, 34)
            End If

            BullionCurvedProgressBar1.TotalGB = Math.Round(totalMemoryGB)
            BullionCurvedProgressBar1.Current = usedMemoryGB
            BullionCurvedProgressBar1.SubText = String.Format("{0} GB used of {1} GB", BullionCurvedProgressBar1.Current, BullionCurvedProgressBar1.TotalGB)
            memoryUsage.Interval = 1000

            BullionCurvedProgressBar1.Invalidate()

            Dim thresholdPercentage As Integer = BullionSlider2.Value

            ' Check if the memory usage exceeds the threshold and the system has been idle for more than 1 hour
            Dim idleTime As TimeSpan = IdleTimeHelper.GetIdleTime()

            If thresholdPercentage > 0 AndAlso usedMemoryPercentage >= thresholdPercentage AndAlso idleTime.TotalMinutes >= 1 Then
                LogEvent($"Memory usage is {Math.Round(usedMemoryPercentage, 2)}% (threshold: {thresholdPercentage}%). System idle for {idleTime.TotalMinutes:F0} minutes. Initiating wipe.")

                ' Increment the counter and check if adjustment is needed
                Dim currentTime As DateTime = DateTime.Now
                If currentTime - lastWipeCheckTime <= adjustmentTimeFrame Then
                    wipeTriggerCount += 1
                Else
                    wipeTriggerCount = 1 ' Reset the counter if outside the time frame
                End If
                lastWipeCheckTime = currentTime

                ' Adjust the threshold if too many wipes occur
                If wipeTriggerCount >= wipeAdjustmentThreshold Then
                    thresholdPercentage = Math.Min(100, thresholdPercentage + 5) ' Increase by 5%, max at 100%
                    BullionSlider2.Value = thresholdPercentage ' Update slider value
                    Label3.Text = $"Wipe when above {thresholdPercentage}%"
                    SaveSettings()
                    LogEvent($"Threshold adjusted to {thresholdPercentage}% to reduce frequent wipes.")
                    wipeTriggerCount = 0 ' Reset the counter after adjustment
                End If

                ' Trigger the wipe process
                BullionButton1_Click(Nothing, Nothing)

                ' Sleep for 10 seconds to allow the wipe to run
                LogEvent("Sleeping for 10 seconds to allow the wipe process to complete.")
                Thread.Sleep(10000) ' Pause for 10 seconds
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function IsUserAdmin() As Boolean
        Dim identity = WindowsIdentity.GetCurrent()
        Dim principal = New WindowsPrincipal(identity)
        Return principal.IsInRole(WindowsBuiltInRole.Administrator)
    End Function

    Public Sub UpdateTempFileStorageUsage()
        Dim hours As Integer = 4
        tempUsage.Interval = hours * 60 * 60 * 1000

        Dim originalTempFileStorageSpaceText As String = tempFileStorageSpace.Text

        Try
            Dim tempPath As String = Path.GetTempPath()

            If Not Directory.Exists(tempPath) Then
                tempFileStorageSpace.Text = "Temporary folder not found."
                Return
            End If

            Dim rootPath As String = Path.GetPathRoot(tempPath)
            If String.IsNullOrEmpty(rootPath) Then
                tempFileStorageSpace.Text = "Unable to determine the drive for the temporary folder."
                Return
            End If

            Dim driveInfo As New DriveInfo(rootPath)

            If Not driveInfo.IsReady Then
                tempFileStorageSpace.Text = "Drive is not ready."
                Return
            End If

            Dim totalSpaceGB As Long = Math.Ceiling(driveInfo.TotalSize / (1024 * 1024 * 1024.0))
            Dim freeSpaceGB As Long = Math.Ceiling(driveInfo.AvailableFreeSpace / (1024 * 1024 * 1024.0))
            Dim usedSpaceGB As Long = totalSpaceGB - freeSpaceGB

            Dim tempFileSizeBytes As Long = GetAccessibleDirectorySize(tempPath)
            Dim tempFileSizeGB As Long = Math.Ceiling(tempFileSizeBytes / (1024 * 1024 * 1024.0))

            tempFileStorageSpace.Text = String.Format("{0} GB total, {1} GB used ({2} GB temp files)", totalSpaceGB, usedSpaceGB, tempFileSizeGB)

            If BullionMultiFlatProgressBar1 IsNot Nothing Then
                BullionMultiFlatProgressBar1.Maximum = totalSpaceGB
                BullionMultiFlatProgressBar1.CurrentUsedSpace = usedSpaceGB - 10
                BullionMultiFlatProgressBar1.CurrentTempSpace = usedSpaceGB + (tempFileSizeGB + 10)
                BullionMultiFlatProgressBar1.Invalidate()
            End If
        Catch ex As Exception
            tempFileStorageSpace.Text = "Error retrieving storage information."
        Finally
            Me.WindowState = FormWindowState.Normal
        End Try
    End Sub

    Private Function GetAccessibleDirectorySize(ByVal folderPath As String) As Long
        Dim totalSize As Long = 0

        Try
            Dim directoryInfo As New IO.DirectoryInfo(folderPath)

            totalSize += GetFilesSize(directoryInfo)

            For Each subDirectory In directoryInfo.GetDirectories()
                Try
                    totalSize += GetAccessibleDirectorySize(subDirectory.FullName)
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try

        Return totalSize
    End Function

    Private Function GetFilesSize(ByVal directoryInfo As IO.DirectoryInfo) As Long
        Dim totalSize As Long = 0

        Try
            For Each file In directoryInfo.GetFiles()
                Try
                    totalSize += file.Length
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try

        Return totalSize
    End Function


    Private Sub BullionButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BullionButton1.Click
        LogEvent("Wipe initiated.")

        Try
            BullionButton1.Enabled = False
            BullionButton1.Cursor = Cursors.WaitCursor
            Me.Cursor = Cursors.WaitCursor
            BullionButton1.Text = "Processing..."
            Application.DoEvents()

            Dim originalStatusText As String = BullionStatusStrip1.StatusText
            BullionStatusStrip1.StatusText = "Wiping process is starting. Please wait..."

            ThreadPool.QueueUserWorkItem(Sub(state)
                                             Try
                                                 If wipeDNSCache.Checked Then
                                                     LogEvent("Wiping DNS cache started.")
                                                     Invoke(Sub() BullionStatusStrip1.StatusText = "Wiping DNS cache...")
                                                     DnsCacheCleaner.ClearDnsCache()
                                                     System.Threading.Thread.Sleep(1500)
                                                     LogEvent("Wiping DNS cache finished.")
                                                 End If

                                                 If wipeStandbyMemory.Checked Then
                                                     LogEvent("Wiping standby memory started.")
                                                     Invoke(Sub() BullionStatusStrip1.StatusText = "Wiping standby memory...")
                                                     StandbyMemoryCleaner.ClearStandbyMemory()
                                                     System.Threading.Thread.Sleep(1500)
                                                     LogEvent("Wiping standby memory finished.")
                                                 End If

                                                 If wipeTempFiles.Checked Then
                                                     LogEvent("Wiping temporary files started.")
                                                     Invoke(Sub() BullionStatusStrip1.StatusText = "Wiping temporary files...")
                                                     TempFileCleaner.ClearTempFiles()
                                                     System.Threading.Thread.Sleep(1500)
                                                     LogEvent("Wiping temporary files finished.")
                                                 End If

                                                 If wipeSetMemory.Checked Then
                                                     LogEvent("Wiping working set memory started.")
                                                     Invoke(Sub() BullionStatusStrip1.StatusText = "Wiping working set memory...")
                                                     WorkingSetCleaner.CleanWorkingSetMemory()
                                                     System.Threading.Thread.Sleep(1500)
                                                     LogEvent("Wiping working set memory finished.")
                                                 End If

                                                 If wipeNetMemory.Checked Then
                                                     LogEvent("Wiping NET memory started.")
                                                     Invoke(Sub() BullionStatusStrip1.StatusText = "Wiping NET memory...")
                                                     GarbageCollector.ForceGarbageCollection()
                                                     System.Threading.Thread.Sleep(1500)
                                                     LogEvent("Wiping NET memory finished.")
                                                 End If

                                                 Invoke(Sub() BullionStatusStrip1.StatusText = "All processes completed successfully.")
                                                 System.Threading.Thread.Sleep(2000)
                                                 Invoke(Sub() BullionStatusStrip1.StatusText = originalStatusText)
                                                 LogEvent("All processes have been completed.")

                                             Catch ex As Exception
                                                 LogEvent("Error during wipe processes.")
                                                 Invoke(Sub() BullionStatusStrip1.Text = $"Error: {ex.Message}")
                                             Finally
                                                 Invoke(Sub()
                                                            BullionButton1.Text = "Wipe"
                                                            BullionButton1.Enabled = True
                                                            BullionButton1.Cursor = Cursors.Hand
                                                            Me.Cursor = Cursors.Default
                                                        End Sub)
                                             End Try
                                         End Sub)
        Catch ex As Exception
            LogEvent($"Error: {ex.Message}")
            Invoke(Sub()
                       BullionStatusStrip1.Text = "Error during wipe."
                       BullionButton1.Enabled = True
                       BullionButton1.Cursor = Cursors.Hand
                       Me.Cursor = Cursors.Default
                   End Sub)
        End Try
    End Sub


    Private Sub BullionSlider1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BullionSlider1.ValueChanged
        Dim hours As Integer = BullionSlider1.Value
        Label1.Text = String.Format("Wipe every {0}h, while away", hours)

        If hours > 0 Then
            targetTime = DateTime.Now.AddHours(hours)

            wipeInterval = hours * 3600000
            wipeTimer.Interval = wipeInterval
            wipeTimer.Start()

            UpdateCountdown()
        Else
            wipeTimer.Stop()
        End If

        SaveSettings()
    End Sub

    Private Sub UpdateCountdown()
        Dim remainingTime As TimeSpan = targetTime - DateTime.Now

        If remainingTime.TotalSeconds > 0 Then
            Dim countdownMessage As String = String.Format("Next wipe: {0:D2}:{1:D2}:{2:D2}",
                                                        remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds)
            NotifyIcon1.Text = String.Format("Memory Usage: {0}%" & Environment.NewLine & "{1}", GetMemoryUsage(), countdownMessage)

            Application.DoEvents()

            Task.Delay(1000).ContinueWith(Sub() UpdateCountdown())
        Else
            BullionSlider1_ValueChanged(Nothing, Nothing)
        End If
    End Sub

    Private Function GetMemoryUsage() As Integer
        Dim computerInfo As New Microsoft.VisualBasic.Devices.ComputerInfo()
        Dim totalMemoryBytes As ULong = computerInfo.TotalPhysicalMemory
        Dim availableMemoryBytes As ULong = computerInfo.AvailablePhysicalMemory

        Return 100 - CInt((availableMemoryBytes / totalMemoryBytes) * 100)
    End Function

    Private Sub wipeTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles wipeTimer.Tick
        wipeTimer.Stop()

        Dim idleTime As TimeSpan = IdleTimeHelper.GetIdleTime()

        If idleTime.TotalMinutes >= 1 Then
            LogEvent("Idle threshold met. Performing wipe.")
            BullionButton1_Click(Nothing, Nothing)
            wipeTimer.Start()
        Else
            LogEvent("System not idle enough for wipe. Resetting wipe timer.")
            wipeTimer.Start()
        End If
    End Sub

    Public Class IdleTimeHelper
        <DllImport("user32.dll", SetLastError:=True)>
        Private Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
        End Function

        <StructLayout(LayoutKind.Sequential)>
        Public Structure LASTINPUTINFO
            Public cbSize As UInteger
            Public dwTime As UInteger
        End Structure

        Public Shared Function GetIdleTime() As TimeSpan
            Dim lii As New LASTINPUTINFO()
            lii.cbSize = CUInt(Marshal.SizeOf(GetType(LASTINPUTINFO)))

            If GetLastInputInfo(lii) Then
                Dim currentTickCount As UInteger = CUInt(Environment.TickCount And &HFFFFFFFFUI)
                Dim lastInputTickCount As UInteger = lii.dwTime

                Dim millis As UInteger
                If currentTickCount >= lastInputTickCount Then
                    millis = currentTickCount - lastInputTickCount
                Else
                    millis = (UInteger.MaxValue - lastInputTickCount) + currentTickCount
                End If

                Return TimeSpan.FromMilliseconds(millis)
            Else
                Return TimeSpan.Zero
            End If
        End Function
    End Class

    Private Sub BullionSlider2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BullionSlider2.ValueChanged
        Dim thresholdPercentage As Integer = BullionSlider2.Value
        Label3.Text = $"Wipe when above {thresholdPercentage}%"
        SaveSettings()
        LogEvent($"Memory threshold updated to {thresholdPercentage}%.")
    End Sub

    Private Sub HandleHighMemoryUsage(ByVal usedMemoryPercentage As Integer, ByVal thresholdPercentage As Integer)
        BullionStatusStrip1.Text = String.Format("Memory usage is at {0}%. Initiating cleanup...", usedMemoryPercentage)

        BullionButton1_Click(Nothing, Nothing)
    End Sub

    Private Sub CheckBoxChanged(ByVal sender As Object, ByVal e As EventArgs) Handles wipeDNSCache.CheckedChanged, wipeStandbyMemory.CheckedChanged, wipeTempFiles.CheckedChanged, wipeSetMemory.CheckedChanged, wipeNetMemory.CheckedChanged
        SaveSettings()
    End Sub

    Private Sub BullionMultiFlatProgressBar1_Click(sender As Object, e As EventArgs) Handles BullionMultiFlatProgressBar1.Click
        log.Show()
    End Sub
End Class