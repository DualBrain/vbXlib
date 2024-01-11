''' <summary>
''' Extensions need a way to hang private data on some structures.
''' </summary>
Public Structure XExtData
  ''' <summary>
  ''' number returned by XRegisterExtension
  ''' </summary>
  Public Number As Integer ' int
  ''' <summary>
  ''' next item on list of data for structure
  ''' </summary>
  Public [Next] As IntPtr ' XExtData *
  ''' <summary>
  ''' called to free private storage
  ''' </summary>
  Public FreePrivate As Func(Of XExtData, Integer) ' ?
  ''' <summary>
  ''' data private to this extension
  ''' </summary>
  Public PrivateData As IntPtr ' XPointer
End Structure