Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient
Public Class DAProducts
    Public DataBase As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public DataSet As New DataSet
    Public common As New CONECTASQL.ConectaSQL
#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoProducts) As String
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@ProductId", DbType.Int64, objInfo.ProductId)
            DataBase.AddInParameter(DbCommand, "@SubCategoryId", DbType.Int64, objInfo.SubCategory)
            DataBase.AddInParameter(DbCommand, "@MarkId", DbType.Int64, objInfo.MarkId)
            DataBase.AddInParameter(DbCommand, "@ProductKey", DbType.String, objInfo.ProductKey)
            DataBase.AddInParameter(DbCommand, "@ProductName", DbType.String, objInfo.ProductName)
            DataBase.AddInParameter(DbCommand, "@ShortDescription", DbType.String, objInfo.ShortDescription)
            DataBase.AddInParameter(DbCommand, "@LongDescription", DbType.String, objInfo.LongDescription)
            DataBase.AddInParameter(DbCommand, "@ProductFeatures", DbType.String, objInfo.ProductFeatures)
            DataBase.AddInParameter(DbCommand, "@UnitPrice", DbType.Decimal, objInfo.UnitPrice)
            DataBase.AddInParameter(DbCommand, "@UnitInStock", DbType.UInt64, objInfo.UnitInStock)
            Return DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoProducts)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Insert_Product")
            DataBase.AddInParameter(DbCommand, "SubCategoryID", DbType.Int64, objInfo.SubCategory)
            DataBase.AddInParameter(DbCommand, "MarkID", DbType.Int64, objInfo.MarkId)
            DataBase.AddInParameter(DbCommand, "ProductKey", DbType.String, objInfo.ProductKey)
            DataBase.AddInParameter(DbCommand, "ProductName", DbType.String, objInfo.ProductName)
            DataBase.AddInParameter(DbCommand, "shortDescription", DbType.String, objInfo.ShortDescription)
            DataBase.AddInParameter(DbCommand, "LongDescription", DbType.String, objInfo.LongDescription)
            DataBase.AddInParameter(DbCommand, "UnitPrice", DbType.Decimal, objInfo.UnitPrice)
            DataBase.AddInParameter(DbCommand, "UnitInStock", DbType.UInt64, objInfo.UnitInStock)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoProducts)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Update_Product")
            DataBase.AddInParameter(DbCommand, "ProductIDEdit", DbType.Int64, objInfo.ProductId)
            DataBase.AddInParameter(DbCommand, "SubCategoryID", DbType.Int64, objInfo.SubCategory)
            DataBase.AddInParameter(DbCommand, "MarkID", DbType.Int64, objInfo.MarkId)
            DataBase.AddInParameter(DbCommand, "ProductKey", DbType.String, objInfo.ProductKey)
            DataBase.AddInParameter(DbCommand, "ProductName", DbType.String, objInfo.ProductName)
            DataBase.AddInParameter(DbCommand, "shortDescription", DbType.String, objInfo.ShortDescription)
            DataBase.AddInParameter(DbCommand, "LongDescription", DbType.String, objInfo.ShortDescription)
            DataBase.AddInParameter(DbCommand, "UnitPrice", DbType.Decimal, objInfo.UnitPrice)
            DataBase.AddInParameter(DbCommand, "UnitInStock", DbType.UInt64, objInfo.UnitInStock)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoProducts)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Delete_Product")
            DataBase.AddInParameter(DbCommand, "Id", DbType.Int64, objInfo.ProductId)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function LoadById(ByVal objInfo As Information.InfoProducts) As List(Of InfoProducts)
        Try
            Dim ObjInfoProducts As New List(Of InfoProducts)
            Dim precio As String
            If objInfo.UnitInStock > 0 Then
                precio = " producto_unidad.precio_V" & objInfo.UnitInStock & " as UnitPrice,"
            Else
                precio = "0 as UnitPrice,"
            End If
            DataSet = common.sqlconsulta("select producto.sub_fam as SubCategoryID, producto.marca as MarkID, producto.codigo as ProductKey, producto.codigo_pro as ProductName, producto.imagen as Imagen, producto.descripcion as shortDescription,  " & precio & " producto.CLAVE as CLAVEPRODUCTO, producto_unidad.cantidad as cantidad_unidad,PRODUCTO.tasa_iva ,PRODUCTO.tasa_ieps,producto_unidad.Unidad From producto inner join producto_unidad on producto.clave=producto_unidad.clave  where producto.clave =" & objInfo.ProductId & "and producto_unidad.Unidad = '" & objInfo.Unidad.ToUpper & "'", "dProducto")
            For Each Row As DataRow In DataSet.Tables(0).Rows
                Dim Obj As New InfoProducts
                Obj.SubCategory = Row("SubCategoryID").ToString
                Obj.MarkId = Row("MarkID").ToString
                Obj.ProductKey = Row("ProductKey").ToString
                Obj.ProductName = Row("ProductName").ToString
                Obj.ShortDescription = Row("shortDescription").ToString
                Obj.Imagen = Row("Imagen").ToString
                Obj.CLAVEPRODUCTO = Row("CLAVEPRODUCTO")
                Obj.cantidadunidad = Row("cantidad_unidad")
                Obj.tasa_iva = Row("tasa_iva")
                Obj.tasaieps = Row("tasa_ieps")
                Obj.Unidad = Row("Unidad").ToString
                'Obj.LongDescription = Row("LongDescription").ToString
                Obj.UnitPrice = Row("UnitPrice").ToString
                'Obj.UnitInStock = Row("UnitInStock").ToString
                ObjInfoProducts.Add(Obj)
            Next
            Return ObjInfoProducts
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function LoadSearch(ByVal objInfo As Information.InfoProducts) As DataSet
        Try

            DbCommand = DataBase.GetStoredProcCommand("search_products")
            DataBase.AddInParameter(DbCommand, "IdCat", DbType.Int64, objInfo.idCategory)
            DataBase.AddInParameter(DbCommand, "ProductName", DbType.String, objInfo.ProductName)
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            Return DataSet

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Loadlistproduct(ByVal objInfo As Information.InfoProducts) As DataSet
        Try
            Dim precio As String
            If objInfo.UnitInStock > 0 Then
                precio = " producto_unidad.precio_V" & objInfo.UnitInStock & " as UnitPrice,"
            Else
                precio = "0 as UnitPrice,"
            End If

            DataSet = common.sqlconsulta("Select top 100 00000.00 as cantidad,producto.clave as ProductID, producto_unidad.unidad as Unidad ,producto.codigo_pro as ProductName, producto.descripcion as shortDescription," & precio & "producto_unidad.precio_V1_II, producto.familia as Categoria, producto.sub_fam as Subcategoria, producto.moneda, producto.codigo_bar, producto.codigo_pv, producto.marca as Marca, producto.imagen as ProductImagen From producto inner join producto_unidad on producto.clave=producto_unidad.clave where PRODUCTO.EMPRESA=1 AND PRODUCTO.VENTA=1    AND PRODUCTO.en_linea=1 and (PRODUCTO.familia='" & objInfo.idCategory & "' or producto.descripcion like '%" & objInfo.ProductName & "%') order by DESCRIPCION", "dproducto")
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoaProductForSales(ByVal objInfo As Information.InfoProducts) As List(Of InfoProducts)

        Try
            Dim sql As String
            Dim ObjInfoProducts As New List(Of InfoProducts)

            sql = "select " &
                                "producto.clave as ProductID," &
                                "producto.sub_fam as SubCategoryID, " &
                                "producto.marca as MarkID," &
                                "producto.CODIGO_PV as ProductKey, " &
                                "producto.codigo_pro as ProductName, " &
                                "producto.descripcion as shortDescription, " &
                                "producto.descrip_am as LongDescription, " &
                                "producto_unidad.precio_V1 as UnitPrice," &
                                "producto.marca as MarkName," &
                                "producto_unidad.Unidad," &
                                "producto.Imagen" &
                                " from producto inner join producto_unidad on producto.clave=producto_unidad.clave" &
                                " where PRODUCTO.EMPRESA=1 AND PRODUCTO.VENTA=1 and PRODUCTO.en_linea=1 and PRODUCTO.CLAVE =" & objInfo.ProductId & "and producto_unidad.Unidad = '" & objInfo.Unidad.ToUpper & "'"
            DataSet = common.sqlconsulta(sql, "dProducto")
            For Each Row As DataRow In DataSet.Tables(0).Rows
                Dim Obj As New InfoProducts
                Obj.SubCategory = Row("SubCategoryID").ToString
                Obj.MarkId = Row("MarkID").ToString
                Obj.ProductKey = Row("ProductKey").ToString
                Obj.ProductName = Row("ProductName").ToString
                Obj.ShortDescription = Row("shortDescription").ToString
                Obj.LongDescription = Row("LongDescription").ToString
                Obj.UnitInStock = 0 'Row("UnitInStock").ToString
                Obj.MarckName = Row("MarkName").ToString
                Obj.Imagen = Row("Imagen").ToString
                ObjInfoProducts.Add(Obj)
            Next

            Return ObjInfoProducts

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region
End Class
