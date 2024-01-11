Imports System.Runtime.InteropServices

Public Class XCursor
  Inherits XHandle

  Private ReadOnly m_display As XDisplay

  Public Sub New(display As XDisplay, shape As XCursors)
    m_display = display
    Handle = XCreateFontCursor(m_display.Handle, Convert.ToInt32(shape))
  End Sub

  Public Overrides Sub Dispose()
    Dim rslt = XFreeCursor(m_display.Handle, Handle)
    MyBase.Dispose()
  End Sub

  Public Sub DefineCursor(w As XWindow)
    Dim rslt = XDefineCursor(m_display.Handle, w.Handle, Handle)
    MyBase.Dispose()
  End Sub

  Public Sub DefineCursorOnRoot()
    Dim rslt = XDefineCursor(m_display.Handle, New IntPtr(m_display.Root), Handle)
  End Sub

  <DllImport("libX11.so.6")>
  Private Shared Function XCreateFontCursor(display As IntPtr, shape As Integer) As IntPtr
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XDefineCursor(display As IntPtr, w As IntPtr, cursor As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XFreeCursor(display As IntPtr, cursor As IntPtr) As Integer
  End Function

End Class