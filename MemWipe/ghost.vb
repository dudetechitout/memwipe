Imports System.ComponentModel
Imports System.Drawing.Drawing2D

'Creator: Aeonhack
'Date: 8/8/2010
'Version: 1.0
'This is a modified version of the "FutureTheme".


Class BullionTheme
    Inherits Control
    Protected ReadOnly Property IsInDesignMode As Boolean
        Get
            Return LicenseManager.UsageMode = LicenseUsageMode.Designtime OrElse DesignMode
        End Get
    End Property


    Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
        MyBase.OnHandleCreated(e)

        'If IsInDesignMode Then Return ' Skip runtime-specific code in design mode

        Dock = DockStyle.Fill
        If TypeOf Parent Is Form Then
            With DirectCast(Parent, Form)
                .FormBorderStyle = FormBorderStyle.None
                .BackColor = C1
                .ForeColor = Color.FromArgb(170, 170, 170)
            End With
        End If
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        'If IsInDesignMode Then Return ' Skip runtime-specific behavior in design mode

        If New Rectangle(Parent.Location.X, Parent.Location.Y, Width, 22).IntersectsWith(New Rectangle(MousePosition.X, MousePosition.Y, 1, 1)) Then
            Capture = False
            Dim M As Message = Message.Create(Parent.Handle, 161, New IntPtr(2), IntPtr.Zero)
            DefWndProc(M)
        End If

        MyBase.OnMouseDown(e)
    End Sub

    Dim G As Graphics, B As Bitmap, R1, R2 As Rectangle
    Dim C1, C2, C3 As Color, P1, P2, P3, P4 As Pen, B1 As SolidBrush, B2, B3 As LinearGradientBrush

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)

        ' Initialize design-safe properties
        C1 = Color.FromArgb(248, 248, 248) ' Background
        C2 = Color.FromArgb(255, 255, 255) ' Highlight
        C3 = Color.FromArgb(235, 235, 235) ' Shadow
        P1 = New Pen(Color.FromArgb(215, 215, 215)) ' Border
        P4 = New Pen(Color.FromArgb(230, 230, 230)) ' Diagonal Lines
        P2 = New Pen(C1)
        P3 = New Pen(C2)
        B1 = New SolidBrush(Color.FromArgb(170, 170, 170))
        Font = New Font("Verdana", 7.0F)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If Height > 0 Then
            R1 = New Rectangle(0, 2, Width, 18)
            R2 = New Rectangle(0, 21, Width, 10)
            B2 = New LinearGradientBrush(R1, C1, C3, 90.0F)
            B3 = New LinearGradientBrush(R2, Color.FromArgb(18, 0, 0, 0), Color.Transparent, 90.0F)
            If Not IsInDesignMode Then Invalidate()
        End If
        MyBase.OnSizeChanged(e)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If IsInDesignMode Then
            'e.Graphics.DrawString("BullionTheme (Design Mode)", Me.Font, Brushes.Gray, New PointF(5, 5))
            'Return
        End If

        B = New Bitmap(Width, Height)
        G = Graphics.FromImage(B)

        G.Clear(C1)

        ' Draw background, diagonal lines, and other details
        For I As Integer = 0 To Width + 17 Step 4
            G.DrawLine(P4, I, 21, I - 17, 37)
            G.DrawLine(P4, I - 1, 21, I - 16, 37)
        Next

        G.FillRectangle(B3, R2)
        G.FillRectangle(B2, R1)
        G.DrawString(Text, Font, B1, 5, 5)
        G.DrawRectangle(P2, 1, 1, Width - 3, 19)
        G.DrawRectangle(P3, 1, 39, Width - 3, Height - 41)
        G.DrawRectangle(P1, 0, 0, Width - 1, Height - 1)
        G.DrawLine(P1, 0, 21, Width, 21)
        G.DrawLine(P1, 0, 38, Width, 38)

        e.Graphics.DrawImage(B, 0, 0)
        G.Dispose()
        B.Dispose()
    End Sub

End Class
Class BullionButton
    Inherits Control
    Protected ReadOnly Property IsInDesignMode As Boolean
        Get
            Return LicenseManager.UsageMode = LicenseUsageMode.Designtime OrElse DesignMode
        End Get
    End Property




    Private _Image As Image, ImageSet As Boolean
    Public Property Image() As Image
        Get
            Return _Image
        End Get
        Set(ByVal v As Image)
            _Image = v
            ImageSet = v IsNot Nothing
        End Set
    End Property


    Dim B As Bitmap, G As Graphics, R1 As Rectangle
    Dim C1, C2, C3, C4 As Color, P1, P2, P3, P4 As Pen, B1, B2, B5 As Brush, B3, B4 As LinearGradientBrush

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
        C1 = Color.FromArgb(244, 244, 244) 'Background
        C2 = Color.FromArgb(220, 220, 220) 'Highlight
        C3 = Color.FromArgb(248, 248, 248) 'Lesser Highlight
        C4 = Color.FromArgb(24, Color.Black)
        P1 = New Pen(Color.FromArgb(255, 255, 255)) 'Shadow
        P2 = New Pen(Color.FromArgb(40, Color.White))
        P3 = New Pen(Color.FromArgb(20, Color.White))
        P4 = New Pen(Color.FromArgb(10, Color.Black)) 'Down-Left
        B1 = New SolidBrush(C1)
        B2 = New SolidBrush(C3)
        B5 = New SolidBrush(Color.FromArgb(170, 170, 170)) 'Text Color
        Font = New Font("Verdana", 8.0F)
    End Sub

    Private State As Integer
    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        State = 0
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        State = 1
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        State = 1
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        State = 2
        Invalidate()
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        R1 = New Rectangle(2, 2, Width - 4, 4)
        B3 = New LinearGradientBrush(ClientRectangle, C3, C2, 90.0F)
        B4 = New LinearGradientBrush(R1, C4, Color.Transparent, 90.0F)
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If IsInDesignMode Then
            'Return
        End If

        B = New Bitmap(Width, Height)
        G = Graphics.FromImage(B)

        G.FillRectangle(B3, ClientRectangle)

        Select Case State
            Case 0 'Up
                G.FillRectangle(B2, 1, 1, Width - 2, Height - 2)
                G.DrawRectangle(P4, 2, 2, Width - 5, Height - 5)
            Case 1 'Over
                G.FillRectangle(B1, 1, 1, Width - 2, Height - 2)
                G.DrawRectangle(P4, 2, 2, Width - 5, Height - 5)
            Case 2 'Down
                G.FillRectangle(B1, 1, 1, Width - 2, Height - 2)
                G.FillRectangle(B4, R1)
                G.DrawLine(P4, 2, 2, 2, Height - 3)
        End Select

        Dim S As SizeF = G.MeasureString(Text, Font)
        G.DrawString(Text, Font, B5, Convert.ToInt32(Width / 2 - S.Width / 2), Convert.ToInt32(Height / 2 - S.Height / 2))

        G.DrawRectangle(P1, 1, 1, Width - 3, Height - 3)

        If ImageSet Then G.DrawImage(_Image, 5, CInt(Height / 2 - _Image.Height / 2), _Image.Width, _Image.Height)

        e.Graphics.DrawImage(B, 0, 0)
        G.Dispose()
        B.Dispose()
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

End Class
Class BullionProgressBar
    Inherits Control

#Region " Properties "
    Private _Maximum As Double = 100
    Public Property Maximum() As Double
        Get
            Return _Maximum
        End Get
        Set(ByVal v As Double)
            _Maximum = v
            Progress = _Current / v * 100
            Invalidate()
        End Set
    End Property
    Private _Current As Double
    Public Property Current() As Double
        Get
            Return _Current
        End Get
        Set(ByVal v As Double)
            _Current = v
            Progress = v / _Maximum * 100
            Invalidate()
        End Set
    End Property
    Private _Progress As Integer
    Public Property Progress() As Double
        Get
            Return _Progress
        End Get
        Set(ByVal v As Double)
            If v < 0 Then v = 0 Else If v > 100 Then v = 100
            _Progress = Convert.ToInt32(v)
            _Current = v * 0.01 * _Maximum
            If Width > 0 Then UpdateProgress()
            Invalidate()
        End Set
    End Property

    Dim C2 As Color = Color.PaleTurquoise  'Dark Color
    Public Property Color1() As Color
        Get
            Return C2
        End Get
        Set(ByVal v As Color)
            C2 = v
            UpdateColors()
            Invalidate()
        End Set
    End Property
    Dim C3 As Color = Color.AliceBlue  'Light color
    Public Property Color2() As Color
        Get
            Return C3
        End Get
        Set(ByVal v As Color)
            C3 = v
            UpdateColors()
            Invalidate()
        End Set
    End Property

#End Region

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
    End Sub

    Dim G As Graphics, B As Bitmap, R1, R2 As Rectangle, X As ColorBlend
    Dim C1 As Color, P1, P2, P3 As Pen, B1, B2 As LinearGradientBrush, B3 As SolidBrush
    Sub New()

        C1 = Color.FromArgb(246, 246, 246) 'Background
        P1 = New Pen(Color.FromArgb(70, Color.White), 2)
        P2 = New Pen(C2)
        P3 = New Pen(Color.FromArgb(255, 255, 255)) 'Highlight
        B3 = New SolidBrush(Color.FromArgb(100, Color.White))
        X = New ColorBlend(4)
        X.Colors = {C2, C3, C3, C2}
        X.Positions = {0.0F, 0.1F, 0.9F, 1.0F}
        R2 = New Rectangle(2, 2, 2, 2)
        B2 = New LinearGradientBrush(R2, Nothing, Nothing, 180.0F)
        B2.InterpolationColors = X

    End Sub

    Sub UpdateColors()
        P2.Color = C2
        X.Colors = {C2, C3, C3, C2}
        B2.InterpolationColors = X
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
        R1 = New Rectangle(0, 1, Width, 4)
        B1 = New LinearGradientBrush(R1, Color.FromArgb(24, Color.Black), Color.Transparent, 90.0F)
        UpdateProgress()
        Invalidate()
        MyBase.OnSizeChanged(e)
    End Sub

    Sub UpdateProgress()
        If _Progress = 0 Then Return
        R2 = New Rectangle(2, 2, Convert.ToInt32((Width - 4) * (_Progress * 0.01)), Height - 4)
        B2 = New LinearGradientBrush(R2, Nothing, Nothing, 180.0F)
        B2.InterpolationColors = X
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        B = New Bitmap(Width, Height)
        G = Graphics.FromImage(B)

        G.Clear(C1)

        G.FillRectangle(B1, R1)

        If _Progress > 0 Then
            G.FillRectangle(B2, R2)

            G.FillRectangle(B3, 2, 3, R2.Width, 4)
            G.DrawRectangle(P1, 4, 4, R2.Width - 4, Height - 8)

            G.DrawRectangle(P2, 2, 2, R2.Width - 1, Height - 5)
        End If

        G.DrawRectangle(P3, 0, 0, Width - 1, Height - 1)

        e.Graphics.DrawImage(B, 0, 0)
        G.Dispose()
        B.Dispose()
    End Sub

End Class
Class BullionSeperator
    Inherits Control

    Private _Orientation As Orientation
    Public Property Orientation() As Orientation
        Get
            Return _Orientation
        End Get
        Set(ByVal v As Orientation)
            _Orientation = v
            UpdateOffset()
            Invalidate()
        End Set
    End Property

    Dim G As Graphics, B As Bitmap, I As Integer
    Dim C1 As Color, P1, P2 As Pen
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
        C1 = Color.FromArgb(248, 248, 248) 'Background
        P1 = New Pen(Color.FromArgb(230, 230, 230)) 'Shadow
        P2 = New Pen(Color.FromArgb(255, 255, 255)) 'Highlight
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        UpdateOffset()
        MyBase.OnSizeChanged(e)
    End Sub

    Sub UpdateOffset()
        I = Convert.ToInt32(If(_Orientation = 0, Height / 2 - 1, Width / 2 - 1))
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        B = New Bitmap(Width, Height)
        G = Graphics.FromImage(B)

        G.Clear(C1)

        If _Orientation = 0 Then
            G.DrawLine(P1, 0, I, Width, I)
            G.DrawLine(P2, 0, I + 1, Width, I + 1)
        Else
            G.DrawLine(P2, I, 0, I, Height)
            G.DrawLine(P1, I + 1, 0, I + 1, Height)
        End If

        e.Graphics.DrawImage(B, 0, 0)
        G.Dispose()
        B.Dispose()
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
    End Sub

End Class
Class BullionWindowControls
    Inherits Control

    Private closeButtonRect As Rectangle
    Private minimizeButtonRect As Rectangle
    Private headerRect As Rectangle
    Private C1, C2, C3 As Color
    Private currentHover As String = "" ' Tracks hover state ("close", "minimize", or "")

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)

        ' Use the same colors and styles as BullionTheme
        C1 = Color.FromArgb(248, 248, 248) ' Background
        C2 = Color.FromArgb(255, 255, 255) ' Highlight
        C3 = Color.FromArgb(235, 235, 235) ' Shadow

        Height = 30 ' Fixed height for the header
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)

        'If DesignMode Then Return

        If Width > 0 And Height > 0 Then
            ' Define header and button rectangles
            headerRect = New Rectangle(0, 0, Width, Height)
            closeButtonRect = New Rectangle(Width - 20, 0, 18, 18)
            minimizeButtonRect = New Rectangle(Width - 40, 3, 20, 20)
        End If

        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)

        'If DesignMode Then Return

        Dim newHover As String = ""
        Dim newCursor As Cursor = Cursors.Default ' Default cursor

        If closeButtonRect.Contains(e.Location) Then
            newHover = "close"
            newCursor = Cursors.Hand ' Pointer cursor for close button
        ElseIf minimizeButtonRect.Contains(e.Location) Then
            newHover = "minimize"
            newCursor = Cursors.Hand ' Pointer cursor for minimize button
        End If

        ' Update hover state and cursor only if changed
        If currentHover <> newHover Then
            currentHover = newHover
            Cursor = newCursor ' Set the cursor
            Invalidate() ' Trigger redraw only if hover state changes
        End If
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)

        If currentHover <> "" Then
            currentHover = ""
            Invalidate() ' Reset hover state when mouse leaves
        End If
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        'If DesignMode Then Return

        If Parent IsNot Nothing AndAlso TypeOf Parent Is Form Then
            Dim parentForm As Form = DirectCast(Parent, Form)

            If closeButtonRect.Contains(e.Location) Then
                parentForm.Hide() ' Close the form
                parentForm.ShowInTaskbar = False
            ElseIf minimizeButtonRect.Contains(e.Location) Then
                parentForm.WindowState = FormWindowState.Minimized ' Minimize the form
            End If
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim G As Graphics = e.Graphics

        ' Prevent drawing during design mode
        If DesignMode Then
            'G.DrawString("BullionWindowControls", Font, Brushes.Gray, New PointF(5, 5))
            'Return
        End If

        ' Draw the header background
        Using headerGradient As New LinearGradientBrush(headerRect, C1, C3, LinearGradientMode.Vertical)
            G.FillRectangle(headerGradient, headerRect)
        End Using

        ' Draw Minimize Button
        DrawMinimizeButton(G, minimizeButtonRect)

        ' Draw Close Button
        DrawCloseButton(G, closeButtonRect)
    End Sub

    Private Sub DrawMinimizeButton(ByVal G As Graphics, ByVal rect As Rectangle)
        ' Disable anti-aliasing for sharp lines
        G.SmoothingMode = Drawing2D.SmoothingMode.None

        ' Define the pen for the minimize line
        Dim lineColor As Color = If(currentHover = "minimize", Color.Gray, Color.DarkGray)
        Dim lineWidth As Integer = 2 ' Fixed integer width for sharpness
        Using linePen As New Pen(lineColor, lineWidth)
            linePen.Alignment = Drawing2D.PenAlignment.Center ' Align the pen to the pixel grid

            ' Calculate the exact coordinates for the horizontal line
            Dim centerY As Integer = rect.Y + (rect.Height \ 2) ' Integer division for exact middle
            Dim startX As Integer = rect.X + 5
            Dim endX As Integer = rect.X + rect.Width - 5

            ' Draw the horizontal line
            G.DrawLine(linePen, startX, centerY, endX, centerY)
        End Using
    End Sub

    Private Sub DrawCloseButton(ByVal G As Graphics, ByVal rect As Rectangle)
        ' Enable anti-aliasing for smooth lines
        G.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        ' Define the pen for the "X" with a sharper color and dynamic width
        Dim lineColor As Color = If(currentHover = "close", Color.FromArgb(200, 45, 45), Color.FromArgb(255, 75, 75))
        Dim lineWidth As Single = 1.6F ' Change this value to adjust line width
        Using linePen As New Pen(lineColor, lineWidth)
            Dim cords As Integer = 5

            ' Calculate the exact coordinates for the "X"
            Dim startX1 As Integer = rect.X + cords
            Dim startY1 As Integer = rect.Y + cords
            Dim endX1 As Integer = rect.X + rect.Width - cords
            Dim endY1 As Integer = rect.Y + rect.Height - cords

            Dim startX2 As Integer = rect.X + rect.Width - cords
            Dim startY2 As Integer = rect.Y + cords
            Dim endX2 As Integer = rect.X + cords
            Dim endY2 As Integer = rect.Y + rect.Height - cords

            ' Draw the "X" with thicker lines
            G.DrawLine(linePen, startX1, startY1, endX1, endY1) ' First line
            G.DrawLine(linePen, startX2, startY2, endX2, endY2) ' Second line
        End Using
    End Sub
End Class

Public Class BullionCurvedProgressBar
    Inherits Control

    ' Properties
    Private _Maximum As Double = 100
    Public Property TotalGB() As Double
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Double)
            If value < 0 Then value = 0
            _Maximum = value
            If Not DesignMode Then Invalidate()
        End Set
    End Property

    Private _Current As Double
    Public Property Current() As Double
        Get
            Return _Current
        End Get
        Set(ByVal value As Double)
            If value < 0 Then value = 0
            _Current = value
            If Not DesignMode Then Invalidate()
        End Set
    End Property

    Private ReadOnly Property Progress() As Double
        Get
            If TotalGB = 0 Then Return 0
            Return (_Current / TotalGB) * 100
        End Get
    End Property

    ' Add default colors
    Public Property ProgressBarColorStart As Color = Color.PaleTurquoise ' Dark Color
    Public Property ProgressBarColorEnd As Color = Color.AliceBlue ' Light Color
    Public Property ProgressBarTempColorStart As Color = Color.LightCoral ' Dark Color for Temp Space
    Public Property ProgressBarTempColorEnd As Color = Color.MistyRose ' Light Color for Temp Space
    Public Property ProgressBackgroundColor As Color = Color.LightGray
    Public Property ProgressTextColor As Color = Color.DarkGray
    Public Property InnerBackgroundColor As Color = Color.Black
    Public Property ProgressTextFont As Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
    Public Property SubTextFont As Font = New Font("Segoe UI", 10.0F)
    Public Property SubText As String = "Available"
    Public Property ShadowColor As Color = Color.FromArgb(40, 0, 0, 0)

    Public Sub New()
        ' Ensure the control is double-buffered
        DoubleBuffered = True
        If Not DesignMode Then
            TotalGB = 100
            Current = 0
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        ' Skip rendering in design mode
        If DesignMode Then
            'e.Graphics.DrawString("BullionCurvedProgressBar", Font, Brushes.Gray, New PointF(10, 10))
            'Return
        End If

        Dim graphics = e.Graphics
        graphics.SmoothingMode = SmoothingMode.AntiAlias

        ' Define the drawing bounds
        Dim bounds As Rectangle = New Rectangle(10, 10, Width - 20, Height - 20)
        Dim progressThickness As Integer = 8 ' Thickness of the progress arc
        Dim backgroundThickness As Integer = 6 ' Thickness of the gray background arc

        ' Draw shadow effect
        Dim shadowBounds As Rectangle = New Rectangle(bounds.X + 2, bounds.Y + 2, bounds.Width, bounds.Height)
        Using shadowBrush As New SolidBrush(ShadowColor)
            graphics.FillEllipse(shadowBrush, shadowBounds)
        End Using

        ' Draw the background arc (gray ring)
        Using bgPen As New Pen(ProgressBackgroundColor, backgroundThickness)
            graphics.DrawArc(bgPen, bounds, 0, 360)
        End Using

        ' Draw the temp space progress arc with a gradient
        Dim tempGradientRect As New RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height)
        Using tempGradientBrush As New LinearGradientBrush(tempGradientRect, ProgressBarTempColorStart, ProgressBarTempColorEnd, LinearGradientMode.ForwardDiagonal)
            Using progressPen As New Pen(tempGradientBrush, progressThickness)
                graphics.DrawArc(progressPen, bounds, -90, CSng((Progress / 100) * 360))
            End Using
        End Using

        ' Draw the main progress arc with a gradient
        Dim gradientRect As New RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height)
        Using gradientBrush As New LinearGradientBrush(gradientRect, ProgressBarColorStart, ProgressBarColorEnd, LinearGradientMode.ForwardDiagonal)
            Using progressPen As New Pen(gradientBrush, progressThickness)
                graphics.DrawArc(progressPen, bounds, -90, CSng((Progress / 100) * 360))
            End Using
        End Using

        ' Draw inner background circle (black)
        Dim innerBounds As Rectangle = New Rectangle(bounds.X + progressThickness, bounds.Y + progressThickness, bounds.Width - progressThickness * 2, bounds.Height - progressThickness * 2)
        Using innerBrush As New SolidBrush(InnerBackgroundColor)
            graphics.FillEllipse(innerBrush, innerBounds)
        End Using

        ' Draw progress text in the middle
        Dim progressText As String = String.Format("{0:F2} GB", Current)
        Dim textSize As SizeF = graphics.MeasureString(progressText, ProgressTextFont)
        Dim textPosition As New PointF((Width - textSize.Width) / 2, (Height - textSize.Height) / 2 - 10)

        ' Draw main text
        Using textBrush As New SolidBrush(ProgressTextColor)
            graphics.DrawString(progressText, ProgressTextFont, textBrush, textPosition)
        End Using

        ' Draw subtext below the percentage
        Dim subText As String = String.Format("{0:F1}% of {1} GB", Progress, TotalGB)
        Dim subTextSize As SizeF = graphics.MeasureString(subText, SubTextFont)
        Dim subTextPosition As New PointF((Width - subTextSize.Width) / 2, textPosition.Y + textSize.Height)
        Using subTextBrush As New SolidBrush(Color.Gray)
            graphics.DrawString(subText, SubTextFont, subTextBrush, subTextPosition)
        End Using
    End Sub
End Class


Public Class BullionGroupBox
    Inherits GroupBox

    ' Properties for customization
    Public Property HeaderBackgroundColor As Color = Color.FromArgb(245, 245, 245)
    Public Property HeaderBorderColor As Color = Color.FromArgb(200, 200, 200)
    Public Property HeaderTextColor As Color = Color.FromArgb(100, 100, 100)
    Public Property BackgroundColor As Color = Color.FromArgb(240, 240, 240) ' Subtle off-white background
    Public Property BorderColor As Color = Color.FromArgb(220, 220, 220)
    Public Property HeaderFont As Font = New Font("Segoe UI", 8.0F, FontStyle.Regular)

    Public Sub New()
        DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        Font = HeaderFont
        ForeColor = HeaderTextColor
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim graphics As Graphics = e.Graphics
        graphics.SmoothingMode = SmoothingMode.AntiAlias

        ' Define the rectangles for header and body
        Dim headerHeight As Integer = Font.Height + 10
        Dim headerRect As New Rectangle(0, 0, Width - 1, headerHeight)
        Dim bodyRect As New Rectangle(0, headerHeight, Width - 1, Height - headerHeight)

        ' Draw the background for the body with a subtle tone
        Using bodyBrush As New SolidBrush(BackgroundColor)
            graphics.FillRectangle(bodyBrush, bodyRect)
        End Using

        ' Draw the header background
        Using headerBrush As New SolidBrush(HeaderBackgroundColor)
            graphics.FillRectangle(headerBrush, headerRect)
        End Using

        ' Draw the header border line
        Using headerBorderPen As New Pen(HeaderBorderColor, 1)
            graphics.DrawLine(headerBorderPen, 0, headerHeight, Width, headerHeight)
        End Using

        ' Draw border around the group box
        Using borderPen As New Pen(BorderColor, 1)
            graphics.DrawRectangle(borderPen, New Rectangle(0, 0, Width - 1, Height - 1))
        End Using

        ' Draw the header text
        Dim textSize As SizeF = graphics.MeasureString(Text, HeaderFont)
        Dim textPosition As New PointF(10, (headerHeight - textSize.Height) / 2)
        Using textBrush As New SolidBrush(HeaderTextColor)
            graphics.DrawString(Text, HeaderFont, textBrush, textPosition)
        End Using
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        ' Prevent flickering by avoiding default background paint
    End Sub
End Class

Public Class BullionCheckBox
    Inherits Control

    ' Properties for customization
    Private _Checked As Boolean
    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            Invalidate() ' Redraw the control
        End Set
    End Property

    Public Property BorderColor As Color = Color.FromArgb(200, 200, 200)
    Public Property CheckColor As Color = Color.FromArgb(100, 150, 220)
    Public Property BackgroundColor As Color = Color.FromArgb(240, 240, 240)
    Public Property HoverColor As Color = Color.FromArgb(220, 220, 220)
    Public Property TextColor As Color = Color.FromArgb(100, 100, 100)
    Public Property CheckBoxSize As Integer = 14
    Public Property BoxBorderThickness As Integer = 1

    Private _Hover As Boolean = False

    Public Sub New()
        DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        Font = New Font("Segoe UI", 8.0F, FontStyle.Regular)
        ForeColor = TextColor
        Size = New Size(100, 20) ' Default size
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim graphics As Graphics = e.Graphics
        graphics.SmoothingMode = SmoothingMode.AntiAlias

        ' Define the checkbox rectangle
        Dim boxRect As New Rectangle(0, (Height - CheckBoxSize) \ 2, CheckBoxSize, CheckBoxSize)

        ' Draw the checkbox background
        Using boxBrush As New SolidBrush(If(_Hover, HoverColor, BackgroundColor))
            graphics.FillRectangle(boxBrush, boxRect)
        End Using

        ' Draw the checkbox border
        Using borderPen As New Pen(BorderColor, BoxBorderThickness)
            graphics.DrawRectangle(borderPen, boxRect)
        End Using

        ' Draw the checkmark if checked
        If Checked Then
            Using checkBrush As New SolidBrush(CheckColor)
                Dim checkSize As Integer = CheckBoxSize - 6
                Dim checkRect As New Rectangle(boxRect.X + 3, boxRect.Y + 3, checkSize, checkSize)
                graphics.FillRectangle(checkBrush, checkRect)
            End Using
        End If

        ' Draw the text
        Dim textPosition As New PointF(CheckBoxSize + 6, (Height - Font.Height) / 2)
        Using textBrush As New SolidBrush(TextColor)
            graphics.DrawString(Text, Font, textBrush, textPosition)
        End Using
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        _Hover = True
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        _Hover = False
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseClick(ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Checked = Not Checked
            RaiseEvent CheckedChanged(Me, EventArgs.Empty)
        End If
        MyBase.OnMouseClick(e)
    End Sub

    Public Event CheckedChanged As EventHandler
End Class

Public Class BullionSlider
    Inherits Control

    ' Properties for customization
    Private _Value As Integer
    Private _Minimum As Integer = 0
    Private _Maximum As Integer = 100

    Public Property Value As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value < _Minimum Then value = _Minimum
            If value > _Maximum Then value = _Maximum
            _Value = value
            Invalidate() ' Redraw the control
            RaiseEvent ValueChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Minimum As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            _Minimum = value
            If _Value < _Minimum Then _Value = _Minimum
            Invalidate()
        End Set
    End Property

    Public Property Maximum As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            _Maximum = value
            If _Value > _Maximum Then _Value = _Maximum
            Invalidate()
        End Set
    End Property

    Public Property TrackColor As Color = Color.FromArgb(220, 220, 220)
    Public Property ProgressColor As Color = Color.FromArgb(100, 150, 220)
    Public Property ThumbColor As Color = Color.FromArgb(100, 100, 100)
    Public Property HoverThumbColor As Color = Color.FromArgb(120, 120, 120)
    Public Property TrackHeight As Integer = 6
    Public Property ThumbSize As Integer = 12

    Private _Hover As Boolean = False
    Private _Dragging As Boolean = False

    Public Sub New()
        DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        Width = 150
        Height = 30
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim graphics As Graphics = e.Graphics
        graphics.SmoothingMode = SmoothingMode.AntiAlias

        ' Define the track rectangle
        Dim trackRect As New Rectangle(0, (Height - TrackHeight) \ 2, Width, TrackHeight)

        ' Draw the track
        Using trackBrush As New SolidBrush(TrackColor)
            graphics.FillRectangle(trackBrush, trackRect)
        End Using

        ' Calculate the progress width
        Dim progressWidth As Integer = CInt((Width - ThumbSize) * ((_Value - _Minimum) / (_Maximum - _Minimum)))

        ' Draw the progress
        Using progressBrush As New SolidBrush(ProgressColor)
            graphics.FillRectangle(progressBrush, New Rectangle(0, (Height - TrackHeight) \ 2, progressWidth, TrackHeight))
        End Using

        ' Draw the thumb
        Dim thumbX As Integer = progressWidth
        Dim thumbRect As New Rectangle(thumbX, (Height - ThumbSize) \ 2, ThumbSize, ThumbSize)
        Using thumbBrush As New SolidBrush(If(_Hover Or _Dragging, HoverThumbColor, ThumbColor))
            graphics.FillEllipse(thumbBrush, thumbRect)
        End Using
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            _Dragging = True
            UpdateValueFromMouse(e.X)
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If _Dragging Then
            UpdateValueFromMouse(e.X)
        Else
            Dim thumbRect As New Rectangle(CInt((Width - ThumbSize) * ((_Value - _Minimum) / (_Maximum - _Minimum))), (Height - ThumbSize) \ 2, ThumbSize, ThumbSize)
            _Hover = thumbRect.Contains(e.Location)
            Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            _Dragging = False
            Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        _Hover = False
        Invalidate()
    End Sub

    Private Sub UpdateValueFromMouse(ByVal mouseX As Integer)
        Dim relativeX As Integer = Math.Max(0, Math.Min(Width - ThumbSize, mouseX))
        Value = CInt((_Maximum - _Minimum) * (relativeX / (Width - ThumbSize)) + _Minimum)
    End Sub

    Public Event ValueChanged As EventHandler
End Class

Public Class BullionStatusStrip
    Inherits Control

    ' Properties for customization
    Public Property BackgroundColor As Color = Color.FromArgb(240, 240, 240)
    Public Property BorderColor As Color = Color.FromArgb(200, 200, 200)
    Public Property TextColor As Color = Color.FromArgb(100, 100, 100)
    Public Property StatusFont As Font = New Font("Segoe UI", 8.0F, System.Drawing.FontStyle.Regular)
    Public Property BorderThickness As Integer = 1

    Private StatusTextList As List(Of String) = New List(Of String)()
    Public Property StatusText As String
        Get
            Return String.Join(" | ", StatusTextList)
        End Get
        Set(ByVal value As String)
            StatusTextList.Clear()
            StatusTextList.Add(value)
            Invalidate() ' Redraw the control
        End Set
    End Property

    Public Sub AddStatusText(ByVal value As String)
        StatusTextList.Add(value)
        Invalidate()
    End Sub

    Public Sub ClearStatusText()
        StatusTextList.Clear()
        Invalidate()
    End Sub

    Public Sub New()
        DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        Font = StatusFont
        ForeColor = TextColor
        Height = 30 ' Default height

        ' Attach event handlers for hover effects
        AddHandler Me.MouseEnter, AddressOf OnMouseEnterHandler
        AddHandler Me.MouseLeave, AddressOf OnMouseLeaveHandler
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim graphics As Graphics = e.Graphics
        graphics.SmoothingMode = SmoothingMode.AntiAlias

        ' Draw the background
        Using backgroundBrush As New SolidBrush(BackgroundColor)
            graphics.FillRectangle(backgroundBrush, ClientRectangle)
        End Using

        ' Draw the top border line
        Using borderPen As New Pen(BorderColor, BorderThickness)
            graphics.DrawLine(borderPen, 0, 0, Width, 0)
        End Using

        ' Draw the bottom border line
        Using borderPen As New Pen(BorderColor, BorderThickness)
            graphics.DrawLine(borderPen, 0, Height - BorderThickness, Width, Height - BorderThickness)
        End Using

        ' Draw the status text
        Dim textPosition As New PointF(5, (Height - Font.Height) / 2)
        Using textBrush As New SolidBrush(TextColor)
            graphics.DrawString(StatusText, Font, textBrush, textPosition)
        End Using
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        ' Prevent flickering by avoiding default background paint
    End Sub

    ' Event handlers for mouse hover
    Private Sub OnMouseEnterHandler(ByVal sender As Object, ByVal e As EventArgs)
        Cursor = Cursors.Hand ' Change cursor to pointer
    End Sub

    Private Sub OnMouseLeaveHandler(ByVal sender As Object, ByVal e As EventArgs)
        Cursor = Cursors.Default ' Revert cursor to default
    End Sub
End Class

Class BullionMultiProgressBar
    Inherits Control

#Region " Properties "
    Private _Maximum As Double = 100
    Public Property Maximum() As Double
        Get
            Return _Maximum
        End Get
        Set(ByVal v As Double)
            _Maximum = v
            ProgressUsedSpace = _CurrentUsedSpace / v * 100
            ProgressTempSpace = _CurrentTempSpace / v * 100
            Invalidate()
        End Set
    End Property

    Private _CurrentUsedSpace As Double
    Public Property CurrentUsedSpace() As Double
        Get
            Return _CurrentUsedSpace
        End Get
        Set(ByVal v As Double)
            _CurrentUsedSpace = v
            ProgressUsedSpace = v / _Maximum * 100
            Invalidate()
        End Set
    End Property

    Private _CurrentTempSpace As Double
    Public Property CurrentTempSpace() As Double
        Get
            Return _CurrentTempSpace
        End Get
        Set(ByVal v As Double)
            _CurrentTempSpace = v
            ProgressTempSpace = v / _Maximum * 100
            Invalidate()
        End Set
    End Property

    Private _ProgressUsedSpace As Integer
    Public Property ProgressUsedSpace() As Double
        Get
            Return _ProgressUsedSpace
        End Get
        Set(ByVal v As Double)
            If v < 0 Then v = 0 Else If v > 100 Then v = 100
            _ProgressUsedSpace = Convert.ToInt32(v)
            _CurrentUsedSpace = v * 0.01 * _Maximum
            If Width > 0 Then UpdateProgress()
            Invalidate()
        End Set
    End Property

    Private _ProgressTempSpace As Integer
    Public Property ProgressTempSpace() As Double
        Get
            Return _ProgressTempSpace
        End Get
        Set(ByVal v As Double)
            If v < 0 Then v = 0 Else If v > 100 Then v = 100
            _ProgressTempSpace = Convert.ToInt32(v)
            _CurrentTempSpace = v * 0.01 * _Maximum
            If Width > 0 Then UpdateProgress()
            Invalidate()
        End Set
    End Property

    Dim C2 As Color = Color.PaleTurquoise  ' Dark Color for Used Space
    Public Property Color1() As Color
        Get
            Return C2
        End Get
        Set(ByVal v As Color)
            C2 = v
            UpdateColors()
            Invalidate()
        End Set
    End Property

    Dim C3 As Color = Color.AliceBlue  ' Light Color for Used Space
    Public Property Color2() As Color
        Get
            Return C3
        End Get
        Set(ByVal v As Color)
            C3 = v
            UpdateColors()
            Invalidate()
        End Set
    End Property

    Dim C4 As Color = Color.LightCoral  ' Dark Color for Temp Space
    Public Property Color3() As Color
        Get
            Return C4
        End Get
        Set(ByVal v As Color)
            C4 = v
            UpdateColors()
            Invalidate()
        End Set
    End Property

    Dim C5 As Color = Color.MistyRose  ' Light Color for Temp Space
    Public Property Color4() As Color
        Get
            Return C5
        End Get
        Set(ByVal v As Color)
            C5 = v
            UpdateColors()
            Invalidate()
        End Set
    End Property

#End Region

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
    End Sub

    Dim G As Graphics, B As Bitmap, R1, R2, R3 As Rectangle, X1, X2 As ColorBlend
    Dim C1 As Color, P1, P2, P3 As Pen, B1, B2, B3 As LinearGradientBrush, B4 As SolidBrush

    Sub New()
        C1 = Color.FromArgb(246, 246, 246)  ' Background
        P1 = New Pen(Color.FromArgb(70, Color.White), 2)
        P2 = New Pen(C2)
        P3 = New Pen(Color.FromArgb(255, 255, 255))  ' Highlight
        B4 = New SolidBrush(Color.FromArgb(100, Color.White))
        X1 = New ColorBlend(4)
        X1.Colors = {C2, C3, C3, C2}
        X1.Positions = {0.0F, 0.1F, 0.9F, 1.0F}
        X2 = New ColorBlend(4)
        X2.Colors = {C4, C5, C5, C4}
        X2.Positions = {0.0F, 0.1F, 0.9F, 1.0F}
        R2 = New Rectangle(2, 2, 2, 2)
        B2 = New LinearGradientBrush(R2, Nothing, Nothing, 180.0F)
        B2.InterpolationColors = X1
        R3 = New Rectangle(2, 2, 2, 2)
        B3 = New LinearGradientBrush(R3, Nothing, Nothing, 180.0F)
        B3.InterpolationColors = X2
    End Sub

    Sub UpdateColors()
        P2.Color = C2
        X1.Colors = {C2, C3, C3, C2}
        B2.InterpolationColors = X1
        X2.Colors = {C4, C5, C5, C4}
        B3.InterpolationColors = X2
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
        R1 = New Rectangle(0, 1, Width, 4)
        B1 = New LinearGradientBrush(R1, Color.FromArgb(24, Color.Black), Color.Transparent, 90.0F)
        UpdateProgress()
        Invalidate()
        MyBase.OnSizeChanged(e)
    End Sub

    Sub UpdateProgress()
        If _ProgressUsedSpace > 0 Then
            R2 = New Rectangle(2, 2, Convert.ToInt32((Width - 4) * (_ProgressUsedSpace * 0.01)), Height - 4)
            B2 = New LinearGradientBrush(R2, Nothing, Nothing, 180.0F)
            B2.InterpolationColors = X1
        End If

        If _ProgressTempSpace > 0 Then
            R3 = New Rectangle(2, 2, Convert.ToInt32((Width - 4) * (_ProgressTempSpace * 0.01)), Height - 4)
            B3 = New LinearGradientBrush(R3, Nothing, Nothing, 180.0F)
            B3.InterpolationColors = X2
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        B = New Bitmap(Width, Height)
        G = Graphics.FromImage(B)

        G.Clear(C1)

        G.FillRectangle(B1, R1)

        If _ProgressTempSpace > 0 Then
            G.FillRectangle(B3, R3)
            G.FillRectangle(B4, 2, 3, R3.Width, Height - 4)
            G.DrawRectangle(P1, 4, 4, R3.Width - 4, Height - 8)
            G.DrawRectangle(P2, 2, 2, R3.Width - 1, Height - 5)
        End If

        If _ProgressUsedSpace > 0 Then
            G.FillRectangle(B2, R2)
            G.FillRectangle(B4, 2, 3, R2.Width, Height - 4)
            G.DrawRectangle(P1, 4, 4, R2.Width - 4, Height - 8)
            G.DrawRectangle(P2, 2, 2, R2.Width - 1, Height - 5)
        End If

        G.DrawRectangle(P3, 0, 0, Width - 1, Height - 1)

        e.Graphics.DrawImage(B, 0, 0)
        G.Dispose()
        B.Dispose()
    End Sub
End Class


Class BullionMultiFlatProgressBar
    Inherits Control

#Region "Properties"
    Private _Maximum As Double = 100
    Public Property Maximum() As Double
        Get
            Return _Maximum
        End Get
        Set(ByVal v As Double)
            _Maximum = v
            ProgressUsedSpace = _CurrentUsedSpace / v * 100
            ProgressTempSpace = _CurrentTempSpace / v * 100
            Invalidate()
        End Set
    End Property

    Private _CurrentUsedSpace As Double
    Public Property CurrentUsedSpace() As Double
        Get
            Return _CurrentUsedSpace
        End Get
        Set(ByVal v As Double)
            _CurrentUsedSpace = v
            ProgressUsedSpace = v / _Maximum * 100
            Invalidate()
        End Set
    End Property

    Private _CurrentTempSpace As Double
    Public Property CurrentTempSpace() As Double
        Get
            Return _CurrentTempSpace
        End Get
        Set(ByVal v As Double)
            _CurrentTempSpace = v
            ProgressTempSpace = v / _Maximum * 100
            Invalidate()
        End Set
    End Property

    Private _ProgressUsedSpace As Integer
    Public Property ProgressUsedSpace() As Double
        Get
            Return _ProgressUsedSpace
        End Get
        Set(ByVal v As Double)
            If v < 0 Then v = 0 Else If v > 100 Then v = 100
            _ProgressUsedSpace = Convert.ToInt32(v)
            _CurrentUsedSpace = v * 0.01 * _Maximum
            Invalidate()
        End Set
    End Property

    Private _ProgressTempSpace As Integer
    Public Property ProgressTempSpace() As Double
        Get
            Return _ProgressTempSpace
        End Get
        Set(ByVal v As Double)
            If v < 0 Then v = 0 Else If v > 100 Then v = 100
            _ProgressTempSpace = Convert.ToInt32(v)
            _CurrentTempSpace = v * 0.01 * _Maximum
            Invalidate()
        End Set
    End Property

    Public Property UsedSpaceColor As Color = Color.FromArgb(140, 200, 240) ' Softer blue
    Public Property TempSpaceColor As Color = Color.FromArgb(220, 120, 120) ' Softer red
    Public Property BackgroundColor As Color = Color.FromArgb(250, 250, 250) ' Off-white
    Public Property BorderColor As Color = Color.FromArgb(230, 230, 230)
    Public Property HighlightColor As Color = Color.FromArgb(245, 245, 245)
    Public Property TextColor As Color = Color.FromArgb(100, 100, 100)
    Public Property BorderThickness As Integer = 1
    Public Property ProgressTextFont As Font = New Font("Verdana", 7.0F, FontStyle.Regular)
#End Region

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
        ' Do nothing to prevent flickering
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        ' Draw background
        g.Clear(BackgroundColor)

        ' Adjust padding for progress bars
        Dim paddingTop As Integer = 2
        Dim paddingBottom As Integer = 4
        Dim progressBarHeight As Integer = Height - paddingTop - paddingBottom

        ' Draw temp space progress with reversed gradient
        If _ProgressTempSpace > 0 Then
            Dim tempWidth As Integer = Convert.ToInt32((Width - 4) * (_ProgressTempSpace * 0.01))
            Using tempGradientBrush As New LinearGradientBrush(New Rectangle(2, paddingTop, tempWidth, progressBarHeight), Color.FromArgb(255, 200, 200), TempSpaceColor, LinearGradientMode.Horizontal)
                g.FillRectangle(tempGradientBrush, 2, paddingTop, tempWidth, progressBarHeight)
            End Using
        End If

        ' Draw used space progress with softer gradient
        If _ProgressUsedSpace > 0 Then
            Dim usedWidth As Integer = Convert.ToInt32((Width - 4) * (_ProgressUsedSpace * 0.01))
            Using usedGradientBrush As New LinearGradientBrush(New Rectangle(2, paddingTop, usedWidth, progressBarHeight), Color.FromArgb(200, 220, 255), UsedSpaceColor, LinearGradientMode.Horizontal)
                g.FillRectangle(usedGradientBrush, 2, paddingTop, usedWidth, progressBarHeight)
            End Using
        End If

        ' Draw border
        Using borderPen As New Pen(BorderColor, BorderThickness)
            g.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1)
        End Using

        ' Draw highlight line
        Using highlightPen As New Pen(HighlightColor, BorderThickness)
            g.DrawLine(highlightPen, 0, paddingTop, Width, paddingTop)
        End Using

        ' Draw progress text
        Dim progressText As String = ProgressUsedSpace.ToString() & "%"
        Dim textSize As SizeF = g.MeasureString(progressText, ProgressTextFont)
        Dim textPosition As New PointF((Width - textSize.Width) / 2, (Height - textSize.Height) / 2)
        Using textBrush As New SolidBrush(TextColor)
            g.DrawString(progressText, ProgressTextFont, textBrush, textPosition)
        End Using
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        Invalidate()
    End Sub
End Class

