Imports sycsa.Information
Imports sycsa.DataAccessLayer

Public Class BLProducts
    Inherits Information.InfoProducts
    Public DataSet As New DataSet
    Public objDA As New DataAccessLayer.DAProducts

#Region "Save"

    Public Function SaveReturn(ByVal objInfo As Information.InfoProducts) As String
        Try
            Me.ProductId = objDA.SaveReturn(CType(Me, Information.InfoProducts))
            Return ProductId
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save()
        Try
            objDA.Save(CType(Me, Information.InfoProducts))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Update"
    Public Sub Update()
        Try
            objDA.Update(CType(Me, Information.InfoProducts))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete()
        Try
            objDA.Delete(CType(Me, Information.InfoProducts))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"

    Public Function LoadById() As List(Of InfoProducts)
        Try
            Dim ObjInfoProducts As New List(Of InfoProducts)
            ObjInfoProducts = objDA.LoadById(CType(Me, Information.InfoProducts))
            Return ObjInfoProducts
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadSearch() As DataSet
        Try
            DataSet = objDA.LoadSearch(CType(Me, Information.InfoProducts))
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Loadlistproduct() As DataSet
        Try
            DataSet = objDA.Loadlistproduct(CType(Me, Information.InfoProducts))
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoaProductForSales() As List(Of InfoProducts)
        Try
            Dim ObjInfoProducts As New List(Of InfoProducts)
            ObjInfoProducts = objDA.LoaProductForSales(CType(Me, Information.InfoProducts))
            Return ObjInfoProducts
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region


End Class
