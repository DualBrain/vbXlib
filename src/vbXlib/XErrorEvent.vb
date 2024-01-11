Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XErrorEvent
  Public Type As XEventType
  Public Display As IntPtr
  Public ResourceId As Long
  Public Serial As Long
  Public Error_Code As Byte
  Public Request_Code As Byte
  Public Minor_Code As Byte
End Structure