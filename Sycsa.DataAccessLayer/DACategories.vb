
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Public Class DACategories

	Public DataBase As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
	Public DbCommand As Common.DbCommand
	Public DataSet As DataSet
    Public common As New CONECTASQL.ConectaSQL

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoCategories) As String
		Try
			DbCommand = DataBase.GetStoredProcCommand("")
			DataBase.AddInParameter(DbCommand, "@IdCategories", DbType.Int64, objInfo.IdCategories)
			DataBase.AddInParameter(DbCommand, "@CategoryName", DbType.String, objInfo.CategoryName)
			DataBase.AddInParameter(DbCommand, "@Description", DbType.Int32, objInfo.Description)
			DataBase.AddInParameter(DbCommand, "@Active", DbType.Int32, objInfo.Active)
			Return DataBase.ExecuteScalar(DbCommand)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Sub Save(ByVal objInfo As Information.InfoCategories)
		Try
			DbCommand = DataBase.GetStoredProcCommand("Insert_Category")
			DataBase.AddInParameter(DbCommand, "CategoryName", DbType.String, objInfo.CategoryName)
			DataBase.AddInParameter(DbCommand, "Description", DbType.String, objInfo.Description)
			DataBase.ExecuteNonQuery(DbCommand)
		Catch ex As Exception
			Throw ex
		End Try
	End Sub
#End Region

#Region "Update"
	Public Sub Update(ByVal objInfo As Information.InfoCategories)
		Try
			DbCommand = DataBase.GetStoredProcCommand("Update_Category")
			DataBase.AddInParameter(DbCommand, "IdCatagory", DbType.Int64, objInfo.IdCategories)
			DataBase.AddInParameter(DbCommand, "CategoryName", DbType.String, objInfo.CategoryName)
			DataBase.AddInParameter(DbCommand, "Description", DbType.String, objInfo.Description)
			DataBase.ExecuteNonQuery(DbCommand)
		Catch ex As Exception
			Throw ex
		End Try
	End Sub
#End Region

#Region "Delete"
	Public Sub Delete(ByVal objInfo As Information.InfoCategories)
		Try
			DbCommand = DataBase.GetStoredProcCommand("Delete_Category")
			DataBase.AddInParameter(DbCommand, "IdCatagory", DbType.Int64, objInfo.IdCategories)
			DataBase.ExecuteNonQuery(DbCommand)
		Catch ex As Exception
			Throw ex
		End Try
	End Sub
#End Region

#Region "Load"
	Public Function LoadById(ByVal objInfo As Information.InfoCategories) As List(Of InfoCategories)
		Try
			Dim ObjInfoCategory As New List(Of InfoCategories)
			DbCommand = DataBase.GetStoredProcCommand("Select_Category")
			DataBase.AddInParameter(DbCommand, "IdCategory", DbType.Int64, objInfo.IdCategories)
			DataSet = DataBase.ExecuteDataSet(DbCommand)
			For Each Row As DataRow In DataSet.Tables(0).Rows
				Dim obj As New InfoCategories
				obj.IdCategories = Row("idCategories")
				obj.CategoryName = Row("CategoryName").ToString
				obj.Description = Row("Description").ToString
				ObjInfoCategory.Add(obj)
			Next
			Return ObjInfoCategory
		Catch ex As Exception
			Throw ex
		End Try
	End Function


	Public Function Load(ByVal objInfo As Information.InfoCategories) As DataSet
		Try

			DbCommand = DataBase.GetStoredProcCommand("Select_Category_all")
			DataSet = DataBase.ExecuteDataSet(DbCommand)
			Return DataSet

		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LoadLayout(ByVal objInfo As Information.InfoCategories) As DataSet
		Try
			DataSet = common.sqlconsulta("select FAMILIA as idCategories , FAMILIA as CategoryName  from producto where producto.empresa=1 and PRODUCTO.en_linea=1  and FAMILIA <> ''  group by producto.FAMILIA order by familia", "dCategorias")

			Return DataSet

		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region
End Class
