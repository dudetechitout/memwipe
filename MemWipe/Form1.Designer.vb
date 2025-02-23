<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.tempFileStorageSpace = New System.Windows.Forms.Label()
        Me.memoryUsage = New System.Windows.Forms.Timer(Me.components)
        Me.tempUsage = New System.Windows.Forms.Timer(Me.components)
        Me.wipeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.BullionMultiFlatProgressBar1 = New MemWipe.BullionMultiFlatProgressBar()
        Me.BullionStatusStrip1 = New MemWipe.BullionStatusStrip()
        Me.BullionGroupBox2 = New MemWipe.BullionGroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BullionSlider2 = New MemWipe.BullionSlider()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BullionSlider1 = New MemWipe.BullionSlider()
        Me.BullionGroupBox1 = New MemWipe.BullionGroupBox()
        Me.wipeNetMemory = New MemWipe.BullionCheckBox()
        Me.wipeSetMemory = New MemWipe.BullionCheckBox()
        Me.wipeTempFiles = New MemWipe.BullionCheckBox()
        Me.wipeStandbyMemory = New MemWipe.BullionCheckBox()
        Me.wipeDNSCache = New MemWipe.BullionCheckBox()
        Me.BullionWindowControls1 = New MemWipe.BullionWindowControls()
        Me.settingsButton = New MemWipe.BullionButton()
        Me.BullionButton1 = New MemWipe.BullionButton()
        Me.BullionCurvedProgressBar1 = New MemWipe.BullionCurvedProgressBar()
        Me.BullionTheme1 = New MemWipe.BullionTheme()
        Me.BullionGroupBox2.SuspendLayout()
        Me.BullionGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tempFileStorageSpace
        '
        Me.tempFileStorageSpace.AutoSize = True
        Me.tempFileStorageSpace.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.tempFileStorageSpace.Location = New System.Drawing.Point(12, 385)
        Me.tempFileStorageSpace.Name = "tempFileStorageSpace"
        Me.tempFileStorageSpace.Size = New System.Drawing.Size(264, 24)
        Me.tempFileStorageSpace.TabIndex = 8
        Me.tempFileStorageSpace.Text = "500 GB total, 150 GB used (8.2 GB temp files)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'wipeTimer
        '
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'BullionMultiFlatProgressBar1
        '
        Me.BullionMultiFlatProgressBar1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.BullionMultiFlatProgressBar1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.BullionMultiFlatProgressBar1.BorderThickness = 1
        Me.BullionMultiFlatProgressBar1.CurrentTempSpace = 0R
        Me.BullionMultiFlatProgressBar1.CurrentUsedSpace = 0R
        Me.BullionMultiFlatProgressBar1.HighlightColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BullionMultiFlatProgressBar1.Location = New System.Drawing.Point(12, 359)
        Me.BullionMultiFlatProgressBar1.Maximum = 100.0R
        Me.BullionMultiFlatProgressBar1.Name = "BullionMultiFlatProgressBar1"
        Me.BullionMultiFlatProgressBar1.ProgressTempSpace = 0R
        Me.BullionMultiFlatProgressBar1.ProgressTextFont = New System.Drawing.Font("Verdana", 7.0!)
        Me.BullionMultiFlatProgressBar1.ProgressUsedSpace = 0R
        Me.BullionMultiFlatProgressBar1.Size = New System.Drawing.Size(295, 23)
        Me.BullionMultiFlatProgressBar1.TabIndex = 10
        Me.BullionMultiFlatProgressBar1.TempSpaceColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.BullionMultiFlatProgressBar1.Text = "BullionMultiFlatProgressBar1"
        Me.BullionMultiFlatProgressBar1.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.BullionMultiFlatProgressBar1.UsedSpaceColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(240, Byte), Integer))
        '
        'BullionStatusStrip1
        '
        Me.BullionStatusStrip1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BullionStatusStrip1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BullionStatusStrip1.BorderThickness = 0
        Me.BullionStatusStrip1.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.BullionStatusStrip1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.BullionStatusStrip1.Location = New System.Drawing.Point(1, 449)
        Me.BullionStatusStrip1.Name = "BullionStatusStrip1"
        Me.BullionStatusStrip1.Size = New System.Drawing.Size(561, 23)
        Me.BullionStatusStrip1.StatusFont = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BullionStatusStrip1.StatusText = "Built by Dude Tech It Out | <3 it? Support with a donation!"
        Me.BullionStatusStrip1.TabIndex = 9
        Me.BullionStatusStrip1.Text = "BullionStatusStrip1"
        Me.BullionStatusStrip1.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        '
        'BullionGroupBox2
        '
        Me.BullionGroupBox2.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.BullionGroupBox2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.BullionGroupBox2.Controls.Add(Me.Label3)
        Me.BullionGroupBox2.Controls.Add(Me.BullionSlider2)
        Me.BullionGroupBox2.Controls.Add(Me.Label1)
        Me.BullionGroupBox2.Controls.Add(Me.BullionSlider1)
        Me.BullionGroupBox2.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.BullionGroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.BullionGroupBox2.HeaderBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BullionGroupBox2.HeaderBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BullionGroupBox2.HeaderFont = New System.Drawing.Font("Verdana", 7.0!)
        Me.BullionGroupBox2.HeaderTextColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.BullionGroupBox2.Location = New System.Drawing.Point(334, 282)
        Me.BullionGroupBox2.Name = "BullionGroupBox2"
        Me.BullionGroupBox2.Size = New System.Drawing.Size(217, 155)
        Me.BullionGroupBox2.TabIndex = 6
        Me.BullionGroupBox2.TabStop = False
        Me.BullionGroupBox2.Text = "Auto Optimization Settings"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.DarkGray
        Me.Label3.Location = New System.Drawing.Point(13, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 12)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Wipe when above 0%"
        '
        'BullionSlider2
        '
        Me.BullionSlider2.HoverThumbColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.BullionSlider2.Location = New System.Drawing.Point(16, 117)
        Me.BullionSlider2.Maximum = 100
        Me.BullionSlider2.Minimum = 0
        Me.BullionSlider2.Name = "BullionSlider2"
        Me.BullionSlider2.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.BullionSlider2.Size = New System.Drawing.Size(180, 30)
        Me.BullionSlider2.TabIndex = 8
        Me.BullionSlider2.Text = "BullionSlider2"
        Me.BullionSlider2.ThumbColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.BullionSlider2.ThumbSize = 12
        Me.BullionSlider2.TrackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.BullionSlider2.TrackHeight = 6
        Me.BullionSlider2.Value = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.DarkGray
        Me.Label1.Location = New System.Drawing.Point(13, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Wipe every 0h, while away"
        '
        'BullionSlider1
        '
        Me.BullionSlider1.HoverThumbColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.BullionSlider1.Location = New System.Drawing.Point(16, 55)
        Me.BullionSlider1.Maximum = 24
        Me.BullionSlider1.Minimum = 0
        Me.BullionSlider1.Name = "BullionSlider1"
        Me.BullionSlider1.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.BullionSlider1.Size = New System.Drawing.Size(180, 30)
        Me.BullionSlider1.TabIndex = 6
        Me.BullionSlider1.Text = "BullionSlider1"
        Me.BullionSlider1.ThumbColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.BullionSlider1.ThumbSize = 12
        Me.BullionSlider1.TrackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.BullionSlider1.TrackHeight = 6
        Me.BullionSlider1.Value = 0
        '
        'BullionGroupBox1
        '
        Me.BullionGroupBox1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.BullionGroupBox1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.BullionGroupBox1.Controls.Add(Me.wipeNetMemory)
        Me.BullionGroupBox1.Controls.Add(Me.wipeSetMemory)
        Me.BullionGroupBox1.Controls.Add(Me.wipeTempFiles)
        Me.BullionGroupBox1.Controls.Add(Me.wipeStandbyMemory)
        Me.BullionGroupBox1.Controls.Add(Me.wipeDNSCache)
        Me.BullionGroupBox1.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.BullionGroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.BullionGroupBox1.HeaderBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BullionGroupBox1.HeaderBorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BullionGroupBox1.HeaderFont = New System.Drawing.Font("Verdana", 7.0!)
        Me.BullionGroupBox1.HeaderTextColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.BullionGroupBox1.Location = New System.Drawing.Point(334, 51)
        Me.BullionGroupBox1.Name = "BullionGroupBox1"
        Me.BullionGroupBox1.Size = New System.Drawing.Size(217, 217)
        Me.BullionGroupBox1.TabIndex = 5
        Me.BullionGroupBox1.TabStop = False
        Me.BullionGroupBox1.Text = "Wipe Settings"
        '
        'wipeNetMemory
        '
        Me.wipeNetMemory.BackgroundColor = System.Drawing.Color.Transparent
        Me.wipeNetMemory.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.wipeNetMemory.BoxBorderThickness = 1
        Me.wipeNetMemory.CheckBoxSize = 14
        Me.wipeNetMemory.CheckColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.wipeNetMemory.Checked = True
        Me.wipeNetMemory.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.wipeNetMemory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.wipeNetMemory.HoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.wipeNetMemory.Location = New System.Drawing.Point(16, 184)
        Me.wipeNetMemory.Name = "wipeNetMemory"
        Me.wipeNetMemory.Size = New System.Drawing.Size(139, 20)
        Me.wipeNetMemory.TabIndex = 4
        Me.wipeNetMemory.Text = "Wipe .NET Memory"
        Me.wipeNetMemory.TextColor = System.Drawing.Color.DarkGray
        '
        'wipeSetMemory
        '
        Me.wipeSetMemory.BackgroundColor = System.Drawing.Color.Transparent
        Me.wipeSetMemory.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.wipeSetMemory.BoxBorderThickness = 1
        Me.wipeSetMemory.CheckBoxSize = 14
        Me.wipeSetMemory.CheckColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.wipeSetMemory.Checked = True
        Me.wipeSetMemory.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.wipeSetMemory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.wipeSetMemory.HoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.wipeSetMemory.Location = New System.Drawing.Point(16, 146)
        Me.wipeSetMemory.Name = "wipeSetMemory"
        Me.wipeSetMemory.Size = New System.Drawing.Size(139, 20)
        Me.wipeSetMemory.TabIndex = 3
        Me.wipeSetMemory.Text = "Wipe Set Memory"
        Me.wipeSetMemory.TextColor = System.Drawing.Color.DarkGray
        '
        'wipeTempFiles
        '
        Me.wipeTempFiles.BackgroundColor = System.Drawing.Color.Transparent
        Me.wipeTempFiles.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.wipeTempFiles.BoxBorderThickness = 1
        Me.wipeTempFiles.CheckBoxSize = 14
        Me.wipeTempFiles.CheckColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.wipeTempFiles.Checked = False
        Me.wipeTempFiles.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.wipeTempFiles.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.wipeTempFiles.HoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.wipeTempFiles.Location = New System.Drawing.Point(16, 109)
        Me.wipeTempFiles.Name = "wipeTempFiles"
        Me.wipeTempFiles.Size = New System.Drawing.Size(139, 20)
        Me.wipeTempFiles.TabIndex = 2
        Me.wipeTempFiles.Text = "Wipe Temp Files"
        Me.wipeTempFiles.TextColor = System.Drawing.Color.DarkGray
        '
        'wipeStandbyMemory
        '
        Me.wipeStandbyMemory.BackgroundColor = System.Drawing.Color.Transparent
        Me.wipeStandbyMemory.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.wipeStandbyMemory.BoxBorderThickness = 1
        Me.wipeStandbyMemory.CheckBoxSize = 14
        Me.wipeStandbyMemory.CheckColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.wipeStandbyMemory.Checked = True
        Me.wipeStandbyMemory.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.wipeStandbyMemory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.wipeStandbyMemory.HoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.wipeStandbyMemory.Location = New System.Drawing.Point(16, 74)
        Me.wipeStandbyMemory.Name = "wipeStandbyMemory"
        Me.wipeStandbyMemory.Size = New System.Drawing.Size(139, 20)
        Me.wipeStandbyMemory.TabIndex = 1
        Me.wipeStandbyMemory.Text = "Wipe Standby Memory"
        Me.wipeStandbyMemory.TextColor = System.Drawing.Color.DarkGray
        '
        'wipeDNSCache
        '
        Me.wipeDNSCache.BackgroundColor = System.Drawing.Color.Transparent
        Me.wipeDNSCache.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.wipeDNSCache.BoxBorderThickness = 1
        Me.wipeDNSCache.CheckBoxSize = 14
        Me.wipeDNSCache.CheckColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.wipeDNSCache.Checked = True
        Me.wipeDNSCache.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.wipeDNSCache.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.wipeDNSCache.HoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.wipeDNSCache.Location = New System.Drawing.Point(16, 39)
        Me.wipeDNSCache.Name = "wipeDNSCache"
        Me.wipeDNSCache.Size = New System.Drawing.Size(139, 20)
        Me.wipeDNSCache.TabIndex = 0
        Me.wipeDNSCache.Text = "Wipe DNS Cache"
        Me.wipeDNSCache.TextColor = System.Drawing.Color.DarkGray
        '
        'BullionWindowControls1
        '
        Me.BullionWindowControls1.Location = New System.Drawing.Point(487, 1)
        Me.BullionWindowControls1.Name = "BullionWindowControls1"
        Me.BullionWindowControls1.Size = New System.Drawing.Size(75, 18)
        Me.BullionWindowControls1.TabIndex = 4
        Me.BullionWindowControls1.Text = "BullionWindowControls1"
        '
        'settingsButton
        '
        Me.settingsButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settingsButton.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.settingsButton.Image = Nothing
        Me.settingsButton.Location = New System.Drawing.Point(172, 414)
        Me.settingsButton.Name = "settingsButton"
        Me.settingsButton.Size = New System.Drawing.Size(135, 23)
        Me.settingsButton.TabIndex = 3
        Me.settingsButton.Text = "Settings"
        '
        'BullionButton1
        '
        Me.BullionButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BullionButton1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.BullionButton1.Image = Nothing
        Me.BullionButton1.Location = New System.Drawing.Point(12, 414)
        Me.BullionButton1.Name = "BullionButton1"
        Me.BullionButton1.Size = New System.Drawing.Size(135, 23)
        Me.BullionButton1.TabIndex = 2
        Me.BullionButton1.Text = "Wipe"
        '
        'BullionCurvedProgressBar1
        '
        Me.BullionCurvedProgressBar1.Current = 0R
        Me.BullionCurvedProgressBar1.InnerBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.BullionCurvedProgressBar1.Location = New System.Drawing.Point(12, 51)
        Me.BullionCurvedProgressBar1.Name = "BullionCurvedProgressBar1"
        Me.BullionCurvedProgressBar1.ProgressBackgroundColor = System.Drawing.Color.LightGray
        Me.BullionCurvedProgressBar1.ProgressBarColorEnd = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.BullionCurvedProgressBar1.ProgressBarColorStart = System.Drawing.Color.FromArgb(CType(CType(144, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.BullionCurvedProgressBar1.ProgressBarTempColorEnd = System.Drawing.Color.MistyRose
        Me.BullionCurvedProgressBar1.ProgressBarTempColorStart = System.Drawing.Color.LightCoral
        Me.BullionCurvedProgressBar1.ProgressTextColor = System.Drawing.Color.DarkGray
        Me.BullionCurvedProgressBar1.ProgressTextFont = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BullionCurvedProgressBar1.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BullionCurvedProgressBar1.Size = New System.Drawing.Size(295, 295)
        Me.BullionCurvedProgressBar1.SubText = "Available"
        Me.BullionCurvedProgressBar1.SubTextFont = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BullionCurvedProgressBar1.TabIndex = 1
        Me.BullionCurvedProgressBar1.Text = "BullionCurvedProgressBar1"
        Me.BullionCurvedProgressBar1.TotalGB = 100.0R
        '
        'BullionTheme1
        '
        Me.BullionTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BullionTheme1.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.BullionTheme1.Location = New System.Drawing.Point(0, 0)
        Me.BullionTheme1.Name = "BullionTheme1"
        Me.BullionTheme1.Size = New System.Drawing.Size(563, 473)
        Me.BullionTheme1.TabIndex = 0
        Me.BullionTheme1.Text = "MemWipe"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 473)
        Me.Controls.Add(Me.BullionMultiFlatProgressBar1)
        Me.Controls.Add(Me.BullionStatusStrip1)
        Me.Controls.Add(Me.tempFileStorageSpace)
        Me.Controls.Add(Me.BullionGroupBox2)
        Me.Controls.Add(Me.BullionGroupBox1)
        Me.Controls.Add(Me.BullionWindowControls1)
        Me.Controls.Add(Me.settingsButton)
        Me.Controls.Add(Me.BullionButton1)
        Me.Controls.Add(Me.BullionCurvedProgressBar1)
        Me.Controls.Add(Me.BullionTheme1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MemWipe"
        Me.BullionGroupBox2.ResumeLayout(False)
        Me.BullionGroupBox2.PerformLayout()
        Me.BullionGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BullionTheme1 As MemWipe.BullionTheme
    Friend WithEvents BullionCurvedProgressBar1 As MemWipe.BullionCurvedProgressBar
    Friend WithEvents BullionButton1 As MemWipe.BullionButton
    Friend WithEvents settingsButton As MemWipe.BullionButton
    Friend WithEvents BullionWindowControls1 As MemWipe.BullionWindowControls
    Friend WithEvents BullionGroupBox1 As MemWipe.BullionGroupBox
    Friend WithEvents wipeDNSCache As MemWipe.BullionCheckBox
    Friend WithEvents wipeNetMemory As MemWipe.BullionCheckBox
    Friend WithEvents wipeSetMemory As MemWipe.BullionCheckBox
    Friend WithEvents wipeTempFiles As MemWipe.BullionCheckBox
    Friend WithEvents wipeStandbyMemory As MemWipe.BullionCheckBox
    Friend WithEvents BullionSlider1 As MemWipe.BullionSlider
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BullionGroupBox2 As MemWipe.BullionGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BullionSlider2 As MemWipe.BullionSlider
    Friend WithEvents tempFileStorageSpace As System.Windows.Forms.Label
    Friend WithEvents BullionStatusStrip1 As MemWipe.BullionStatusStrip
    Friend WithEvents memoryUsage As System.Windows.Forms.Timer
    Friend WithEvents tempUsage As System.Windows.Forms.Timer
    Friend WithEvents BullionMultiFlatProgressBar1 As MemWipe.BullionMultiFlatProgressBar
    Friend WithEvents wipeTimer As System.Windows.Forms.Timer
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
End Class
