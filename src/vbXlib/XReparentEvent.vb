Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XReparentEvent
  Public Type As XEventType
  Public Serial As Long
  Public SendEvent As Boolean
  Public Display As IntPtr
  Public [Event] As Integer
  Public Window As IntPtr
  Public Parent As IntPtr
  Public X, Y As Integer
  Public OverrideRedirect As Integer
End Structure