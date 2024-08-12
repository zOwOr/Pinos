Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient
Public Class DAMarks
    Public DataBase As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public common As New CONECTASQL.ConectaSQL
    Public DataSet As DataSet

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoMarks) As String
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdMark", DbType.UInt64, objInfo.IdMark)
            DataBase.AddInParameter(DbCommand, "@MarkName", DbType.String, objInfo.MarkName)
            DataBase.AddInParameter(DbCommand, "@Description", DbType.String, objInfo.Description)
            DataBase.AddInParameter(DbCommand, "@MarkIamge", DbType.String, objInfo.MarkIamge)
            DataBase.AddInParameter(DbCommand, "@MarkThumb", DbType.String, objInfo.MarkThumb)
            DataBase.AddInParameter(DbCommand, "@Active", DbType.Boolean, objInfo.Active)
            Return DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoMarks)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Insert_Mark")
            DataBase.AddInParameter(DbCommand, "MarkName", DbType.String, objInfo.MarkName)
            DataBase.AddInParameter(DbCommand, "Description", DbType.String, objInfo.Description)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoMarks)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Update_Mark")
            DataBase.AddInParameter(DbCommand, "Id", DbType.UInt64, objInfo.IdMark)
            DataBase.AddInParameter(DbCommand, "MarkName", DbType.String, objInfo.MarkName)
            DataBase.AddInParameter(DbCommand, "Description", DbType.String, objInfo.Description)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoMarks)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Delete_Mark")
            DataBase.AddInParameter(DbCommand, "Id", DbType.UInt64, objInfo.IdMark)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function LoadById(ByVal objInfo As Information.InfoMarks) As IList(Of InfoMarks)
        Try
            Dim ObjInfoMark As New List(Of InfoMarks)
            DbCommand = DataBase.GetStoredProcCommand("Select_Mark")
            DataBase.AddInParameter(DbCommand, "Id", DbType.UInt64, objInfo.IdMark)
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            For Each Row As DataRow In DataSet.Tables(0).Rows
                Dim Obj As New InfoMarks
                Obj.MarkName = Row("MarkName").ToString
                Obj.Description = Row("Description").ToString
                ObjInfoMark.Add(Obj)
            Next
            Return ObjInfoMark
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadMark() As DataSet
        Try
            DataSet = common.sqlconsulta("select producto.MARCA as idMark,producto.MARCA as MarkName from producto where producto.empresa=1 and PRODUCTO.marca <>'' and producto.en_linea=1 group by MARCA order by producto.MARCA", "dMarcas")
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

End Class
