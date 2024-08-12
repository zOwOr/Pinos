Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient

Public Class DAPosts
    Public DataBase As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public DataSet As DataSet

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoPosts) As String
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@Id", DbType.String, objInfo.Id)
            DataBase.AddInParameter(DbCommand, "@PostAuthor", DbType.String, objInfo.PostAuthor)
            DataBase.AddInParameter(DbCommand, "@PostContent", DbType.String, objInfo.PostContent)
            DataBase.AddInParameter(DbCommand, "@PostTitle", DbType.String, objInfo.PostTitle)
            DataBase.AddInParameter(DbCommand, "@PostName", DbType.String, objInfo.PostName)
            DataBase.AddInParameter(DbCommand, "@MenuOrder", DbType.String, objInfo.MenuOrder)
            DataBase.AddInParameter(DbCommand, "@PostDate", DbType.String, objInfo.PostDate)
            DataBase.AddInParameter(DbCommand, "@PostModified", DbType.String, objInfo.PostModified)
            DataBase.AddInParameter(DbCommand, "@PostType", DbType.String, objInfo.PostType)
            DataBase.AddInParameter(DbCommand, "@Active", DbType.String, objInfo.Active)
            Return DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As InfoPosts)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@Id", DbType.String, objInfo.Id)
            DataBase.AddInParameter(DbCommand, "@PostAuthor", DbType.String, objInfo.PostAuthor)
            DataBase.AddInParameter(DbCommand, "@PostContent", DbType.String, objInfo.PostContent)
            DataBase.AddInParameter(DbCommand, "@PostTitle", DbType.String, objInfo.PostTitle)
            DataBase.AddInParameter(DbCommand, "@PostName", DbType.String, objInfo.PostName)
            DataBase.AddInParameter(DbCommand, "@MenuOrder", DbType.String, objInfo.MenuOrder)
            DataBase.AddInParameter(DbCommand, "@PostDate", DbType.String, objInfo.PostDate)
            DataBase.AddInParameter(DbCommand, "@PostModified", DbType.String, objInfo.PostModified)
            DataBase.AddInParameter(DbCommand, "@PostType", DbType.String, objInfo.PostType)
            DataBase.AddInParameter(DbCommand, "@Active", DbType.String, objInfo.Active)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As InfoPosts)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@Id", DbType.String, objInfo.Id)
            DataBase.AddInParameter(DbCommand, "@PostAuthor", DbType.String, objInfo.PostAuthor)
            DataBase.AddInParameter(DbCommand, "@PostContent", DbType.String, objInfo.PostContent)
            DataBase.AddInParameter(DbCommand, "@PostTitle", DbType.String, objInfo.PostTitle)
            DataBase.AddInParameter(DbCommand, "@PostName", DbType.String, objInfo.PostName)
            DataBase.AddInParameter(DbCommand, "@MenuOrder", DbType.String, objInfo.MenuOrder)
            DataBase.AddInParameter(DbCommand, "@PostDate", DbType.String, objInfo.PostDate)
            DataBase.AddInParameter(DbCommand, "@PostModified", DbType.String, objInfo.PostModified)
            DataBase.AddInParameter(DbCommand, "@PostType", DbType.String, objInfo.PostType)
            DataBase.AddInParameter(DbCommand, "@Active", DbType.String, objInfo.Active)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As InfoPosts)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@Id", DbType.String, objInfo.Id)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function Load(ByVal objInfo As InfoPosts) As DataSet
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@Id", DbType.String, objInfo.Id)
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class
