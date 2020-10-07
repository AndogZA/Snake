Option Strict On
Option Explicit On
Option Infer Off
Public Class Apple
    Const SCORE As Integer = 10
    Public x As Integer
    Public y As Integer
    Public IsActive As Boolean
    Public Sub New()
    End Sub
    Public Function isEaten() As Integer
        IsActive = False
        Return SCORE
    End Function
    Public Sub Spawn(height As Integer, width As Integer)
        VBMath.Randomize()
        x = CInt((width - 2) * VBMath.Rnd()) + 1
        y = CInt((height - 2) * VBMath.Rnd()) + 1
        IsActive = True
    End Sub
End Class
