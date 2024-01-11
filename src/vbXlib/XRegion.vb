Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XRegion
  Public Size As Integer
  Public NumRects As Integer
  Public Rects As IntPtr
  ' BOX *rects;
  Public Extents As XBox
End Structure