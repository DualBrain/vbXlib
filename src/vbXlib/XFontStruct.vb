Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Explicit, Size:=80)>
Public Structure XFontStruct
  <FieldOffset(0)>
  Public Ext_Data As IntPtr
  <FieldOffset(4)>
  Public fId As Integer
  <FieldOffset(8)>
  Public Direction As Integer
  <FieldOffset(12)>
  Public Min_char_or_byte2 As Integer
  <FieldOffset(16)>
  Public Max_char_or_byte2 As Integer
  <FieldOffset(20)>
  Public Min_byte1 As Integer
  <FieldOffset(24)>
  Public Max_byte1 As Integer
  <FieldOffset(28)>
  Public All_chars_exist As Integer
  <FieldOffset(32)>
  Public Default_char As Integer
  <FieldOffset(36)>
  Public N_properties As Integer
  <FieldOffset(40)>
  Public Properties As IntPtr
  <FieldOffset(44)>
  Public Min_bounds As IntPtr
  <FieldOffset(56)>
  Public Max_bounds As IntPtr
  <FieldOffset(68)>
  Public Per_char As IntPtr
  <FieldOffset(72)>
  Public Ascent As Integer
  <FieldOffset(76)>
  Public Descent As Integer
End Structure