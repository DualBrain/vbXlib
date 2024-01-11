Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XConfigureEvent
  Public Type As XEventType
  Public Serial As Long
  Public Send_Event As Boolean
  Public Display As IntPtr
  Public _Event As Integer
  Public Window As IntPtr
  Public X, Y As Integer
  Public Width, Height As Integer
  Public Border_Width As Integer
  Public Above As Integer
  Public Override_Redirect As Integer
End Structure