Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient


Public Class DASample
    Public DataBase As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public DataSet As DataSet

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoSample) As String
        Try
            DbCommand = DataBase.GetStoredProcCommand("Save_UserReturn")
            DataBase.AddInParameter(DbCommand, "@IdUser", DbType.Int32, objInfo.IdUser)
            DataBase.AddInParameter(DbCommand, "@Name", DbType.String, objInfo.Name)
            Return DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoSample)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Save_User")
            DataBase.AddInParameter(DbCommand, "@IdUser", DbType.Int32, objInfo.IdUser)
            DataBase.AddInParameter(DbCommand, "@Name", DbType.String, objInfo.Name)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoSample)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Update_User")
            DataBase.AddInParameter(DbCommand, "@IdUser", DbType.Int32, objInfo.IdUser)
            DataBase.AddInParameter(DbCommand, "@Name", DbType.String, objInfo.Name)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoSample)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Delete_User")
            DataBase.AddInParameter(DbCommand, "@IdUser", DbType.Int32, objInfo.IdUser)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function Load(ByVal objInfo As Information.InfoSample) As DataSet
        Try
            DbCommand = DataBase.GetStoredProcCommand("Load_User")
            DataBase.AddInParameter(DbCommand, "@IdUser", DbType.Int32, objInfo.IdUser)
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region



End Class
