Imports System.Runtime.InteropServices

Public NotInheritable Class XEvent
  Inherits XHandle

  Private ReadOnly m_display As XDisplay
  Private m_xevent As BaseXEvent

  Public Event ShapeHandlerEvent As ShapeHandler
  Public Event KeyPressHandlerEvent As KeyPressHandler
  Public Event KeyReleaseHandlerEvent As KeyReleaseHandler
  Public Event ButtonPressHandlerEvent As ButtonPressHandler
  Public Event ButtonReleaseHandlerEvent As ButtonReleaseHandler
  Public Event ExposeHandlerEvent As ExposeHandler
  Public Event EnterNotifyHandlerEvent As EnterNotifyHandler
  Public Event LeaveNotifyHandlerEvent As LeaveNotifyHandler
  Public Event MotionNotifyHandlerEvent As MotionNotifyHandler
  Public Event FocusInHandlerEvent As FocusInHandler
  Public Event FocusOutHandlerEvent As FocusOutHandler
  Public Event KeymapNotifyHandlerEvent As KeymapNotifyHandler
  Public Event GraphicsExposeHandlerEvent As GraphicsExposeHandler
  Public Event NoExposeHandlerEvent As NoExposeHandler
  Public Event VisibilityNotifyHandlerEvent As VisibilityNotifyHandler
  Public Event CreateNotifyHandlerEvent As CreateNotifyHandler
  Public Event DestroyNotifyHandlerEvent As DestroyNotifyHandler
  Public Event UnmapNotifyHandlerEvent As UnmapNotifyHandler
  Public Event MapNotifyHandlerEvent As MapNotifyHandler
  Public Event MapRequestHandlerEvent As MapRequestHandler
  Public Event ReparentNotifyHandlerEvent As ReparentNotifyHandler
  Public Event ConfigureNotifyHandlerEvent As ConfigureNotifyHandler
  Public Event ConfigureRequestHandlerEvent As ConfigureRequestHandler
  Public Event GravityNotifyHandlerEvent As GravityNotifyHandler
  Public Event ResizeRequestHandlerEvent As ResizeRequestHandler
  Public Event CirculateNotifyHandlerEvent As CirculateNotifyHandler
  Public Event CirculateRequestHandlerEvent As CirculateRequestHandler
  Public Event PropertyNotifyHandlerEvent As PropertyNotifyHandler
  Public Event SelectionClearHandlerEvent As SelectionClearHandler
  Public Event SelectionRequestHandlerEvent As SelectionRequestHandler
  Public Event SelectionNotifyHandlerEvent As SelectionNotifyHandler
  Public Event ColormapNotifyHandlerEvent As ColormapNotifyHandler
  Public Event ClientMessageHandlerEvent As ClientMessageHandler
  Public Event MappingNotifyHandlerEvent As MappingNotifyHandler

  'Public Event ErrorHandlerEvent As ErrorHandler

  Public Sub New(display As XDisplay)
    m_display = display
    Handle = Marshal.AllocHGlobal(Marshal.SizeOf(GetType(BaseXEvent)))
    SetErrorHandler()
  End Sub

  Public Overrides Sub Dispose()
    'Console.WriteLine("Disposing of XEvent")
    Marshal.FreeHGlobal(Handle)
    MyBase.Dispose()
  End Sub

  Public ReadOnly Property Type As XEventType
    Get
      Return m_xevent.Type
    End Get
  End Property

  Public Function CheckTypedEvent(eventType As XEventType) As Boolean
    Return XCheckTypedEvent(m_display.Handle, eventType, Handle)
  End Function

  Public Function [Next]() As Integer
    Dim status = XNextEvent(m_display.Handle, Handle)
    m_xevent = CType(Marshal.PtrToStructure(Handle, GetType(BaseXEvent)), BaseXEvent)
    Return status
  End Function

  Public ReadOnly Property Any As XAnyEvent
    Get
      Dim result As XAnyEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XAnyEvent)), XAnyEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Key As XKeyEvent
    Get
      Dim result As XKeyEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XKeyEvent)), XKeyEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Button As XButtonEvent
    Get
      Dim result As XButtonEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XButtonEvent)), XButtonEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Motion As XMotionEvent
    Get
      Dim result As XMotionEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XMotionEvent)), XMotionEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Crossing As XCrossingEvent
    Get
      Dim result As XCrossingEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XCrossingEvent)), XCrossingEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Focus As XFocusChangeEvent
    Get
      Dim result As XFocusChangeEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XFocusChangeEvent)), XFocusChangeEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Expose As XExposeEvent
    Get
      Dim result As XExposeEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XExposeEvent)), XExposeEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property GraphicsExpose As XGraphicsExposeEvent
    Get
      Dim result As XGraphicsExposeEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XGraphicsExposeEvent)), XGraphicsExposeEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property NoExpose As XNoExposeEvent
    Get
      Dim result As XNoExposeEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XNoExposeEvent)), XNoExposeEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Visibility As XVisibilityEvent
    Get
      Dim result As XVisibilityEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XVisibilityEvent)), XVisibilityEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property CreateWindow As XCreateWindowEvent
    Get
      Dim result As XCreateWindowEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XCreateWindowEvent)), XCreateWindowEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property DestroyWindow As XDestroyWindowEvent
    Get
      Dim result As XDestroyWindowEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XDestroyWindowEvent)), XDestroyWindowEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Unmap As XUnmapEvent
    Get
      Dim result As XUnmapEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XUnmapEvent)), XUnmapEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Map As XMapEvent
    Get
      Dim result As XMapEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XMapEvent)), XMapEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property MapRequest As XMapRequestEvent
    Get
      Dim result As XMapRequestEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XMapRequestEvent)), XMapRequestEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Reparent As XReparentEvent
    Get
      Dim result As XReparentEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XReparentEvent)), XReparentEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Configure As XConfigureEvent
    Get
      Dim result As XConfigureEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XConfigureEvent)), XConfigureEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Gravity As XGravityEvent
    Get
      Dim result As XGravityEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XGravityEvent)), XGravityEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property ResizeRequest As XResizeRequestEvent
    Get
      Dim result As XResizeRequestEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XResizeRequestEvent)), XResizeRequestEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property ConfigureRequest As XConfigureRequestEvent
    Get
      Dim result As XConfigureRequestEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XConfigureRequestEvent)), XConfigureRequestEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Circulate As XCirculateEvent
    Get
      Dim result As XCirculateEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XCirculateEvent)), XCirculateEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property CirculateRequest As XCirculateRequestEvent
    Get
      Dim result As XCirculateRequestEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XCirculateRequestEvent)), XCirculateRequestEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property [Property] As XPropertyEvent
    Get
      Dim result As XPropertyEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XPropertyEvent)), XPropertyEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property SelectionClear As XSelectionClearEvent
    Get
      Dim result As XSelectionClearEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XSelectionClearEvent)), XSelectionClearEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property SelectionRequest As XSelectionRequestEvent
    Get
      Dim result As XSelectionRequestEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XSelectionRequestEvent)), XSelectionRequestEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Selection As XSelectionEvent
    Get
      Dim result As XSelectionEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XSelectionEvent)), XSelectionEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Colormap As XColormapEvent
    Get
      Dim result As XColormapEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XColormapEvent)), XColormapEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property ClientMessage As XClientMessageEvent
    Get
      Dim result As XClientMessageEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XClientMessageEvent)), XClientMessageEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Mapping As XMappingEvent
    Get
      Dim result As XMappingEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XMappingEvent)), XMappingEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property [Error] As XErrorEvent
    Get
      Dim result As XErrorEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XErrorEvent)), XErrorEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Keymap As XKeymapEvent
    Get
      Dim result As XKeymapEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XKeymapEvent)), XKeymapEvent)
      Return result
    End Get
  End Property

  Public ReadOnly Property Shape As XShapeEvent
    Get
      Dim result As XShapeEvent
      result = CType(Marshal.PtrToStructure(Handle, GetType(XShapeEvent)), XShapeEvent)
      Return result
    End Get
  End Property

  Public Function AllowEvents(eventMode As XEventMode) As Integer
    Return XAllowEvents(Handle, eventMode, 0)
  End Function

  Public Function SendClientMessage(w As XWindow, a As XAtom, propagate As Boolean, eventMask As XEventMask) As Integer
    If w Is Nothing OrElse
       a Is Nothing OrElse
       propagate OrElse
       eventMask = XEventMask.Button1MotionMask Then
    End If
    Return 0
  End Function

  Public Function Pending() As Integer
    Return XPending(m_display.Handle)
  End Function

  Public Sub [Loop]()

    Do

      [Next]()

      Select Case Type
        Case XEventType.KeyPress
          Dim key1 As XKeyEvent = Key
          RaiseEvent KeyPressHandlerEvent(key1, New XWindow(m_display, key1.Window), New XWindow(m_display, key1.Root), New XWindow(m_display, key1.Subwindow))

        Case XEventType.KeyRelease
          Dim key1 As XKeyEvent = Key
          RaiseEvent KeyReleaseHandlerEvent(key1, New XWindow(m_display, key1.Window), New XWindow(m_display, key1.Root), New XWindow(m_display, key1.Subwindow))

        Case XEventType.ButtonPress
          Dim button1 As XButtonEvent = Button
          RaiseEvent ButtonPressHandlerEvent(button1, New XWindow(m_display, button1.Window), New XWindow(m_display, button1.Root), New XWindow(m_display, button1.Subwindow))

        Case XEventType.ButtonRelease
          Dim button1 As XButtonEvent = Button
          RaiseEvent ButtonReleaseHandlerEvent(button1, New XWindow(m_display, button1.Window), New XWindow(m_display, button1.Root), New XWindow(m_display, button1.Subwindow))

        Case XEventType.Expose
          Dim expose1 As XExposeEvent = Expose
          RaiseEvent ExposeHandlerEvent(expose1, New XWindow(m_display, expose1.Window))

        Case XEventType.EnterNotify
          Dim crossing1 As XCrossingEvent = Crossing
          RaiseEvent EnterNotifyHandlerEvent(crossing1, New XWindow(m_display, crossing1.Window), New XWindow(m_display, crossing1.Root), New XWindow(m_display, crossing1.Subwindow))

        Case XEventType.LeaveNotify
          Dim crossing1 As XCrossingEvent = Crossing
          RaiseEvent LeaveNotifyHandlerEvent(Crossing, New XWindow(m_display, crossing1.Window), New XWindow(m_display, crossing1.Root), New XWindow(m_display, crossing1.Subwindow))

        Case XEventType.MotionNotify
          Dim motion1 As XMotionEvent = Motion
          RaiseEvent MotionNotifyHandlerEvent(motion1, New XWindow(m_display, motion1.Window), New XWindow(m_display, motion1.Root), New XWindow(m_display, motion1.Subwindow))

        Case XEventType.FocusIn
          Dim focus1 As XFocusChangeEvent = Focus
          RaiseEvent FocusInHandlerEvent(Focus, New XWindow(m_display, focus1.Window))

        Case XEventType.FocusOut
          Dim focus1 As XFocusChangeEvent = Focus
          RaiseEvent FocusOutHandlerEvent(Focus, New XWindow(m_display, focus1.Window))

        Case XEventType.KeymapNotify
          Dim keymap1 As XKeymapEvent = Keymap
          RaiseEvent KeymapNotifyHandlerEvent(keymap1, New XWindow(m_display, keymap1.Window))

        Case XEventType.GraphicsExpose
          Dim graphicsexpose1 As XGraphicsExposeEvent = GraphicsExpose
          RaiseEvent GraphicsExposeHandlerEvent(graphicsexpose1, New XWindow(m_display, graphicsexpose1.Drawable))

        Case XEventType.NoExpose
          Dim noexpose1 As XNoExposeEvent = NoExpose
          RaiseEvent NoExposeHandlerEvent(noexpose1, New XWindow(m_display, noexpose1.Drawable))

        Case XEventType.VisibilityNotify
          Dim visibility1 As XVisibilityEvent = Visibility
          RaiseEvent VisibilityNotifyHandlerEvent(visibility1, New XWindow(m_display, visibility1.Window))

        Case XEventType.CreateNotify
          Dim createwindow1 As XCreateWindowEvent = CreateWindow
          RaiseEvent CreateNotifyHandlerEvent(createwindow1, New XWindow(m_display, createwindow1.Parent), New XWindow(m_display, createwindow1.Window))

        Case XEventType.DestroyNotify
          Dim destroywindow1 As XDestroyWindowEvent = DestroyWindow
          RaiseEvent DestroyNotifyHandlerEvent(destroywindow1, New XWindow(m_display, destroywindow1.Window))

        Case XEventType.UnmapNotify
          Dim unmap1 As XUnmapEvent = Unmap
          RaiseEvent UnmapNotifyHandlerEvent(unmap1, New XWindow(m_display, unmap1.Window))

        Case XEventType.MapNotify
          Dim map1 As XMapEvent = Map
          RaiseEvent MapNotifyHandlerEvent(map1, New XWindow(m_display, map1.Window))

        Case XEventType.MapRequest
          Dim maprequest1 As XMapRequestEvent = MapRequest
          RaiseEvent MapRequestHandlerEvent(maprequest1, New XWindow(m_display, maprequest1.Parent), New XWindow(m_display, maprequest1.Window))

        Case XEventType.ReparentNotify
          Dim reparent1 As XReparentEvent = Reparent
          RaiseEvent ReparentNotifyHandlerEvent(reparent1, New XWindow(m_display, reparent1.Parent), New XWindow(m_display, reparent1.Window))

        Case XEventType.ConfigureNotify
          Dim configure1 As XConfigureEvent = Configure
          RaiseEvent ConfigureNotifyHandlerEvent(Configure, New XWindow(m_display, configure1.Window))

        Case XEventType.ConfigureRequest
          Dim configure1 As XConfigureRequestEvent = ConfigureRequest
          RaiseEvent ConfigureRequestHandlerEvent(ConfigureRequest, New XWindow(m_display, configure1.Window))

        Case XEventType.GravityNotify
          Dim gravity1 As XGravityEvent = Gravity
          RaiseEvent GravityNotifyHandlerEvent(gravity1, New XWindow(m_display, gravity1.Window))

        Case XEventType.ResizeRequest
          Dim resizerequest1 As XResizeRequestEvent = ResizeRequest
          RaiseEvent ResizeRequestHandlerEvent(resizerequest1, New XWindow(m_display, resizerequest1.Window))

        Case XEventType.CirculateNotify
          Dim circulate1 As XCirculateEvent = Circulate
          RaiseEvent CirculateNotifyHandlerEvent(circulate1, New XWindow(m_display, circulate1.Window))

        Case XEventType.CirculateRequest
          Dim circulate1 As XCirculateRequestEvent = CirculateRequest
          RaiseEvent CirculateRequestHandlerEvent(circulate1, New XWindow(m_display, circulate1.Parent), New XWindow(m_display, circulate1.Window))

        Case XEventType.PropertyNotify
          Dim property1 As XPropertyEvent = [Property]
          RaiseEvent PropertyNotifyHandlerEvent([Property], New XWindow(m_display, [Property].Window))

        Case XEventType.SelectionClear
          Dim selectionclear1 As XSelectionClearEvent = SelectionClear
          RaiseEvent SelectionClearHandlerEvent(selectionclear1, New XWindow(m_display, selectionclear1.Window))

        Case XEventType.SelectionRequest
          Dim selectionrequest1 As XSelectionRequestEvent = SelectionRequest
          RaiseEvent SelectionRequestHandlerEvent(selectionrequest1, New XWindow(m_display, selectionrequest1.Owner), New XWindow(m_display, selectionrequest1.Requestor), New XWindow(m_display, selectionrequest1.Target))

        Case XEventType.SelectionNotify
          Dim selection1 As XSelectionEvent = Selection
          RaiseEvent SelectionNotifyHandlerEvent(selection1, New XWindow(m_display, selection1.Requestor), New XWindow(m_display, selection1.Target))

        Case XEventType.ColormapNotify
          Dim colormap1 As XColormapEvent = Colormap
          RaiseEvent ColormapNotifyHandlerEvent(colormap1, New XWindow(m_display, colormap1.Window))

        Case XEventType.ClientMessage
          Dim clientmessage1 As XClientMessageEvent = ClientMessage
          RaiseEvent ClientMessageHandlerEvent(clientmessage1, New XWindow(m_display, clientmessage1.Window))

        Case XEventType.MappingNotify
          Dim mapping1 As XMappingEvent = Mapping
          RaiseEvent MappingNotifyHandlerEvent(mapping1, New XWindow(m_display, mapping1.Window))

        Case Else
          Dim shape1 As XShapeEvent = Shape
          RaiseEvent ShapeHandlerEvent(shape1, New XWindow(m_display, shape1.Window))

      End Select

    Loop

  End Sub

  <DllImport("libX11.so.6")>
  Private Shared Function XNextEvent(display As IntPtr, handle As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XCheckTypedEvent(display As IntPtr, eventType As XEventType, eventReturn As IntPtr) As Boolean
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XAllowEvents(display As IntPtr, eventMode As XEventMode, time As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XSendEvent(display As IntPtr, w As IntPtr, propagate As Boolean, eventMask As XEventMask, eventSend As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XPending(display As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XSetErrorHandler(err As XHandleXError) As Integer
  End Function

  Public Sub SetErrorHandler()
    Dim rslt = XSetErrorHandler(New XHandleXError(AddressOf HandleError))
  End Sub

  Private Function HandleError(d As IntPtr, e As IntPtr) As Integer
    Dim err = CType(Marshal.PtrToStructure(e, GetType(XErrorEvent)), XErrorEvent)
    Console.WriteLine($"Size of XErrorEvent = {Marshal.SizeOf(err)}")
    Console.WriteLine($"Size of IntPtr = {Marshal.SizeOf(err.Display)}")
    Console.WriteLine($"Err.{err.ResourceId}")
    Console.WriteLine($"Err.{err.Serial}")
    Console.WriteLine($"Err.{err.Error_Code}")
    Console.WriteLine($"Err.{err.Request_Code}")
    Console.WriteLine($"Err.{err.Minor_Code}")
    'Return ErrorHandlerEvent(err)
    Return 0
  End Function

End Class