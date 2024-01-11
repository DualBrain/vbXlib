Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XButtonEvent
  Public Type As XEventType
  Public Serial As Long
  Public Send_Event As Boolean
  Public Display As IntPtr
  Public Window As IntPtr
  Public Root As IntPtr
  Public Subwindow As IntPtr
  Public Time As Long
  Public X, Y As Integer
  Public X_Root, Y_Root As Integer
  Public State As Integer
  Public Button As Integer
  Public Same_Screen As Boolean
End Structure