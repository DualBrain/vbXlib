Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure XWindowAttributes
  ''' <summary>
  ''' location of window
  ''' </summary>
  Public X, Y As Integer ' int
  ''' <summary>
  ''' width and height of window
  ''' </summary>
  Public Width, Height As Integer ' int
  ''' <summary>
  ''' border width of window
  ''' </summary>
  Public BorderWidth As Integer ' int
  ''' <summary>
  ''' depth of window
  ''' </summary>
  Public Depth As Integer ' int
  ''' <summary>
  ''' the associated visual structure
  ''' </summary>
  Public Visual As IntPtr ' Visual *
  ''' <summary>
  ''' root of screen containing window
  ''' </summary>
  Public Root As IntPtr ' Window
  ''' <summary>
  ''' InputOutput, InputOnly
  ''' </summary>
  Public [Class] As Integer ' int
  ''' <summary>
  ''' one of bit gravity values
  ''' </summary>
  Public BitGravity As Integer ' int
  ''' <summary>
  ''' one of the window gravity values
  ''' </summary>
  Public WinGravity As Integer ' int
  ''' <summary>
  ''' NotUseful, WhenMapped, Always
  ''' </summary>
  Public BackingStore As Integer ' int
  ''' <summary>
  ''' planes to be preserved if possible
  ''' </summary>
  Public BackingPlanes As Long ' unsigned long
  ''' <summary>
  ''' value to be used when restoring planes
  ''' </summary>
  Public BackingPixel As Long ' unsigned long
  ''' <summary>
  ''' boolean, should bits under be saved?
  ''' </summary>
  Public SaveUnder As Boolean ' Bool
  ''' <summary>
  ''' color map to be associated with window
  ''' </summary>
  Public Colormap As IntPtr ' Colormap
  ''' <summary>
  ''' boolean, is color map currently installed
  ''' </summary>
  Public MapInstalled As Boolean ' Bool
  ''' <summary>
  ''' IsUnmapped, IsUnviewable, IsViewable
  ''' </summary>
  Public MapState As XMapState ' int
  ''' <summary>
  ''' set of events all people have interest in
  ''' </summary>
  Public AllEventMasks As Long ' long
  ''' <summary>
  ''' my event mask
  ''' </summary>
  Public YourEventMask As Long ' long
  ''' <summary>
  ''' set of events that should not propagate
  ''' </summary>
  Public DoNotPropagateMask As Long ' long
  ''' <summary>
  ''' boolean value for override-redirect
  ''' </summary>
  Public OverrideRedirect As Boolean ' Bool
  ''' <summary>
  ''' back pointer to correct screen
  ''' </summary>
  Public Screen As IntPtr ' Screen *
End Structure