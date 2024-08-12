Imports sycsa.Information.InfoOrdersCanceled
Imports sycsa.DataAccessLayer.DAOrdersCanceled

Public Class BEOrdersCanceled
    Inherits Information.InfoOrdersCanceled
    Public objDA As New DataAccessLayer.DAOrdersCanceled
    Public DataSet As New DataSet

#Region "Save"

    Public Function SaveReturn(ByVal objInfo As Information.InfoOrdersCanceled) As String
        Try
            Me.IdCancellations = objDA.SaveReturn(CType(Me, Information.InfoOrdersCanceled))
            Return IdCancellations
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoOrdersCanceled)
        Try
            objDA.Save(CType(Me, Information.InfoOrdersCanceled))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region


#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoOrdersCanceled)
        Try
            objDA.Update(CType(Me, Information.InfoOrdersCanceled))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoOrdersCanceled)
        Try
            objDA.Delete(CType(Me, Information.InfoOrdersCanceled))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Load"

    Public Function Load(ByVal objInfo As Information.InfoOrdersCanceled) As DataSet
        Try
            DataSet = objDA.Load(CType(Me, Information.InfoOrdersCanceled))
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


End Class
