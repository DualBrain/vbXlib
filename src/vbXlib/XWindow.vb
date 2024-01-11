Imports System.Drawing
Imports System.Runtime.InteropServices

Public Class XWindow
  Inherits XHandle

  Private ReadOnly m_display As XDisplay
  Private m_disposed As Boolean = False

  Public ReadOnly Property Id As IntPtr
    Get
      Return Handle
    End Get
  End Property

  Public ReadOnly Property Root As IntPtr
    Get
      Return XDefaultRootWindow(m_display.Handle)
    End Get
  End Property

  Public Property Name As String
    Get
      Dim name1 As String = [String].Empty
      Dim rslt = XFetchName(m_display.Handle, Handle, name1)
      Return name1
    End Get
    Set(value As String)
      Dim rslt = XStoreName(m_display.Handle, Handle, value)
    End Set
  End Property

  Public Function SelectInput(mask As XEventMask) As Integer
    Return XSelectInput(m_display.Handle, Handle, mask)
  End Function

  Public Function DefineCursor(cursor As XCursor) As Integer
    Return XDefineCursor(m_display.Handle, Handle, cursor.Handle)
  End Function

  Public Sub New(display As XDisplay)
    m_display = display
    Handle = Root
  End Sub

  Public Sub New(display As XDisplay, handle As IntPtr)
    m_display = display
    Me.Handle = handle
  End Sub

  Public Sub New(display As XDisplay, rect As Rectangle)
    m_display = display
    Handle = XCreateSimpleWindow(m_display.Handle,
                                 Root,
                                 rect.X,
                                 rect.Y,
                                 rect.Width,
                                 rect.Height,
                                 1,
                                 m_display.Screen.BlackPixel(),
                                 m_display.Screen.WhitePixel())
  End Sub

  Public Sub New(display As XDisplay, rect As Rectangle, borderWidth As Integer, borderColor As Integer, backgroundColor As Integer)
    m_display = display
    Handle = XCreateSimpleWindow(m_display.Handle,
                                 Root,
                                 rect.X,
                                 rect.Y,
                                 rect.Width,
                                 rect.Height,
                                 borderWidth,
                                 borderColor,
                                 backgroundColor)
  End Sub

  Public Sub New(display As XDisplay, parent As XWindow, rect As Rectangle, borderWidth As Integer, borderColor As Integer, backgroundColor As Integer)
    m_display = display
    Handle = XCreateSimpleWindow(m_display.Handle,
                                 parent.Handle,
                                 rect.X,
                                 rect.Y,
                                 rect.Width,
                                 rect.Height,
                                 borderWidth,
                                 borderColor,
                                 backgroundColor)
  End Sub

  Public Overrides Sub Dispose()
    Destroy()
    MyBase.Dispose()
  End Sub

  Public Sub Destroy()
    If Not m_disposed Then
      'Console.WriteLine("Destroying window")
      Dim rslt = XDestroyWindow(m_display.Handle, Handle)
      m_disposed = True
    End If
  End Sub

  Public Sub Map()
    If Handle <> Root Then
      Dim rslt = XMapWindow(m_display.Handle, Handle)
    End If
  End Sub

  Public Sub Unmap()
    Dim rslt = XunmapWindow(m_display.Handle, Handle)
  End Sub

  Public Sub MapSubwindows()
    Dim rslt = XMapSubwindows(m_display.Handle, Handle)
  End Sub

  Public Function Reparent(window As XWindow, p As Point) As Integer
    Return XReparentWindow(m_display.Handle, Handle, window.Handle, p.X, p.Y)
  End Function

  Public Function Clear() As Integer
    Return XClearWindow(m_display.Handle, Handle)
  End Function

  Public Function DrawString(gc As XGC, p As Point, text As String) As Integer
    Return XDrawString(m_display.Handle, Handle, gc.Handle, p.X, p.Y, text, text.Length)
  End Function

  Public Function ChangeAttributes(mask As XWindowAttributeFlags, attributes As XSetWindowAttributes) As Integer
    Dim attr = Marshal.AllocHGlobal(Marshal.SizeOf(attributes))
    Marshal.StructureToPtr(attributes, attr, False)
    Dim result = XChangeWindowAttributes(m_display.Handle, Handle, mask, attr)
    Marshal.FreeHGlobal(attr)
    Return result
  End Function

  Public Function ChangeAttributesOnRoot(mask As XWindowAttributeFlags, attributes As XSetWindowAttributes) As Integer
    If mask <> XWindowAttributeFlags.CWBackingPixel OrElse
      attributes.BackgroundPixel <> 0 AndAlso
      m_display.Handle <> IntPtr.Zero Then
    End If
    Return 0
  End Function

  Public Function GetAttributes() As XWindowAttributes
    Dim windowAttributesReturn As XWindowAttributes
    Dim rslt = XGetWindowAttributes(m_display.Handle, Handle, windowAttributesReturn)
    Return windowAttributesReturn
  End Function

  Public Function QueryTree() As List(Of XWindow)
    Dim rootReturn As IntPtr
    Dim parentReturn As IntPtr
    Dim childrenReturn As IntPtr
    Dim nchildrenReturn As Integer
    Dim rslt = XQueryTree(m_display.Handle,
                          Handle,
                          rootReturn,
                          parentReturn,
                          childrenReturn,
                          nchildrenReturn)
    Console.WriteLine($"Total Windows = {nchildrenReturn}")
    Dim awins = New IntPtr(nchildrenReturn - 1) {}
    Marshal.Copy(childrenReturn, awins, 0, awins.Length)
    Dim wins As New List(Of XWindow)
    For Each wid In awins
      Dim win = New XWindow(m_display, wid)
      wins.Add(win)
    Next
    Return wins
  End Function

  Public Function Configure(valueMask As Integer, changes As XWindowChanges) As Integer
    Return XConfigureWindow(m_display.Handle, Handle, valueMask, changes)
  End Function

  Public Function GrabButton(button As Integer, modifiers As XModMask, grabWindow As IntPtr, ownerEvents As Boolean, eventMask As XEventMask, pointerMode As XGrabMode, keyboardMode As XGrabMode, confineTo As Integer, cursor As IntPtr) As Integer
    Return XGrabButton(m_display.Handle,
                       button,
                       modifiers,
                       grabWindow,
                       ownerEvents,
                       eventMask,
                       pointerMode,
                       keyboardMode,
                       confineTo,
                       cursor)
  End Function

  Public Function GrabButton(button As Integer, modifiers As XModMask, eventMask As XEventMask) As Integer
    Return XGrabButton(m_display.Handle,
                       button,
                       modifiers,
                       Handle,
                       True,
                       eventMask,
                       XGrabMode.GrabModeAsync,
                       XGrabMode.GrabModeAsync,
                       0,
                       IntPtr.Zero)
  End Function

  Public Function UngrabButton(button As XMouseButton, modifiers As XModMask) As Integer
    Return XUngrabButton(m_display.Handle, button, modifiers, Handle)
  End Function

  Public Function GrabPointer(eventMask As XEventMask) As Integer
    Return XGrabPointer(m_display.Handle,
                        Handle,
                        True,
                        eventMask,
                        XGrabMode.GrabModeAsync,
                        XGrabMode.GrabModeAsync,
                        0,
                        0,
                        0)
  End Function

  Public Function UngrabPointer() As Integer
    Return XUngrabPointer(m_display.Handle, 0)
  End Function

  Public Function QueryPointer() As XPointerQueryInfo

    Dim pi As New XPointerQueryInfo

    Dim rootReturn, childReturn As IntPtr
    Dim rootReturnX, rootReturnY, winReturnX, winReturnY, maskReturn As Integer

    XQueryPointer(m_display.Handle,
                  Handle,
                  rootReturn,
                  childReturn,
                  rootReturnX,
                  rootReturnY,
                  winReturnX,
                  winReturnY,
                  maskReturn)

    pi.Root = rootReturn
    pi.Child = childReturn
    pi.RootX = rootReturnX
    pi.RootY = rootReturnY
    pi.WinX = winReturnX
    pi.WinY = winReturnY
    pi.Mask = maskReturn

    Return pi

  End Function

  Public Function SetInputFocus(revertTo As XInputFocus) As Integer
    Return XSetInputFocus(m_display.Handle, Handle, revertTo, 0)
  End Function

  Public Function Move(p As Point) As Integer
    Return XMoveWindow(m_display.Handle, Handle, p.X, p.Y)
  End Function

  Public Function Resize(size As Size) As Integer
    Return XResizeWindow(m_display.Handle, Handle, size.Width, size.Height)
  End Function

  Public Function MoveResize(rect As Rectangle) As Integer
    Return XMoveResizeWindow(m_display.Handle,
                             Handle,
                             rect.X,
                             rect.Y,
                             rect.Width,
                             rect.Height)
  End Function

  Public Function MoveResize(x As Integer, y As Integer, width As Integer, height As Integer) As Integer
    Return XMoveResizeWindow(m_display.Handle,
                             Handle,
                             x,
                             y,
                             width,
                             height)
  End Function

  Public Function Raise() As Integer
    Return XRaiseWindow(m_display.Handle, Handle)
  End Function

  Public Function Lower() As Integer
    Return XLowerWindow(m_display.Handle, Handle)
  End Function

  Public Function SetBackgroundColor(color As XColor) As Integer
    Return XSetWindowBackground(m_display.Handle, Handle, color.Pixel)
  End Function

  Public Function SetBackgroundColor(color As Color) As Integer
    Return XSetWindowBackground(m_display.Handle, Handle, New XColor(m_display, color).Pixel)
  End Function

  Public Function GrabKey(keysym As XKeySym, modifiers As XModMask, ownerEvents As Boolean, pointerMode As XGrabMode, keyboardMode As XGrabMode) As Integer
    Return XGrabKey(m_display.Handle,
                    XKeysymToKeycode(m_display.Handle, keysym),
                    modifiers,
                    Handle,
                    ownerEvents,
                    pointerMode,
                    keyboardMode)
  End Function

  Public Function UngrabKey(keysym As XKeySym, modifiers As XModMask) As Integer
    Return XUngrabKey(m_display.Handle, XKeysymToKeycode(m_display.Handle, keysym), modifiers, Handle)
  End Function

  Public Function KeysymToKeycode(keysym As XKeySym) As Integer
    Return XKeysymToKeycode(m_display.Handle, keysym)
  End Function

  Public Function KeycodeToKeysym(keycode As Integer) As XKeySym
    Return XKeycodeToKeysym(m_display.Handle, keycode, 0)
  End Function

  Public Shared Function LookupKeysym(ByRef keyEvent As XKeyEvent) As XKeySym
    Return XLookupKeysym(keyEvent, 0)
  End Function

  Public Function GetTransientForHint() As XWindow

    Dim windowReturn As IntPtr

    Dim rslt = XGetTransientForHint(m_display.Handle, Handle, windowReturn)

    If windowReturn = IntPtr.Zero Then
      Return Nothing
    Else
      Return New XWindow(m_display, windowReturn)
    End If

  End Function

  Public Function SetTransientForHint(propWindow As XWindow) As Integer
    Return XSetTransientForHint(m_display.Handle, Handle, propWindow.Handle)
  End Function

  Public Function AddToSaveSet() As Integer
    Return XAddToSaveSet(m_display.Handle, Handle)
  End Function

  Public Function RemoveFromSaveSet() As Integer
    Return XRemoveFromSaveSet(m_display.Handle, Handle)
  End Function

  Public Function KillClient() As Integer
    Return XKillClient(m_display.Handle, Handle)
  End Function

  Public Function GetWMHints() As XWMHints

    Dim ptr = XGetWMHints(m_display.Handle, Handle)

    Dim hints As XWMHints

    hints = CType(Marshal.PtrToStructure(ptr, GetType(XWMHints)), XWMHints)

    Return hints

  End Function

  Public Sub SetWMHints(wmhints As XWMHints)
    Dim rslt = XSetWMHints(m_display.Handle, Handle, wmhints)
  End Sub

  Public Function GetNormalHints() As XSizeHints
    Dim hintsReturn As IntPtr
    Dim hints As XSizeHints
    hintsReturn = XAllocSizeHints()
    Dim rslt = XGetNormalHints(m_display.Handle, Handle, hintsReturn)
    hints = CType(Marshal.PtrToStructure(hintsReturn, GetType(XSizeHints)), XSizeHints)
    rslt = XFree(hintsReturn)
    Return hints
  End Function

  Public Function SetBackgroundPixmap(p As XPixmap) As Integer
    Return XSetWindowBackgroundPixmap(m_display.Handle, Handle, p.Handle)
  End Function

  Public Function SetWindowBorder(color As XColor) As Integer
    Return XSetWindowBorder(m_display.Handle, Handle, color.Pixel)
  End Function

  Public Function SetWindowBorderWidth(width As Integer) As Integer
    Return XSetWindowBorderWidth(m_display.Handle, Handle, width)
  End Function

  Public Function ClassHint(<Out> ByRef classHintReturn As XClassHint) As Integer
    Return XGetClassHint(m_display.Handle, Handle, classHintReturn)
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XQueryTree(display As IntPtr, w As IntPtr, <Out> ByRef rootReturn As IntPtr, <Out> ByRef parentReturn As IntPtr, <Out> ByRef childrenReturn As IntPtr, <Out> ByRef nchildrenReturn As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XDefaultRootWindow(display As IntPtr) As IntPtr
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XMapWindow(display As IntPtr, window As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XunmapWindow(display As IntPtr, window As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XMapSubwindows(display As IntPtr, window As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XDestroyWindow(display As IntPtr, window As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XCreateSimpleWindow(display As IntPtr, parent As IntPtr, x As Integer, y As Integer, w As Integer, h As Integer, borderWidth As Integer, border As Integer, color As Integer) As IntPtr
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XStoreName(display As IntPtr, w As IntPtr, name As String) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XFetchName(display As IntPtr, w As IntPtr, <Out> ByRef windowNameReturn As String) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XSelectInput(display As IntPtr, w As IntPtr, mask As XEventMask) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XReparentWindow(display As IntPtr, w As IntPtr, p As IntPtr, x As Integer, y As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XClearWindow(display As IntPtr, w As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6", CharSet:=CharSet.Ansi)>
  Private Shared Function XDrawString(display As IntPtr, displayable As IntPtr, gc As IntPtr,
                                      x As Integer, y As Integer, str As String, length As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XChangeWindowAttributes(display As IntPtr, w As IntPtr, mask As XWindowAttributeFlags, attributes As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XGrabButton(display As IntPtr, button As Integer, modifiers As XModMask, grabWindow As IntPtr, ownerEvents As Boolean, eventMask As XEventMask, pointerMode As XGrabMode, keyboardMode As XGrabMode, confineTo As Integer, cursor As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XUngrabButton(display As IntPtr, button As XMouseButton, modifiers As XModMask, grabWindow As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XConfigureWindow(display As IntPtr, w As IntPtr, valueMask As Integer, changes As XWindowChanges) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XGetWindowAttributes(display As IntPtr, w As IntPtr, <Out> ByRef windowAttributesReturn As XWindowAttributes) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XUngrabPointer(display As IntPtr, t As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XGrabPointer(display As IntPtr, grabWindow As IntPtr, ownerEvents As Boolean, eventMask As XEventMask, pointerMode As XGrabMode, keyboardMode As XGrabMode, confineTo As Integer, cursor As Integer, time As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XSetInputFocus(display As IntPtr, focus As IntPtr, revertTo As XInputFocus, time As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XMoveWindow(display As IntPtr, w As IntPtr, x As Integer, y As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XResizeWindow(display As IntPtr, w As IntPtr, width As Integer, height As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XMoveResizeWindow(display As IntPtr, w As IntPtr, x As Integer, y As Integer, width As Integer, height As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XRaiseWindow(display As IntPtr, w As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XLowerWindow(display As IntPtr, w As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XSetWindowBackground(display As IntPtr, w As IntPtr, backgroundPixel As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XGrabKey(display As IntPtr, keycode As Integer, modifiers As XModMask, grabWindow As IntPtr, ownerEvents As Boolean, pointerMode As XGrabMode, keyboardMode As XGrabMode) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XUngrabKey(display As IntPtr, keycode As Integer, modifiers As XModMask, grabWindow As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XKeysymToKeycode(display As IntPtr, keysym As XKeySym) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XKeycodeToKeysym(display As IntPtr, keycode As Integer, index As Integer) As XKeySym
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XLookupKeysym(ByRef keyEvent As XKeyEvent, index As Integer) As XKeySym
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XGetTransientForHint(display As IntPtr, w As IntPtr, <Out> ByRef windowReturn As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XSetTransientForHint(display As IntPtr, w As IntPtr, propWindow As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XAddToSaveSet(display As IntPtr, w As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XRemoveFromSaveSet(display As IntPtr, w As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XKillClient(display As IntPtr, resource As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XDeleteProperty(display As IntPtr, w As IntPtr, [property] As XAtom) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XGetWMHints(display As IntPtr, w As IntPtr) As IntPtr
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XGetNormalHints(display As IntPtr, w As IntPtr, hintsReturn As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XAllocSizeHints() As IntPtr
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XFree(data As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XSetWMHints(display As IntPtr, w As IntPtr, wmHints As XWMHints) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Sub XSetWMNormalHints(display As IntPtr, w As IntPtr, ByRef hints As XSizeHints)
  End Sub

  <DllImport("libX11.so.6")>
  Private Shared Function XGetWMProtocols(display As IntPtr, w As IntPtr, protocolsReturn As IntPtr, <Out> ByRef countReturn As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XDrawLine(display As IntPtr, d As IntPtr, gc As IntPtr, x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XDrawRectangle(display As IntPtr, d As IntPtr, gc As IntPtr, x As Integer, y As Integer, width As Integer, height As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XGetGeometry(display As IntPtr, d As IntPtr, <Out> ByRef rootReturn As IntPtr, <Out> ByRef returnX As Integer, <Out> ByRef returnY As Integer, <Out> ByRef widthReturn As Integer, <Out> ByRef heightReturn As Integer, <Out> ByRef borderWidthReturn As Integer, <Out> ByRef depthReturn As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XSetWindowBorder(display As IntPtr, w As IntPtr, borderPixel As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XGetClassHint(display As IntPtr, w As IntPtr, <Out> ByRef classHintReturn As XClassHint) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XSetWindowBackgroundPixmap(display As IntPtr, w As IntPtr, backgroundPixmap As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XDefineCursor(display As IntPtr, w As IntPtr, cursor As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XRootWindow(display As IntPtr, screen As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XQueryPointer(display As IntPtr, w As IntPtr, <Out> ByRef rootReturn As IntPtr, <Out> ByRef childReturn As IntPtr, <Out> ByRef rootReturnX As Integer, <Out> ByRef rootReturnY As Integer, <Out> ByRef winReturnX As Integer, <Out> ByRef winReturnY As Integer, <Out> ByRef maskReturn As Integer) As Boolean
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XSetWindowBorderWidth(display As IntPtr, w As IntPtr, width As Integer) As Integer
  End Function

End Class