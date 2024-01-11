Public MustInherit Class XHandle
  Implements IDisposable

  Public Property Handle As IntPtr

  Public Overridable Sub Dispose() Implements IDisposable.Dispose
    Handle = IntPtr.Zero
  End Sub

End Class