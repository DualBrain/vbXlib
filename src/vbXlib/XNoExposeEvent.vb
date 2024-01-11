Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XNoExposeEvent
  Public Type As XEventType
  Public Serial As Long
  Public SendEvent As Boolean
  Public Display As IntPtr
  Public Drawable As IntPtr
  Public MajorCode As Integer
  Public MinorCode As Integer
End Structure