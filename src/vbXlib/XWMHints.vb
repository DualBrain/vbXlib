Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XWMHints
  Public Flags1 As XWMHintFlags
  Public Input As Boolean
  Public Initial_State As XWindowState
  Public Icon_Pixmap As Integer
  Public Icon_Window As IntPtr
  Public Icon_X, Icon_Y As Integer
  Public Icon_Mask As Integer
  Public Window_Group As Integer
End Structure