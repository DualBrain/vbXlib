Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XKeymapEvent
  Public Type As XEventType
  Public Serial As Long
  Public Display As IntPtr
  Public Window As IntPtr
  <MarshalAs(UnmanagedType.LPArray, SizeConst:=20)>
  Public Key_Vector As Char()
End Structure