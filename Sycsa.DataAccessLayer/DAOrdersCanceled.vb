Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient

Public Class DAOrdersCanceled
    Public Database As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public Dataset As DataSet

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoOrdersCanceled) As String
        Try
            DbCommand = Database.GetStoredProcCommand("")
            Database.AddInParameter(DbCommand, "@IdCancellations", DbType.Int32, objInfo.IdCancellations)
            Database.AddInParameter(DbCommand, "@IdOrders", DbType.Int64, objInfo.IdOrders)
            Database.AddInParameter(DbCommand, "@DescriptionCancellation", DbType.String, objInfo.DescriptionCancellation)
            Database.AddInParameter(DbCommand, "@CancellationDate", DbType.DateTime, objInfo.CancellationDate)
            Return Database.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoOrdersCanceled)
        Try
            DbCommand = Database.GetStoredProcCommand("")
            Database.AddInParameter(DbCommand, "@IdCancellations", DbType.Int32, objInfo.IdCancellations)
            Database.AddInParameter(DbCommand, "@IdOrders", DbType.Int64, objInfo.IdOrders)
            Database.AddInParameter(DbCommand, "@DescriptionCancellation", DbType.String, objInfo.DescriptionCancellation)
            Database.AddInParameter(DbCommand, "@CancellationDate", DbType.DateTime, objInfo.CancellationDate)
            Database.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoOrdersCanceled)
        Try
            DbCommand = Database.GetStoredProcCommand("")
            Database.AddInParameter(DbCommand, "@IdCancellations", DbType.Int32, objInfo.IdCancellations)
            Database.AddInParameter(DbCommand, "@IdOrders", DbType.Int64, objInfo.IdOrders)
            Database.AddInParameter(DbCommand, "@DescriptionCancellation", DbType.String, objInfo.DescriptionCancellation)
            Database.AddInParameter(DbCommand, "@CancellationDate", DbType.DateTime, objInfo.CancellationDate)
            Database.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoOrdersCanceled)
        Try
            DbCommand = Database.GetStoredProcCommand("")
            Database.AddInParameter(DbCommand, "@IdCancellations", DbType.Int32, objInfo.IdCancellations)
            Database.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Load"
    Public Function Load(ByVal objInfo As Information.InfoOrdersCanceled)
        Try
            DbCommand = Database.GetStoredProcCommand("")
            Database.AddInParameter(DbCommand, "@IdCancellations", DbType.Int32, objInfo.IdCancellations)
            Dataset = Database.ExecuteDataSet(DbCommand)
            Return Dataset
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
