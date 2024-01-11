Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XMotionEvent
  Public Type As XEventType
  Public Serial As Long
  Public SendEvent As Boolean
  Public Display As IntPtr
  Public Window As IntPtr
  Public Root As IntPtr
  Public Subwindow As IntPtr
  Public Time As Long
  Public X, Y As Integer
  Public RootX, RootY As Integer
  Public State As Integer
  Public IsHint As Char
  Public SameScreen As Boolean
End Structure