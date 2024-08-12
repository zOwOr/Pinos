Imports sycsa.DataAccessLayer
Imports sycsa.Information
Public Class BLOptions
    Inherits InfoOptions
    Public ObjDa As New DAOptions

    Public Sub SaveMethodSend()
        Try
            ObjDa.SaveMethodSend(CType(Me, Information.InfoOptions))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function Load() As List(Of InfoOptions)
        Try
            Dim ObjInfoOptions As New List(Of InfoOptions)
            With ObjDa
                ObjInfoOptions = .Load
            End With
            Return ObjInfoOptions
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Update(ByVal dtObj As DataTable)
        Try
            With ObjDa
                .Update(dtObj)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
