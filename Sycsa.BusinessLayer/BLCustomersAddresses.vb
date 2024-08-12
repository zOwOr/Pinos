Imports sycsa.Information
Imports sycsa.DataAccessLayer

Public Class BLCustomersAddresses
    Inherits Information.InfoCustomersAddresses

    Public DataSet As New DataSet
    Public objDA As New DataAccessLayer.DACustomersAddresses

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoCustomersAddresses) As String
        Try
            Me.IdAddress = objDA.SaveReturn(CType(Me, Information.InfoCustomersAddresses))
            Return IdAddress
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoCustomersAddresses)
        Try
            objDA.Save(CType(Me, Information.InfoCustomersAddresses))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoCustomersAddresses)
        Try
            objDA.Update(CType(Me, Information.InfoCustomersAddresses))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete()
        Try
            objDA.Delete(CType(Me, Information.InfoCustomersAddresses))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"

    Public Function Load() As List(Of InfoCustomers)
        Try
            Dim ObjInfoCustomer As New List(Of InfoCustomers)
            ObjInfoCustomer = objDA.Load(CType(Me, Information.InfoCustomersAddresses))
            Return ObjInfoCustomer
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadAll() As DataSet
        Try
            DataSet = objDA.LoadAll(CType(Me, Information.InfoCustomersAddresses))
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

End Class
