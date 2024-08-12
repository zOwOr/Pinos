Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient

Public Class DAOrdersDetails
    Public Database As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public DataSet As DataSet

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoOrdersDetails) As String
        Try
            DbCommand = Database.GetStoredProcCommand("")
            Database.AddInParameter(DbCommand, "@IdOrdersDetails", DbType.Int64, objInfo.IdOrdersDetails)
            Database.AddInParameter(DbCommand, "@IdOrder", DbType.Int64, objInfo.IdOrder)
            Database.AddInParameter(DbCommand, "@IdProduct", DbType.Int32, objInfo.IdProduct)
            Database.AddInParameter(DbCommand, "@UnitPrice", DbType.Decimal, objInfo.UnitPrice)
            Database.AddInParameter(DbCommand, "@Quantity", DbType.Int16, objInfo.Quantity)
            Return Database.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoOrdersDetails)
        Try
            DbCommand = Database.GetStoredProcCommand("")
            Database.AddInParameter(DbCommand, "@IdOrdersDetails", DbType.Int64, objInfo.IdOrdersDetails)
            Database.AddInParameter(DbCommand, "@IdOrder", DbType.Int64, objInfo.IdOrder)
            Database.AddInParameter(DbCommand, "@IdProduct", DbType.Int32, objInfo.IdProduct)
            Database.AddInParameter(DbCommand, "@UnitPrice", DbType.Decimal, objInfo.UnitPrice)
            Database.AddInParameter(DbCommand, "@Quantity", DbType.Int32, objInfo.Quantity)
            Database.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoOrdersDetails)
        Try
            DbCommand = Database.GetStoredProcCommand("")
            Database.AddInParameter(DbCommand, "@IdOrdersDetails", DbType.Int64, objInfo.IdOrdersDetails)
            Database.AddInParameter(DbCommand, "@IdOrder", DbType.Int64, objInfo.IdOrder)
            Database.AddInParameter(DbCommand, "@IdProduct", DbType.Int32, objInfo.IdProduct)
            Database.AddInParameter(DbCommand, "@UnitPrice", DbType.Decimal, objInfo.UnitPrice)
            Database.AddInParameter(DbCommand, "@Quantity", DbType.Int32, objInfo.Quantity)
            Database.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoOrdersDetails)
        Try
            DbCommand = Database.GetStoredProcCommand("")
            Database.AddInParameter(DbCommand, "@IdOrdersDetails", DbType.Int64, objInfo.IdOrdersDetails)
            Database.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function Load(ByVal objInfo As Information.InfoOrdersDetails) As DataSet
        Try
            DbCommand = Database.GetStoredProcCommand("")
            Database.AddInParameter(DbCommand, "@IdOrdersDetails", DbType.Int64, objInfo.IdOrdersDetails)
            DataSet = Database.ExecuteDataSet(DbCommand)
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
