Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient
Public Class DAMenus
    Public DataBase As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public DataSet As DataSet

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoMenus) As String
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdMenus", DbType.Int64, objInfo.IdMenus)
            DataBase.AddInParameter(DbCommand, "@Name", DbType.String, objInfo.Name)
            DataBase.AddInParameter(DbCommand, "@Description", DbType.String, objInfo.Description)
            DataBase.AddInParameter(DbCommand, "@Active", DbType.Boolean, objInfo.Active)
            Return DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoMenus)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdMenus", DbType.Int64, objInfo.IdMenus)
            DataBase.AddInParameter(DbCommand, "@Name", DbType.String, objInfo.Name)
            DataBase.AddInParameter(DbCommand, "@Description", DbType.String, objInfo.Description)
            DataBase.AddInParameter(DbCommand, "@Active", DbType.Boolean, objInfo.Active)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoMenus)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdMenus", DbType.Int64, objInfo.IdMenus)
            DataBase.AddInParameter(DbCommand, "@Name", DbType.String, objInfo.Name)
            DataBase.AddInParameter(DbCommand, "@Description", DbType.String, objInfo.Description)
            DataBase.AddInParameter(DbCommand, "@Active", DbType.Boolean, objInfo.Active)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoMenus)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdMenus", DbType.Int64, objInfo.IdMenus)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function Load(ByVal objInfo As Information.InfoMenus) As DataSet
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdMenus", DbType.Int64, objInfo.IdMenus)
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
