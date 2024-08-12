Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports System.Data.SqlClient


Public Class DACustomers
    Public DataBase As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")
    Public DbCommand As Common.DbCommand
    Public Dataset As DataSet
    Public common As New CONECTASQL.ConectaSQL

#Region "Save"
    Public Function SaveReturn(ByVal objInfo As Information.InfoCustomers) As String
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdCustomer", DbType.Int64, objInfo.IdCustomer)
            DataBase.AddInParameter(DbCommand, "@Email", DbType.String, objInfo.Email)
            DataBase.AddInParameter(DbCommand, "@Pass", DbType.String, objInfo.Pass)
            DataBase.AddInParameter(DbCommand, "@Name", DbType.String, objInfo.Name)
            DataBase.AddInParameter(DbCommand, "@LastName", DbType.String, objInfo.LastName)
            DataBase.AddInParameter(DbCommand, "@BirthDate", DbType.Date, objInfo.BirthDate)
            DataBase.AddInParameter(DbCommand, "@Phone", DbType.String, objInfo.Phone)
            DataBase.AddInParameter(DbCommand, "@EmailVerifield", DbType.Boolean, objInfo.EmailVerifield)
            DataBase.AddInParameter(DbCommand, "@Active", DbType.Boolean, objInfo.Active)
            DataBase.AddInParameter(DbCommand, "@CustomersDate", DbType.DateTime, objInfo.CustomersDate)
            Return DataBase.ExecuteScalar(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Save(ByVal objInfo As Information.InfoCustomers)
        Try
            common.sqlcomando("insert into usuarioweb (fecha_alta, cliente,  usuario, password, nombre, cia, telefonos, email, estatus, rol) " & _
                                               "values( " & DateTime.Now.ToString("dd/MM/yyyy") & ",0,'" & objInfo.Name & "','" & objInfo.Pass & "','" & objInfo.LastName & "','" & objInfo.CompanyFac & "','" & objInfo.Phone & "','" & objInfo.Email & "',1, 'USUARIO')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SaveAddress(ByVal objInfo As Information.InfoCustomers)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Insert_CustomersAddress")
            DataBase.AddInParameter(DbCommand, "Id", DbType.String, objInfo.IdCustomer)
            DataBase.AddInParameter(DbCommand, "CompanyFac", DbType.String, objInfo.CompanyFac)
            DataBase.AddInParameter(DbCommand, "RFCFac", DbType.String, objInfo.RFCFac)
            DataBase.AddInParameter(DbCommand, "PhoneFac", DbType.String, objInfo.PhoneFac)
            DataBase.AddInParameter(DbCommand, "AdressFac", DbType.String, objInfo.DireccionFac)
            DataBase.AddInParameter(DbCommand, "ColonyFac", DbType.String, objInfo.ColoniaFac)
            DataBase.AddInParameter(DbCommand, "CPFac", DbType.String, objInfo.CPFac)
            DataBase.AddInParameter(DbCommand, "CityFac", DbType.String, objInfo.CityFac)
            DataBase.AddInParameter(DbCommand, "StateFac", DbType.String, objInfo.StateFac)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SaveContact(ByVal ObjInfo As Information.InfoCustomers)
        Try
            Dim sql As String = "insert into CONTACTO (subject,name,Email,Message,IP,ContactDate) " & _
                              "values('" & ObjInfo.Subject & "','" & ObjInfo.ContactName & "','" & ObjInfo.ContactEmail & "','" & ObjInfo.ContactMsg & "', '192.171.1.0', " & DateTime.Now.ToString("yyyy-MM-dd") & " )"
            common.sqlcomando(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Update"

    Public Sub UpdateAddressCustomer(ByVal objInfo As Information.InfoCustomers)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Update_AddressCustomers")
            DataBase.AddInParameter(DbCommand, "Id", DbType.Int64, objInfo.IdAddress)
            DataBase.AddInParameter(DbCommand, "CompanyFac", DbType.String, objInfo.CompanyFac)
            DataBase.AddInParameter(DbCommand, "RFCFac", DbType.String, objInfo.RFCFac)
            DataBase.AddInParameter(DbCommand, "PhoneFac", DbType.String, objInfo.PhoneFac)
            DataBase.AddInParameter(DbCommand, "AdressFac", DbType.String, objInfo.DireccionFac)
            DataBase.AddInParameter(DbCommand, "ColonyFac", DbType.String, objInfo.ColoniaFac)
            DataBase.AddInParameter(DbCommand, "CPFac", DbType.String, objInfo.CPFac)
            DataBase.AddInParameter(DbCommand, "CityFac", DbType.String, objInfo.CityFac)
            DataBase.AddInParameter(DbCommand, "StateFac", DbType.String, objInfo.StateFac)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Update(ByVal objInfo As Information.InfoCustomers)
        Try
            DbCommand = DataBase.GetStoredProcCommand("Update_Customers")
            DataBase.AddInParameter(DbCommand, "Id", DbType.Int64, objInfo.IdCustomer)
            DataBase.AddInParameter(DbCommand, "Name", DbType.String, objInfo.Name)
            DataBase.AddInParameter(DbCommand, "LastName", DbType.String, objInfo.LastName)
            DataBase.AddInParameter(DbCommand, "phone", DbType.String, objInfo.Phone)
            DataBase.AddInParameter(DbCommand, "birth_date", DbType.Date, objInfo.BirthDate)
            DataBase.AddInParameter(DbCommand, "Email", DbType.String, objInfo.Email)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateCount(ByVal objInfo As Information.InfoCustomers)
        Try
            common.sqlcomando("update usuarioweb set usuario='" & objInfo.Name & "', nombre='" & objInfo.LastName & "', telefonos='" & objInfo.Phone & "', email='" & objInfo.Email & "' where clave=" & objInfo.IdCustomer)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdatePassword(ByVal objInfo As Information.InfoCustomers)
        Try
            common.sqlcomando("update usuarioweb set password='" & objInfo.Pass & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete(ByVal objInfo As Information.InfoCustomers)
        Try
            DbCommand = DataBase.GetStoredProcCommand("")
            DataBase.AddInParameter(DbCommand, "@IdCustomer", DbType.Int64, objInfo.IdCustomer)
            DataBase.ExecuteNonQuery(DbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load"
    Public Function LoadById(ByVal objInfo As Information.InfoCustomers) As List(Of InfoCustomers)
        Try
            Dim objInfoCustomer As New List(Of InfoCustomers)
            Dataset = common.sqlconsulta("select clave as idCustomer,  usuario as Name, nombre  as LastName, telefonos as phone, Email, *  from usuarioweb where clave =" & objInfo.IdCustomer, "dUsuaio")
            For Each Row As DataRow In Dataset.Tables(0).Rows
                Dim Obj As New InfoCustomers
                Obj.Name = Row("Name").ToString
                Obj.LastName = Row("LastName").ToString
                Obj.Phone = Row("phone").ToString
                Obj.Email = Row("Email").ToString
                'Obj.CustomersDate = Row("CustomersDate").ToString
                'Obj.EmailVerifield = Boolean.Parse(Row("EmailVerifield").ToString)
                'Obj.Canceled = Integer.Parse(Row("Canceled").ToString)
                'Obj.Paid = Integer.Parse(Row("Paid").ToString)
                'Obj.Active = Boolean.Parse(Row("Active").ToString)
                objInfoCustomer.Add(Obj)
            Next
            Return objInfoCustomer
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadAddressById(ByVal ObjInfo As Information.InfoCustomers) As List(Of InfoCustomers)
        Try
            Dim ObjInfoCustomer As New List(Of InfoCustomers)
            Dataset = common.sqlconsulta("select uw.clave as idCustomer,  uw.usuario as Name, uw.nombre as LastName, cl.TELEFONOS1 as phone, uw.Email,  cl.clave as idAddress, cl.CIA as Company, cl.RFC, (rtrim(cl.DIRECCION) + ' '+ rtrim(cl.NUMERO)) as Adress, cl.COLONIA as Colony, cl.CP, cl.CIUDAD as City, cl.ESTADO as State, cl.PAIS as Country  from usuarioweb uw inner join cliente cl on uw.cliente = cl.clave where uw.clave = " & ObjInfo.IdCustomer, "dDireccion")

            For Each Row As DataRow In Dataset.Tables(0).Rows
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
                ObjInfoCustomer.Add(Obj)
            Next
            Return ObjInfoCustomer
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadLogin(ByVal objInfo As Information.InfoCustomers) As List(Of InfoCustomers)
        Try
            Dim objInfoCustomer As New List(Of InfoCustomers)
            Dataset = common.sqlconsulta("select uw.clave as idCustomer, uw.nombre as Name,  cl.lista, cl.cia, uw.cliente from usuarioweb uw inner join cliente cl on uw.cliente = cl.clave where usuario='" & objInfo.UserName & "' and password='" & objInfo.Pass & "'", "dLogin")
            For Each Row As DataRow In Dataset.Tables(0).Rows
                Dim Obj As New InfoCustomers
                Obj.IdCustomer = Row("idCustomer").ToString
                Obj.Name = Row("Name").ToString
                Obj.Paid = Row("lista")
                Obj.CompanyFac = Row("cia").ToString
                Obj.StateFac = Row("cliente").ToString
                objInfoCustomer.Add(Obj)
            Next
            Return objInfoCustomer
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
