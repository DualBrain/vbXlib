Imports System.Runtime.InteropServices

''' <summary>
''' Data structure for setting window attributes.
''' </summary>
<StructLayout(LayoutKind.Sequential)>
Public Structure XSetWindowAttributes
  ''' <summary>
  ''' background or None or ParentRelative
  ''' </summary>
  Public BackgroundPixmap As IntPtr ' Pixmap
  ''' <summary>
  ''' background pixel
  ''' </summary>
  Public BackgroundPixel As Long ' unsigned long
  ''' <summary>
  ''' order of the window
  ''' </summary>
  Public BorderPixmap As IntPtr ' Pixmap
  ''' <summary>
  ''' border pixel value
  ''' </summary>
  Public BorderPixel As Long ' unsigned long
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
  ''' value to use in restoring planes
  ''' </summary>
  Public BackingPixel As Long ' unsigned long
  ''' <summary>
  ''' should bits under be saved? (popups)
  ''' </summary>
  Public SaveUnder As Boolean ' Bool
  ''' <summary>
  ''' set of events that should be saved
  ''' </summary>
  Public EventMask As Long 'XEventMask ' long
  ''' <summary>
  ''' set of events that should not propagate
  ''' </summary>
  Public DoNotPropogateMask As Long 'XEventMask ' long
  ''' <summary>
  ''' boolean value for override-redirect
  ''' </summary>
  Public OverrideRedirect As Boolean ' Bool
  ''' <summary>
  ''' color map to be associated with window
  ''' </summary>
  Public Colormap As IntPtr ' Colormap
  ''' <summary>
  ''' cursor to be displayed (or None)
  ''' </summary>
  Public Cursor As IntPtr ' Cursor
End Structure