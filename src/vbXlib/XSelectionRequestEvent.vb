Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XSelectionRequestEvent
  Public Type As XEventType
  Public Serial As Long
  Public SendEvent As Boolean
  Public Display As IntPtr
  Public Owner As IntPtr
  Public Requestor As IntPtr
  Public Selection As Integer
  Public Target As IntPtr
  Public [Property] As Integer
  Public Time As Integer
End Structure