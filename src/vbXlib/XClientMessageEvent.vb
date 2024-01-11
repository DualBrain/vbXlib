Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XClientMessageEvent
  Public Type As XEventType
  Public Serial As Long
  Public Send_Event As Boolean
  Public Display As IntPtr
  Public Window As IntPtr
  Public Message_Type As ULong 'XAtom
  Public Format As Integer
  'Public Data As XClientMessageEventData
  Public L0 As Long
  Public L1 As Long
  Public L2 As Long
  Public L3 As Long
  Public L4 As Long
End Structure

<StructLayout(LayoutKind.Explicit)>
Public Structure XClientMessageEventData
  <FieldOffset(0)>
  <MarshalAs(UnmanagedType.LPArray, SizeConst:=20)>
  Public B As Char()
  <FieldOffset(0)>
  <MarshalAs(UnmanagedType.LPArray, SizeConst:=10)>
  Public S As Short()
  <FieldOffset(0)>
  <MarshalAs(UnmanagedType.LPArray, SizeConst:=5)>
  Public L As Long()
End Structure