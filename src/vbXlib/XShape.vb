Imports System.Runtime.InteropServices

Public Class XShape

  Private ReadOnly m_display As XDisplay
  Private m_shapeEvent As Integer
  Private ReadOnly m_hasShapeExt As Boolean

  Public Const NUMBER_EVENT As Integer = XShapeEventMask.ShapeNotify + 1

  Public Sub New(dpy As XDisplay)
    m_display = dpy
    m_hasShapeExt = Query()
  End Sub

  Public ReadOnly Property [Event] As Integer
    Get
      Return m_shapeEvent
    End Get
  End Property

  Public Function Query() As Boolean
    Dim errorBase As Integer
    Return XShapeQueryExtension(m_display.Handle, m_shapeEvent, errorBase)
  End Function

  Public ReadOnly Property Type As Integer
    Get
      Return m_shapeEvent
    End Get
  End Property

  Public ReadOnly Property HasShape As Boolean
    Get
      Return m_hasShapeExt
    End Get
  End Property

  Public Function Version() As XShapeVersionInfo
    Dim majorVersion, minorVersion As Integer
    Dim rslt = XShapeQueryVersion(m_display.Handle, majorVersion, minorVersion)
    Dim svi = New XShapeVersionInfo With {.MajorVersion = majorVersion,
                                          .MinorVersion = minorVersion}
    Return svi
  End Function

  <DllImport("libXext.so")>
  Private Shared Function XShapeQueryExtension(display As IntPtr, <Out> ByRef eventBase As Integer, <Out> ByRef errorBase As Integer) As Boolean
  End Function

  <DllImport("libXext.so")>
  Private Shared Function XShapeQueryVersion(display As IntPtr, <Out> ByRef majorVersion As Integer, <Out> ByRef minorVersion As Integer) As Integer
  End Function

End Class