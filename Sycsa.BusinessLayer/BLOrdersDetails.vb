Imports sycsa.Information.InfoOrdersDetails
Imports sycsa.DataAccessLayer.DAOrdersDetails

Public Class BLOrdersDetails
    Inherits Information.InfoOrdersDetails
    Public objDA As New DataAccessLayer.DAOrdersDetails
    Public Dataset As New DataSet

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoOrdersDetails) As String
        Try
            Me.IdOrdersDetails = objDA.SaveReturn(CType(Me, Information.InfoOrdersDetails))
            Return IdOrdersDetails
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoOrdersDetails)
        Try
            objDA.Save(CType(Me, Information.InfoOrdersDetails))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoOrdersDetails)
        Try
            objDA.Update(CType(Me, Information.InfoOrdersDetails))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoOrdersDetails)
        Try
            objDA.Delete(CType(Me, Information.InfoOrdersDetails))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Load"
    Public Function Load(ByVal objInfo As Information.InfoOrdersDetails) As DataSet
        Try
            Dataset = objDA.Load(CType(Me, Information.InfoOrdersDetails))
            Return Dataset
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
