Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XGCValues
  Public [Function] As XGCFunctionMask
  Public Plane_Mask As Integer
  Public Foreground As Integer
  Public Background As Integer
  Public Line_Width As Integer
  Public Line_Style As Integer
  Public Cap_Style As Integer
  Public Join_Style As Integer
  Public Fill_Style As Integer
  Public Fill_Rule As Integer
  Public Arc_Mode As Integer
  Public Tile As Integer
  Public Stipple As Integer
  Public Ts_X_Origin As Integer
  Public Ts_Y_Origin As Integer
  Public Font As Integer
  Public Subwindow_Mode As XSubwindowMode
  Public Graphics_Exposure As Integer
  Public Clip_X_Origin As Integer
  Public Clip_Y_Origin As Integer
  Public Clip_Mask As Integer
  Public Dash_Offset As Integer
  Public Dashes As Char
End Structure