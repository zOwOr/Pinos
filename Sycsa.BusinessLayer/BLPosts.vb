Imports sycsa.Information
Imports sycsa.DataAccessLayer

Public Class BLPosts
    Inherits Information.InfoPosts

    Public DataSet As New DataSet
    Public objDA As New DataAccessLayer.DAPosts

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoPosts) As String
        Try
            Me.Id = objDA.SaveReturn(CType(Me, Information.InfoPosts))
            Return Id
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoPosts)
        Try
            objDA.Save(CType(Me, Information.InfoPosts))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoPosts)
        Try
            objDA.Update(CType(Me, Information.InfoPosts))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoPosts)
        Try
            objDA.Delete(CType(Me, Information.InfoPosts))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function Load(ByVal objInfo As Information.InfoPosts) As DataSet
        Try
            DataSet = objDA.Load(CType(Me, Information.InfoPosts))
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
