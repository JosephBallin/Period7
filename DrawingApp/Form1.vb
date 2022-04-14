﻿Public Class Form1
    Private m_Previous As System.Nullable(Of Point) = Nothing
    Dim m_shapes As New Collection
    Dim c As Color
    Dim w As Integer
    Dim h As Integer
    Dim type As String
    Dim s1 As Integer
    Dim s2 As Integer



    Private Sub pictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        m_Previous = e.Location
        pictureBox1_MouseMove(sender, e)
    End Sub

    Private Sub pictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If m_Previous IsNot Nothing Then

            Dim d As Object

            d = New Line(PictureBox1.Image, m_Previous, e.Location)
            d.pen = New Pen(c, w)


            If type = "Line" Then
                d = New Line(PictureBox1.Image, m_Previous, e.Location)
                d.pen = New Pen(c, w)
                d.xSpeed = xSpeedTrackBar.Value
            End If

            If type = "Rectangle" Then
                d = New Rect(PictureBox1.Image, m_Previous, e.Location)
                d.fill = CheckBox2.Checked
                d.color1 = Button2.BackColor
                d.color2 = Button3.BackColor
                d.pen = New Pen(c, w)
            End If

            If type = "Circle" Then
                d = New circle(PictureBox1.Image, m_Previous, e.Location)
                d.pen = New Pen(c, w)
            End If

            If type = "Poly" Then
                d = New Poly(PictureBox1.Image, m_Previous, e.Location)
                d.pen = New Pen(c, w)
            End If

            If type = "N-Gon" Then
                d = New Poly(PictureBox1.Image, m_Previous, e.Location)
                d.pen = New Pen(c, w)
                d.radius = TrackBar3.Value
                d.sides = TrackBar2.Value
            End If

            If type = "Pent" Then
                d = New Pent(PictureBox1.Image, m_Previous, e.Location)
                d.pen = New Pen(c, w)
            End If

            If type = "Hex" Then
                d = New Hex(PictureBox1.Image, m_Previous, e.Location)
                d.pen = New Pen(c, w)
            End If

            If type = "Hept" Then
                d = New Hept(PictureBox1.Image, m_Previous, e.Location)
                d.pen = New Pen(c, w)
            End If

            If type = "Octo" Then
                d = New Oct(PictureBox1.Image, m_Previous, e.Location)
                d.pen = New Pen(c, w)
            End If

            If type = "Yes" Then
                d = New Yes(PictureBox1.Image, m_Previous, e.Location)
                d.pen = New Pen(c, w)
            End If

            If type = "Picture" Then
                d = New PBox(PictureBox1.Image, m_Previous, e.Location)
                d.w = TrackBar4.Value
                d.h = TrackBar4.Value

                d.picture = PictureBox2.Image
            End If

            m_shapes.Add(d)
            PictureBox1.Invalidate()
            m_Previous = e.Location
        End If
    End Sub

    Private Sub pictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        m_Previous = Nothing
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        clear()
    End Sub

    Sub clear()
        If PictureBox1.Image Is Nothing Then
            Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)
            End Using
            PictureBox1.Image = bmp
        End If
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint

        clear()

        For Each s As Object In m_shapes
            s.Draw()
        Next
        If (CheckBox1.Checked) Then
            Refresh()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        Button1.BackColor = c
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        sender.BackColor = c
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        sender.BackColor = c
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        w = TrackBar1.Value
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.White)
        End Using
        PictureBox1.Image = bmp
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SaveFileDialog1.ShowDialog()
        PictureBox1.Image.Save(SaveFileDialog1.FileName)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        type = "Rectangle"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        type = "Line"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        type = "Circle"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        c = sender.backcolor
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        c = sender.backcolor
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        c = sender.backcolor
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        c = sender.backcolor
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        c = sender.backcolor
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs)
        type = "Poly"
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        type = "N-Gon"
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        type = "Picture"
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        PictureBox2.Load(OpenFileDialog1.FileName)
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        type = "Octo"
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        type = "Pent"
    End Sub

    Private Sub Button14_Click_1(sender As Object, e As EventArgs) Handles Button14.Click
        type = "Hept"
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        type = "Hex"
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        type = "Yes"
    End Sub
End Class

