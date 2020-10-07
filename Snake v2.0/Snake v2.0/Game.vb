Option Strict On
Option Explicit On
Option Infer Off
Public Class Game
    Private _Height As Integer
    Private _Width As Integer
    Private _Game(,) As String
    Private Board As String
    Public Score As Integer
    Public objSnake As Snake
    Public objApple As Apple
    Public GameOver As Boolean
    Public Enum Direction As Integer
        UP = 0
        RIGHT = 1
        DOWN = 2
        LEFT = 3
    End Enum
    Public Sub New(Hight As Integer, Width As Integer)
        _Height = Hight
        _Width = Width
        ReDim _Game(_Height, _Width)
        objSnake = New Snake(CInt(Width / 2), CInt(Hight / 2), Direction.RIGHT)
        objApple = New Apple()
    End Sub
    Public Sub Play()
        Console.Clear()
        If Console.KeyAvailable Then
            Select Case Console.ReadKey().Key
                Case ConsoleKey.UpArrow : objSnake.SetHeadDirection(Direction.UP, 0)
                Case ConsoleKey.RightArrow : objSnake.SetHeadDirection(Direction.RIGHT, 0)
                Case ConsoleKey.DownArrow : objSnake.SetHeadDirection(Direction.DOWN, 0)
                Case ConsoleKey.LeftArrow : objSnake.SetHeadDirection(Direction.LEFT, 0)
            End Select
        End If
        If (objSnake.Segment(0).Position.x = objApple.x) And (objSnake.Segment(0).Position.y = objApple.y) Then
            Score += objApple.isEaten()
            objSnake.NewSegment()
        End If
        If Not (objApple.IsActive) Then
            objApple.Spawn(_Height, _Width)
        End If
        objSnake.Move()
        Render()
        Threading.Thread.Sleep(150)
    End Sub
    Public Sub Render()
        GenerateGameBoard()
        Board = GameBoard
        Console.WriteLine("                                Score: " + CStr(Score))
        Console.WriteLine(Board)
    End Sub
    Public Sub IsDead()
        If (objSnake.Segment(0).Position.x = 0) Or (objSnake.Segment(0).Position.y = 0) Or (objSnake.Segment(0).Position.x = _Width) Or (objSnake.Segment(0).Position.y = _Height) Then GameOver = True
        For i As Integer = 1 To objSnake.Length
            If (objSnake.Segment(0).Position.x = objSnake.Segment(i).Position.x) And (objSnake.Segment(0).Position.y = objSnake.Segment(i).Position.y) Then GameOver = True
        Next
    End Sub
    Private Sub GenerateGameBoard()
        If GameOver Then
            Exit Sub
        Else
            _Game(0, 0) = "+"
            _Game(0, _Width) = "+"
            _Game(_Height, 0) = "+"
            _Game(_Height, _Width) = "+"
            For i As Integer = 1 To _Width - 1
                _Game(0, i) = "-"
                _Game(_Height, i) = "-"
            Next i
            For j As Integer = 1 To _Height - 1
                _Game(j, 0) = "|"
                _Game(j, _Width) = "|"
            Next
            For k As Integer = 1 To _Height - 1
                For l As Integer = 1 To _Width - 1
                    _Game(k, l) = " "
                Next
            Next
            _Game(objApple.y, objApple.x) = "*"
            For m As Integer = 1 To objSnake.Length
                _Game(objSnake.Segment(m).Position.y, objSnake.Segment(m).Position.x) = "O"
            Next
            _Game(objSnake.Segment(0).Position.y, objSnake.Segment(0).Position.x) = "X"
        End If
        IsDead()
    End Sub
    Public ReadOnly Property GameBoard As String
        Get
            Dim Display As String
            For i As Integer = 0 To _Height
                For j As Integer = 0 To _Width
                    Display += _Game(i, j)
                Next
                Display += vbNewLine
            Next
            Return Display
        End Get
    End Property
End Class