Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient

Public Class DANewsLetters
    Public DataBase As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public DataSet As DataSet

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoNewsLetters) As String
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdNewsLetters", DbType.Int64, objInfo.IdNewsLetters)
            DataBase.AddInParameter(DbCommand, "@NewsLettersName", DbType.String, objInfo.NewsLettersName)
            DataBase.AddInParameter(DbCommand, "@Subject", DbType.String, objInfo.Subject)
            DataBase.AddInParameter(DbCommand, "@ContentHTML", DbType.String, objInfo.ContentHTML)
            DataBase.AddInParameter(DbCommand, "@ContentText", DbType.String, objInfo.ContentText)
            DataBase.AddInParameter(DbCommand, "@DateSend", DbType.DateTime, objInfo.DateSend)
            DataBase.AddInParameter(DbCommand, "@Active", DbType.Boolean, objInfo.Active)
            DataBase.AddInParameter(DbCommand, "@NewLettersDate", DbType.DateTime, objInfo.NewLettersDate)
            Return DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoNewsLetters, ByVal dtObj As DataTable)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Insert_NewsLetters")
            DataBase.AddInParameter(DbCommand, "NewslettersName", DbType.String, objInfo.NewsLettersName)
            DataBase.AddInParameter(DbCommand, "Subject", DbType.String, objInfo.Subject)
            DataBase.AddInParameter(DbCommand, "Content_html", DbType.String, objInfo.ContentHTML)
            Dim IdNew As Integer = DataBase.ExecuteScalar(DbCommand)
            If dtObj.Rows.Count > 0 Then
                For Each Row As DataRow In dtObj(0).Table.Rows
                    Dim Obj As New InfoNewsLetters
                    Obj.IdNewsLetters = IdNew
                    Obj.IdCategory = Integer.Parse(Row("IdCategory").ToString)
                    DbCommand = DataBase.GetStoredProcCommand("Insert_NewLetterDetail")
                    DataBase.AddInParameter(DbCommand, "IdNew", DbType.Int64, Obj.IdNewsLetters)
                    DataBase.AddInParameter(DbCommand, "IdCategory", DbType.Int64, Obj.IdCategory)
                    DataBase.ExecuteNonQuery(DbCommand)
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoNewsLetters)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Update_NewsLetters")
            DataBase.AddInParameter(DbCommand, "Id", DbType.Int64, objInfo.IdNewsLetters)
            DataBase.AddInParameter(DbCommand, "NewS", DbType.String, objInfo.NewsLettersName)
            DataBase.AddInParameter(DbCommand, "Sub", DbType.String, objInfo.Subject)
            DataBase.AddInParameter(DbCommand, "Content", DbType.String, objInfo.ContentHTML)
            DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoNewsLetters)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Delete_NewsLetters")
            DataBase.AddInParameter(DbCommand, "Id", DbType.Int64, objInfo.IdNewsLetters)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function LoadById(ByVal objInfo As Information.InfoNewsLetters) As List(Of InfoNewsLetters)
        Try
            Dim ObjObjInfoNewsLetters As New List(Of InfoNewsLetters)
            DbCommand = DataBase.GetStoredProcCommand("Select_NewsLetters")
            DataBase.AddInParameter(DbCommand, "Id", DbType.Int64, objInfo.IdNewsLetters)
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            For Each Row As DataRow In DataSet.Tables(0).Rows
                Dim Obj As New InfoNewsLetters
                Obj.NewsLettersName = Row("NewslettersName").ToString
                Obj.Subject = Row("Subject").ToString
                Obj.ContentHTML = Row("Content_html").ToString
                ObjObjInfoNewsLetters.Add(Obj)
            Next
            Return ObjObjInfoNewsLetters
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadCategory(ByVal objInfo As Information.InfoNewsLetters) As DataTable
        Try
            Dim ObjObjCategory As New List(Of InfoNewsLetters)
            DbCommand = DataBase.GetStoredProcCommand("Select_AllCategory")
            DataBase.AddInParameter(DbCommand, "Id", DbType.Int64, objInfo.IdNewsLetters)
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            'For Each Row As DataRow In DataSet.Tables(0).Rows
            '    Dim Obj As New InfoNewsLetters
            '    Obj.IdCategory = Row("idCategorie").ToString
            '    ObjObjCategory.Add(Obj)
            'Next
            Return DataSet.Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
