Imports System
Imports System.Data
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports sycsa.Information
Imports sycsa.BusinessLayer

Imports System.Net.Mail
Imports System.Net
Imports System.Security
Imports System.Net.Mime
Imports System.IO


Public Class CheckoutShipping

    Inherits System.Web.UI.Page
    Dim Objt As New BLCustomersAddresses
    Dim ObjBLCustomer As New BLCustomers
    Dim ObjBL As New BLOptions
    Public oBlGcRecovery As New BLGcRecoveryPass
    Dim common As New CONECTASQL.ConectaSQL
    Public ObjInfoOptions As New List(Of InfoOptions)
    Dim ObjInfoCustomerAddress As New List(Of Information.InfoCustomers)
    Dim ObjInfoCustomer As New List(Of Information.InfoCustomers)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            Dim _idCustomers As Int64

            'Si no ahi inicio de sesion se bloquea la pantalla
            If Session("MM_UserId") Is Nothing Then

                Dim httpReference As String
                httpReference = Page.Request.Url.AbsoluteUri.ToString
                httpReference = ResolveUrl(httpReference)
                Session("PageReferent") = httpReference

                Response.Redirect("~/Login.aspx?", True)
            Else

                If Session("_TotalItemsProduct") IsNot Nothing Then

                    _idCustomers = Session("MM_UserId")
                    'Requests
                    If Request.QueryString("address") = "change" Then
                        'Carga datos 
                        Dim _IdA As Integer = Request.QueryString("param")
                        LoadAdrees(_idCustomers, _IdA, -1)
                    Else
                        LoadAdrees(_idCustomers, -1, 1)
                    End If

                Else
                    Response.Redirect("Home.aspx", True)
                End If

            End If

        End If

    End Sub



    Function LoadAdrees(_Id As Int64, _idAddress As Integer, _DefaultAddress As Integer)
        'Datos del usuario
        With ObjBLCustomer
            .IdCustomer = _Id
            ObjInfoCustomer = .LoadById()
            txtName.Text = ObjInfoCustomer(0).Name
            txtLastName.Text = ObjInfoCustomer(0).LastName
            txtPhone.Text = ObjInfoCustomer(0).Phone
        End With
        'Datos de la direccion
        With Objt

            .IdClient = _Id
            ObjInfoCustomerAddress = .Load()

            Hfaddress.Value = ObjInfoCustomerAddress(0).IdAddress
            ' txtCompany.Text = ObjInfoCustomerAddress(0).CompanyFac
            txtAdress.Text = ObjInfoCustomerAddress(0).DireccionFac
            txtColony.Text = ObjInfoCustomerAddress(0).ColoniaFac
            txtCP.Text = ObjInfoCustomerAddress(0).CPFac
            txtCity.Text = ObjInfoCustomerAddress(0).CityFac
            txtState.Text = ObjInfoCustomerAddress(0).StateFac
            txtCountry.Text = ObjInfoCustomerAddress(0).Country

        End With


        Return Nothing
    End Function


    Protected Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click

        If Session("SettingShipping") IsNot Nothing Then
            Session.Remove("SettingShipping")
        End If


        Dim _SettingShipping As New List(Of InfoSettingForShipping)
        'Guardamos datos de lo que coloco en el formulario 
        Dim Setting As New InfoSettingForShipping
        Setting.SettingNotes = txtNotes.Text
        Setting.SettingAddress = Hfaddress.Value
        Setting.SettingMethodSend = HfMethosSend.Value
        Setting.SettingMethodPayment = -1
        Setting.SettingOrdenCompra = txtorden.Text
        _SettingShipping.Add(Setting)

        Session("SettingShipping") = _SettingShipping


        'Continue
        Response.Redirect("CheckoutPayment.aspx", True)

    End Sub
    'Protected Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
    '    Dim _Cliente As Int64
    '    Dim _Direccion As Int64
    '    Dim _tab As DataSet = Nothing
    '    Dim sql As String = String.Empty
    '    Dim lista As Integer = 0

    '    If Session("MM_UserId") IsNot Nothing Then
    '        _Cliente = Session("MM_UserId")
    '        lista = Session("MM_Lista")
    '        _Direccion = Hfaddress.Value
    '    End If
    '    Dim cond_venta As String
    '    Dim vendedor As String
    '    Dim Subtotal As Decimal = ShoppingCart.CapturarProducto().SubTotal
    '    Dim TotalIva As Decimal = (ShoppingCart.CapturarProducto().SubTotal * 0.16)
    '    Dim formapago As String
    '    Dim usoCfdi As String
    '    With Objt
    '        .IdClient = Session("MM_UserId")
    '        ObjInfoCustomerAddress = .Load()
    '        cond_venta = ObjInfoCustomerAddress(0).CondVenta
    '        vendedor = ObjInfoCustomerAddress(0).Vendedor
    '        formapago = ObjInfoCustomerAddress(0).FormaPago
    '        usoCfdi = ObjInfoCustomerAddress(0).UsoCfdi
    '    End With

    '    'Guardado de informacion a la tabla de Orders
    '    sql = " DECLARE @FOLIOSIG  varchar(50) "
    '    sql = sql & "	SET @FOLIOSIG = 'PED'+  RIGHT('000000' + convert(varchar, (select isnull(max(SUBSTRING(FOLIO,6,6)),0)+1 AS FOLIO from DOCVEN where EMPRESA=1 AND TIPO_DOC='PED' AND SERIE='IN')),6) "
    '    sql = sql & "Insert into DOCVEN (EMPRESA, TIPO_DOC, SERIE, FOLIO, CLIENTE, SUCURSAL,CLI_MOS,COND_VENTA, FECHA_ALTA, MONEDA, TIPO_CAMBIO, VENDEDOR, ORDEN_COMP,LISTA,TASA_DESC1, TASA_DESC2, SUBS_TOTAL, DESC_VOL, DESC_1, DESC_2, SUB_TOTAL, TASA_IVA,tot_IEPS, TOT_IVA, RET_IVA, RET_ISR,TOTAL,TOTAL_MN, SALDO_MN, ESTATUS, ESTATUSSAT, REFERENCIA, SOLICITANTE,SOLICITANTE1,EMBARCAR_A, observaciones, usuario_alta,METODOPAGO,numctapago, formapago, usocfdi,CVECLIORI, CVECLIdes, camion, chofer) "
    '    sql = sql & "Values("
    '    sql = sql & "1,'PED','IN',@FOLIOSIG," & Session("MM_CLIENTE") & ",0,0,'" & cond_venta & "',GETDATE(),'MXN',1,'" & vendedor & "','" & txtorden.Text & "'," & lista & ",0,0,round(" & Subtotal & ",2),0,0,0,round(" & Subtotal & ",2)"
    '    sql = sql & ",16,0,round(" & TotalIva & ",2),0,0,round(" & (Subtotal + TotalIva) & ",2),round(" & (Subtotal + TotalIva) & ",2),round(" & (Subtotal + TotalIva) & ",2),'PEN','',''," & _Cliente & ",'','" & 1 & "','" & txtNotes.Text & "','WEB','','','" & formapago & "','" & usoCfdi & "',0,0,0,0"
    '    sql = sql & ")"

    '    sql = sql & "  DECLARE @CLAVESIG  INT "
    '    sql = sql & " SET @CLAVESIG =( select @@IDENTITY as 'identity') "

    '    'Guardado de productos
    '    Dim _ListProducts As New GridView()
    '    _ListProducts.DataSource = ShoppingCart.CapturarProducto().ListProducts.AsEnumerable
    '    _ListProducts.DataBind()

    '    For Each _orows As GridViewRow In _ListProducts.Rows
    '        Dim partida As Integer = partida + 1
    '        sql = sql & " insert into DOCVENDE(clave,codigo_pro, almacen, partida, cantidad, cantidad_unidad, unidad, lista, precio_uni, t_desc_vol, coa, descrip_am, importe,tasa_iva, tasa_ieps,visible, tasa_ret_iva, tasa_ret_isr,  DOCVENDE.DIAS_RENTA, DOCVENDE.CANT_PZAS,DOCVENDE.ORDEN_RENTA, DOCVENDE.FECHA_INI, DOCVENDE.FECHA_FIN,CANT_SURTIDA,FOLIO_PEDIDO, PARTIDA_PEDIDO)"
    '        sql = sql & " values( @CLAVESIG," & _orows.Cells(0).Text.ToString & ",'PRIM'," & partida & "," & _orows.Cells(5).Text.ToString & "," & _orows.Cells(8).Text.ToString & ",'" & _orows.Cells(3).Text.ToString.ToUpper & "'," & lista & ",round(" & _orows.Cells(4).Text.ToString.ToUpper & ",2),"
    '        sql = sql & "0,0,'',round(" & _orows.Cells(6).Text.ToString & ",2)," & _orows.Cells(9).Text.ToString & "," & _orows.Cells(10).Text.ToString & ",1,0,0,0,0,'',NULL,NULL,0,0,0"
    '        sql = sql & " ) "
    '    Next


    '    common.sqlcomando(sql)

    '    If Session("SettingShipping") IsNot Nothing Then
    '        Session.Remove("SettingShipping")
    '    End If


    '    Dim _SettingShipping As New List(Of InfoSettingForShipping)
    '    'Guardamos datos de lo que coloco en el formulario 
    '    Dim Setting As New InfoSettingForShipping
    '    Setting.SettingNotes = txtNotes.Text
    '    Setting.SettingAddress = Hfaddress.Value
    '    Setting.SettingMethodSend = HfMethosSend.Value
    '    Setting.SettingMethodPayment = -1
    '    Setting.SettingOrdenCompra = txtorden.Text
    '    _SettingShipping.Add(Setting)

    '    Session("SettingShipping") = _SettingShipping


    '    'Continue
    '    Response.Redirect("CheckoutPayment.aspx", True)
    '    'Envio de correo al cliente, se especifica el idioma en el cual esta la pagina 
    '    'SendEmailToCustomers("Es", 1, _Cliente)

    '    'Session("_IdCliente") = _Cliente

    '    'Continue
    '    'If chNewAccount.Checked = True Then
    '    '    Response.Redirect("ShoppingSend.aspx?account=new", True)
    '    'Else
    '    'Response.Redirect("ShoppingSend.aspx?", True)
    '    'End If


    'End Sub
    Sub SendEmailToCustomers(_Language As String, _key As Int64, _cliente As Int64)

        Try

            Dim _Subject As String = ""
            Dim ObjBLCustomer As New BLCustomers

            Dim ObjInfoCustomer As New List(Of InfoCustomers)
            With ObjBLCustomer
                .IdCustomer = _cliente
                ObjInfoCustomer = .LoadById()
            End With

            Dim host As String = Request.ServerVariables("HTTP_HOST")
            Dim URl = "http://" & host & "/Layout/preOrderInfo.aspx?key=" & _key.ToString & "&lang=" & _Language
            Dim HTML As String = ScreenScrapeHtml(URl)


            'Labels
            If _Language = "Es" Then
                _Subject = "Cotización recibida | Gracias por su preferencia"
            ElseIf _Language = "En" Then
                _Subject = "Quote received | Thanks for your preference"
            End If

            ObjInfoOptions = ObjBL.Load
            Dim _EmailFrom = ObjInfoOptions(9).OptionValue
            Dim _Host As String = ObjInfoOptions(7).OptionValue
            Dim _UserHost As String = ObjInfoOptions(9).OptionValue
            Dim _PassHost As String = ObjInfoOptions(10).OptionValue
            Dim _Port As String = ObjInfoOptions(8).OptionValue
            Dim _SLL As Boolean = IIf(ObjInfoOptions(21).OptionValue = "Y", True, False)


            Dim mail As New MailMessage()
            Dim smtp As New SmtpClient

            mail.To.Add(New MailAddress(ObjInfoCustomer(0).Email.ToString, ObjInfoCustomer(0).Name.ToString))
            mail.From = New MailAddress(_EmailFrom, "MyAh a tu servicio")

            mail.Subject = _Subject
            mail.IsBodyHtml = True
            mail.Body = HTML
            mail.Priority = System.Net.Mail.MailPriority.Normal

            smtp.Host = _Host
            smtp.Port = _Port
            If _SLL = True Then
                smtp.EnableSsl = True
            End If

            smtp.UseDefaultCredentials = False
            smtp.Credentials = New System.Net.NetworkCredential(_UserHost, _PassHost)
            smtp.Send(mail)


        Catch ex As Exception
            Throw ex
        End Try


    End Sub
    Public Function ScreenScrapeHtml(ByVal url As String) As String
        Dim objRequest As WebRequest = System.Net.HttpWebRequest.Create(url)
        Dim sr As New StreamReader(objRequest.GetResponse().GetResponseStream())
        Dim result As String = sr.ReadToEnd()
        sr.Close()
        Return result
    End Function

    Function RandomString(_Size As Int32)

        Dim _String As String = ""

        Dim obj As New Random()
        Dim posibles As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim longitud As Integer = posibles.Length
        Dim letra As Char

        For i As Integer = 0 To _Size - 1
            letra = posibles(obj.[Next](longitud))
            _String += letra.ToString()
        Next

        Return _String
    End Function
End Class