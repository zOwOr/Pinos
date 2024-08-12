Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient

Public Class DAUsers
    Public DataBase As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public DataSet As DataSet

#Region "Save"

    Public Function SaveReturn(ByVal objInfo As Information.InfoUsers) As String
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@Id", DbType.Int32, objInfo.Id)
            DataBase.AddInParameter(DbCommand, "@UserLogin", DbType.String, objInfo.UserLogin)
            DataBase.AddInParameter(DbCommand, "@UserPass", DbType.String, objInfo.UserPass)
            DataBase.AddInParameter(DbCommand, "@UserNicename", DbType.String, objInfo.UserNicename)
            DataBase.AddInParameter(DbCommand, "@UserName", DbType.String, objInfo.UserName)
            DataBase.AddInParameter(DbCommand, "@UserEmail", DbType.String, objInfo.UserEmail)
            DataBase.AddInParameter(DbCommand, "@UserRegistered", DbType.DateTime, objInfo.UserRegistered)
            DataBase.AddInParameter(DbCommand, "@Active", DbType.Boolean, objInfo.Active)
            Return DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoUsers)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Insert_User")
            DataBase.AddInParameter(DbCommand, "user_nickename", DbType.String, objInfo.UserNicename)
            DataBase.AddInParameter(DbCommand, "user_name", DbType.String, objInfo.UserName)
            DataBase.AddInParameter(DbCommand, "user_login", DbType.String, objInfo.UserLogin)
            DataBase.AddInParameter(DbCommand, "user_pass", DbType.String, objInfo.UserPass)
            DataBase.AddInParameter(DbCommand, "user_email", DbType.String, objInfo.UserEmail)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoUsers)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Update_User")
            DataBase.AddInParameter(DbCommand, "IdUser", DbType.Int32, objInfo.Id)
            DataBase.AddInParameter(DbCommand, "user_nickname", DbType.String, objInfo.UserNicename)
            DataBase.AddInParameter(DbCommand, "user_name", DbType.String, objInfo.UserName)
            DataBase.AddInParameter(DbCommand, "user_pass", DbType.String, objInfo.UserPass)
            DataBase.AddInParameter(DbCommand, "user_email", DbType.String, objInfo.UserEmail)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoUsers)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Delete_User")
            DataBase.AddInParameter(DbCommand, "IdUser", DbType.Int32, objInfo.Id)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"

    Public Function StartSesion(ByVal objInfo As InfoUsers) As List(Of InfoUsers)
        Try
            Dim ObjInfoUser As New List(Of InfoUsers)
            DbCommand = DataBase.GetStoredProcCommand("sp_Login")
            DataBase.AddInParameter(DbCommand, "UserName", DbType.String, objInfo.UserLogin)
            DataBase.AddInParameter(DbCommand, "Pass", DbType.String, objInfo.UserPass)
            DataSet = DataBase.ExecuteDataSet(DbCommand)

            For Each Row As DataRow In DataSet.Tables(0).Rows
                Dim Obj As New InfoUsers
                Obj.Id = Integer.Parse(Row("ID").ToString)
                Obj.UserNicename = Row("user_nickname").ToString
                Obj.UserName = Row("user_name").ToString
                Obj.UserEmail = Row("user_email").ToString
                Obj.Active = Row("Active").ToString
                ObjInfoUser.Add(Obj)
            Next
            Return ObjInfoUser
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function LoadById(ByVal objInfo As InfoUsers) As List(Of InfoUsers)
        Try
            Dim ObjInfoUser As New List(Of InfoUsers)
            DbCommand = DataBase.GetStoredProcCommand("Select_User")
            DataBase.AddInParameter(DbCommand, "IdUser", DbType.Int32, objInfo.Id)
            DataSet = DataBase.ExecuteDataSet(DbCommand)

            For Each Row As DataRow In DataSet.Tables(0).Rows
                Dim Obj As New InfoUsers
                Obj.Id = Integer.Parse(Row("ID").ToString)
                Obj.UserLogin = Row("user_login").ToString
                Obj.UserNicename = Row("user_nickname").ToString
                Obj.UserName = Row("user_name").ToString
                Obj.UserLogin = Row("user_login").ToString
                Obj.UserPass = Row("user_pass").ToString
                Obj.UserEmail = Row("user_email").ToString
                ObjInfoUser.Add(Obj)
            Next
            Return ObjInfoUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadUser(ByVal objInfo As InfoUsers) As List(Of InfoUsers)
        Try
            Dim ObjInfoUser As New List(Of InfoUsers)
            DbCommand = DataBase.GetStoredProcCommand("Select_UserLogin")
            DataBase.AddInParameter(DbCommand, "UserLogin", DbType.String, objInfo.UserLogin)
            DataBase.AddInParameter(DbCommand, "UserPass", DbType.String, objInfo.UserPass)
            DataSet = DataBase.ExecuteDataSet(DbCommand)

            For Each Row As DataRow In DataSet.Tables(0).Rows
                Dim Obj As New InfoUsers
                Obj.Id = Integer.Parse(Row("ID").ToString)
                Obj.UserName = Row("user_name").ToString
                ObjInfoUser.Add(Obj)
            Next
            Return ObjInfoUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function





#End Region
End Class
