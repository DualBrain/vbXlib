Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XpmAttributes
  Public ValueMask As XPixmapValueMask
  Public Visual As IntPtr
  Public Colormap As IntPtr
  Public Depth As Integer
  Public Width As Integer
  Public Height As Integer
  Public HotspotX As Integer
  Public HotspotY As Integer
  Public Cpp As Integer
  Public Pixels As IntPtr
  Public Npixels As Integer
  Public ColorSymbols As IntPtr
  Public NumSymbols As Integer
  Public RgbFname As String
  Public Nextensions As Integer
  Public Extensions As IntPtr
  Public Ncolors As Integer
  Public ColorTable As IntPtr
  ' 3.2 backward compatibility code 
  Public HintsCmt As String
  Public ColorsCmt As String
  Public PixelsCmt As String
  ' end 3.2 bc 
  Public MaskPixel As Integer
  ' Color Allocation Directives 
  Public ExactColors As Boolean
  Public Closeness As Integer
  Public RedCloseness As Integer
  Public GreenCloseness As Integer
  Public BlueCloseness As Integer
  Public ColorKey As Integer
  Public AllocPixels As IntPtr
  Public NallocPixels As Integer
  Public AllocCloseColors As Boolean
  Public BitmapFormat As Integer
  ' Color functions 
  Public AllocColor As IntPtr
  Public FreeColors As IntPtr
  Public ColorClosure As IntPtr
End Structure