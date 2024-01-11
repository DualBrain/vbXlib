Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XExposeEvent
  Public Type As XEventType
  Public Serial As Long
  Public Send_Event As Boolean
  Public Display As IntPtr
  Public Window As IntPtr
  Public X, Y As Integer
  Public Width, Height As Integer
  Public Count As Integer
End Structure