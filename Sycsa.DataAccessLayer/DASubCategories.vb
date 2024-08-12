Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient

Public Class DASubCategories
    Public DataBase As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public DataSet As DataSet
    Public common As New CONECTASQL.ConectaSQL

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoSubCategories) As String
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdSubCategories", DbType.Int64, objInfo.IdSubCategories)
            DataBase.AddInParameter(DbCommand, "@IdCategories", DbType.Int64, objInfo.IdCategories)
            DataBase.AddInParameter(DbCommand, "@SubCategoriesName", DbType.String, objInfo.SubCategoriesName)
            DataBase.AddInParameter(DbCommand, "@Description", DbType.String, objInfo.Description)
            DataBase.AddInParameter(DbCommand, "@Active", DbType.Boolean, objInfo.Active)
            Return DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoSubCategories)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Insert_SubCategory")
            DataBase.AddInParameter(DbCommand, "idCategories", DbType.Int64, objInfo.IdCategories)
            DataBase.AddInParameter(DbCommand, "SubCategoriesName", DbType.String, objInfo.SubCategoriesName)
            DataBase.AddInParameter(DbCommand, "Description", DbType.String, objInfo.Description)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Update"

    Public Sub Update(ByVal objInfo As Information.InfoSubCategories)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Update_SubCategory")
            DataBase.AddInParameter(DbCommand, "IdSub", DbType.Int64, objInfo.IdSubCategories)
            DataBase.AddInParameter(DbCommand, "SubCategoriesName", DbType.String, objInfo.SubCategoriesName)
            DataBase.AddInParameter(DbCommand, "Description", DbType.String, objInfo.Description)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Delete"

    Public Sub Delete(ByVal objInfo As Information.InfoSubCategories)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Delete_SubCategory")
            DataBase.AddInParameter(DbCommand, "IdSub", DbType.Int64, objInfo.IdSubCategories)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region


#Region "Load"

    Public Function Load(ByVal objInfo As Information.InfoSubCategories) As List(Of InfoSubCategories)

        Try
            Dim ObjInfoSubCategory As New List(Of InfoSubCategories)
            DbCommand = DataBase.GetStoredProcCommand("Select_SubCategory")
            DataBase.AddInParameter(DbCommand, "IdSub", DbType.Int64, objInfo.IdSubCategories)
            DataSet = DataBase.ExecuteDataSet(DbCommand)

            For Each Row As DataRow In DataSet.Tables(0).Rows
                Dim obj As New InfoSubCategories
                obj.IdSubCategories = Integer.Parse(Row("idSubCategories").ToString)
                obj.SubCategoriesName = Row("SubCategoriesName").ToString
                obj.Description = Row("Description").ToString
                ObjInfoSubCategory.Add(obj)
            Next
            Return ObjInfoSubCategory
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function LoadBy(ByVal objInfo As Information.InfoSubCategories) As DataSet

        Try
            DataSet = common.sqlconsulta("select producto.SUB_fam as idSubCategories, producto.SUB_fam as SubCategoriesName, FAMILIA  from producto where producto.empresa=1 and SUB_fam <> '' and   FAMILIA = '" & objInfo.IdCategories & "' group by producto.FAMILIA, producto.SUB_fam  order by producto.FAMILIA, producto.SUB_fam", "dSubcategorias")
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try

    End Function



#End Region
End Class
