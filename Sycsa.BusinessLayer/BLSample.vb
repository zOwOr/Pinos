Imports sycsa.Information
Imports sycsa.DataAccessLayer

Public Class BLSample
    Inherits Information.InfoSample

    Public DataSet As New DataSet
    Public objDA As New DataAccessLayer.DASample

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoSample) As String
        Try
            Me.IdUser = objDA.SaveReturn(CType(Me, Information.InfoSample))
            Return IdUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoSample)
        Try
            objDA.Save(CType(Me, Information.InfoSample))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoSample)
        Try
            objDA.Update(CType(Me, Information.InfoSample))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoSample)
        Try
            objDA.Delete(CType(Me, Information.InfoSample))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function Load(ByVal objInfo As Information.InfoSample) As DataSet
        Try
            DataSet = objDA.Load(CType(Me, Information.InfoSample))
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
