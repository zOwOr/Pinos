Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient

Public Class DAPaymentMethod
    Public Database As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public DataSet As DataSet

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoPaymentMethod) As String
        Try
            DbCommand = Database.GetStoredProcCommand("")
            Database.AddInParameter(DbCommand, "@IdPaymentMethod", DbType.Int32, objInfo.IdPaymentMethod)
            Database.AddInParameter(DbCommand, "@Description", DbType.String, objInfo.Description)
            Database.AddInParameter(DbCommand, "@PaymentImagen", DbType.String, objInfo.PaymentImagen)
            Return Database.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoPaymentMethod)
        Try
            DbCommand = Database.GetStoredProcCommand("")
            Database.AddInParameter(DbCommand, "@IdPaymentMethod", DbType.Int32, objInfo.IdPaymentMethod)
            Database.AddInParameter(DbCommand, "@Description", DbType.String, objInfo.Description)
            Database.AddInParameter(DbCommand, "@PaymentImagen", DbType.String, objInfo.PaymentImagen)
            Database.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoPaymentMethod)
        Try
            DbCommand = Database.GetStoredProcCommand("")
            Database.AddInParameter(DbCommand, "@IdPaymentMethod", DbType.Int32, objInfo.IdPaymentMethod)
            Database.AddInParameter(DbCommand, "@Description", DbType.String, objInfo.Description)
            Database.AddInParameter(DbCommand, "@PaymentImagen", DbType.String, objInfo.PaymentImagen)
            Database.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Detele"
    Public Sub Delete(ByVal objInfo As Information.InfoPaymentMethod)
        Try
            DbCommand = Database.GetStoredProcCommand("")
            Database.AddInParameter(DbCommand, "@IdPaymentMethod", DbType.Int32, objInfo.IdPaymentMethod)
            Database.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function Load(ByVal objInfo As Information.InfoPaymentMethod) As DataSet
        Try
            DbCommand = Database.GetStoredProcCommand("")
            Database.AddInParameter(DbCommand, "@IdPaymentMethod", DbType.Int32, objInfo.IdPaymentMethod)
            DataSet = Database.ExecuteDataSet(DbCommand)
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
