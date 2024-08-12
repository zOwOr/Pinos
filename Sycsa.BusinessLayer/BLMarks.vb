Imports sycsa.Information
Imports sycsa.DataAccessLayer
Public Class BLMarks
    Inherits Information.InfoMarks

    Public DataSet As New DataSet
    Public objDA As New DataAccessLayer.DAMarks

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoMarks) As String
        Try
            Me.IdMark = objDA.SaveReturn(CType(Me, Information.InfoMarks))
            Return IdMark
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save()
        Try
            objDA.Save(CType(Me, Information.InfoMarks))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update()
        Try
            objDA.Update(CType(Me, Information.InfoMarks))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete()
        Try
            objDA.Delete(CType(Me, Information.InfoMarks))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function LoadById() As IList(Of InfoMarks)
        Try
            Dim ObjInfoMark As New List(Of InfoMarks)
            ObjInfoMark = objDA.LoadById(CType(Me, Information.InfoMarks))
            Return ObjInfoMark
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function LoadMark() As DataSet
        Try
            DataSet = objDA.LoadMark()
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
