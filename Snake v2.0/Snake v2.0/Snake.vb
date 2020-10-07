Option Strict On
Option Explicit On
Option Infer Off
Public Class Snake
    Public Structure sPosition
        Public x As Integer
        Public y As Integer
    End Structure
    Public Structure sDirection
        Public dx As Integer
        Public dy As Integer
    End Structure
    Public Structure sSegment
        Public Position As sPosition
        Public Direction As sDirection
    End Structure
    Public Segment() As sSegment
    Public Length As Integer
    Public HeadDirection As Integer
    Public Sub New(HeadPosX As Integer, HeadPosY As Integer, conDirection As Integer)
        Length = 5
        ReDim Segment(Length)
        Segment(0).Position.x = HeadPosX
        Segment(0).Position.y = HeadPosY
        HeadDirection = conDirection
        For i As Integer = 1 To Length
            Segment(i).Position.x = HeadPosX - i
            Segment(i).Position.y = HeadPosY
        Next
        For j As Integer = 0 To Length
            SetHeadDirection(conDirection, j)
        Next
    End Sub
    Public Sub NewSegment()
        'Adds a new segment to the end of the snake
        Length += 1
        ReDim Preserve Segment(Length)
        Segment(Length).Position.x = Segment(Length - 1).Position.x - Segment(Length - 1).Direction.dx
        Segment(Length).Position.y = Segment(Length - 1).Position.y - Segment(Length - 1).Direction.dy
        Segment(Length).Direction.dx = Segment(Length - 1).Direction.dx
        Segment(Length).Direction.dy = Segment(Length - 1).Direction.dy
    End Sub
    Public Sub Move()
        'Moves each segment of the snake
        Dim NewX(Length), NewY(Length) As Integer
        For j As Integer = 1 To Length
            'Records directional data from each segament
            NewX(j) = Segment(j - 1).Direction.dx
            NewY(j) = Segment(j - 1).Direction.dy
        Next
        For i As Integer = 0 To Length
            'Changes the direction of each segment to the previous segment
            Segment(i).Position.x += Segment(i).Direction.dx
            Segment(i).Position.y += Segment(i).Direction.dy
            'SetDirection(HeadDirection, 0)
            If i > 0 Then
                Segment(i).Direction.dx = NewX(i)
                Segment(i).Direction.dy = NewY(i)
            End If
        Next
    End Sub
    Public Sub SetHeadDirection(Direction As Integer, j As Integer)
        'Sets the direction of the indicated segment
        Select Case Direction
            Case 0
                If HeadDirection <> 2 Then
                    Segment(j).Direction.dx = 0
                    Segment(j).Direction.dy = -1
                    HeadDirection = 0
                End If
            Case 1
                If HeadDirection <> 3 Then
                    Segment(j).Direction.dx = 1
                    Segment(j).Direction.dy = 0
                    HeadDirection = 1
                End If
            Case 2
                If HeadDirection <> 0 Then
                    Segment(j).Direction.dx = 0
                    Segment(j).Direction.dy = 1
                    HeadDirection = 2
                End If
            Case 3
                If HeadDirection <> 1 Then
                    Segment(j).Direction.dx = -1
                    Segment(j).Direction.dy = 0
                    HeadDirection = 3
                End If
        End Select
    End Sub
End Class