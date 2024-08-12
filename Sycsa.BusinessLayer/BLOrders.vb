Imports sycsa.Information
Imports sycsa.DataAccessLayer
Public Class BLOrders
    Inherits Information.InfoOrders

    Public DataSet As New DataSet
    Public objDA As New DataAccessLayer.DAOrders

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoOrders) As String
        Try
            Me.IdOrders = objDA.SaveReturn(CType(Me, Information.InfoOrders))
            Return IdOrders
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Save() As DataSet
        Try

            DataSet = objDA.Save(CType(Me, Information.InfoOrders))
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub SaveProducto()
        Try

            objDA.SaveProducto(CType(Me, Information.InfoOrders))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoOrders)
        Try
            objDA.Update(CType(Me, Information.InfoOrders))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoOrders)
        Try
            objDA.Delete(CType(Me, Information.InfoOrders))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"


    Public Function LoadById() As List(Of InfoOrders)
        Try
            Dim ObjInfoOrder As New List(Of InfoOrders)
            ObjInfoOrder = objDA.LoadById(CType(Me, Information.InfoOrders))
            Return ObjInfoOrder
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function LoadMethondSend() As DataSet
        Try

            DataSet = objDA.LoadMethondSend(CType(Me, Information.InfoOrders))
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class
