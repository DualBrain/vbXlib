Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XColormapEvent
  Public Type As XEventType
  Public Serial As Long
  Public Send_Event As Boolean
  Public Display As IntPtr
  Public Window As IntPtr
  Public Colormap As Integer
  Public _New As Integer
  Public State As Integer
End Structure