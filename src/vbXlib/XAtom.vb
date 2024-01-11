Imports System.Runtime.InteropServices

Public Class XAtom

  Private ReadOnly m_display As XDisplay
  Private ReadOnly m_atom As Integer

  Public Sub New(display As XDisplay, atomName As String, onlyIfExists As Boolean)
    m_display = display
    m_atom = XInternAtom(m_display.Handle, atomName, onlyIfExists)
  End Sub

  Public ReadOnly Property Id As Integer
    Get
      Return m_atom
    End Get
  End Property

  Public ReadOnly Property Name As String
    Get
      Return XGetAtomName(m_display.Handle, m_atom)
    End Get
  End Property

  <DllImport("libX11.so.6")>
  Private Shared Function XInternAtom(display As IntPtr, atomName As String, onlyIfExists As Boolean) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XGetAtomName(display As IntPtr, atom As Integer) As String
  End Function

End Class