Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient
Public Class DAOrders
    Public DataBase As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public DataSet As DataSet
#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoOrders) As String
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdOrders", DbType.Int64, objInfo.IdOrders)
            DataBase.AddInParameter(DbCommand, "@NOrder", DbType.Int64, objInfo.NOrder)
            DataBase.AddInParameter(DbCommand, "@IdCustomer", DbType.Int64, objInfo.IdCustomer)
            DataBase.AddInParameter(DbCommand, "@IdAddressCustomers", DbType.Int64, objInfo.IdAddressCustomers)
            DataBase.AddInParameter(DbCommand, "@IdPaymentMethod", DbType.Int64, objInfo.IdPaymentMethod)
            DataBase.AddInParameter(DbCommand, "@OrderTotalPrices", DbType.Int64, objInfo.OrderTotalPrices)
            DataBase.AddInParameter(DbCommand, "@OrderIVA", DbType.Int64, objInfo.OrderIVA)
            DataBase.AddInParameter(DbCommand, "@Bill", DbType.Int64, objInfo.Bill)
            DataBase.AddInParameter(DbCommand, "@OrderDate", DbType.Int64, objInfo.OrderDate)
            DataBase.AddInParameter(DbCommand, "@OrderFinished", DbType.Int64, objInfo.OrderFinished)
            DataBase.AddInParameter(DbCommand, "@OrderCancel", DbType.Int64, objInfo.OrderCancel)
            DataBase.AddInParameter(DbCommand, "@PaymentStatus", DbType.Int64, objInfo.PaymentStatus)
            Return DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Save(ByVal objInfo As Information.InfoOrders) As DataSet

        Try

            DbCommand = DataBase.GetStoredProcCommand("Insert_Orders")
            'DataBase.AddInParameter(DbCommand, "@NOrder", DbType.Int64, objInfo.NOrder)
            DataBase.AddInParameter(DbCommand, "Customers", DbType.Int64, objInfo.IdCustomer)
            DataBase.AddInParameter(DbCommand, "AddressCustomers", DbType.Int64, objInfo.IdAddressCustomers)
            'DataBase.AddInParameter(DbCommand, "@IdPaymentMethod", DbType.Int64, objInfo.IdPaymentMethod)
            DataBase.AddInParameter(DbCommand, "TotalPrices", DbType.Decimal, objInfo.OrderTotalPrices)
            DataBase.AddInParameter(DbCommand, "IVA", DbType.Decimal, objInfo.OrderIVA)
            'DataBase.AddInParameter(DbCommand, "@Bill", DbType.Int64, objInfo.Bill)
            'DataBase.AddInParameter(DbCommand, "@OrderDate", DbType.Int64, objInfo.OrderDate)
            'DataBase.AddInParameter(DbCommand, "@OrderFinished", DbType.Int64, objInfo.OrderFinished)
            'DataBase.AddInParameter(DbCommand, "@OrderCancel", DbType.Int64, objInfo.OrderCancel)
            DataBase.AddInParameter(DbCommand, "Status", DbType.Int32, objInfo.PaymentStatus)
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            Return DataSet

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function SaveProducto(ByVal objInfo As Information.InfoOrders) As DataSet

        Try

            DbCommand = DataBase.GetStoredProcCommand("Insert_OrdersDetail")
            DataBase.AddInParameter(DbCommand, "@OrderID", DbType.Int64, objInfo.IdOrders)
            DataBase.AddInParameter(DbCommand, "@Product", DbType.Int64, objInfo.IdProduct)
            DataBase.AddInParameter(DbCommand, "@Price", DbType.Decimal, objInfo.Price)
            DataBase.AddInParameter(DbCommand, "@quantiyProduct", DbType.Int32, objInfo.Quantiy)
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            Return DataSet

        Catch ex As Exception
            Throw ex
        End Try


    End Function
#End Region

#Region "Update"
    Public Sub Update(ByVal objInfo As Information.InfoOrders)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdOrders", DbType.Int64, objInfo.IdOrders)
            DataBase.AddInParameter(DbCommand, "@NOrder", DbType.Int64, objInfo.NOrder)
            DataBase.AddInParameter(DbCommand, "@IdCustomer", DbType.Int64, objInfo.IdCustomer)
            DataBase.AddInParameter(DbCommand, "@IdAddressCustomers", DbType.Int64, objInfo.IdAddressCustomers)
            DataBase.AddInParameter(DbCommand, "@IdPaymentMethod", DbType.Int64, objInfo.IdPaymentMethod)
            DataBase.AddInParameter(DbCommand, "@OrderTotalPrices", DbType.Int64, objInfo.OrderTotalPrices)
            DataBase.AddInParameter(DbCommand, "@OrderIVA", DbType.Int64, objInfo.OrderIVA)
            DataBase.AddInParameter(DbCommand, "@Bill", DbType.Int64, objInfo.Bill)
            DataBase.AddInParameter(DbCommand, "@OrderDate", DbType.Int64, objInfo.OrderDate)
            DataBase.AddInParameter(DbCommand, "@OrderFinished", DbType.Int64, objInfo.OrderFinished)
            DataBase.AddInParameter(DbCommand, "@OrderCancel", DbType.Int64, objInfo.OrderCancel)
            DataBase.AddInParameter(DbCommand, "@PaymentStatus", DbType.Int64, objInfo.PaymentStatus)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoOrders)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdOrders", DbType.Int64, objInfo.IdOrders)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function LoadById(ByVal objInfo As Information.InfoOrders) As List(Of InfoOrders)
        Try
            Dim ObjInfoOrder As New List(Of InfoOrders)
            DbCommand = DataBase.GetStoredProcCommand("Select_Order")
            DataBase.AddInParameter(DbCommand, "Id", DbType.Int64, objInfo.IdOrders)
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            For Each Row As DataRow In DataSet.Tables(0).Rows
                Dim Obj As New InfoOrders
                Obj.IdOrders = Integer.Parse(Row("idOrders").ToString)
                Obj.NOrder = Integer.Parse(Row("nOrder").ToString)
                Obj.Customer = Row("Customber").ToString
                Obj.Phone = Row("phone").ToString
                Obj.Bill = Row("Bill").ToString
                Obj.OrderDate = DateTime.Parse(Row("OrderDate").ToString)
                Obj.OrderFinished = Row("OrderFinished").ToString
                Obj.OrderTotalPrices = Double.Parse(Row("OrderTotalPrice").ToString)
                Obj.OrderIVA = Double.Parse(Row("OrderIVA").ToString)
                Obj.Company = Row("Company").ToString
                Obj.RFC = Row("RFC").ToString
                Obj.PhoneC = Row("Phone").ToString
                Obj.Address = Row("Adress").ToString
                Obj.Colony = Row("Colony").ToString
                Obj.CP = Row("CP").ToString
                Obj.City = Row("City").ToString
                Obj.State = Row("State").ToString
                ObjInfoOrder.Add(Obj)
            Next
            Return ObjInfoOrder
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function LoadMethondSend(ByVal objInfo As Information.InfoOrders) As DataSet
        Try

            DbCommand = DataBase.GetStoredProcCommand("Select_Method_Send_byId")
            DataBase.AddInParameter(DbCommand, "IdSend", DbType.Int64, objInfo.IdMethodSend)
            DataSet = DataBase.ExecuteDataSet(DbCommand)
            Return DataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

End Class
