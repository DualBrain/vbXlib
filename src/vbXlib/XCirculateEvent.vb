Imports System.Runtime.InteropServices


<StructLayout(LayoutKind.Sequential)>
Public Structure XCirculateEvent
  Public Type As XEventType
  Public Serial As Long
  Public Send_Event As Boolean
  Public Display As IntPtr
  Public _event As Integer
  Public Window As IntPtr
  Public Place As Integer
End Structure