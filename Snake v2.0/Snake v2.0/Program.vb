Option Strict On
Option Explicit On
Option Infer Off
Imports System
Module Program
    Private Game As Game
    Private Height As Integer
    Private Width As Integer
    Sub Main()
        Console.WriteLine("Enter the size of the game board (req. 20):")
        Height = CInt(Console.ReadLine())
        Width = Height
        Game = New Game(Height, Width)
        While Not (Game.GameOver)
            Game.Play()
        End While
        Console.WriteLine("Score: " + CStr(Game.Score))
    End Sub
End Module