Imports sycsa.Information
Imports sycsa.DataAccessLayer

Public Class BLMenus
    Inherits Information.InfoMenus

    Public DataSet As New DataSet
    Public objDA As New DataAccessLayer.DAMenus

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoMenus) As String
        Try
            Me.IdMenus = objDA.SaveReturn(CType(Me, Information.InfoMenus))
            Return IdMenus
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoMenus)
        Try
            objDA.Save(CType(Me, Information.InfoMenus))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoMenus)
        Try
            objDA.Update(CType(Me, Information.InfoMenus))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoMenus)
        Try
            objDA.Delete(CType(Me, Information.InfoMenus))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function Load(ByVal objInfo As Information.InfoMenus) As DataSet
        Try
            DataSet = objDA.Load(CType(Me, Information.InfoMenus))
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
