﻿''' <summary>
''' 狼
''' </summary>
Public Class Wolf
    Inherits PieceBase

    Public Overrides ReadOnly Property Camp As Camp = Camp.Wolf

    Public Overrides Function Moveable(map As Map, loc As VectorInt) As Boolean
        If map.GetAvailiable(loc) AndAlso map.GetJoint(loc).Connected() AndAlso map.Locate(loc) Is Nothing Then
            Dim temp As VectorInt = (loc - Location)
            Dim tempAbs As VectorInt = temp.AbsNew
            If InnerVectors.Contains(tempAbs) Then
                If map.GetJoint(Location).Connected(temp) Then
                    Return True
                End If
            ElseIf OuterVectors.Contains(tempAbs) Then
                Dim tempPart As VectorInt = temp / 2
                If map.Locate(Location + tempPart)?.Camp = Camp.Sheep Then
                    If map.GetJoint(Location).Connected(tempPart) Then
                        If map.GetJoint(Location + tempPart).Connected(tempPart) Then
                            Return True
                        End If
                    End If
                End If
            End If
        End If
        Return False
    End Function
End Class
