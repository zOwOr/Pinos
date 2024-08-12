Imports sycsa.Information
Imports sycsa.DataAccessLayer

Public Class BLSubCategories
    Inherits Information.InfoSubCategories
    Public objDA As New DataAccessLayer.DASubCategories
    Public Dataset As New DataSet

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoSubCategories) As String
        Try
            Me.IdSubCategories = objDA.SaveReturn(CType(Me, Information.InfoSubCategories))
            Return IdSubCategories
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save()
        Try
            objDA.Save(CType(Me, Information.InfoSubCategories))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Update"
    Public Sub Update()
        Try
            objDA.Update(CType(Me, Information.InfoSubCategories))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete()
        Try
            objDA.Delete(CType(Me, Information.InfoSubCategories))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"

    Public Function Load() As List(Of InfoSubCategories)

        Try
            Dim ObjInfoSubCategory As New List(Of InfoSubCategories)
            ObjInfoSubCategory = objDA.Load(CType(Me, Information.InfoSubCategories))
            Return ObjInfoSubCategory
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function LoadBy() As DataSet

        Try
            Dataset = objDA.LoadBy(CType(Me, Information.InfoSubCategories))
            Return Dataset
        Catch ex As Exception
            Throw ex
        End Try

    End Function



#End Region
End Class
