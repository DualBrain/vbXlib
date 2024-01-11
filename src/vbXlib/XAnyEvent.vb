Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XAnyEvent
  Public Type As XEventType
  Public Serial As Long
  Public Send_Event As Boolean
  Public Display As IntPtr
  Public Window As IntPtr
End Structure