Imports System
Imports sycsa.Information
Imports sycsa.BusinessLayer
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Xml
Imports sycsa.DataAccessLayer
Public Class Cobranza
    Inherits System.Web.UI.Page
    Public Html As New vpublic
    Dim clav As String = String.Empty
    Dim _cokiePagedProducts As HttpCookie = New HttpCookie("_PagedProducts")
    Public common As New CONECTASQL.ConectaSQL
    Public reports As New _Default

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("MM_UserId") Is Nothing Then

            Dim httpReference As String
            httpReference = Page.Request.Url.AbsoluteUri.ToString
            httpReference = ResolveUrl(httpReference)
            Session("PageReferent") = httpReference
            Response.Redirect("~/Login.aspx?", True)
        End If
        If IsPostBack = False Then
            BindListView()
        End If
    End Sub
    Private Sub BindListView()
        Dim DataSet As New DataSet
        Dim id As String = IIf(Session("MM_CLIENTE") Is Nothing, "0", Session("MM_CLIENTE"))


        DataSet = common.sqlconsulta("SELECT [CLAVE] ,[EMPRESA] ,[TIPO_DOC] ,[FOLIO] ,[CLIENTE] ,[FECHA_ALTA] ,[FECHA_BAJA] ,[FECHA_REAL] ,[TOTAL_APLICADO] ,[ESTATUS], [ESTATUSSAT],[ARCHIVOXML]  FROM [DOCCOB]  where estatus <> 'CAN' and estatus <> 'PEN' and cliente = " & id, "dProducto")
        ListProducts.DataSource = DataSet

        ListProducts.DataBind()
    End Sub
    Protected Sub ListProducts_ItemCommand(sender As Object, e As ListViewCommandEventArgs) Handles ListProducts.ItemCommand
        If e.CommandName = "Imprimir" Then
            Dim args() As String = e.CommandArgument.ToString().Split(";")
            Dim tipo_doc As String = args(1).ToString()
            Dim clave As String = args(0).ToString()
            Dim queryString As String = "/Default.aspx?clav=" & clave & "&name_report=" & IIf(tipo_doc = "COB", "cobranza.frx", "notadecredito.frx")

            Dim newWin As String = "window.open('" & queryString & "','Cobranzas','height=550, width=870,toolbar=no,directories=no,status=no, menubar=no,scrollbars=yes,resizable=no');"

            ClientScript.RegisterStartupScript(Me.GetType(), "Facturas", newWin, True)
        ElseIf e.CommandName = "ImprimirXML" Then
            ReturmXML(e.CommandArgument.ToString())
        End If
        BindListView()
    End Sub
    Private Sub ReturmXML(clave As String)
        Dim DataSet As New DataSet
        Dim id As String = IIf(Session("MM_CLIENTE") Is Nothing, "0", Session("MM_CLIENTE"))
        DataSet = common.sqlconsulta("SELECT [FOLIO],[ARCHIVOXML] FROM [DOCCOB]  where cliente = " & id & " and clave=" & clave, "dProducto")
        Dim doc As XmlDocument = New XmlDocument()
        Dim foliocob As String = DataSet.Tables(0).Rows(0).Item("FOLIO").ToString
        Dim nombre_archivo As String = RTrim(Session("EMP_RFC")) + RTrim(foliocob) + ".xml"
        If String.IsNullOrWhiteSpace(DataSet.Tables(0).Rows(0).Item("ARCHIVOXML").ToString) Then
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
    Private Function RemoveSpecialCharacters(str As String) As String
        Return Regex.Replace(str, "[^a-zA-Z0-9_.- ]+", "", RegexOptions.Compiled)
    End Function

    'Protected Sub chFill_CheckedChanged(sender As Object, e As EventArgs) Handles chFill.CheckedChanged
    '    If chFill.Checked = True Then
    '        Dim DataSet As New DataSet
    '        Dim id As String = IIf(Session("MM_CLIENTE") Is Nothing, "0", Session("MM_CLIENTE"))


    '        DataSet = common.sqlconsulta("SELECT [CLAVE] ,[EMPRESA] ,[TIPO_DOC] ,[FOLIO] ,[CLIENTE] ,[FECHA_ALTA] ,[FECHA_BAJA] ,[ORDEN_COMP] ,[LISTA] ,[DESC_VOL] ,[SUB_TOTAL] ,[TOT_IVA] ,[TOTAL] ,[TOTAL_MN] ,[SALDO_MN] ,[ESTATUS],[ARCHIVOXML]  FROM [DOCVEN]  where TIPO_DOC='FAC'  and cliente = " & id & " and SALDO_MN > 0", "dProducto")
    '        ListProducts.DataSource = DataSet

    '        ListProducts.DataBind()
    '    Else
    '        BindListView()
    '    End If

    'End Sub

End Class