Imports System.Drawing
Imports System.Runtime.InteropServices

Public Class XGC
  Inherits XHandle

  Private m_display As XDisplay
  Private m_isDefaultGC As Boolean

  Public Sub New(display As XDisplay)
    m_display = display
    Handle = XDefaultGC(m_display.Handle, m_display.Screen.Number)
    m_isDefaultGC = True
  End Sub

  Public Sub New(display As XDisplay, valueMask As XGCValuesMask, values As XGCValues)
    InitGC(display, New IntPtr(display.Root), valueMask, values)
  End Sub

  Public Sub New(display As XDisplay, window As XWindow, valueMask As XGCValuesMask, values As XGCValues)
    InitGC(display, window.Handle, valueMask, values)
  End Sub

  Private Sub InitGC(display As XDisplay, d As IntPtr, valueMask As XGCValuesMask, values As XGCValues)
    m_display = display
    Handle = XCreateGC(m_display.Handle, d, valueMask, values)
    m_isDefaultGC = False
  End Sub

  Public Overrides Sub Dispose()
    If Not m_isDefaultGC Then
      Dim rslt = XFreeGC(m_display.Handle, Handle)
      MyBase.Dispose()
    End If
  End Sub

  Public Function SetForeground(foreground As XColor) As Integer
    Return XSetForeground(m_display.Handle, Handle, foreground.Pixel)
  End Function

  Public Function SetForeground(foreground As Color) As Integer
    Return XSetForeground(m_display.Handle, Handle, New XColor(m_display, foreground).Pixel)
  End Function

  Public Function SetBackground(background As XColor) As Integer
    Return XSetBackground(m_display.Handle, Handle, background.Pixel)
  End Function

  Public Function SetBackground(background As Color) As Integer
    Return XSetForeground(m_display.Handle, Handle, New XColor(m_display, background).Pixel)
  End Function

  Public Function CopyArea(src As XWindow, dest As XWindow, src_x As Integer, src_y As Integer, width As Integer, height As Integer, dest_x As Integer, dest_y As Integer) As Integer
    Return XCopyArea(m_display.Handle, src.Handle, dest.Handle, Handle, src_x, src_y, width, height, dest_x, dest_y)
  End Function

  Public Function ChangeGC(valueMask As Integer, ByRef values As XGCValues) As Integer
    Return XChangeGC(m_display.Handle, Handle, valueMask, values)
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XDefaultGC(display As IntPtr, screenNumber As Integer) As IntPtr
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XCreateGC(display As IntPtr, d As IntPtr, valueMask As XGCValuesMask, ByRef values As XGCValues) As IntPtr
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XFreeGC(display As IntPtr, gc As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XSetForeground(display As IntPtr, gc As IntPtr, foreground As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XSetBackground(display As IntPtr, gc As IntPtr, background As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XCopyArea(display As IntPtr, src As IntPtr, dest As IntPtr, gc As IntPtr, src_x As Integer, src_y As Integer, width As Integer, height As Integer, dest_x As Integer, dest_y As Integer) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XChangeGC(display As IntPtr, gc As IntPtr, valueMask As Integer, ByRef values As XGCValues) As Integer
  End Function

End Class