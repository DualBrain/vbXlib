Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XCrossingEvent
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
  Public Mode As Integer
  Public Detail As Integer
  Public Same_Screen As Integer
  Public Focus As Integer
  Public State As Integer
End Structure