Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient
Public Class DAOptions
    Public DataBase As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public DataSet As DataSet

#Region "Save"

    Public Function SaveReturn(ByVal objInfo As Information.InfoOptions) As String
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdOption", DbType.Int64, objInfo.IdOption)
            DataBase.AddInParameter(DbCommand, "@OptionName", DbType.String, objInfo.OptionName)
            DataBase.AddInParameter(DbCommand, "@OptionValue", DbType.String, objInfo.OptionValue)
            DataBase.AddInParameter(DbCommand, "@AutoLoad", DbType.String, objInfo.AutoLoad)
            Return DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function SaveMethodSend(ByVal objInfo As Information.InfoOptions) As String
        Try
            DbCommand = DataBase.GetStoredProcCommand("insert_MethodSend")
            DataBase.AddInParameter(DbCommand, "OptionSend", DbType.String, objInfo.OptionSend)
            DataBase.AddInParameter(DbCommand, "PriceSend", DbType.Decimal, objInfo.PriceSend)
            DataBase.AddInParameter(DbCommand, "CommSend", DbType.String, objInfo.CommSend)
            Return DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function updateMethodSend(ByVal objInfo As Information.InfoOptions) As String
        Try
            DbCommand = DataBase.GetStoredProcCommand("update_MethodSend")
            DataBase.AddInParameter(DbCommand, "IdOptionSend", DbType.Int32, objInfo.idSend)
            DataBase.AddInParameter(DbCommand, "OptionSend", DbType.String, objInfo.OptionSend)
            DataBase.AddInParameter(DbCommand, "PriceSend", DbType.Decimal, objInfo.PriceSend)
            DataBase.AddInParameter(DbCommand, "CommSend", DbType.String, objInfo.CommSend)
            Return DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub Save(ByVal objInfo As Information.InfoOptions)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdOption", DbType.Int64, objInfo.IdOption)
            DataBase.AddInParameter(DbCommand, "@OptionName", DbType.String, objInfo.OptionName)
            DataBase.AddInParameter(DbCommand, "@OptionValue", DbType.String, objInfo.OptionValue)
            DataBase.AddInParameter(DbCommand, "@AutoLoad", DbType.String, objInfo.AutoLoad)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal dtObj As DataTable)
        Try

            For Each Row As DataRow In dtObj(0).Table.Rows
                Dim Obj As New InfoOptions
                Obj.IdOption = Integer.Parse(Row("IdOption").ToString)
                Obj.OptionValue = Row("OptionValue").ToString
                DbCommand = DataBase.GetStoredProcCommand("Update_Options")
                DataBase.AddInParameter(DbCommand, "Id", DbType.Int64, Obj.IdOption)
                DataBase.AddInParameter(DbCommand, "OpValue", DbType.String, Obj.OptionValue)
                DataBase.ExecuteNonQuery(DbCommand)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoOptions)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdOption", DbType.Int64, objInfo.IdOption)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function Load() As List(Of InfoOptions)
        Try
            Dim ObjInfoOptions As New List(Of InfoOptions)
            DbCommand = DataBase.GetStoredProcCommand("Select_Options")
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            For Each Row As DataRow In DataSet.Tables(0).Rows
                Dim Obj As New InfoOptions
                Obj.IdOption = Integer.Parse(Row("idOptions").ToString)
                Obj.OptionValue = Row("option_value").ToString
                ObjInfoOptions.Add(Obj)
            Next
            Return ObjInfoOptions
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
