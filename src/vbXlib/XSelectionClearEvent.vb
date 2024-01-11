Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XSelectionClearEvent
  Public Type As XEventType
  Public Serial As Long
  Public SendEvent As Boolean
  Public Display As IntPtr
  Public Window As IntPtr
  Public Selection As Integer
  Public Time As Integer
End Structure