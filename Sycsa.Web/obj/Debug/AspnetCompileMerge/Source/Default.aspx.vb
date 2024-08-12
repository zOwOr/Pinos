Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports FastReport
Imports FastReport.Utils
Imports FastReport.Web
Imports System.Collections.Generic
Imports System.IO
Imports FastReport.Data
Imports System

Public Class _Default
    Inherits System.Web.UI.Page
    Private Shared FConfigLoaded As Boolean
    Private Shared FReportsPath As String
    Private Shared FDataBasePath As String
    Public name_report As String = String.Empty
    Public sql As String = String.Empty
    Public clav As Integer = 0
    Public common As New CONECTASQL.ConectaSQL
    Protected Sub Page_Load(sender As Object, e As EventArgs)

    End Sub
    Protected Sub WebReport1_StartReport(sender As Object, e As EventArgs)
        Dim url As String = HttpContext.Current.Request.ServerVariables("HTTP_REFERER")
        Dim array As String() = Split(url, "?", 2)
        Dim arrayParam As String() = Split(array(1), "&", 2)
        Dim arrayvalor As String() = Split(arrayParam(0).ToString, "=", 2)
        clav = arrayvalor(1)
        arrayvalor = Split(arrayParam(1).ToString, "=", 2)
        name_report = arrayvalor(1)


        Dim FReport As Report = TryCast(sender, WebReport).Report
        FReport.Load(Server.MapPath("~\reportes\" & name_report))
        'Label1.Text = FReport.ReportInfo.Description;
        'Label1.Style.Add("padding", "5px");
        WebReport1.Prepare()
        WebReport1.Report = FReport
        RegisterData(FReport)
    End Sub

    Private Sub RegisterData(FReport As Report)
        Dim infototal As New DataSet()
        infototal = common.sqlconsulta("SELECT ROUND(TOTAL,2) AS TOTAL, MONEDA FROM DOCVEN WHERE CLAVE=" & clav, "DSTABLA")
        Dim FDataSet As New DataSet()
        sql = "SELECT  emp.rfc AS ciarfc, emp.Nombre AS cianom, emp.direccion AS ciadir, emp.colonia AS ciacol, emp.ciudad AS ciacd, emp.cp AS ciacp, " & _
        " emp.pais AS ciapais, emp.estado AS ciaest, emp.numero AS cianum, emp.clavecfd, " & _
        " emp.certificadoarch AS ciacerti, emp.llave AS ciakey,   emp.rutalogo,emp.telefonos as ciatel,  " & _
        " emp.fax as ciafax, emp.paginaweb as ciapaginaweb,emp.email as ciaemail,    emp.certificadoarch, emp.llave, emp.nocertificado,  emp.series,  " & _
        " ' " & Letras(Convert.ToDecimal(infototal.Tables(0).Rows(0).Item("TOTAL")).ToString, Convert.ToString(infototal.Tables(0).Rows(0).Item("MONEDA")).ToString) & "' AS letras , emp.cvekey, " & _
        " series.Formato,series.FormatoEM, series.FORMATO_ARCHIVO, series.FORMATOem_ARCHIVO,series.IMPRESORA, series.COPIAS, " & _
        " substring(series.REGIMEN,6,100) as regimen, series.leyenda1, 'Documento elaborado por sistema Sysfe Tel '+ emp.telDis as leyenda2,  " & _
        " series.leyenda3, CondicionVenta.DESCRIPCION AS cvecondvta,                                         " & _
        " CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.cia ELSE CLI_MOS.nombre END AS  clinom, CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.direccion ELSE CLI_MOS.direccion END AS clidir, CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.colonia ELSE CLI_MOS.COLONIA END AS clicol, CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.RFC ELSE CLI_MOS.RFC END AS  cliRFC, CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.CP ELSE CLI_MOS.CP END AS clicp, CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.ciudad ELSE CLI_MOS.CIUDAD END AS cliciu, CASE  WHEN DOCVEN.CLI_MOS=0 THEN cli.estado ELSE CLI_MOS.ESTADO END AS cliest, " & _
        " CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.NUMERO ELSE CLI_MOS.NUMERO END AS clinum, cli.telefonos1 as clitel,cli.entre_calles, cli.pais as clipais, " & _
        " DOCVENDE.partida, p.clave AS codigo_pro, DOCVENDE.UNIDAD, DOCVENDe.descrip_am, DOCVENDE.cantidad,  DOCVENDe.precio_uni AS precio_uni, DOCVENDe.T_DESC_VOL, DOCVENDe.coa, DOCVENDe.importe, DOCVENDe.tasa_iva, DOCVENDe.tasa_ieps, DOCVENDE.DIAS_RENTA, DOCVENDE.CANT_PZAS,DOCVENDE.ORDEN_RENTA, DOCVENDE.FECHA_INI, DOCVENDE.FECHA_FIN, " & _
        " p.VOL_X_UNI, DOCVEN.tipo_cambio, docven.moneda AS moneda, DOCVEN.clave,  DOCVEN.EMPRESA,  DOCVEN.tipo_doc, DOCVEN.solicitante as dv_solicitante ,DOCVEN.vendedor,AGENTES.DESCRIPCION AS agente_descrip, DOCVEN.serie AS cveser,  DOCVEN.folio,  DOCVEN.cliente AS DV_CLIENTE,DOCVEN.cli_mos AS DV_CLIMOS,  DOCVEN.fecha, DOCVEN.fecha_baja AS DV_FECHA_BAJA,  " & _
        " DOCVEN.lista,    DOCVEN.subs_total, DOCVEN.CARGO_EX, DOCVEN.sub_total,  DOCVEN.tasa_iva,  " & _
        " DOCVEN.tot_iva, DOCVEN.tot_ieps, DOCVEN.DESC_VOL,  DOCVEN.ret_iva,   docven.ret_isr,  docven.total,docven.total_mn,  DOCVEN.saldo_mn, DOCVEN.CAMBIO,  DOCVEN.cadenaoriginal,  " & _
        " DOCVEN.sellodigital,  DOCVEN.estatus,DOCVEN.estatussat,    DOCVEN.valordeclarado,  DOCVEN.observaciones AS DV_OBSERVACIONES,  DOCVEN.referencia AS DV_REFERENCIA, DOCVEN.orden_comp AS DV_orden_comp,metodospago.clave+DOCVEN.metodopago as metodopago,DOCVEN.numctapago, CondicionVenta.descripcion as cond_venta,  DOCVEN.factura,  " & _
        " DOCVEN.adDenda, DOCVEN.enviada, DOCVEN.pedido,DOCVEN.remision,  DOCVEN.fechapedido,    DOCVEN.uuid,  DOCVEN.certificadosat,  DOCVEN.certificadofecha,  DOCVEN.sellosat,  " & _
        " DOCVEN.cadenasat,  DOCVEN.afectado,  DOCVEN.fecha_alta,DOCVEN.EMBARCAR_A AS DV_EMBARCAR_A, DOCVEN.USUARIO_ALTA, DOCVEN.USUARIO_BAJA,  " & _
        " DOCVEN.cvecliori,  DOCVEN.cveclides,  DOCVEN.camion,  DOCVEN.chofer, archivoxml,'  folios  ' as remisiones, " & _
        " DOCVEN.ncertifica AS num_cert,   p.codigo_pv, p.codigo, p.descripcion, " & _
        " CliDes.cia AS clides_nombre, CliDes.direccion AS clides_calle, CliDes.numero AS CliDes_numero, CliDes.cp AS CliDes_cp,Clides.colonia AS Clides_colonia,Clides.rfc AS CliDes_rfc, CliDes.entre_calles AS CliDes_entre, CliDes.ciudad AS CliDes_ciudad, CliDes.estado AS CliDes_estado,  " & _
        " CliDes.telefonos1 AS CliDes_tel, CliDes.contacto AS CliDes_contacto, CliOri.cia AS CliOri_nombre, CliOri.direccion AS CliOri_calle, CliOri.numero AS CliOri_numero,  " & _
        " CliOri.cp AS CliOri_cp,CliOri.colonia AS CliOri_colonia, Cliori.rfc AS Cliori_rfc, CliOri.entre_calles AS CliOri_entre, CliOri.telefonos1 AS CliOri_tel, CliOri.contacto, CliOri.ciudad AS Cliori_ciudad, CliOri.estado AS Cliori_estado,  camiones.descripcion AS chof_descrip,  " & _
        " camiones.nom_corto AS cam_nom_corto,  camiones.placas AS cam_placas,  camiones.numeroserie AS cam_numeroserie,  " & _
        " camiones.numeroeconomico AS cam_numeroeco,  camiones.marca AS cam_marca,  camiones.modelo AS cam_modelo,  " & _
        " camiones.dueno AS cam_dueno,  camiones.asegurador AS cam_asegurador,  camiones.poliza AS cam_poliza,  " & _
        " camiones.FECHA_VEN AS cam_fecha_ven,  choferes.operador AS chof_operador,  choferes.calle AS chof_calle,  choferes.numero AS chof_numero,  " & _
        " choferes.cp AS chof_cp,  choferes.telefonos AS chof_tel,  choferes.reg_imss AS chof_regimss,  choferes.n_licencia AS chof_numlicencia,  " & _
        " choferes.vencimiento AS chof_vencimiento " & _
        "FROM   DOCVEN INNER JOIN  " & _
        "	DOCVENDE ON  DOCVEN.clave =  DOCVENDE.clave INNER JOIN  " & _
        "	Empresas AS emp ON  DOCVEN.EMPRESA = emp.Clave INNER JOIN  " & _
        "	Cliente AS cli ON cli.clave =  DOCVEN.cliente LEFT OUTER JOIN  " & _
        "	ClI_MOS  ON cli_MOS.clave =  DOCVEN.cli_MOS INNER JOIN  " & _
        "	Producto AS p ON p.clave =  DOCVENDE.CODIGO_PRO LEFT OUTER JOIN  " & _
        "	AGENTES ON DOCVEN.VENDEDOR=AGENTES.AGENTE LEFT OUTER JOIN  " & _
        "	CondicionVenta ON  DOCVEN.cond_venta =  CondicionVenta.cond_venta  left outer join  " & _
        "	METODOSPAGO ON METODOSPAGO.DESCRIPCION=DOCVEN.METODOPAGO LEFT OUTER JOIN  " & _
        "	series on STR(DOCVEN.EMPRESA) + docven.tipo_doc + docven.serie = STR(series.EMPRESA) + series.tipo_doc + series.nombre left outer join " & _
        "	choferes ON  DOCVEN.chofer =  choferes.clave left outer join " & _
        "	camiones ON  DOCVEN.camion =  camiones.clave left outer join  " & _
        "	Cliente AS CliOri ON  DOCVEN.cvecliori = CliOri.clave left outer join  " & _
        "	Cliente AS CliDes ON  DOCVEN.cveclides = CliDes.clave " & _
        " where DOCVEN.Clave=" & clav & " AND DOCVENDE.VISIBLE = 1 order by DOCVENde.partida"
        FDataSet = common.sqlconsulta(sql, "DSTABLA")
        Me.CreateDataSources()
        FReport.RegisterData(FDataSet)
        FReport.GetDataSource("DSTABLA").Enabled = True
    End Sub
    Public Function Letras(ByVal numero As String, ByVal MONEDA As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras As String = ""
        Dim entero As String = ""
        Dim dec As String = ""
        Dim flag As String = ""

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "CIEN "
                                Else
                                    palabras = palabras & "CIENTO "
                                End If
                            Case "2"
                                palabras = palabras & "DOSCIENTOS "
                            Case "3"
                                palabras = palabras & "TRESCIENTOS "
                            Case "4"
                                palabras = palabras & "CUATROCIENTOS "
                            Case "5"
                                palabras = palabras & "QUINIENTOS "
                            Case "6"
                                palabras = palabras & "SEISCIENTOS "
                            Case "7"
                                palabras = palabras & "SETECIENTOS "
                            Case "8"
                                palabras = palabras & "OCHOCIENTOS "
                            Case "9"
                                palabras = palabras & "NOVECIENTOS "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "0"
                                flag = "N"
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "DIEZ "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "ONCE "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "DOCE "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "TRECE "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "CATORCE "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "QUINCE "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "DIECI"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "VEINTE "
                                    flag = "S"
                                Else
                                    palabras = palabras & "VEINTI"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "TREINTA "
                                    flag = "S"
                                Else
                                    palabras = palabras & "TREINTA Y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "CUARENTA "
                                    flag = "S"
                                Else
                                    palabras = palabras & "CUARENTA Y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "CINCUENTA "
                                    flag = "S"
                                Else
                                    palabras = palabras & "CINCUENTA Y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "SESENTA "
                                    flag = "S"
                                Else
                                    palabras = palabras & "SESENTA Y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "SETENTA "
                                    flag = "S"
                                Else
                                    palabras = palabras & "SETENTA Y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "OCHENTA "
                                    flag = "S"
                                Else
                                    palabras = palabras & "OCHENTA Y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "NOVENTA "
                                    flag = "S"
                                Else
                                    palabras = palabras & "NOVENTA Y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    'If y = 1 Then
                                    '    palabras = palabras & "UNO "
                                    'Else
                                    palabras = palabras & "UN "
                                    'End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "DOS "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "TRES "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "CUATRO "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "CINCO "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "SEIS "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "SIETE "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "OCHO "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "NUEVE "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And
                    Len(entero) <= 6) Then palabras = palabras & "MIL "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "MILLON "
                    Else
                        palabras = palabras & "MILLONES "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            Dim TIPO_MON As String = " PESOS "
            If MONEDA.ToString.Trim = "MXN" Or MONEDA = "MN" Then
                MONEDA = " M.N. "
            ElseIf MONEDA.ToString.Trim = "USD" Or MONEDA = "DLL" Then
                MONEDA = " USD "
                TIPO_MON = " DOLLARES USD "
            End If

            If dec <> "" Then
                Letras = "**" & palabras + TIPO_MON + dec & "/100 " & MONEDA & " **"
            Else
                Letras = "**" & palabras + TIPO_MON + "00/100 " + MONEDA & " **"
            End If
        Else
            Letras = ""
        End If
    End Function

    Private Sub CreateDataSources()
    End Sub
End Class
