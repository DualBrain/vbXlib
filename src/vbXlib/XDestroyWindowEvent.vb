Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XDestroyWindowEvent
  Public Type As XEventType
  Public Serial As Long
  Public Send_Event As Boolean
  Public Display As IntPtr
  Public _Event As Integer
  Public Window As IntPtr
End Structure