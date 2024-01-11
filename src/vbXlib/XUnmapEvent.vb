Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XUnmapEvent
  Public Type As XEventType
  Public Serial As Long
  Public SendEvent As Boolean
  Public Display As IntPtr
  Public [Event] As Integer
  Public Window As IntPtr
  Public FromConfigure As Integer
End Structure