Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XMapRequestEvent
  Public Type As XEventType
  Public Serial As Long
  Public SendEvent As Boolean
  Public Display As IntPtr
  Public Parent As IntPtr
  Public Window As IntPtr
End Structure