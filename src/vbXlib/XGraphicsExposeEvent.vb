Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XGraphicsExposeEvent
  Public Type As XEventType
  Public Serial As Long
  Public Send_Event As Boolean
  Public Display As IntPtr
  Public Drawable As IntPtr
  Public X, Y As Integer
  Public Width, Height As Integer
  Public Count As Integer
  Public Major_Code As Integer
  Public Minor_Code As Integer
End Structure