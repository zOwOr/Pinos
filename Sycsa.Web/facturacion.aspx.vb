Imports System
Imports System.Xml
Imports System.Xml.Xsl
Imports sycsa.BusinessLayer
Imports sycsa.DataAccessLayer
Imports Org.BouncyCastle.Crypto
Imports System.Net
Imports System.IO
Imports Org.BouncyCastle
Imports System.Web.Script.Serialization

Public Class facturacion

    Inherits System.Web.UI.Page
    Public ObjBLCustomer As New BLCustomers
    Public common As New CONECTASQL.ConectaSQL
    Private m_xmlDOM As New XmlDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Facturacion"
        If IsPostBack = False Then
            'If Session("MM_UserId") IsNot Nothing Then

            'End If
            If Session("MM_UserId") Is Nothing Then

                Dim httpReference As String
                httpReference = Page.Request.Url.AbsoluteUri.ToString
                httpReference = ResolveUrl(httpReference)
                Session("PageReferent") = httpReference

                'Response.Redirect("~/Login.aspx?", True)
            Else
                LoadById(Session("MM_UserId"))
            End If
        End If
    End Sub
    Public Sub LoadById(ByVal Id As Integer)
        Try
            Dim ObjInfoCustomer As New List(Of Information.InfoCustomers)
            With ObjBLCustomer
                .IdCustomer = Id
                ObjInfoCustomer = .LoadById()
                txtrfc.Text = ObjInfoCustomer(0).Name
                txtNOMBRE.Text = ObjInfoCustomer(0).LastName
                'txtEmail.Text = ObjInfoCustomer(0).Email
                txtphone.Text = ObjInfoCustomer(0).Phone
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            Dim csqlcom As String = "update cli_mos set nombre='" + txtNOMBRE.Text.ToString.Trim + "', direccion='" + txtdireccion.Text.ToString.Trim + "', colonia='" + txtcolonia.Text.ToString.Trim + "', cp='" + txtcodigopostal.Text.ToString.Trim + "', ciudad='" + txtciudad.Text.ToString.Trim + "', estado='" + txtestado.Text.ToString.Trim + "', telefono='" + txtphone.Text.ToString.Trim + "', regimen='" + txtregimen_cbo.Text.ToString.Trim + "', formapago='" + txtformapago.Text.ToString.Trim + "', usocfdi='" + txtusocfdi.Text.ToString.Trim + "' where  cli_mos.clave='" + TXTCLIMOS.Text.ToString.Trim.ToUpper + "'  "
            common.sqlcomando(csqlcom)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Protected Sub btnbuscarrfc_click() Handles btnbuscarrfc.Click
        buscacliente()
    End Sub
    Protected Sub buscacliente()
        Dim DATASET As New DataSet
        DATASET = common.buscacliente(txtrfc.Text.ToString.Trim.ToUpper)

        If DATASET.Tables(0).Rows.Count > 0 Then
            TXTCLIMOS.Text = DATASET.Tables(0).Rows(0).Item("clave").ToString
            txtNOMBRE.Text = DATASET.Tables(0).Rows(0).Item("nombre").ToString
            txtformapago.Text = DATASET.Tables(0).Rows(0).Item("formapago").ToString
            txtregimen_cbo.Text = DATASET.Tables(0).Rows(0).Item("regimen").ToString
            txtusocfdi.Text = DATASET.Tables(0).Rows(0).Item("usocfdi").ToString
            txtcodigopostal.Text = DATASET.Tables(0).Rows(0).Item("cp").ToString
            txtphone.Text = DATASET.Tables(0).Rows(0).Item("telefono").ToString
            txtdireccion.Text = DATASET.Tables(0).Rows(0).Item("direccion").ToString
            txtcolonia.Text = DATASET.Tables(0).Rows(0).Item("colonia").ToString
            txtciudad.Text = DATASET.Tables(0).Rows(0).Item("ciudad").ToString
            txtestado.Text = DATASET.Tables(0).Rows(0).Item("estado").ToString
            DATASET = common.buscaemail(DATASET.Tables(0).Rows(0).Item("clave").ToString, "CLI_MOS")

            Listemails.DataSource = DATASET

            Listemails.DataBind()
        Else
            enviamsg("No se encontro RFC, favor de ingresar datos de facturacion")

            btnbuscarrfc.Visible = False
            inicializa()

            btnActualizar.Visible = False
        End If




    End Sub



    Protected Sub btnfacturar_Click(sender As Object, e As EventArgs)
        Dim secretKey As String = "6Lf5sdApAAAAAMIPMKc7v5eKaF9A6ZspWYapX3h_"
        Dim recaptcha_response = gRecaptchaResponse.Value
        Dim Myrequest As WebRequest = WebRequest.Create("https://www.google.com/recaptcha/api/siteverify")
        Myrequest.Method = "POST"
        Dim postData As String = "secret=" & secretKey & "&response=" & recaptcha_response
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)

        Myrequest.ContentType = "application/x-www-form-urlencoded"
        Myrequest.ContentLength = byteArray.Length

        Dim dataStream As Stream = Myrequest.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()

        Dim response As WebResponse = Myrequest.GetResponse()
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)

        Using dataStream1 As Stream = response.GetResponseStream()

            Dim reader As New StreamReader(dataStream1)
            Dim responseFromServer As String = reader.ReadToEnd()
            Dim jsonData As String = responseFromServer
            Dim JsonResults As Object = New JavaScriptSerializer().Deserialize(Of Object)(jsonData)

            If JsonResults("success") = True Then
                Dim datosTicket As New DataSet
                If System.String.IsNullOrEmpty(TXTCLIMOS.Text.ToString) Then
                    enviamsg("Favor de ingresar RFC y datos de facturacion ")
                    Return
                End If
                datosTicket = common.sqlconsulta("select dv.clave, dv.empresa, dv.cliente, dv.folio, dv.fecha_alta, dv.cond_venta, dv.tasa_desc1, dv.sub_total, dv.tot_iva, dv.total_mn, dv.subs_total, dv.tot_ieps, dv.ret_isr, dv.ret_iva, dv.DESC_VOL, dv.desc_1, dv.desc_2, dv.clave, (SELECT FOLIO FROM DOCVEN WHERE CLAVE=dv.folio_fac) AS folio_fac from docven AS DV where dv.estatus='AFE' AND  dv.tipo_doc='NOT' and dv.folio='" + TXTFOLIO.Text.ToString + "' and dv.total_mn=" + TXTTOTAL.Text.ToString.Trim + " ", "SERIES")
                If datosTicket.Tables(0).Rows.Count > 0 Then
                    If Not System.String.IsNullOrEmpty(datosTicket.Tables(0).Rows(0).Item("folio_fac").ToString.Trim) Then
                        enviamsg("Documento facturado en el folio " + datosTicket.Tables(0).Rows(0).Item("folio_fac").ToString.Trim + ", el dia " + datosTicket.Tables(0).Rows(0).Item("fecha_alta").ToString)
                        Return
                    End If
                    common.facturar(datosTicket, TXTFOLIO.Text.ToString, TXTCLIMOS.Text.ToString, txtformapago.Text.ToString, txtusocfdi.Text.ToString)

                Else

                    enviamsg("No se encontro numero de ticket, favor de intentar de nuevo")
                End If
            Else
                enviamsg("error en validacion de captcha, intenta nuevamente")

            End If

        End Using
        response.Close()



    End Sub
    Protected Sub ejecuta() Handles btntimbrar.Click
        Dim datosTicket As New DataSet
        If System.String.IsNullOrEmpty(TXTCLIMOS.Text.ToString) Then
            enviamsg("Favor de ingresar RFC y datos de facturacion ")
            Return
        End If
        datosTicket = common.sqlconsulta("select dv.clave, dv.empresa, folio_fac, (SELECT cli_mos.rfc FROM DOCVEN inner join cli_mos on docven.cli_mos=cli_mos.clave WHERE docven.CLAVE=dv.folio_fac) AS rfc, dv.cliente, dv.folio, dv.fecha_alta, dv.cond_venta, dv.tasa_desc1, dv.sub_total, dv.tot_iva, dv.total_mn, dv.subs_total, dv.tot_ieps, dv.ret_isr, dv.ret_iva, dv.DESC_VOL, dv.desc_1, dv.desc_2, dv.clave, (SELECT FOLIO FROM DOCVEN WHERE CLAVE=dv.folio_fac) AS folio_new from docven AS DV where dv.estatus='AFE' AND  dv.tipo_doc='NOT' and dv.folio='" + TXTFOLIO.Text.ToString + "' and dv.total_mn=" + TXTTOTAL.Text.ToString.Trim + " ", "SERIES")
        If datosTicket.Tables(0).Rows.Count > 0 Then
            If Not System.String.IsNullOrEmpty(datosTicket.Tables(0).Rows(0).Item("folio_new").ToString.Trim) Then
                enviamsg("Documento facturado en el folio " + datosTicket.Tables(0).Rows(0).Item("folio_new").ToString.Trim + ", el dia " + datosTicket.Tables(0).Rows(0).Item("fecha_alta").ToString)

                If datosTicket.Tables(0).Rows(0).Item("rfc").ToString.ToUpper.Trim = txtrfc.Text.ToString.ToUpper.Trim Then
                    descargarxml(datosTicket.Tables(0).Rows(0).Item("folio_fac").ToString.Trim)
                    ReturmXML(datosTicket.Tables(0).Rows(0).Item("folio_fac").ToString.Trim)

                End If
                Return
            End If
            Dim restim = common.facturar(datosTicket, TXTFOLIO.Text.ToString, TXTCLIMOS.Text.ToString, txtformapago.Text.ToString, txtusocfdi.Text.ToString)
            'enviamsg(restim.ToString)
            Dim dataset As New DataSet
            dataset = common.sqlconsulta("SELECT [FOLIO],[ARCHIVOXML] FROM [DOCVEN] where TIPO_DOC='FAC'  and clave=" & restim, "dProducto")
            If dataset.Tables(0).Rows.Count > 0 Then
                If Not System.String.IsNullOrEmpty(dataset.Tables(0).Rows(0).Item("archivoxml").ToString.Trim) Then
                    ReturmXML(restim)
                    descargarxml(restim)
                    enviamsg("Se genero CFDI con exito")
                End If

            End If


        Else

            enviamsg("No se encontro numero de ticket, favor de intentar de nuevo")
        End If
        'common.sqlcomando("update DOCVEN set estatus='0' where clave = 277985")

        'afectar(277985, "web", 1, 1, 277985)

    End Sub
    Function descargarxml(clave As String)
        Dim queryString As String = "/Default.aspx?clav=" & clave & "&name_report=" & "/factura.frx"

        Dim newWin As String = "window.open('" & queryString & "','Facturas','height=550, width=870,toolbar=no,directories=no,status=no, menubar=no,scrollbars=yes,resizable=no');"

        ClientScript.RegisterStartupScript(Me.GetType(), "Facturas", newWin, True)
        Return newWin

    End Function
    Private Sub ReturmXML(clave As String)
        Dim DataSet As New DataSet
        Dim id As String = IIf(Session("MM_CLIENTE") Is Nothing, "0", Session("MM_CLIENTE"))
        DataSet = common.sqlconsulta("SELECT [FOLIO],[ARCHIVOXML] FROM [DOCVEN] where TIPO_DOC='FAC'  and clave=" & clave, "dProducto")
        Dim foliofac As String = DataSet.Tables(0).Rows(0).Item("FOLIO").ToString
        Dim doc As New XmlDocument
        Dim nombre_archivo As String = RTrim(foliofac) & ".xml"
        If String.IsNullOrEmpty(DataSet.Tables(0).Rows(0).Item("ARCHIVOXML").ToString) Then
        Else
            doc.LoadXml(DataSet.Tables(0).Rows(0).Item("ARCHIVOXML").ToString)
        End If
        Dim stream = New MemoryStream()
        Dim settings As New XmlWriterSettings()
        settings.Indent = True
        Using writer As XmlWriter = XmlWriter.Create(stream, settings)
            doc.WriteTo(writer)
        End Using
        Dim data As Byte() = stream.ToArray()
        Response.Clear()
        Response.ContentType = "text/xml"
        Response.AppendHeader("content-disposition", "attachment; filename=" & nombre_archivo)
        Response.BinaryWrite(data)
        Response.End()
        stream.Flush()
        stream.Close()
    End Sub
    Public Sub enviamsg(ByVal msg As String)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('" + msg + "');", True)

    End Sub


    Protected Sub inicializa()
        TXTCLIMOS.Text = ""
        txtNOMBRE.Text = ""
        txtformapago.Text = ""
        txtregimen_cbo.Text = ""
        txtusocfdi.Text = ""
        txtcodigopostal.Text = ""
        txtphone.Text = ""
        txtdireccion.Text = ""
        txtcolonia.Text = ""
        txtciudad.Text = ""
        txtestado.Text = ""
        TXTFOLIO.Text = ""
        TXTTOTAL.Text = ""
    End Sub


End Class
