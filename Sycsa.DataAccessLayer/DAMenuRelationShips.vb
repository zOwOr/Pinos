Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient

Public Class DAMenuRelationShips
    Public DataBase As Microsoft.Practices.EnterpriseLibrary.Data.Database = DatabaseFactory.CreateDatabase("")
    Public DbCommand As Common.DbCommand
    Public DataSet As DataSet

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoMenuRelationShips) As String
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdMenuRelationShips", DbType.Int64, objInfo.IdMenuRelationShips)
            DataBase.AddInParameter(DbCommand, "@IdObject", DbType.Int64, objInfo.IdObject)
            DataBase.AddInParameter(DbCommand, "@IdMenu", DbType.Int64, objInfo.IdMenu)
            DataBase.AddInParameter(DbCommand, "@Order", DbType.Int64, objInfo.Order)
            Return DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoMenuRelationShips)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdMenuRelationShips", DbType.Int64, objInfo.IdMenuRelationShips)
            DataBase.AddInParameter(DbCommand, "@IdObject", DbType.Int64, objInfo.IdObject)
            DataBase.AddInParameter(DbCommand, "@IdMenu", DbType.Int64, objInfo.IdMenu)
            DataBase.AddInParameter(DbCommand, "@Order", DbType.Int64, objInfo.Order)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoMenuRelationShips)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdMenuRelationShips", DbType.Int64, objInfo.IdMenuRelationShips)
            DataBase.AddInParameter(DbCommand, "@IdObject", DbType.Int64, objInfo.IdObject)
            DataBase.AddInParameter(DbCommand, "@IdMenu", DbType.Int64, objInfo.IdMenu)
            DataBase.AddInParameter(DbCommand, "@Order", DbType.Int64, objInfo.Order)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoMenuRelationShips)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdMenuRelationShips", DbType.Int64, objInfo.IdMenuRelationShips)
            DataBase.AddInParameter(DbCommand, "@IdObject", DbType.Int64, objInfo.IdObject)
            DataBase.AddInParameter(DbCommand, "@IdMenu", DbType.Int64, objInfo.IdMenu)
            DataBase.AddInParameter(DbCommand, "@Order", DbType.Int64, objInfo.Order)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Load"
    Public Function Load(ByVal objInfo As Information.InfoMenuRelationShips) As DataSet
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdMenuRelationShips", DbType.Int64, objInfo.IdMenuRelationShips)
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
