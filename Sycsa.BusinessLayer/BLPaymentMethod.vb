Imports sycsa.Information
Imports sycsa.DataAccessLayer

Public Class BLPaymentMethod
    Inherits Information.InfoPaymentMethod
    Public objDA As New DataAccessLayer.DAPaymentMethod
    Public DataSet As New DataSet

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoPaymentMethod) As String
        Try
            Me.IdPaymentMethod = objDA.SaveReturn(CType(Me, Information.InfoPaymentMethod))
            Return IdPaymentMethod
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoPaymentMethod)
        Try
            objDA.Save(CType(Me, Information.InfoPaymentMethod))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoPaymentMethod)
        Try
            objDA.Update(CType(Me, Information.InfoPaymentMethod))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoPaymentMethod)
        Try
            objDA.Delete(CType(Me, Information.InfoPaymentMethod))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function Load(ByVal objInfo As Information.InfoPaymentMethod) As DataSet
        Try
            DataSet = objDA.Load(CType(Me, Information.InfoPaymentMethod))
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
