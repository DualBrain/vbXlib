Imports System.Runtime.InteropServices

''' <summary>
''' Information used by the visual utility routines to find desired visual
''' type from the many visuals a display may support.
''' </summary>
<StructLayout(LayoutKind.Sequential)>
Public Structure XVisualInfo
  Public Visual As IntPtr ' Visual*
  Public VisualId As ULong ' VisualID: unsigned long OR CARD32, BITS32 
  Public Screen As Integer ' int
  Public Depth As Integer ' int
  Public [Class] As Integer ' int
  Public RedMask As ULong ' unsigned long
  Public GreenMask As ULong ' unsigned long
  Public BlueMask As ULong ' unsigned long
  Public ColormapSize As Integer ' int
  Public BitsPerRgb As Integer ' int
End Structure