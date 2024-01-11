Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XCharStruct
  Public Lbearing As Short
  Public Rbearing As Short
  Public Width As Short
  Public Ascent As Short
  Public Descent As Short
  Public Attributes As UShort
End Structure