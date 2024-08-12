Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient
Public Class DAProductPicture
    Public DataBase As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public DataSet As DataSet

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoProductPicture) As String
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdProductsPicture", DbType.Int64, objInfo.IdProductsPicture)
            DataBase.AddInParameter(DbCommand, "@IdProduct", DbType.Int64, objInfo.IdProduct)
            DataBase.AddInParameter(DbCommand, "@ProductImage", DbType.String, objInfo.ProductImage)
            DataBase.AddInParameter(DbCommand, "@ProductThumb", DbType.String, objInfo.ProductThumb)
            Return DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoProductPicture)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdProductsPicture", DbType.Int64, objInfo.IdProductsPicture)
            DataBase.AddInParameter(DbCommand, "@IdProduct", DbType.Int64, objInfo.IdProduct)
            DataBase.AddInParameter(DbCommand, "@ProductImage", DbType.String, objInfo.ProductImage)
            DataBase.AddInParameter(DbCommand, "@ProductThumb", DbType.String, objInfo.ProductThumb)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoProductPicture)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdProductsPicture", DbType.Int64, objInfo.IdProductsPicture)
            DataBase.AddInParameter(DbCommand, "@IdProduct", DbType.Int64, objInfo.IdProduct)
            DataBase.AddInParameter(DbCommand, "@ProductImage", DbType.String, objInfo.ProductImage)
            DataBase.AddInParameter(DbCommand, "@ProductThumb", DbType.String, objInfo.ProductThumb)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoProductPicture)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdProductsPicture", DbType.Int64, objInfo.IdProductsPicture)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function Load(ByVal objInfo As Information.InfoProductPicture) As DataSet
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdProductsPicture", DbType.Int64, objInfo.IdProductsPicture)
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
