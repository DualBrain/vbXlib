Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XVisibilityEvent
  Public Type As XEventType
  Public Serial As Long
  Public SendEvent As Boolean
  Public Display As IntPtr
  Public Window As IntPtr
  Public State As Integer
End Structure