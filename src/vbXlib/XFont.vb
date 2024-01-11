Imports System.Runtime.InteropServices

Public Class XFont
  Inherits XHandle

  Private ReadOnly m_display As XDisplay
  Private m_font As XFontStruct

  Public Sub New(display As XDisplay, name As String)
    m_display = display
    Handle = XLoadQueryFont(m_display.Handle, name)
    If Handle <> IntPtr.Zero Then
      m_font = CType(Marshal.PtrToStructure(Handle, GetType(XFontStruct)), XFontStruct)
    Else
      Throw New Exception("Font could not be loaded!")
    End If
    'Console.WriteLine($"Ascent = {m_font.ascent} | Descent = {m_font.descent}")
  End Sub

  Public ReadOnly Property FontStruct As XFontStruct
    Get
      Return m_font
    End Get
  End Property

  Public Overrides Sub Dispose()
    Console.WriteLine("Freeing Font")
    Dim rstl = XFreeFont(m_display.Handle, Handle)
    MyBase.Dispose()
  End Sub

  Public ReadOnly Property Ascent As Integer
    Get
      Return m_font.Ascent
    End Get
  End Property

  Public ReadOnly Property Descent As Integer
    Get
      Return m_font.Descent
    End Get
  End Property

  Public ReadOnly Property FID As Integer
    Get
      Return m_font.fId
    End Get
  End Property

  Public Function TextExtents(str As String) As XCharStruct
    Dim direction_return, font_ascent_return, font_descent_return As Integer
    Dim overall As XCharStruct
    Dim overall_return As IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(GetType(XCharStruct)))
    Dim rslt = XTextExtents(m_font, str, str.Length, direction_return, font_ascent_return, font_descent_return, overall_return)
    overall = CType(Marshal.PtrToStructure(overall_return, GetType(XCharStruct)), XCharStruct)
    Marshal.FreeHGlobal(overall_return)
    Return overall
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XLoadQueryFont(display As IntPtr, name As String) As IntPtr
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XFreeFont(display As IntPtr, font_struct As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XTextExtents(ByRef font_struct As XFontStruct, _string As String, nchars As Integer, <Out> ByRef direction_return As Integer, <Out> ByRef font_ascent_return As Integer, <Out> ByRef font_descent_return As Integer, overall_return As IntPtr) As Integer
  End Function

End Class