Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure BaseXColor
  Public Pixel As Integer
  Public Red, Green, Blue As UShort
  Public Flags As Char
  Public Pad As Char
End Structure