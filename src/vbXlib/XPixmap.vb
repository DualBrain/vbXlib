Imports System.Runtime.InteropServices

Public Class XPixmap
  Inherits XHandle

  Private ReadOnly m_display As XDisplay
  Private m_mask As Integer
  Private m_width As Integer = 0
  Private m_height As Integer = 0
  Private m_success As Boolean = False

  Public Sub New(display As XDisplay)
    m_display = display
  End Sub

  Public Function ReadFileToPixmap(d As XWindow, filename As String) As Boolean

    Dim pixmapReturn As IntPtr
    Dim shapemaskReturn As Integer
    Dim attr = New XpmAttributes With {.ValueMask = XPixmapValueMask.XpmSize}

    If XpmReadFileToPixmap(m_display.Handle,
                           d.Handle,
                           filename,
                           pixmapReturn,
                           shapemaskReturn,
                           attr) = 0 Then
      Handle = pixmapReturn
      m_mask = shapemaskReturn
      m_width = attr.Width
      m_height = attr.Height
      m_success = True
      Return True
    End If

    Return False

  End Function

  Public Function ReadPixmapFromData(d As XWindow, data As String()) As Boolean

    Dim pixmapReturn As IntPtr
    Dim shapemaskReturn As Integer
    Dim attr = New XpmAttributes With {.ValueMask = XPixmapValueMask.XpmSize}

    If XpmCreatePixmapFromData(m_display.Handle,
                               d.Handle,
                               data,
                               pixmapReturn,
                               shapemaskReturn,
                               attr) = 0 Then
      Handle = pixmapReturn
      m_mask = shapemaskReturn
      m_width = attr.Width
      m_height = attr.Height
      'Console.WriteLine($"PIXMAP: W={m_width} | H={m_height}")
      m_success = True
      Return True
    End If

    Return False

  End Function

  Public ReadOnly Property Mask As Integer
    Get
      Return m_mask
    End Get
  End Property

  Public ReadOnly Property Width As Integer
    Get
      Return m_width
    End Get
  End Property

  Public ReadOnly Property Height As Integer
    Get
      Return m_height
    End Get
  End Property

  Public Sub Free()
    If m_success Then
      Console.WriteLine("Freeing Pixmap")
      Dim rslt = XFreePixmap(m_display.Handle, Handle)
    End If
  End Sub

  <DllImport("libX11.so.6")>
  Private Shared Function XFreePixmap(display As IntPtr, pixmap As IntPtr) As Integer
  End Function

  <DllImport("libXpm.so")>
  Private Shared Function XpmReadFileToPixmap(display As IntPtr, d As IntPtr, filename As String, <Out> ByRef pixmapReturn As IntPtr, <Out> ByRef shapemaskReturn As Integer, ByRef attributes As XpmAttributes) As Integer
  End Function

  <DllImport("libXpm.so")>
  Private Shared Function XpmCreatePixmapFromData(display As IntPtr, d As IntPtr, data As String(), <Out> ByRef pixmapReturn As IntPtr, <Out> ByRef shapemaskReturn As Integer, ByRef attributes As XpmAttributes) As Integer
  End Function

End Class