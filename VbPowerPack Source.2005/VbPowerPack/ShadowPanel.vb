Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

<ToolboxBitmap(GetType(ShadowBlendPanel), "PanelWithShadow.bmp")> _
Public Class ShadowBlendPanel
    Inherits BlendPanel

    Private Declare Function GetWindowDC Lib "user32" Alias "GetWindowDC" (ByVal hwnd As IntPtr) _
                As IntPtr
    Private Declare Function ReleaseDC Lib "user32" Alias "ReleaseDC" (ByVal hwnd As IntPtr, _
        ByVal hdc As IntPtr) As Integer

    Public Sub New()

    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_NCPAINT As Integer = &H85

        '
        ' Redraw border to look like panel is raised
        '

        If m.Msg = WM_NCPAINT Then
            Dim hdc As IntPtr = GetWindowDC(m.HWnd)
            Dim g As Graphics = Graphics.FromHdc(hdc)
            Dim rDraw As Rectangle = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

            Dim pBottom As Pen = New Pen(Color.Gray, 3)
            Dim pTop As Pen = New Pen(Color.White, 3)

            g.DrawRectangle(pBottom, rDraw)

            Dim pts(2) As Point

            pts(0) = New Point(0, Me.Height - 1)
            pts(1) = New Point(0, 0)
            pts(2) = New Point(Me.Width - 1, 0)

            g.DrawLines(pTop, pts)
            ReleaseDC(Me.Handle, hdc)
        Else
            MyBase.WndProc(m)

        End If

    End Sub

    Private Sub DrawShadow()
        Dim g As Graphics = Me.Parent.CreateGraphics
        Dim brShadow As New SolidBrush(Color.FromArgb(128, Color.Black))

        '
        ' Draw a shadow on the parent to make panel look like it is raised
        ' This matrix offsets shadow a little right and down
        '

        Dim mx As New Matrix(1.0F, 0, 0, 1.0F, 4, 4)
        Dim rdraw As New Rectangle(Me.Left, Me.Top, Me.Width, Me.Height)

        g.Transform = mx

        g.FillRectangle(brShadow, rdraw)
        g.Dispose()
        brShadow.Dispose()
    End Sub

    Private Sub ParentPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        DrawShadow()
    End Sub

    Private Sub ShadowPanel_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ParentChanged
        DrawShadow()
    End Sub

End Class
