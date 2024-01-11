Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XResizeRequestEvent
  Public Type As XEventType
  Public Serial As Long
  Public SendEvent As Boolean
  Public Display As IntPtr
  Public Window As IntPtr
  Public Width, Height As Integer
End Structure