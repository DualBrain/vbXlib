Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XCreateWindowEvent
  Public Type As XEventType
  Public Serial As Long
  Public Send_Event As Boolean
  Public Display As IntPtr
  Public Parent As IntPtr
  Public Window As IntPtr
  Public X, Y As Integer
  Public Width, Height As Integer
  Public Border_Width As Integer
  Public Override_Redirect As Integer
End Structure