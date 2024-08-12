Imports sycsa.Information
Imports sycsa.DataAccessLayer

Public Class BLNewsLetters
    Inherits Information.InfoNewsLetters
    Public objDA As New DataAccessLayer.DANewsLetters
    Public DataSet As New DataSet

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoNewsLetters) As String
        Try
            Me.IdNewsLetters = objDA.SaveReturn(CType(Me, Information.InfoNewsLetters))
            Return IdNewsLetters
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    Public Sub Save(ByVal dtObj As DataTable)
        Try
            objDA.Save(CType(Me, Information.InfoNewsLetters), dtObj)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "Update"
    Public Sub Update()
        Try
            objDA.Update(CType(Me, Information.InfoNewsLetters))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete()
        Try
            objDA.Delete(CType(Me, Information.InfoNewsLetters))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function LoadById() As List(Of InfoNewsLetters)
        Try
            Dim ObjInfoNewsLetters As List(Of InfoNewsLetters)
            ObjInfoNewsLetters = objDA.LoadById(CType(Me, Information.InfoNewsLetters))
            Return ObjInfoNewsLetters
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadCategory() As DataTable
        Try
            'Dim ObjInfoCategory As List(Of InfoNewsLetters)
            Dim DataTable As New DataTable
            DataTable = objDA.LoadCategory(CType(Me, Information.InfoNewsLetters))
            Return DataTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
