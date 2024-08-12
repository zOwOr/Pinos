Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient
Public Class DACustomersAddresses
    Public DataBase As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public DataSet As DataSet
    Public common As New CONECTASQL.ConectaSQL
#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoCustomersAddresses) As String
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdAddress", DbType.Int64, objInfo.IdAddress)
            DataBase.AddInParameter(DbCommand, "@IdAddress", DbType.Int64, objInfo.IdClient)
            DataBase.AddInParameter(DbCommand, "@IdAddress", DbType.String, objInfo.IdAddress)
            DataBase.AddInParameter(DbCommand, "@RFC", DbType.String, objInfo.RFC)
            DataBase.AddInParameter(DbCommand, "@Phone", DbType.String, objInfo.Phone)
            DataBase.AddInParameter(DbCommand, "@Address", DbType.String, objInfo.Address)
            DataBase.AddInParameter(DbCommand, "@Colony", DbType.String, objInfo.Colony)
            DataBase.AddInParameter(DbCommand, "@CP", DbType.String, objInfo.CP)
            DataBase.AddInParameter(DbCommand, "@City", DbType.String, objInfo.City)
            DataBase.AddInParameter(DbCommand, "@State", DbType.String, objInfo.State)
            DataBase.AddInParameter(DbCommand, "@Country", DbType.String, objInfo.Country)
            Return DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoCustomersAddresses)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdAddress", DbType.Int64, objInfo.IdAddress)
            DataBase.AddInParameter(DbCommand, "@IdAddress", DbType.Int64, objInfo.IdClient)
            DataBase.AddInParameter(DbCommand, "@IdAddress", DbType.String, objInfo.IdAddress)
            DataBase.AddInParameter(DbCommand, "@RFC", DbType.String, objInfo.RFC)
            DataBase.AddInParameter(DbCommand, "@Phone", DbType.String, objInfo.Phone)
            DataBase.AddInParameter(DbCommand, "@Address", DbType.String, objInfo.Address)
            DataBase.AddInParameter(DbCommand, "@Colony", DbType.String, objInfo.Colony)
            DataBase.AddInParameter(DbCommand, "@CP", DbType.String, objInfo.CP)
            DataBase.AddInParameter(DbCommand, "@City", DbType.String, objInfo.City)
            DataBase.AddInParameter(DbCommand, "@State", DbType.String, objInfo.State)
            DataBase.AddInParameter(DbCommand, "@Country", DbType.String, objInfo.Country)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoCustomersAddresses)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdAddress", DbType.Int64, objInfo.IdAddress)
            DataBase.AddInParameter(DbCommand, "@IdAddress", DbType.Int64, objInfo.IdClient)
            DataBase.AddInParameter(DbCommand, "@IdAddress", DbType.String, objInfo.IdAddress)
            DataBase.AddInParameter(DbCommand, "@RFC", DbType.String, objInfo.RFC)
            DataBase.AddInParameter(DbCommand, "@Phone", DbType.String, objInfo.Phone)
            DataBase.AddInParameter(DbCommand, "@Address", DbType.String, objInfo.Address)
            DataBase.AddInParameter(DbCommand, "@Colony", DbType.String, objInfo.Colony)
            DataBase.AddInParameter(DbCommand, "@CP", DbType.String, objInfo.CP)
            DataBase.AddInParameter(DbCommand, "@City", DbType.String, objInfo.City)
            DataBase.AddInParameter(DbCommand, "@State", DbType.String, objInfo.State)
            DataBase.AddInParameter(DbCommand, "@Country", DbType.String, objInfo.Country)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoCustomersAddresses)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Delete_CustomersAddresses")
            DataBase.AddInParameter(DbCommand, "Id", DbType.Int64, objInfo.IdAddress)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"

    Public Function Load(ByVal objInfo As Information.InfoCustomersAddresses) As List(Of InfoCustomers)

        Try
            Dim ObjInfoCustomer As New List(Of InfoCustomers)
            DataSet = common.sqlconsulta("select uw.clave as idCustomer,  uw.usuario as Name, uw.nombre as LastName, cl.TELEFONOS1 as phone, uw.Email,  cl.clave as idAddress, cl.CIA as Company, cl.RFC, (rtrim(cl.DIRECCION) + ' '+ rtrim(cl.NUMERO)) as Adress, cl.COLONIA as Colony, cl.CP, cl.CIUDAD as City, cl.ESTADO as State, cl.PAIS as Country,cl.Vendedor, cl.UsoCfdi,cl.FormaPago,cl.Cond_Venta  from usuarioweb uw inner join cliente cl on uw.cliente = cl.clave where uw.clave = " & objInfo.IdClient, "dDireccion")


            For Each Row As DataRow In DataSet.Tables(0).Rows
                Dim Obj As New InfoCustomers
                Obj.IdAddress = Integer.Parse(Row("idAddress").ToString)
                Obj.CompanyFac = Row("Company").ToString
                Obj.RFCFac = Row("RFC").ToString
                Obj.PhoneFac = Row("Phone").ToString
                Obj.DireccionFac = Row("Adress").ToString
                Obj.ColoniaFac = Row("Colony").ToString
                Obj.CPFac = Row("CP").ToString
                Obj.CityFac = Row("City").ToString
                Obj.StateFac = Row("State").ToString
                Obj.Country = Row("Country").ToString
                Obj.Vendedor = Row("Vendedor").ToString
                Obj.UsoCfdi = Row("UsoCfdi").ToString
                Obj.FormaPago = Row("FormaPago").ToString
                Obj.CondVenta = Row("Cond_Venta").ToString
                ObjInfoCustomer.Add(Obj)
            Next


            Return ObjInfoCustomer

        Catch ex As Exception
            Throw ex
        End Try

    End Function



    Public Function LoadAll(ByVal objInfo As Information.InfoCustomersAddresses) As DataSet

        Try
            DbCommand = DataBase.GetStoredProcCommand("Select_CustomersAddress")
            ' DataBase.AddInParameter(DbCommand, "@IdAddress", DbType.Int64, objInfo.IdAddress)
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try

    End Function


#End Region

End Class
