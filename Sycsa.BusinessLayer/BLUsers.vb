Imports sycsa.Information
Imports sycsa.DataAccessLayer

Public Class BLUsers
    Inherits Information.InfoUsers
    Public objDA As New DataAccessLayer.DAUsers
    Public DataSet As New DataSet

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoUsers) As String
        Try
            Me.Id = objDA.SaveReturn(CType(Me, Information.InfoUsers))
            Return Id
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save()
        Try
            objDA.Save(CType(Me, Information.InfoUsers))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Update"
    Public Sub Update()
        Try
            objDA.Update(CType(Me, Information.InfoUsers))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Delete"
    Public Sub Delete()
        Try
            objDA.Delete(CType(Me, Information.InfoUsers))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Load"

    Public Function LoadById() As List(Of InfoUsers)
        Try
            Dim ObjInfoUser As New List(Of InfoUsers)
            ObjInfoUser = objDA.LoadById(CType(Me, InfoUsers))
            Return ObjInfoUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function LoadUser() As List(Of InfoUsers)
        Try
            Dim ObjInfoUser As New List(Of InfoUsers)
            ObjInfoUser = objDA.LoadUser(CType(Me, InfoUsers))
            Return ObjInfoUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function StartSesion() As List(Of InfoUsers)
        Try
            Dim ObjInfoUser As New List(Of InfoUsers)
            ObjInfoUser = objDA.StartSesion(CType(Me, InfoUsers))
            Return ObjInfoUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region
End Class
