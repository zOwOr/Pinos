Imports sycsa.Information
Imports sycsa.DataAccessLayer
Public Class BLProductPicture
    Inherits Information.InfoProductPicture

    Public DataSet As New DataSet
    Public objDA As New DataAccessLayer.DAProductPicture

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoProductPicture) As String
        Try
            Me.IdProductsPicture = objDA.SaveReturn(CType(Me, Information.InfoProductPicture))
            Return IdProductsPicture
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoProductPicture)
        Try
            objDA.Save(CType(Me, Information.InfoProductPicture))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoProductPicture)
        Try
            objDA.Update(CType(Me, Information.InfoProductPicture))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoProductPicture)
        Try
            objDA.Delete(CType(Me, Information.InfoProductPicture))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function Load(ByVal objInfo As Information.InfoProductPicture) As DataSet
        Try
            DataSet = objDA.Load(CType(Me, Information.InfoProductPicture))
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
