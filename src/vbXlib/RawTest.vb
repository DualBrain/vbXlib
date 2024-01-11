'Imports System.Runtime.InteropServices

'Module RawTest

'#Region "GL"

'  Private Const None As Integer = 0

'  Private Const GLX_RGBA As Integer = 4
'  Private Const GLX_DEPTH_SIZE As Integer = 12
'  Private Const GLX_DOUBLEBUFFER As Integer = 5

'  Private Declare Function glXChooseVisual Lib "libGL.so.1" (display As IntPtr,
'                                                             screen As Integer,
'                                                             ByRef attribList() As Integer) As IntPtr

'#End Region

'#Region "X11"

'  Private Const AllocNone As Integer = 0

'  Private Const InputOutput As Integer = 1
'  'Private Const InputOnly As Integer = 2

'  <DllImport("libX11.so.6")>
'  Private Function XDrawString(display As IntPtr, drawable As IntPtr, gc As IntPtr,
'                               x As Integer, y As Integer, str As String, length As Integer) As Integer
'  End Function

'  <DllImport("libX11.so.6")>
'  Private Function XInternAtom(display As IntPtr, atomName As String, onlyIfExists As Boolean) As Integer
'  End Function

'  <DllImport("libX11.so.6")>
'  Private Function XOpenDisplay(display As String) As IntPtr
'  End Function

'  <DllImport("libX11.so.6", CharSet:=CharSet.Ansi)>
'  Private Sub XStoreName(display As IntPtr, window As IntPtr, title As String)
'  End Sub

'  Private Declare Sub XCloseDisplay Lib "libX11.so.6" (display As IntPtr)
'  Private Declare Function XDefaultRootWindow Lib "libX11.so.6" (display As IntPtr) As IntPtr
'  Private Declare Function XFillRectangle Lib "libX11.so.6" (display As IntPtr, drawable As IntPtr, gc As IntPtr,
'                                                             x As Integer, y As Integer,
'                                                             width As Integer, height As Integer) As Integer
'  Private Declare Function XGetWindowAttributes Lib "libX11.so.6" (display As IntPtr, w As IntPtr, <Out> ByRef windowAttributesReturn As VbXlib.XWindowAttributes) As Integer
'  Private Declare Function XLookupKeysym Lib "libX11.so.6" (ByRef keyEvent As VbXlib.XKeyEvent, index As Integer) As VbXlib.XKeySym
'  Private Declare Function XNextEvent Lib "libX11.so.6" (display As IntPtr, handle As IntPtr) As Integer
'  Private Declare Sub XSetWMProtocols Lib "libX11.so.6" (display As IntPtr, window As IntPtr,
'                                                         protocols As Integer(), count As Integer)

'  '---------------------------

'  Private Declare Function XCreateColormap Lib "libX11.so.6" (display As IntPtr,
'                                                              window As IntPtr,
'                                                              visual As IntPtr,
'                                                              alloc As Integer) As IntPtr

'  Private Declare Function XBlackPixel Lib "libX11.so.6" (display As IntPtr, screen As Integer) As ULong
'  Private Declare Function XWhitePixel Lib "libX11.so.6" (display As IntPtr, screen As Integer) As ULong
'  Private Declare Function XDefaultGC Lib "libX11.so.6" (display As IntPtr, screen As Integer) As IntPtr
'  Private Declare Function XCreateGC Lib "libX11.so.6" (display As IntPtr, drawable As IntPtr, valueMask As ULong, ByRef values As VbXlib.XGCValues) As IntPtr
'  Private Declare Function XDefaultScreen Lib "libX11.so.6" (display As IntPtr) As Integer
'  Private Declare Function XRootWindow Lib "libX11.so.6" (display As IntPtr, screen As Integer) As IntPtr
'  Private Declare Function XCreateSimpleWindow Lib "libX11.so.6" (display As IntPtr,
'                                                                  parent As IntPtr,
'                                                                  x As Integer,
'                                                                  y As Integer,
'                                                                  width As Integer,
'                                                                  height As Integer,
'                                                                  borderWidth As Integer,
'                                                                  border As ULong,
'                                                                  background As ULong) As IntPtr

'  Private Declare Function XCreateWindow Lib "libX11.so.6" (display As IntPtr, ' Display*
'                                                            parent As IntPtr, ' Window
'                                                            x As Integer, ' int
'                                                            y As Integer, ' int
'                                                            width As Integer, ' unsigned int
'                                                            height As Integer, ' unsigned int
'                                                            borderWidth As Integer, ' unsigned int
'                                                            depth As Integer, ' int
'                                                            [class] As Integer, ' unsigned int
'                                                            visual As IntPtr, ' Visual*
'                                                            valueMask As VbXlib.XWindowAttributeFlags, ' unsigned long
'                                                            ByRef attributes As VbXlib.XSetWindowAttributes ' XSetWindowAttributes*
'                                                            ) As IntPtr ' Window

'  Private Declare Sub XSelectInput Lib "libX11.so.6" (display As IntPtr, window As IntPtr, eventMask As Long)
'  Private Declare Sub XMapWindow Lib "libX11.so.6" (display As IntPtr, window As IntPtr)

'#End Region

'  Sub Go()

'    If RuntimeInformation.IsOSPlatform(OSPlatform.Windows) Then
'      Console.WriteLine("Not fer winderrrrrrrs!")
'      Environment.Exit(1)
'    End If

'    Dim display = XOpenDisplay(Nothing)
'    If display = IntPtr.Zero Then
'      Console.WriteLine("Cannot open display")
'      Environment.Exit(1)
'    End If

'    Try

'      Dim root = XDefaultRootWindow(display)

'      Dim screen = XDefaultScreen(display)
'      Dim parent = XRootWindow(display, screen)
'      Dim border = XBlackPixel(display, screen)
'      Dim background = XWhitePixel(display, screen)

'      Dim window As IntPtr

'      If False Then

'        ' Testing with opengl (work in progress)...

'        Dim glAttribs = {GLX_RGBA, GLX_DEPTH_SIZE, 24, GLX_DOUBLEBUFFER, None}
'        Dim visual = glXChooseVisual(display, 0, glAttribs)
'        Dim visualInfo = Marshal.PtrToStructure(Of VbXlib.XVisualInfo)(visual)
'        Dim colormap = XCreateColormap(display, root, visualInfo.Visual, AllocNone)

'        Dim winAttribs As VbXlib.XSetWindowAttributes
'        winAttribs.Colormap = colormap
'        winAttribs.EventMask = VbXlib.XEventMask.ExposureMask Or
'                               VbXlib.XEventMask.KeyPressMask Or
'                               VbXlib.XEventMask.KeyReleaseMask Or
'                               VbXlib.XEventMask.ButtonPressMask Or
'                               VbXlib.XEventMask.ButtonReleaseMask Or
'                               VbXlib.XEventMask.PointerMotionMask Or
'                               VbXlib.XEventMask.FocusChangeMask Or
'                               VbXlib.XEventMask.StructureNotifyMask

'        window = XCreateWindow(display,
'                               root,
'                               0,
'                               0,
'                               640,
'                               480,
'                               0,
'                               visualInfo.Depth,
'                               InputOutput,
'                               visualInfo.Visual,
'                               VbXlib.XWindowAttributeFlags.CWColormap Or VbXlib.XWindowAttributeFlags.CWEventMask,
'                               winAttribs)

'      Else

'        ' Testing X11...

'        ' Create a new window inheriting attributes from parent window.
'        window = XCreateSimpleWindow(display,
'                                     parent,
'                                     0, ' Set to 0, 0 to let X11 decide...
'                                     0,
'                                     640,
'                                     480,
'                                     1,
'                                     border,
'                                     background)

'      End If

'      Dim atomName = "WM_DELETE_WINDOW"
'      Dim WM_DELETE_WINDOW = XInternAtom(display, atomName, False)
'      Dim protocols = New Integer() {WM_DELETE_WINDOW}
'      XSetWMProtocols(display, window, protocols, 1)

'      ' Define events to handle...
'      Dim eventMask = VbXlib.XEventMask.ExposureMask Or
'                      VbXlib.XEventMask.KeyPressMask Or
'                      VbXlib.XEventMask.ButtonPressMask

'      XSelectInput(display, window, eventMask)

'      ' Display the window...
'      XMapWindow(display, window)

'      Dim title = If(RuntimeInformation.IsOSPlatform(OSPlatform.OSX),
'                   "AddressOf.com - X11 window (Mac OSX)",
'                   "AddressOf.com - X11 window (Linux)")
'      XStoreName(display, window, title)

'      Dim xe = Marshal.AllocHGlobal(Marshal.SizeOf(GetType(VbXlib._XEvent)))

'      Try
'        Do

'          ' Pops the next even structure for handling...
'          Dim status = XNextEvent(display, xe)
'          Dim xevent = CType(Marshal.PtrToStructure(xe, GetType(VbXlib._XEvent)), VbXlib._XEvent)

'          Select Case xevent.Type
'            Case VbXlib.XEventType.KeyPress
'              Console.WriteLine("KeyPress")
'              Dim key As VbXlib.XKeyEvent
'              key = CType(Marshal.PtrToStructure(xe, GetType(VbXlib.XKeyEvent)), VbXlib.XKeyEvent)
'              Dim value = XLookupKeysym(key, 0)
'              If value = VbXlib.XKeySym.XK_Escape Then
'                Exit Do
'              Else
'                Console.WriteLine($"Key: {value}")
'              End If
'            Case VbXlib.XEventType.KeyRelease
'              Console.WriteLine("KeyRelease")
'            Case VbXlib.XEventType.ButtonPress ' Mouse button pressed.
'              'Console.WriteLine("ButtonPress")
'            Case VbXlib.XEventType.ButtonRelease ' Mouse button released...
'              'Console.WriteLine("ButtonRelease")
'            Case VbXlib.XEventType.MotionNotify
'              Console.WriteLine("MotionNotify")
'            Case VbXlib.XEventType.EnterNotify ' Mouse enters client region...
'              'Console.WriteLine("EnterNotify")
'            Case VbXlib.XEventType.LeaveNotify ' Mouse leaves client region...
'              'Console.WriteLine("LeaveNotify")
'            Case VbXlib.XEventType.FocusIn
'              Console.WriteLine("FocusIn")
'            Case VbXlib.XEventType.FocusOut
'              Console.WriteLine("FocusOut")
'            Case VbXlib.XEventType.KeymapNotify
'              Console.WriteLine("KeymapNotify")
'            Case VbXlib.XEventType.Expose ' "Invalidate"?
'              'Console.WriteLine("Expose")
'              If True Then
'                Dim y_offset = 20

'                Dim s1 = If(RuntimeInformation.IsOSPlatform(OSPlatform.OSX),
'                      "X11 testing (Mac OSX)",
'                      "X11 testing (Linux)")
'                Dim s2 = "(c) 2024 AddressOf.com"
'                Dim rslt = XDrawString(display, window, XDefaultGC(display, screen), 10, y_offset, s1, s1.Length) : y_offset += 20
'                rslt = XDrawString(display, window, XDefaultGC(display, screen), 10, y_offset, s2, s2.Length) : y_offset += 20

'                y_offset += 20

'                Dim systemInformationText = "System information:"
'                Dim osText = $"- Operating System: {RuntimeInformation.OSDescription}"
'                Dim archText = $"- Architecture: {RuntimeInformation.OSArchitecture}"
'                Dim fxText = $"- Framework: {RuntimeInformation.FrameworkDescription}"
'                Dim vbText = $"- Compiler: VISUAL BASIC!!!!!"
'                rslt = XDrawString(display, window, XDefaultGC(display, screen), 10, y_offset, systemInformationText, systemInformationText.Length) : y_offset += 15
'                rslt = XDrawString(display, window, XDefaultGC(display, screen), 10, y_offset, osText, osText.Length) : y_offset += 15
'                rslt = XDrawString(display, window, XDefaultGC(display, screen), 10, y_offset, archText, archText.Length) : y_offset += 15
'                rslt = XDrawString(display, window, XDefaultGC(display, screen), 10, y_offset, fxText, fxText.Length) : y_offset += 15
'                rslt = XDrawString(display, window, XDefaultGC(display, screen), 10, y_offset, vbText, vbText.Length) : y_offset += 20

'                y_offset += 20

'                Dim windowAttributes As VbXlib.XWindowAttributes
'                rslt = XGetWindowAttributes(display, window, windowAttributes)
'                Dim str = $"Current window size: {windowAttributes.Width}x{windowAttributes.Height}"
'                rslt = XDrawString(display, window, XDefaultGC(display, screen), 10, y_offset, str, str.Length) ': y_offset += 20

'              Else
'                ' Fill a single rectangular area for a given drawable...
'                Dim rslt = XFillRectangle(display, window, XDefaultGC(display, screen), 20, 20, 10, 10)
'                ' Draw 8-bit characters in a given drawable...
'                Dim msg = "Hello, World!"
'                rslt = XDrawString(display, window, XDefaultGC(display, screen),
'                                 10, 50, msg, msg.Length)
'              End If
'            Case VbXlib.XEventType.GraphicsExpose
'              Console.WriteLine("GraphicsExpose")
'            Case VbXlib.XEventType.NoExpose
'              Console.WriteLine("NoExpose")
'            Case VbXlib.XEventType.VisibilityNotify
'              Console.WriteLine("VisibilityNotify")
'            Case VbXlib.XEventType.CreateNotify
'              Console.WriteLine("CreateNotify")
'            Case VbXlib.XEventType.DestroyNotify
'              Console.WriteLine("DestroyNotify")
'            Case VbXlib.XEventType.UnmapNotify
'              Console.WriteLine("UnmapNotify")
'            Case VbXlib.XEventType.MapNotify
'              Console.WriteLine("MapNotify")
'            Case VbXlib.XEventType.MapRequest
'              Console.WriteLine("MapRequest")
'            Case VbXlib.XEventType.ReparentNotify
'              Console.WriteLine("ReparentNotify")
'            Case VbXlib.XEventType.ConfigureNotify
'            'NOTE: This one happens often...
'            'Console.WriteLine("ConfigureNotify")
'            Case VbXlib.XEventType.ConfigureRequest
'              Console.WriteLine("ConfigureRequest")
'            Case VbXlib.XEventType.GravityNotify
'              Console.WriteLine("GravityNotify")
'            Case VbXlib.XEventType.ResizeRequest
'              Console.WriteLine("ResizeNotify")
'            Case VbXlib.XEventType.CirculateNotify
'              Console.WriteLine("CirculateNotify")
'            Case VbXlib.XEventType.CirculateRequest
'              Console.WriteLine("CirculateRequest")
'            Case VbXlib.XEventType.PropertyNotify
'              Console.WriteLine("PropertyNotify")
'            Case VbXlib.XEventType.SelectionClear
'              Console.WriteLine("SelectionClear")
'            Case VbXlib.XEventType.SelectionRequest
'              Console.WriteLine("SelectionRequest")
'            Case VbXlib.XEventType.SelectionNotify
'              Console.WriteLine("SelectionNotify")
'            Case VbXlib.XEventType.ColormapNotify
'              Console.WriteLine("ColormapNotify")
'            Case VbXlib.XEventType.ClientMessage
'              'Console.WriteLine("ClientMessage")
'              Dim ce As VbXlib.XClientMessageEvent
'              ce = CType(Marshal.PtrToStructure(xe, GetType(VbXlib.XClientMessageEvent)), VbXlib.XClientMessageEvent)
'              If ce.Format = 32 Then ' Use the L values?
'                If ce.L0 = WM_DELETE_WINDOW Then ' Does it match?
'                  Exit Do ' Exit loop.
'                End If
'              End If
'            Case VbXlib.XEventType.MappingNotify
'              Console.WriteLine("MappingNotify")
'            Case Else
'              Console.WriteLine("Unknown!!!")
'          End Select
'        Loop
'      Finally
'        Marshal.FreeHGlobal(xe)
'      End Try

'    Finally
'      Console.WriteLine("Closing...")
'      XCloseDisplay(display)
'    End Try

'    Console.WriteLine("Closed.")

'  End Sub

'End Module