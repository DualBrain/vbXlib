Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XConfigureRequestEvent
  Public Type As XEventType
  Public Serial As Long
  Public Send_Event As Boolean
  Public Display As IntPtr
  Public Parent As IntPtr
  Public Window As IntPtr
  Public X, Y As Integer
  Public Width, Height As Integer
  Public Border_Width As Integer
  Public Above As Integer
  Public Detail As Integer
  Public Value_Mask As Integer
End Structure