Imports sycsa.Information
Imports sycsa.DataAccessLayer

Public Class BLMenuRelationShips
    Inherits Information.InfoMenuRelationShips
    Public objDA As New DataAccessLayer.DAMenuRelationShips
    Public DataSet As New DataSet

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoMenuRelationShips)
        Try
            Me.IdMenuRelationShips = objDA.SaveReturn(CType(Me, Information.InfoMenuRelationShips))
            Return IdMenuRelationShips
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoMenuRelationShips)
        Try
            objDA.Save(CType(Me, Information.InfoMenuRelationShips))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoMenuRelationShips)
        Try
            objDA.Update(CType(Me, Information.InfoMenuRelationShips))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoMenuRelationShips)
        Try
            objDA.Delete(CType(Me, Information.InfoMenuRelationShips))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Load"

    Public Function Load(ByVal objInfo As Information.InfoMenuRelationShips)
        Try
            DataSet = objDA.Load(CType(Me, Information.InfoMenuRelationShips))
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
