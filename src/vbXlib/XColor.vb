Imports System.Drawing
Imports System.Runtime.InteropServices

Public Class XColor
  Inherits XHandle

  Private ReadOnly m_display As XDisplay
  Private m_namedColor As BaseXColor

  Public Sub New(display As XDisplay, name As String)

    Dim fg, dummyc As IntPtr

    m_display = display

    fg = Marshal.AllocHGlobal(Marshal.SizeOf(GetType(BaseXColor)))
    dummyc = Marshal.AllocHGlobal(Marshal.SizeOf(GetType(BaseXColor)))

    Dim rslt = XAllocNamedColor(m_display.Handle, m_display.Screen.DefaultColormap(), name, fg, dummyc)

    Handle = fg

    m_namedColor = CType(Marshal.PtrToStructure(Handle, GetType(BaseXColor)), BaseXColor)

    Marshal.FreeHGlobal(fg)
    Marshal.FreeHGlobal(dummyc)

  End Sub

  Public Sub New(display As XDisplay, color As Color)
    Me.New(display, ColorTranslator.ToHtml(Color.FromArgb(color.R, color.G, color.B)))
  End Sub

  Public ReadOnly Property Pixel As Integer
    Get
      Return m_namedColor.Pixel
    End Get
  End Property

  Public ReadOnly Property ColorStruct As BaseXColor
    Get
      Return m_namedColor
    End Get
  End Property

  <DllImport("libX11.so.6")>
  Private Shared Function XAllocNamedColor(display As IntPtr, colormap As Integer, colorName As String, screenDefReturn As IntPtr, exactDefReturn As IntPtr) As Integer
  End Function

  <DllImport("libX11.so.6")>
  Private Shared Function XAllocColor(display As IntPtr, colormap As Integer, screenIntOut As IntPtr) As Integer
  End Function

End Class