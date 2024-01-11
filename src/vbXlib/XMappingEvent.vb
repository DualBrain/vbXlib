Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XMappingEvent
  Public Type As XEventType
  Public Serial As Long
  Public SendEvent As Boolean
  Public Display As IntPtr
  Public Window As IntPtr
  Public Request As Integer
  Public FirstKeycode As Integer
  Public Count As Integer
End Structure