Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient

Public Class DAGcRecoveryPass
    Public DataBase As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public DataSet As DataSet

#Region "Save"

    'Public Function SaveReturn(ByVal objInfo As Information.InfoGcRecoveryPass) As String
    '    Try
    '        DbCommand = DataBase.GetStoredProcCommand("Insert_gc_recovery_pass")
    '        DataBase.AddInParameter(DbCommand, "@IdUser", DbType.Int32, objInfo.IdUser)
    '        DataBase.AddInParameter(DbCommand, "@Fecha", DbType.String, objInfo.Fecha)
    '        DataBase.AddInParameter(DbCommand, "@IP", DbType.String, objInfo.IP)
    '        DataBase.AddInParameter(DbCommand, "@Hash", DbType.String, objInfo.HASH)
    '        DataBase.AddInParameter(DbCommand, "@Status", DbType.String, objInfo.Status)
    '        DataBase.AddInParameter(DbCommand, "@Expira", DbType.String, objInfo.Expira)
    '        Return DataBase.ExecuteScalar(DbCommand)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Function Accountactive(ByVal ObjInfo As Information.InfoGcRecoveryPass) As Boolean
        Try
            DbCommand = DataBase.GetStoredProcCommand("Insert_AccountActive")
            DataBase.AddInParameter(DbCommand, "HASHActive", DbType.String, ObjInfo.HASH)
            Dim Active As Boolean
            Active = DataBase.ExecuteScalar(DbCommand)
            Return Active
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoGcRecoveryPass)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Insert_gc_recovery_pass")
            DataBase.AddInParameter(DbCommand, "@IdUser", DbType.Int32, objInfo.IdUser)
            DataBase.AddInParameter(DbCommand, "@Fecha", DbType.DateTime, objInfo.Fecha)
            DataBase.AddInParameter(DbCommand, "@IP", DbType.String, objInfo.IP)
            DataBase.AddInParameter(DbCommand, "@Hash", DbType.String, objInfo.HASH)
            DataBase.AddInParameter(DbCommand, "@Status", DbType.Int16, objInfo.Status)
            DataBase.AddInParameter(DbCommand, "@Expira", DbType.DateTime, objInfo.Expira)
            ' Return DataBase.ExecuteScalar(DbCommand)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

#Region "Update"
    Public Sub SetNewPassWord(ByVal objInfo As Information.InfoUsers)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Update_UserPassWord")
            DataBase.AddInParameter(DbCommand, "@IdUser", DbType.Int32, objInfo.Id)
            DataBase.AddInParameter(DbCommand, "@user_pass", DbType.String, objInfo.UserPass)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub UpdDisablesRequestEmail(ByVal objInfo As Information.InfoGcRecoveryPass)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Update_DisablesRequestEmail")
            DataBase.AddInParameter(DbCommand, "@id_r", DbType.Int32, objInfo.Id_R)
            DataBase.AddInParameter(DbCommand, "@tmstatus", DbType.Int32, 1)

            ' Return DataBase.ExecuteScalar(DbCommand)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoGcRecoveryPass)
        Try
            'DbCommand = DataBase.GetStoredProcCommand("Delete_User")
            'DataBase.AddInParameter(DbCommand, "IdUser", DbType.Int32, objInfo.Id)
            'DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"

    'Public Function StartSesion(ByVal objInfo As InfoUsers) As List(Of InfoUsers)
    '    Try
    '        Dim ObjInfoUser As New List(Of InfoUsers)
    '        'DbCommand = DataBase.GetStoredProcCommand("sp_Login")
    '        'DataBase.AddInParameter(DbCommand, "UserName", DbType.String, objInfo.UserLogin)
    '        'DataBase.AddInParameter(DbCommand, "Pass", DbType.String, objInfo.UserPass)
    '        'DataSet = DataBase.ExecuteDataSet(DbCommand)

    '        'For Each Row As DataRow In DataSet.Tables(0).Rows
    '        '    Dim Obj As New InfoUsers
    '        '    Obj.Id = Integer.Parse(Row("ID").ToString)
    '        '    Obj.UserNicename = Row("user_nickname").ToString
    '        '    Obj.UserName = Row("user_name").ToString
    '        '    Obj.UserEmail = Row("user_email").ToString
    '        '    Obj.Active = Row("Active").ToString
    '        '    ObjInfoUser.Add(Obj)
    '        'Next
    '        Return ObjInfoUser
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function


    Public Function LoadById(ByVal objInfo As InfoGcRecoveryPass) As List(Of InfoGcRecoveryPass)
        Try
            Dim ObjInfoUser As New List(Of InfoGcRecoveryPass)
            DbCommand = DataBase.GetStoredProcCommand("Select_CurrentRecoveryPassByID_R")
            DataBase.AddInParameter(DbCommand, "tmpID_R", DbType.Int32, objInfo.Id_R)
            DataSet = DataBase.ExecuteDataSet(DbCommand)

            For Each Row As DataRow In DataSet.Tables(0).Rows
                Dim Obj As New InfoGcRecoveryPass
                Obj.Id_R = Integer.Parse(Row("ID_R").ToString)
                Obj.IdUser = Row("ID_USER").ToString
                Obj.Fecha = Row("FECHA")
                Obj.IP = Row("IP")
                Obj.HASH = Row("HASH")
                Obj.Status = Row("STATUS")
                Obj.Expira = Row("EXPIRA")
                ObjInfoUser.Add(Obj)
                'solamente debe de existir un solo registro
                Exit For
            Next
            Return ObjInfoUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetUserByMail(ByVal eMail As String) As List(Of InfoUsers)
        Try
            ''
            Dim ObjInfoUser As New List(Of InfoUsers)
            DbCommand = DataBase.GetStoredProcCommand("Select_UserByMail")
            DataBase.AddInParameter(DbCommand, "eMail", DbType.String, eMail)
            DataSet = DataBase.ExecuteDataSet(DbCommand)

            For Each Row As DataRow In DataSet.Tables(0).Rows
                Dim Obj As New InfoUsers
                Obj.Id = Integer.Parse(Row("idCustomer").ToString)
                Obj.UserName = Row("UserName").ToString
                ObjInfoUser.Add(Obj)
            Next
            Return ObjInfoUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetCurrentRecoveryPass(ByVal ValidUsert As InfoUsers) As List(Of InfoGcRecoveryPass)
        Try
            Dim ObjInfoUser As New List(Of InfoGcRecoveryPass)
            DbCommand = DataBase.GetStoredProcCommand("Select_CurrentRecoveryPassByUser")
            DataBase.AddInParameter(DbCommand, "IdUsert", DbType.String, ValidUsert.Id)
            DataBase.AddInParameter(DbCommand, "FechaActual", DbType.DateTime, Now())
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            For Each Row As DataRow In DataSet.Tables(0).Rows
                Dim Obj As New InfoGcRecoveryPass
                Obj.Id_R = Integer.Parse(Row("ID_R").ToString)
                Obj.IdUser = Row("ID_USER").ToString
                Obj.Fecha = Row("FECHA")
                Obj.IP = Row("IP")
                Obj.HASH = Row("HASH")
                Obj.Status = Row("STATUS")
                Obj.Expira = Row("EXPIRA")
                ObjInfoUser.Add(Obj)
            Next
            Return ObjInfoUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ValidaHash(ByVal ValidUsert As String) As List(Of InfoGcRecoveryPass)
        Try
            Dim ObjInfoUser As New List(Of InfoGcRecoveryPass)
            DbCommand = DataBase.GetStoredProcCommand("Select_CurrentRecoveryPassByHash")
            DataBase.AddInParameter(DbCommand, "strHash", DbType.String, ValidUsert)
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            For Each Row As DataRow In DataSet.Tables(0).Rows
                Dim Obj As New InfoGcRecoveryPass
                Obj.Id_R = Integer.Parse(Row("ID_R").ToString)
                Obj.IdUser = Row("ID_USER").ToString
                Obj.Fecha = Row("FECHA")
                Obj.IP = Row("IP")
                Obj.HASH = Row("HASH")
                Obj.Status = Row("STATUS")
                Obj.Expira = Row("EXPIRA")
                ObjInfoUser.Add(Obj)
            Next
            Return ObjInfoUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function




#End Region
End Class
