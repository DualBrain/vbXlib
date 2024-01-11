Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XCirculateRequestEvent
  Public Type As XEventType
  Public Serial As Long
  Public Send_Event As Boolean
  Public Display As IntPtr
  Public Parent As IntPtr
  Public Window As IntPtr
  Public Place As Integer
End Structure