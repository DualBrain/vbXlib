Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XWindowChanges
  Public X, Y As Integer
  Public Width, Height As Integer
  Public BorderWidth As Integer
  Public Sibling As Integer
  Public StackMode As Integer
End Structure