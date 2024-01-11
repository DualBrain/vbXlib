Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Timers
Imports VbXlib

Module Program

  Private m_atom_wm_delete As XAtom
  Private m_display As XDisplay
  Private m_screen As XScreen
  Private m_event As XEvent
  Private m_bg_color As XColor
  Private m_handle_color As XColor
  Private m_gc As XGC
  Private m_mainWindow As XWindow
  Private m_resizeMainWindow As XWindow
  Private m_resizeTopLeftWindow As XWindow
  Private m_resizeTopRightWindow As XWindow
  Private m_resizeBottomLeftWindow As XWindow
  Private m_resizeBottomRightWindow As XWindow
  Private m_attr As XWindowAttributes
  Private m_pointer As XPointer
  Private m_start As XButtonEvent
  Private m_old_resize_x As Integer = 140
  Private m_old_resize_y As Integer = 100
  Private ReadOnly m_min_size As Integer = 50
  Private m_ResizeWindowX As Integer = 240
  Private m_resizeWindowY As Integer = 120
  Private m_resizeWindowWidth As Integer = 320
  Private m_resizeWindowHeight As Integer = 240
  Private ReadOnly m_resize_handle_width As Integer = 10
  Private ReadOnly m_resize_handle_height As Integer = 10

  Private m_timer As Timer

  <DllImport("libX11.so.6")>
  Private Sub XSetWMProtocols(display As IntPtr, window As IntPtr, protocols As Integer(), count As Integer)
  End Sub

  Sub Main()

    If RuntimeInformation.IsOSPlatform(OSPlatform.Windows) Then
      Console.WriteLine("Not fer winderrrrrrrs!")
      Environment.Exit(1)
    End If

    m_timer = New Timer
    m_display = New XDisplay(Nothing)
    m_screen = New XScreen(m_display)
    m_event = New XEvent(m_display)
    m_pointer = New XPointer(m_display)

    Dim atom_name = "WM_DELETE_WINDOW"
    m_atom_wm_delete = New XAtom(m_display, atom_name, False)
    Dim protocols = New Integer() {m_atom_wm_delete.Id}

    m_gc = New XGC(m_display)

    m_bg_color = New XColor(m_display, "#BBBBBB")
    m_handle_color = New XColor(m_display, "#0000FF")

    m_mainWindow = New XWindow(m_display, New Rectangle(10, 10, 640, 480), 0, m_screen.BlackPixel(), m_bg_color.Pixel) 'm_screen.WhitePixel())
    XSetWMProtocols(m_display.Handle, m_mainWindow.Handle, protocols, 1)

    Dim title = If(RuntimeInformation.IsOSPlatform(OSPlatform.OSX),
                   "AddressOf.com - X11 window (Mac OSX)",
                   "AddressOf.com - X11 window (Linux)")
    m_mainWindow.Name = title

    m_mainWindow.SelectInput(XEventMask.KeyPressMask Or XEventMask.ExposureMask)

    m_resizeMainWindow = New XWindow(m_display, m_mainWindow, New Rectangle(m_ResizeWindowX, m_resizeWindowY, m_resizeWindowWidth, m_resizeWindowHeight), 2, m_handle_color.Pixel, m_screen.WhitePixel())
    m_resizeTopLeftWindow = New XWindow(m_display, m_resizeMainWindow, New Rectangle(0, 0, m_resize_handle_width, m_resize_handle_height), 1, m_screen.BlackPixel(), m_handle_color.Pixel)
    m_resizeTopRightWindow = New XWindow(m_display, m_resizeMainWindow, New Rectangle(0, 0, m_resize_handle_width, m_resize_handle_height), 1, m_screen.BlackPixel(), m_handle_color.Pixel)
    m_resizeBottomLeftWindow = New XWindow(m_display, m_resizeMainWindow, New Rectangle(0, 0, m_resize_handle_width, m_resize_handle_height), 1, m_screen.BlackPixel(), m_handle_color.Pixel)
    m_resizeBottomRightWindow = New XWindow(m_display, m_resizeMainWindow, New Rectangle(0, 0, m_resize_handle_width, m_resize_handle_height), 1, m_screen.BlackPixel(), m_handle_color.Pixel)

    Dim rslt = m_resizeMainWindow.SetBackgroundColor(Color.Gray)

    Dim mask = XEventMask.ButtonPressMask Or XEventMask.ButtonReleaseMask

    m_resizeMainWindow.SelectInput(mask)
    m_resizeTopLeftWindow.SelectInput(mask)
    m_resizeTopRightWindow.SelectInput(mask)
    m_resizeBottomLeftWindow.SelectInput(mask)
    m_resizeBottomRightWindow.SelectInput(mask)

    PlaceHandles()

    m_resizeMainWindow.MapSubwindows()
    m_mainWindow.MapSubwindows()
    m_mainWindow.Map()

    AddHandler m_event.ClientMessageHandlerEvent, New ClientMessageHandler(AddressOf HandleClientMessage)
    AddHandler m_event.KeyPressHandlerEvent, New KeyPressHandler(AddressOf HandleKeyPress)
    AddHandler m_event.MotionNotifyHandlerEvent, New MotionNotifyHandler(AddressOf HandleMotionNotify)
    AddHandler m_event.ButtonPressHandlerEvent, New ButtonPressHandler(AddressOf HandleButtonPress)
    AddHandler m_event.ButtonReleaseHandlerEvent, New ButtonReleaseHandler(AddressOf HandleButtonRelease)
    AddHandler m_event.ExposeHandlerEvent, New ExposeHandler(AddressOf HandleExpose)

    m_timer.Interval = 1000
    m_timer.Enabled = True
    AddHandler m_timer.Elapsed, New ElapsedEventHandler(AddressOf UpdateClock)

    m_timer.Start()
    m_event.[Loop]()

  End Sub

  Public Sub DrawClock()
    m_resizeMainWindow.Clear()
    m_resizeMainWindow.DrawString(m_gc, New Point(10, 40), Now.ToString("MM/dd/yyyy HH:mm:ss"))
    m_display.Flush()
  End Sub

  Public Sub UpdateClock(source As Object, e As EventArgs)
    DrawClock()
  End Sub

  Public Sub PlaceHandles()
    m_resizeTopLeftWindow.Move(New Point(-1, -1))
    m_resizeTopRightWindow.Move(New Point(m_resizeWindowWidth - (m_resize_handle_width + 1), -1))
    m_resizeBottomLeftWindow.Move(New Point(-1, m_resizeWindowHeight - (m_resize_handle_height + 1)))
    m_resizeBottomRightWindow.Move(New Point(m_resizeWindowWidth - (m_resize_handle_width + 1), m_resizeWindowHeight - (m_resize_handle_height + 1)))
  End Sub

  Public Sub ResizeTopLeft(x As Integer, y As Integer)
    m_ResizeWindowX = m_attr.X + x
    m_resizeWindowY = m_attr.Y + y
    m_resizeWindowWidth = m_attr.Width - x
    m_resizeWindowHeight = m_attr.Height - y
  End Sub

  Public Sub ResizeBottomLeft(x As Integer, y As Integer)
    m_ResizeWindowX = m_attr.X + x
    m_resizeWindowWidth = m_attr.Width - x
    m_resizeWindowHeight = m_attr.Height + y
  End Sub

  Public Sub ResizeTopRight(x As Integer, y As Integer)
    m_resizeWindowY = m_attr.Y + y
    m_resizeWindowWidth = m_attr.Width + x
    m_resizeWindowHeight = m_attr.Height - y
  End Sub

  Public Sub ResizeBottomRight(x As Integer, y As Integer)
    m_resizeWindowWidth = m_attr.Width + x
    m_resizeWindowHeight = m_attr.Height + y
  End Sub

  Public Sub HandleExpose(e As XExposeEvent, window As XWindow)

    If e.Window = m_mainWindow.Id Then

      DrawClock()
      'm_mainWindow.DrawString(m_gc, New Point(10, 20), "Resize / Move test / Clock / Color test... Press 'ESC' to quit...")

      Dim y_offset = 20

      Dim s1 = If(RuntimeInformation.IsOSPlatform(OSPlatform.OSX),
                      "X11 testing (Mac OSX)",
                      "X11 testing (Linux)")
      Dim s2 = "(c) 2024 AddressOf.com"
      m_mainWindow.DrawString(m_gc, New Point(10, y_offset), s1) : y_offset += 20
      m_mainWindow.DrawString(m_gc, New Point(10, y_offset), s2) : y_offset += 20

      y_offset += 20

      Dim systemInformationText = "System information:"
      Dim osText = $"- Operating System: {RuntimeInformation.OSDescription}"
      Dim archText = $"- Architecture: {RuntimeInformation.OSArchitecture}"
      Dim fxText = $"- Framework: {RuntimeInformation.FrameworkDescription}"
      Dim vbText = $"- Compiler: VISUAL BASIC!!!!!"
      m_mainWindow.DrawString(m_gc, New Point(10, y_offset), systemInformationText) : y_offset += 20
      m_mainWindow.DrawString(m_gc, New Point(10, y_offset), osText) : y_offset += 20
      m_mainWindow.DrawString(m_gc, New Point(10, y_offset), archText) : y_offset += 20
      m_mainWindow.DrawString(m_gc, New Point(10, y_offset), fxText) : y_offset += 20
      m_mainWindow.DrawString(m_gc, New Point(10, y_offset), vbText) : y_offset += 20

      y_offset += 20

      Dim attr = m_mainWindow.GetAttributes()
      Dim str = $"Current window size: {attr.Width}x{attr.Height}"
      m_mainWindow.DrawString(m_gc, New Point(10, y_offset), str) ': y_offset += 20

    End If

  End Sub

  Public Sub HandleButtonPress(e As XButtonEvent, window As XWindow, root As XWindow, subwindow As XWindow)
    m_pointer.Grab(e.Window, XEventMask.PointerMotionMask Or XEventMask.ButtonReleaseMask)
    m_attr = m_resizeMainWindow.GetAttributes()
    m_start = e
    m_old_resize_x = m_ResizeWindowX
    m_old_resize_y = m_resizeWindowY
  End Sub

  Public Sub HandleButtonRelease(e As XButtonEvent, window As XWindow, root As XWindow, subwindow As XWindow)
    m_pointer.Ungrab()
  End Sub

  Private Sub ShutDown()

    Console.WriteLine("Cleaning up and exiting...")
    m_gc.Dispose()
    m_bg_color.Dispose()
    m_handle_color.Dispose()
    m_resizeTopLeftWindow.Dispose()
    m_resizeTopRightWindow.Dispose()
    m_resizeBottomLeftWindow.Dispose()
    m_resizeBottomRightWindow.Dispose()
    m_resizeMainWindow.Dispose()
    m_mainWindow.Dispose()
    m_event.Dispose()
    m_screen.Dispose()
    m_display.Dispose()
    Environment.[Exit](0)

  End Sub

  Public Sub HandleKeyPress(e As XKeyEvent, window As XWindow, root As XWindow, subwindow As XWindow)
    Dim value = XWindow.LookupKeysym(e)
    If value = XKeySym.XK_Escape Then
      ShutDown()
    Else
      Console.WriteLine($"window: {window.Id}")
      Console.WriteLine($"root: {root.Id}")
      Console.WriteLine($"subwindow: {subwindow.Id}")
      Console.WriteLine($"e.Window: {e.Window}")
      Console.WriteLine($"e.Root: {e.Root}")
      Console.WriteLine($"e.Subwindow: {e.Subwindow}")
      Console.WriteLine($"Key: {value}")
    End If
  End Sub

  Private Sub HandleClientMessage(e As XClientMessageEvent, window As XWindow)

    ' The following is from the x.org documentation...

    ' The `message_type` member is set to an atom that indicates how the data should be interpreted
    ' by the receiving client. The `format` member is set to 8, 16, or 32 and specifies whether the
    ' data should be viewed as a list of bytes, shorts, or longs. The `data` member is a union that
    ' contains the members `b`, `s`, and `l`. The `b`, `s`, and `l` members represent data of twenty
    ' 8-bit values, ten 16-bit values, and five 32-bit values. Particular message types might not
    ' make use of all these values. The X server places no interpretation on the values in the
    ' `window`, `message_type`, or `data` members.

    ' When the atom is a 245, getting a `message_type` of 243.
    ' So what does a `message_type` of 243 mean????

    ' According to an SO conversation, many stated not to look at the `message_type` and
    ' instead look at the `L(0)` value??? This, of course, doesn't seem to align with the
    ' documentation on x.org???

    If e.Type = XEventType.ClientMessage Then ' Not needed, but why not for clarity?
      If e.Format = 32 Then ' Read from the "long" data...
        If e.L0 = m_atom_wm_delete.Id Then ' Does the first value match the atom?
          ShutDown() ' Then shut down.
        Else
          Stop
        End If
      Else
        Stop
      End If
    Else
      Stop
    End If

  End Sub

  Public Sub HandleMotionNotify(e As XMotionEvent, window As XWindow, root As XWindow, subwindow As XWindow)

    Dim xdiff = e.RootX - m_start.X_Root
    Dim ydiff = e.RootY - m_start.Y_Root

    If (e.Window = m_resizeTopLeftWindow.Id) OrElse (e.Window = m_resizeBottomLeftWindow.Id) OrElse (e.Window = m_resizeTopRightWindow.Id) OrElse (e.Window = m_resizeBottomRightWindow.Id) Then

      If e.Window = m_resizeTopLeftWindow.Id Then
        ResizeTopLeft(xdiff, ydiff)
      ElseIf e.Window = m_resizeBottomLeftWindow.Id Then
        ResizeBottomLeft(xdiff, ydiff)
      ElseIf e.Window = m_resizeTopRightWindow.Id Then
        ResizeTopRight(xdiff, ydiff)
      ElseIf e.Window = m_resizeBottomRightWindow.Id Then
        ResizeBottomRight(xdiff, ydiff)
      End If

      If m_resizeWindowWidth < m_min_size OrElse m_resizeWindowHeight < m_min_size Then
        Return
      End If

      m_resizeMainWindow.MoveResize(New Rectangle(m_ResizeWindowX, m_resizeWindowY, m_resizeWindowWidth, m_resizeWindowHeight))

      DrawClock()

      PlaceHandles()

    ElseIf e.Window = m_resizeMainWindow.Id Then

      Dim x = m_old_resize_x + (e.RootX - m_start.X_Root)
      Dim y = m_old_resize_y + (e.RootY - m_start.Y_Root)
      m_resizeMainWindow.Move(New Point(x, y))
      m_ResizeWindowX = x
      m_resizeWindowY = y

    End If

  End Sub

End Module