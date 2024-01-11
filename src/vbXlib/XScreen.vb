Imports System.Drawing
Imports System.Runtime.InteropServices

Public Class XScreen
  Inherits XHandle

  Private ReadOnly m_display As XDisplay

  Public Sub New(display As XDisplay)
    m_display = display
    If m_display.Handle = IntPtr.Zero Then
      Throw New NullReferenceException("Display pointer is null")
    End If
    Handle = XDefaultScreenOfDisplay(m_display.Handle)
  End Sub

  Public ReadOnly Property Width As Integer
    Get
      Return XWidthOfScreen(Handle)
    End Get
  End Property

  Public ReadOnly Property Height As Integer
    Get
      Return XHeightOfScreen(Handle)
    End Get
  End Property

  Public ReadOnly Property Geometry As Rectangle
    Get
      Return New Rectangle(0, 0, Width, Height)
    End Get
  End Property

  Public ReadOnly Property Number As Integer
    Get
      Return XScreenNumberOfScreen(Handle)
    End Get
  End Property

  Public Function BlackPixel() As Integer
    Return XBlackPixel(m_display.Handle, Number)
  End Function

  Public Function WhitePixel() As Integer
    Return XWhitePixel(m_display.Handle, Number)
  End Function

  Public Function DefaultColormap() As Integer
    Return XDefaultColormapOfScreen(Handle)
  End Function

  Private Declare Function XBlackPixel Lib "libX11.so.6" (display As IntPtr, screenNumber As Integer) As Integer
  Private Declare Function XDefaultColormapOfScreen Lib "libX11.so.6" (screen As IntPtr) As Integer
  Private Declare Function XDefaultScreenOfDisplay Lib "libX11.so.6" (display As IntPtr) As IntPtr
  Private Declare Function XHeightOfScreen Lib "libX11.so.6" (screen As IntPtr) As Integer
  Private Declare Function XScreenNumberOfScreen Lib "libX11.so.6" (screen As IntPtr) As Integer
  Private Declare Function XWhitePixel Lib "libX11.so.6" (display As IntPtr, screenNumber As Integer) As Integer
  Private Declare Function XWidthOfScreen Lib "libX11.so.6" (screen As IntPtr) As Integer

End Class