Imports System.Runtime.InteropServices

Public Class XDisplay
  Inherits XHandle

  Public Property Screen As XScreen

  Public Sub New(name As String)
    Screen = Nothing
    Handle = XOpenDisplay(name)
    If Handle <> IntPtr.Zero Then
      Screen = New XScreen(Me)
    Else
      Throw New Exception("Display could not be opened!")
    End If
  End Sub

  Public Overrides Sub Dispose()
    Dim rslt = XCloseDisplay(Handle)
    MyBase.Dispose()
  End Sub

  Public Function Sync(discard As Boolean) As Integer
    Return XSync(Handle, Convert.ToInt32(discard))
  End Function

  Public ReadOnly Property Root As Integer
    Get
      Return XDefaultRootWindow(Handle)
    End Get
  End Property

  Public ReadOnly Property DefaultScreen As XScreen
    Get
      Return New XScreen(Me)
    End Get
  End Property

  Public Function GrabServer() As Integer
    Return XGrabServer(Handle)
  End Function

  Public Function UngrabServer() As Integer
    Return XUngrabServer(Handle)
  End Function

  Public Function Flush() As Integer
    Return XFlush(Handle)
  End Function

  Public Function XRes() As Integer
    Return XWidthOfScreen(Screen.Handle)
  End Function

  Public Function YRes() As Integer
    Return XHeightOfScreen(Screen.Handle)
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XOpenDisplay(name As String) As IntPtr
  End Function

  Private Declare Function XCloseDisplay Lib "libX11.so.6" (display As IntPtr) As Integer
  Private Declare Function XSync Lib "libX11.so.6" (display As IntPtr, discard As Integer) As Integer
  Private Declare Function XDefaultRootWindow Lib "libX11.so.6" (display As IntPtr) As Integer
  Private Declare Function XGrabServer Lib "libX11.so.6" (display As IntPtr) As Integer
  Private Declare Function XUngrabServer Lib "libX11.so.6" (display As IntPtr) As Integer
  Private Declare Function XFlush Lib "libX11.so.6" (display As IntPtr) As Integer
  Private Declare Function XWidthOfScreen Lib "libX11.so.6" (screen As IntPtr) As Integer
  Private Declare Function XHeightOfScreen Lib "libX11.so.6" (screen As IntPtr) As Integer

End Class