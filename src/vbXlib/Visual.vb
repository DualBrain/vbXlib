
Imports System.Runtime.InteropServices

''' <summary>
''' Visual structure; contains information about colormapping possible.
''' </summary>
<StructLayout(LayoutKind.Sequential)>
Public Structure Visual
  ''' <summary>
  ''' hook for extension to hang data
  ''' </summary>
  Public ext_data As IntPtr ' XExtData *
  ''' <summary>
  ''' visual id of this visual
  ''' </summary>
  Public VisualId As IntPtr ' VisualID
  ''' <summary>
  ''' class of screen (monochrome, etc.)
  ''' </summary>
  Public [Class] As Integer ' int
  ''' <summary>
  ''' mask values
  ''' </summary>
  Public RedMask, GreenMask, BlueMask As Long ' unsigned long
  ''' <summary>
  ''' log base 2 of distinct color values
  ''' </summary>
  Public BitsPerRgb As Integer ' int
  ''' <summary>
  ''' color map entries
  ''' </summary>
  Public MapEntries As Integer ' int
End Structure