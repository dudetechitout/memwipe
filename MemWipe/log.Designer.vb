<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class log
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BullionTheme1 = New MemWipe.BullionTheme()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.BullionWindowControls1 = New MemWipe.BullionWindowControls()
        Me.SuspendLayout()
        '
        'BullionTheme1
        '
        Me.BullionTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BullionTheme1.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.BullionTheme1.Location = New System.Drawing.Point(0, 0)
        Me.BullionTheme1.Name = "BullionTheme1"
        Me.BullionTheme1.Size = New System.Drawing.Size(770, 450)
        Me.BullionTheme1.TabIndex = 0
        Me.BullionTheme1.Text = "Log"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 57)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(746, 381)
        Me.ListBox1.TabIndex = 1
        '
        'BullionWindowControls1
        '
        Me.BullionWindowControls1.Location = New System.Drawing.Point(694, 1)
        Me.BullionWindowControls1.Name = "BullionWindowControls1"
        Me.BullionWindowControls1.Size = New System.Drawing.Size(75, 21)
        Me.BullionWindowControls1.TabIndex = 2
        Me.BullionWindowControls1.Text = "BullionWindowControls1"
        '
        'log
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 450)
        Me.Controls.Add(Me.BullionWindowControls1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.BullionTheme1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "log"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "log"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BullionTheme1 As BullionTheme
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents BullionWindowControls1 As BullionWindowControls
End Class
