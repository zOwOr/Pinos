Imports sycsa.Information
Imports sycsa.DataAccessLayer

Public Class BLCustomers
    Inherits Information.InfoCustomers

    Public DataSet As New DataSet
    Public objDA As New DataAccessLayer.DACustomers

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoCustomers) As String
        Try
            Me.IdCustomer = objDA.SaveReturn(CType(Me, Information.InfoCustomers))
            Return IdCustomer
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save()
        Try
            objDA.Save(CType(Me, Information.InfoCustomers))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SaveAddress()
        Try
            objDA.SaveAddress(CType(Me, InfoCustomers))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SaveContact()
        Try
            objDA.SaveContact(CType(Me, Information.InfoCustomers))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region


#Region "Update"
    Public Sub UpdateAddressCustomer()
        Try
            objDA.UpdateAddressCustomer(CType(Me, Information.InfoCustomers))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update()
        Try
            objDA.Update(CType(Me, Information.InfoCustomers))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateCount()
        Try
            objDA.UpdateCount(CType(Me, Information.InfoCustomers))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdatePassword()
        Try
            objDA.UpdatePassword(CType(Me, Information.InfoCustomers))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoCustomers)
        Try
            objDA.Delete(CType(Me, Information.InfoCustomers))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Load"
    Public Function LoadById() As List(Of InfoCustomers)
        Try
            Dim ObjInfoCustomer As New List(Of InfoCustomers)
            ObjInfoCustomer = objDA.LoadById(CType(Me, Information.InfoCustomers))
            Return ObjInfoCustomer
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadAddressById() As List(Of InfoCustomers)
        Try
            Dim ObjInfoCustomer As New List(Of InfoCustomers)
            ObjInfoCustomer = objDA.LoadAddressById(CType(Me, InfoCustomers))
            Return ObjInfoCustomer
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadLogin() As List(Of InfoCustomers)
        Try
            Dim ObjInfoCustomer As New List(Of InfoCustomers)
            ObjInfoCustomer = objDA.LoadLogin(CType(Me, Information.InfoCustomers))
            Return ObjInfoCustomer
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
