Imports sycsa.Information
Imports sycsa.DataAccessLayer

Public Class BLCategories
    Inherits Information.InfoCategories
    Public DataSet As New DataSet
    Public objDA As New DataAccessLayer.DACategories

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoCategories) As String
        Try
            Me.IdCategories = objDA.SaveReturn(CType(Me, Information.InfoCategories))
            Return IdCategories
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save()
        Try
            objDA.Save(CType(Me, Information.InfoCategories))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update()
        Try
            objDA.Update(CType(Me, Information.InfoCategories))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete()
        Try
            objDA.Delete(CType(Me, Information.InfoCategories))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"

    Public Function LoadById() As List(Of InfoCategories)
        Try
            Dim ObjInfoCategory As New List(Of InfoCategories)
            ObjInfoCategory = objDA.LoadById(CType(Me, Information.InfoCategories))
            Return ObjInfoCategory
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Load() As DataSet
        Try

            DataSet = objDA.Load(CType(Me, Information.InfoCategories))
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadLayout() As DataSet
        Try

            DataSet = objDA.LoadLayout(CType(Me, Information.InfoCategories))
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region
End Class
