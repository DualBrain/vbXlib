Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XSizeHints
  Public Flags1 As XSizeHintFlags
  Public X, Y As Integer
  Public Width As Integer
  Public Height As Integer
  Public MinWidth As Integer
  Public MinHeight As Integer
  Public MaxWidth As Integer
  Public MaxHeight As Integer
  Public WidthInc As Integer
  Public HeightInc As Integer
  Public MinAspect As XAspect
  Public MaxAspect As XAspect
  Public BaseWidth As Integer
  Public BaseHeight As Integer
  Public WinGravity As Integer
End Structure