Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XPropertyEvent
  Public Type As XEventType
  Public Serial As Long
  Public SendEvent As Boolean
  Public Display As IntPtr
  Public Window As IntPtr
  Public Atom As Integer
  Public Time As Integer
  Public State As Integer
End Structure