Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XShapeEvent
  Public Type As XEventType
  Public Serial As Long
  Public SendEvent As Boolean
  Public Display As IntPtr
  Public Window As IntPtr
  Public Kind As Integer
  Public X, Y As Integer
  Public Width, Height As Integer
  Public Time As Integer
  Public Shaped As Boolean
End Structure