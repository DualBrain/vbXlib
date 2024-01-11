Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XFocusChangeEvent
  Public Type As XEventType
  Public Serial As Long
  Public Send_Event As Boolean
  Public Display As IntPtr
  Public Window As IntPtr
  Public Mode As Integer
  Public Detail As Integer
End Structure