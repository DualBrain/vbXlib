Imports System.Runtime.InteropServices

Public Class XPointer
  Inherits XHandle

  Private ReadOnly m_display As XDisplay

  Public Sub New(display As XDisplay)
    m_display = display
  End Sub

  Public Function Grab(window As IntPtr, eventMask As XEventMask) As Integer
    Return XGrabPointer(m_display.Handle,
                        window,
                        True,
                        eventMask,
                        XGrabMode.GrabModeAsync,
                        XGrabMode.GrabModeAsync,
                        0,
                        IntPtr.Zero,
                        0)
  End Function

  Public Function Ungrab() As Integer
    Return XUngrabPointer(m_display.Handle, 0)
  End Function

  Public Function Query(window As XWindow) As XPointerQueryInfo

    Dim pi As New XPointerQueryInfo

    Dim rootReturn, childReturn As IntPtr
    Dim rootReturnX, rootReturnY, winReturnX, winReturnY, maskReturn As Integer

    XQueryPointer(m_display.Handle,
                  window.Handle,
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

  Public Function Warp(srcWindow As XWindow, destWindow As XWindow, srcX As Integer, srcY As Integer, srcWidth As Integer, srcHeight As Integer, destX As Integer, destY As Integer) As Integer
    Return XWarpPointer(m_display.Handle, srcWindow.Handle, destWindow.Handle, srcX, srcY, srcWidth, srcHeight, destX, destY)
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XUngrabPointer(display As IntPtr, t As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XGrabPointer(display As IntPtr, grabWindow As IntPtr, ownerEvents As Boolean, eventMask As XEventMask, pointerMode As XGrabMode, keyboardMode As XGrabMode, confineTo As Integer, cursor As IntPtr, time As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XQueryPointer(display As IntPtr, window As IntPtr, <Out> ByRef rootReturn As IntPtr, <Out> ByRef childReturn As IntPtr, <Out> ByRef rootReturnX As Integer, <Out> ByRef rootReturnY As Integer, <Out> ByRef winReturnX As Integer, <Out> ByRef winReturnY As Integer, <Out> ByRef maskReturn As Integer) As Boolean
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XWarpPointer(display As IntPtr, srcWindow As IntPtr, destWindow As IntPtr, srcX As Integer, srcY As Integer, srcWidth As Integer, srcHeight As Integer, destX As Integer, destY As Integer) As Integer
  End Function

End Class