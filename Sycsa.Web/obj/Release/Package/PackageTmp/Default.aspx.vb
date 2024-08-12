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
        Dim FDataSet As New DataSet()
        Dim FDataSetdetalle As New DataSet()
        If name_report Like "factura.frx" Or name_report Like "pedido.frx" Then
            infototal = common.sqlconsulta("SELECT ROUND(TOTAL,2) AS TOTAL, MONEDA FROM DOCVEN WHERE CLAVE=" & clav, "DSTABLA")
            Dim inforemisiones As New DataSet()
            Dim folios As String = ""

            inforemisiones = common.sqlconsulta("select folio from docven where folio_fac=" & clav, "ds")
            For i As Integer = 0 To inforemisiones.Tables(0).Rows.Count - 1
                folios = folios + IIf(System.String.IsNullOrEmpty(folios), inforemisiones.Tables(0).Rows(i).Item("folio").ToString, "," + inforemisiones.Tables(0).Rows(i).Item("folio").ToString)
            Next


            sql = "SELECT emp.rfc AS ciarfc, emp.Nombre AS cianom, emp.direccion AS ciadir, emp.colonia As ciacol, emp.ciudad As ciacd, emp.cp As ciacp, " &
                  "emp.pais As ciapais, emp.estado As ciaest, emp.numero AS cianum, emp.clavecfd, emp.certificadoarch As ciacerti, emp.llave AS ciakey, emp.rutalogo, emp.telefonos As ciatel, " &
                  " emp.fax As ciafax,emp.paginaweb as ciapaginaweb, emp.email As ciaemail,emp.certificadoarch, emp.llave, emp.nocertificado, emp.series, " &
                  "'" & Letras(Convert.ToDecimal(infototal.Tables(0).Rows(0).Item("TOTAL")).ToString, Convert.ToString(infototal.Tables(0).Rows(0).Item("MONEDA")).ToString) & "' AS letras , emp.cvekey,  " &
                  "series.Formato,series.FormatoEM, series.FORMATO_ARCHIVO,series.FORMATOem_ARCHIVO, series.FORMATOEMB1, series.IMPRESORA,series.COPIAS,series.IMPRESORAEMB, series.COPIASEMB,  " &
                  "series.REGIMEN as regimen,series.leyenda1, 'Documento elaborado por sistema Sysfe Tel '+emp.telDis as leyenda2, " &
                  " series.leyenda3,series.metodopago as SerieMetodo, series.regimen as serieRegimen,CondicionVenta.DESCRIPCION AS cvecondvta," &
                  "CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.cia ELSE CLI_MOS.nombre " &
                  "END AS  clinom, CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.direccion ELSE CLI_MOS.direccion END AS clidir, CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.colonia ELSE CLI_MOS.COLONIA END AS clicol, CASE  WHEN DOCVEN.CLI_MOS=0 " &
                  "THEN CLI.RFC ELSE CLI_MOS.RFC END AS cliRFC, CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.CP ELSE CLI_MOS.CP END AS clicp, CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.ciudad ELSE CLI_MOS.CIUDAD END AS cliciu, CASE  WHEN DOCVEN.CLI_MOS=0 THEN cli.estado ELSE CLI_MOS.ESTADO END AS cliest,  " &
                  "CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.NUMERO ELSE CLI_MOS.NUMERO END AS clinum, cli.telefonos1 as clitel,cli.entre_calles, cli.pais as clipais, cli.coordenadas, cli.tipo_cliente, " &
                  " zonas.descripcion AS CLI_ZONA, CLI.CHOFER AS CLI_CHOFER, CLI_SUC.EMB_1,CLI_SUC.EMB_2,CLI_SUC.EMB_3,CLI_SUC.TELEFONO, " &    ''''' docvende ''''
                  " DOCVENDE.partida, p.clave AS codigo_pro,DOCVENDE.UNIDAD, DOCVENDe.descrip_am, DOCVENDE.cantidad,docvende.cant_surtida, DOCVENDe.precio_uni AS precio_uni,DOCVENDe.T_DESC_VOL, DOCVENDe.coa, DOCVENDe.imp_desc, " &
                  "DOCVENDe.importe,DOCVENDe.tasa_iva, DOCVENDe.tasa_ieps, DOCVENDE.DIAS_RENTA,DOCVENDE.CANT_PZAS,DOCVENDE.ORDEN_RENTA, DOCVENDE.FECHA_INI,DOCVENDE.FECHA_FIN, DOCVENDE.ancho, DOCVENDE.espesor, DOCVENDE.largo, DOCVENDE.cant_pzas," &
                  " p.VOL_X_UNI,DOCVEN.tipo_cambio, docven.moneda AS moneda, DOCVEN.clave,DOCVEN.EMPRESA,  DOCVEN.tipo_doc, DOCVEN.solicitante as dv_solicitante,DOCVEN.vendedor,AGENTES.DESCRIPCION AS agente_descrip, DOCVEN.serie AS " &
                  "cveser,  DOCVEN.folio,  DOCVEN.cliente AS DV_CLIENTE,DOCVEN.cli_mos AS DV_CLIMOS,  DOCVEN.fecha,DOCVEN.fecha_Emision, DOCVEN.fecha_baja AS DV_FECHA_BAJA, " &
                  "  DOCVENDE.lista,DOCVEN.subs_total, DOCVEN.CARGO_EX, DOCVEN.sub_total,  DOCVEN.tasa_iva, DOCVEN.tot_iva,DOCVEN.tot_ieps, DOCVEN.DESC_VOL, DOCVEN.DESC_1, DOCVEN.DESC_2, DOCVEN.ret_iva,   docven.ret_isr,  docven.total,docven.total_mn, " &
                  " DOCVEN.saldo_mn, DOCVEN.CAMBIO,  DOCVEN.cadenaoriginal, DOCVEN.sellodigital, DOCVEN.estatus,DOCVEN.estatussat, DOCVEN.valordeclarado, DOCVEN.observaciones AS DV_OBSERVACIONES,  DOCVEN.referencia AS " &
                  " DV_REFERENCIA, DOCVEN.orden_comp AS DV_orden_comp,formapago.clave+formapago.descripcion as metodopago,DOCVEN.numctapago,CondicionVenta.descripcion as cond_venta,  DOCVEN.factura, " &
                  " DOCVEN.adDenda,DOCVEN.enviada, DOCVEN.pedido,DOCVEN.remision, docven.fondogarantia as DV_FONDOGARANTIA,  DOCVEN.fechapedido,    DOCVEN.uuid, DOCVEN.certificadosat,  DOCVEN.certificadofecha,  DOCVEN.sellosat, " &
                  " DOCVEN.cadenasat,DOCVEN.afectado,  DOCVEN.fecha_alta,DOCVEN.EMBARCAR_A AS DV_EMBARCAR_A,DOCVEN.USUARIO_ALTA, DOCVEN.USUARIO_BAJA, " &
                  "  DOCVEN.cvecliori,DOCVEN.cveclides,  DOCVEN.camion,  DOCVEN.chofer, archivoxml,'" & folios & "' as remisiones, docven.usocfdi as DocvenUsocfdi,  " &
                  "  DOCVEN.ncertifica AS num_cert,p.codigo_pv, p.codigo_fac, p.codigo, p.descripcion, p.claveprodserv," &
                  " p.claveunidad, docven.ret_local_1,docven.ret_local_2,docven.ret_local_3,docven.ret_local_imp_1,docven.ret_local_imp_2,docven.ret_local_imp_3, docven.ret_total," &
                  " CliDes.cia AS clides_nombre, CliDes.direccion AS clides_calle, CliDes.numero AS CliDes_numero,CliDes.cp AS CliDes_cp,Clides.colonia AS Clides_colonia,Clides.rfc AS CliDes_rfc, CliDes.entre_calles AS CliDes_entre, CliDes.ciudad AS CliDes_ciudad, CliDes.estado AS CliDes_estado, " &
                  " CliDes.telefonos1 AS CliDes_tel,CliDes.contacto AS CliDes_contacto, CliOri.cia AS CliOri_nombre,CliOri.direccion AS CliOri_calle, CliOri.numero AS CliOri_numero, CliOri.cp AS CliOri_cp,CliOri.colonia AS CliOri_colonia, Cliori.rfc AS Cliori_rfc," &
                  " CliOri.entre_calles AS CliOri_entre, CliOri.telefonos1 AS CliOri_tel, CliOri.contacto, CliOri.ciudad AS Cliori_ciudad, CliOri.estado AS Cliori_estado,  camiones.descripcion AS chof_descrip," &
                  " camiones.nom_corto AS cam_nom_corto,  camiones.placas AS cam_placas,  camiones.numeroserie AS cam_numeroserie, " &
                  " camiones.numeroeconomico AS cam_numeroeco,  camiones.marca AS cam_marca,  camiones.modelo AS cam_modelo, camiones.dueno AS cam_dueno," &
                  " camiones.asegurador AS cam_asegurador,  camiones.poliza AS cam_poliza, camiones.FECHA_VEN AS cam_fecha_ven,  choferes.operador AS chof_operador,  choferes.calle AS" &
                  " chof_calle,  choferes.numero AS chof_numero, choferes.cp AS chof_cp, choferes.telefonos AS chof_tel,  choferes.reg_imss AS chof_regimss, choferes.n_licencia AS chof_numlicencia," &
                  " choferes.vencimiento AS chof_vencimiento FROM DOCVEN INNER JOIN DOCVENDE ON  DOCVEN.clave =  DOCVENDE.clave INNER JOIN Empresas AS emp ON  DOCVEN.EMPRESA = emp.Clave INNER JOIN Cliente AS cli ON cli.clave = DOCVEN.cliente LEFT OUTER JOIN" &
                  " cli_suc ON cli_suc.clave =  DOCVEN.sucursal LEFT OUTER JOIN zonas ON zonas.clave =  cli.zona1 LEFT OUTER JOIN ClI_MOS  ON cli_MOS.clave =  DOCVEN.cli_MOS INNER JOIN " &
                  " Producto AS p ON p.clave =  DOCVENDE.CODIGO_PRO LEFT OUTER JOIN AGENTES ON DOCVEN.VENDEDOR=AGENTES.AGENTE LEFT OUTER JOIN " &
                  " CondicionVenta ON  DOCVEN.cond_venta =  CondicionVenta.cond_venta  left outer join formapago ON formapago.clave=DOCVEN.formapago LEFT OUTER JOIN " &
                  " series on STR(DOCVEN.EMPRESA)+docven.tipo_doc+docven.serie=STR(series.EMPRESA)+series.tipo_doc+series.nombre left outer join " + " choferes ON  DOCVEN.chofer =  choferes.clave " &
                  " left outer join camiones ON  DOCVEN.camion =  camiones.clave left outer join Cliente AS CliOri ON  DOCVEN.cvecliori = CliOri.clave left outer join  Cliente AS CliDes ON  DOCVEN.cveclides = CliDes.clave  " &
                  " where DOCVEN.Clave=" & clav & " AND SERIES.EMPRESA=DOCVEN.EMPRESA AND DOCVENDE.VISIBLE=1  order by DOCVENde.partida"

            sql = "SELECT     emp.rfc AS ciarfc, emp.Nombre AS cianom, emp.direccion AS ciadir, emp.colonia AS ciacol, emp.ciudad AS ciacd, emp.cp AS ciacp, " &
            "emp.pais AS ciapais, emp.estado AS ciaest, emp.numero AS cianum, emp.clavecfd,  " &
             "emp.certificadoarch AS ciacerti, emp.llave AS ciakey,   emp.rutalogo,emp.telefonos as ciatel, " &
                         " emp.fax as ciafax, emp.paginaweb as ciapaginaweb,emp.email as ciaemail,    emp.certificadoarch, emp.llave, emp.nocertificado,  emp.series, " &
                          "'" + Letras(Convert.ToDecimal(infototal.Tables(0).Rows(0).Item("TOTAL")).ToString, Convert.ToString(infototal.Tables(0).Rows(0).Item("MONEDA")).ToString) + "' AS letras , emp.cvekey,  " &
                         " series.Formato,series.FormatoEM, series.FORMATO_ARCHIVO, series.FORMATOem_ARCHIVO, series.FORMATOEMB1,series.FORMATOemb1_ARCHIVO, series.IMPRESORA, series.COPIAS,series.IMPRESORAEMB, series.COPIASEMB,  " &
                         "series.REGIMEN as regimen, series.leyenda1, 'Documento elaborado por sistema Sysfe Tel '+ emp.telDis as leyenda2, " &
                         " series.leyenda3, series.metodopago as SerieMetodo, series.regimen as serieRegimen, CondicionVenta.DESCRIPCION AS cvecondvta," +
                         ""
            sql = sql + " CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.cia ELSE CLI_MOS.nombre END AS  clinom, cli.cia2,cli.cia_corto, CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.direccion ELSE CLI_MOS.direccion COLLATE Modern_Spanish_CI_AS END AS clidir, CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.colonia ELSE CLI_MOS.COLONIA END AS clicol, CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.RFC ELSE CLI_MOS.RFC END AS  cliRFC, CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.CP ELSE CLI_MOS.CP END AS clicp, CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.ciudad ELSE CLI_MOS.CIUDAD END AS cliciu, CASE  WHEN DOCVEN.CLI_MOS=0 THEN cli.estado ELSE CLI_MOS.ESTADO END AS cliest,  " &
              "CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.NUMERO ELSE CLI_MOS.NUMERO END AS clinum, CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.regimen ELSE CLI_MOS.regimen END AS cliregimen, cli.telefonos1 as clitel,cli.entre_calles, cli.pais as clipais, cli.coordenadas, cli.tipo_cliente, cli.metododepago as cli_metodopago,"
            ' sucursales 
            sql = sql + " zonas.descripcion AS CLI_ZONA, CLI.CHOFER AS CLI_CHOFER, CLI_SUC.EMB_1, CLI_SUC.EMB_2,CLI_SUC.EMB_3,CLI_SUC.TELEFONO, "
            ''''' docvende ''''
            sql = sql + " DOCVENDE.partida, p.clave AS codigo_pro, DOCVENDE.UNIDAD, DOCVENDe.descrip_am, DOCVENDE.cantidad, docvende.cant_surtida, DOCVENDe.precio_uni AS precio_uni, DOCVENDe.T_DESC_VOL, DOCVENDe.coa, DOCVENDe.imp_desc, DOCVENDe.importe, DOCVENDe.tasa_iva, DOCVENDe.tasa_ieps, DOCVENDE.IMP_IVA, DOCVENDE.IMP_IEPS, DOCVENDE.DIAS_RENTA, DOCVENDE.CANT_PZAS,DOCVENDE.ORDEN_RENTA, DOCVENDE.FECHA, DOCVENDE.FECHA_INI, DOCVENDE.FECHA_FIN,   DOCVENDE.ancho, DOCVENDE.espesor, DOCVENDE.largo, DOCVENDE.cant_pzas," &
                         " p.VOL_X_UNI, p.peso_x_pie, p.imagen, p.cant_emp, DOCVEN.tipo_cambio, docven.moneda AS moneda, DOCVEN.clave,  DOCVEN.EMPRESA,  DOCVEN.tipo_doc, DOCVEN.solicitante as dv_solicitante ,DOCVEN.vendedor,AGENTES.DESCRIPCION AS agente_descrip,  DOCVEN.serie AS cveser,  DOCVEN.folio,  DOCVEN.cliente AS DV_CLIENTE,DOCVEN.cli_mos AS DV_CLIMOS,  DOCVEN.fecha,DOCVEN.fecha_Emision, DOCVEN.fecha_baja AS DV_FECHA_BAJA, " &
                         "  DOCVENDE.lista, cli.lista as cli_lista,   DOCVEN.subs_total, DOCVEN.CARGO_EX, DOCVEN.sub_total,  DOCVEN.tasa_iva,ISNULL(CHOFER.DESCRIPCION,'') as CHOFER_descrip,ISNULL(COBRADOR.DESCRIPCION,'') as COBRADOR_descrip, " &' CHOFER.DESCRIPCION AS CHOFER_descrip, " &  '
                         " DOCVEN.tot_iva, DOCVEN.tot_ieps, DOCVEN.DESC_VOL, DOCVEN.TASA_DESC1, DOCVEN.DESC_1, DOCVEN.DESC_2,  DOCVEN.ret_iva,   docven.ret_isr,  docven.total,docven.total_mn,  DOCVEN.saldo_mn, DOCVEN.CAMBIO,  DOCVEN.cadenaoriginal, " &
                         " DOCVEN.sellodigital,  DOCVEN.estatus,DOCVEN.estatussat,    DOCVEN.valordeclarado,  DOCVEN.observaciones AS DV_OBSERVACIONES,  DOCVEN.referencia AS DV_REFERENCIA, DOCVEN.orden_comp AS DV_orden_comp, formapago.clave+formapago.descripcion as metodopago,DOCVEN.numctapago, CondicionVenta.descripcion as cond_venta,  DOCVEN.factura, " &
                         " DOCVEN.adDenda, DOCVEN.enviada, DOCVEN.pedido,DOCVEN.remision, docven.fondogarantia as DV_FONDOGARANTIA,  DOCVEN.fechapedido,    DOCVEN.uuid,  DOCVEN.certificadosat,  DOCVEN.certificadofecha,  DOCVEN.sellosat, " &
                         " DOCVEN.cadenasat,  DOCVEN.afectado,  DOCVEN.fecha_alta, isnull(dateadd(day,condicionventa.dias_pp , docven.fecha_alta),'') as fecha_venc, DOCVEN.fecha_afe,DOCVEN.EMBARCAR_A AS DV_EMBARCAR_A, DOCVEN.USUARIO_ALTA, DOCVEN.USUARIO_BAJA, " &
                             "  DOCVEN.cvecliori,  DOCVEN.cveclides,  DOCVEN.camion,  DOCVEN.chofer, archivoxml,'" + folios + "' as remisiones, docven.usocfdi as DocvenUsocfdi,  "
            sql = sql + "  DOCVEN.ncertifica AS num_cert,   p.codigo_pv, p.codigo_fac, p.codigo, p.descripcion, p.claveprodserv, p.claveunidad,palm.ESTANTE, docven.ret_local_1, docven.ret_local_2,docven.ret_local_3,docven.ret_local_imp_1,docven.ret_local_imp_2, docven.ret_local_imp_3, docven.ret_total,
                    'https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?id='+ rtrim(Docven.uuid) COLLATE Modern_Spanish_CI_AS  + '&re=' +rtrim(emp.rfc)+'&rr='+rtrim(CASE  WHEN DOCVEN.CLI_MOS=0 THEN CLI.RFC ELSE CLI_MOS.RFC END)+'&tt='+replace(str(docven.total_mn,25,6),SPACE(1),'0') +'&fe='+substring(docven.sellodigital,len(docven.sellodigital)-7,8)  as qr,"

            ''''' transportes ''''
            sql = sql + " CliDes.cia AS clides_nombre, CliDes.direccion AS clides_calle, CliDes.numero AS CliDes_numero, CliDes.cp AS CliDes_cp,Clides.colonia AS Clides_colonia,  Clides.cat_colonia as clides_catcolonia,  Clides.cat_localidad as clides_catlocalidad,   Clides.cat_ciudad as clides_catciudad,  Clides.cat_estado as clides_catestado,  Clides.cat_pais as clides_catpais, Clides.rfc AS CliDes_rfc, CliDes.entre_calles AS CliDes_entre, CliDes.ciudad AS CliDes_ciudad, CliDes.estado AS CliDes_estado, " &
                       " CliDes.telefonos1 AS CliDes_tel, CliDes.contacto AS CliDes_contacto, CliOri.cia AS CliOri_nombre, CliOri.direccion AS CliOri_calle, CliOri.numero AS CliOri_numero, " &
                       " CliOri.cp AS CliOri_cp,CliOri.colonia AS CliOri_colonia,  Cliori.cat_colonia as cliori_catcolonia,  Cliori.cat_localidad as cliori_catlocalidad,   Cliori.cat_ciudad as cliori_catciudad,  Cliori.cat_estado as cliori_catestado,  Cliori.cat_pais as cliori_catpais,  Cliori.rfc AS Cliori_rfc, CliOri.entre_calles AS CliOri_entre, CliOri.telefonos1 AS CliOri_tel, CliOri.contacto, CliOri.ciudad AS Cliori_ciudad, CliOri.estado AS Cliori_estado,  camiones.descripcion AS chof_descrip, " &
                       " camiones.nom_corto AS cam_nom_corto,  camiones.placas AS cam_placas,  camiones.numeroserie AS cam_numeroserie, " &
                       " camiones.numeroeconomico AS cam_numeroeco,  camiones.marca AS cam_marca,  camiones.modelo AS cam_modelo, " &
                       " camiones.dueno AS cam_dueno,  camiones.asegurador AS cam_asegurador,  camiones.poliza AS cam_poliza, camiones.PRIMASEGURO AS cam_primaseguro, camiones.numpermisosct, camiones.permsct,  camiones.configvehicular," &
                       " camiones.FECHA_VEN AS cam_fecha_ven,  choferes.operador AS chof_operador,  choferes.calle AS chof_calle,  choferes.numero AS chof_numero, " &
                       " choferes.cp AS chof_cp,  choferes.rfc AS chof_rfc, choferes.telefonos AS chof_tel,  choferes.reg_imss AS chof_regimss,  choferes.n_licencia AS chof_numlicencia, " &
                       " choferes.vencimiento AS chof_vencimiento, (SELECT TOP 1  ISNULL(DOCVEN_PED.USUARIO_AUT,'') AS USUARIO_AUT FROM DOCVEN_PED WHERE DOCVEN_PED.MOV_PED='AUT' AND DOCVEN_PED.FOLIO_DVE=" + clav.ToString + " ORDER BY FECHA_AUT DESC) AS USUARIO_AUT, 
                       remolques.placas as placas_remolque, remolques.subtiporem "

            sql = sql + "FROM          DOCVEN INNER JOIN " &
                                      " DOCVENDE ON  DOCVEN.clave =  DOCVENDE.clave INNER JOIN " &
                                          " Empresas AS emp ON  DOCVEN.EMPRESA = emp.Clave INNER JOIN " &
                                          " Cliente AS cli ON cli.clave =  DOCVEN.cliente LEFT OUTER JOIN " &
                                          " cli_suc ON cli_suc.clave =  DOCVEN.sucursal LEFT OUTER JOIN " &
                                          " zonas ON zonas.clave =  cli.zona1 LEFT OUTER JOIN " &
                                          " ClI_MOS  ON cli_MOS.clave =  DOCVEN.cli_MOS INNER JOIN " &
                                          " Producto AS p ON p.clave =  DOCVENDE.CODIGO_PRO LEFT OUTER JOIN " &
                                         " Productoalm AS palm ON STR(palm.codigo_pro)+palm.almacen =  STR(DOCVENDE.CODIGO_PRO)+DOCVENDE.ALMACEN COLLATE SQL_Latin1_General_CP1_CI_AS LEFT OUTER JOIN " &
                                          " AGENTES ON DOCVEN.VENDEDOR=AGENTES.AGENTE LEFT OUTER JOIN " &
                                          " AGENTES as chofer ON cli.CHOFER=CHOFER.AGENTE COLLATE Modern_Spanish_CI_AS LEFT OUTER JOIN " &
                                          " AGENTES as COBRADOR ON cli.COBRADOR=COBRADOR.AGENTE LEFT OUTER JOIN " &
                                          " CondicionVenta ON  DOCVEN.cond_venta =  CondicionVenta.cond_venta  left outer join " &
                                          " formapago ON formapago.clave=DOCVEN.formapago LEFT OUTER JOIN " &
                                          " series on STR(DOCVEN.EMPRESA)+docven.tipo_doc+docven.serie=STR(series.EMPRESA)+series.tipo_doc+series.nombre left outer join " +
              " choferes ON  DOCVEN.chofer =  choferes.clave left outer join" &
            " camiones ON  DOCVEN.camion =  camiones.clave left outer join " &
            " remolques ON  DOCVEN.remolques =  remolques.clave left outer join " &
            " Cliente AS CliOri ON  DOCVEN.cvecliori = CliOri.clave left outer join " &
            " Cliente AS CliDes ON  DOCVEN.cveclides = CliDes.clave  " &
     " where DOCVEN.Clave=" + clav.ToString + " AND SERIES.EMPRESA=DOCVEN.EMPRESA AND DOCVENDE.VISIBLE=1  order by DOCVENde.clave_id"



            FDataSet = common.sqlconsulta(sql, "DSTABLA")
            Me.CreateDataSources()
            FReport.RegisterData(FDataSet)
            FReport.GetDataSource("DSTABLA").Enabled = True
        Else
            infototal = common.sqlconsulta("SELECT TIPO_DOC, TOTAL_MN, MONEDA FROM DOCCOB WHERE CLAVE=" & clav, "DSDoccob")
            sql = "SELECT  emp.rfc AS ciarfc, emp.Nombre AS cianom, emp.direccion AS ciadir, emp.colonia AS ciacol, emp.ciudad AS ciacd, emp.cp AS ciacp, emp.pais AS ciapais, emp.estado AS ciaest, emp.numero AS cianum, " &
                    " empser.REGIMEN AS REGIMEN, doccob.ncertifica AS num_cert, empser.leyenda1, 'Documento elaborado por sistema Sysfe Tel '+ emp.telDis as leyenda2, empser.leyenda3, empser.IMPRESORA, empser.COPIAS," &
                    " CASE  WHEN DOCCOB.CLI_MOS=0 THEN CLI.cia ELSE CLI_MOS.nombre END AS  clinom, CASE  WHEN DOCCOB.CLI_MOS=0 THEN CLI.direccion ELSE CLI_MOS.direccion END AS clidir, CASE  WHEN DOCCOB.CLI_MOS=0 THEN CLI.colonia" &
                    " ELSE CLI_MOS.COLONIA END AS clicol, CASE  WHEN DOCCOB.CLI_MOS=0 THEN CLI.RFC ELSE CLI_MOS.RFC END AS  cliRFC, CASE  WHEN DOCCOB.CLI_MOS=0 THEN CLI.CP ELSE CLI_MOS.CP END AS clicp, CASE  WHEN DOCCOB.CLI_MOS=0" &
                    " THEN CLI.ciudad ELSE CLI_MOS.CIUDAD END AS cliciu, CASE  WHEN DOCCOB.CLI_MOS=0 THEN cli.estado ELSE CLI_MOS.ESTADO END AS cliest," &
                    " CASE  WHEN DOCCOB.CLI_MOS=0 THEN CLI.NUMERO ELSE CLI_MOS.NUMERO END AS clinum, cli.telefonos1 as clitel,cli.entre_calles, cli.pais as clipais," &
                    " p.clave AS codigo_pro,  doccobde.tiponc, p.descripcion,   DOCCOBDE.descrip_am AS descrip_am , DOCCOBDE.cantidad,  DOCCOBDE.precio_uni AS precio_uni, DOCCOBDE.porciento,  DOCCOBDE.importe_par, DOCCOBDE.iva_par," &
                    " docven.folio as foliofac,docven.total_mn as totalfac,doccobde.saldo as saldofac, docven.uuid as uuidfac,  doccob.DESCRIPCION AS NCR_DESCRIPCION, doccob.fecha_Emision, doccob.FECHA_REAL, DOCCOB.TOTAL_NO_COB, DOCCOB.VALOR_MOV," &
                    " DOCCOB.clave, DOCCOB.EMPRESA, DOCCOB.tipo_doc, DOCCOB.serie As cveser, DOCCOB.folio, doccob.tipo_mov, DOCCOB.cliente, DOCCOB.fecha_alta, doccob.banco, doccob.rfcbanco, doccob.cuenta, DOCCOB.NUMOPERACION, BANCO.RfcEmisorCtaBen, BANCO.CUENTA As CtaBeneficiario, " &
                    " DOCCOB.MONEDA, DOCCOB.TIPO_cAMBIO, DOCCOB.TOTAL_APLICADO, DOCCOB.VALOR_MN, DOCCOB.HECHO_POR, DOCCOB.AUTORIZO, DOCCOB.sub_total, DOCCOB.total_iva, DOCCOB.retiva, DOCCOB.retisr, DOCCOB.total, DOCCOB.cadenaoriginal, " &
                    " DOCCOB.sellodigital, DOCCOB.estatus, DOCCOB.estatussat, DOCCOB.fecha_baja, DOCCOB.uuid, DOCCOB.certificadosat, DOCCOB.certificadofecha, DOCCOB.sellosat, " &
                    " DOCCOB.cadenasat, DOCCOB.usocfdi, DOCCOB.afectado, empser.Formato, empser.Formatoem,'" & Letras(Convert.ToDecimal(infototal.Tables(0).Rows(0).Item("TOTAL_MN")).ToString, Convert.ToString(infototal.Tables(0).Rows(0).Item("MONEDA")).ToString) & "' AS letras," &
                    " formapago.clave+formapago.descripcion as METODOPAGO,doccob.NUMCTAPAGO, doccob.archivoxml FROM DOCCOB LEFT OUTER JOIN DOCCOBDE ON  DOCCOB.clave =  DOCCOBDE.clave LEFT OUTER JOIN " &
                    " BANCO ON  DOCCOB.bancoben =  BANCO.clave LEFT OUTER JOIN Empresas AS emp ON  DOCCOB.EMPRESA = emp.Clave LEFT OUTER JOIN " &
                    " series  AS empser on str(doccob.empresa)+doccob.tipo_doc+doccob.serie=str(empser.empresa)+empser.tipo_doc+empser.nombre LEFT OUTER JOIN " &
                    " Cliente AS cli ON cli.clave =  DOCCOB.CLIENTE  left outer join cli_mos on doccob.CLI_MOS=CLI_MOS.clave LEFT OUTER JOIN " &
                    " DOCVEN on DOCVEN.clave=" + IIf(infototal.Tables(0).Rows(0).Item("TIPO_DOC") = "NCR", "doccobde.folio_dve_ref ", "doccobde.folio_dve") + "  LEFT OUTER JOIN " &
                    " Producto AS p ON p.clave =  DOCCOBDE.CODIGO_PRO left outer join " &
                    " formapago ON formapago.clave=DOCcob.formapago where " & IIf(infototal.Tables(0).Rows(0).Item("TIPO_DOC") = "NCR", "not doccobde.folio_dve_ref  is null and ", "") & " empser.activo = 1 And doccob.Clave = " & Convert.ToInt32(clav).ToString &
                    " ORDER BY  DOCCOB.clave DESC "
            FDataSet = common.sqlconsulta(sql, "DSDoccob")
            sql = "Select docven.uuid As dv_uuid,doccobde.*, docven.saldo_mn as Saldofac from doccobde LEFT OUTER Join  DOCVEN on DOCVEN.clave=" + IIf(infototal.Tables(0).Rows(0).Item("TIPO_DOC") = "NCR",
                        "doccobde.folio_dve_ref ", "doccobde.folio_dve") + " where doccobde.folio_dve_ref Is null And doccobde.clave =" & clav
            FDataSetdetalle = common.sqlconsulta(sql, "DSDoccobAplicacion")
            Me.CreateDataSources()
            FReport.RegisterData(FDataSet)
            FReport.RegisterData(FDataSetdetalle)
            FReport.GetDataSource("DSDoccob").Enabled = True
            FReport.GetDataSource("DSDoccobAplicacion").Enabled = True
        End If
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
