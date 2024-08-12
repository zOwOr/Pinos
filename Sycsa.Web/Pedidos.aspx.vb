Public Class Pedidos
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

        'AND NOT (estatus='CAN' OR estatus='PEN') AND SALDO_MN>0
        DataSet = common.sqlconsulta("SELECT [CLAVE] ,[EMPRESA] ,[TIPO_DOC] ,[FOLIO] ,[CLIENTE] ,[FECHA_ALTA] ,[FECHA_BAJA] ,[ORDEN_COMP] ,[LISTA] ,[DESC_VOL] ,[SUB_TOTAL] ,[TOT_IVA] ,[TOTAL] ,[TOTAL_MN] ,[SALDO_MN] ,[ESTATUS],[ARCHIVOXML]  FROM [DOCVEN]  where TIPO_DOC='PED' AND cliente = " & id, "dProducto")
        ListProducts.DataSource = DataSet

        ListProducts.DataBind()
    End Sub
    Protected Sub ListProducts_ItemCommand(sender As Object, e As ListViewCommandEventArgs) Handles ListProducts.ItemCommand
        If e.CommandName = "Imprimir" Then
            Dim queryString As String = "/Default.aspx?clav=" & e.CommandArgument.ToString() & "&name_report=" & "pedido.frx"

            Dim newWin As String = "window.open('" & queryString & "','Pedidos','height=550, width=870,toolbar=no,directories=no,status=no, menubar=no,scrollbars=yes,resizable=no');"

            ClientScript.RegisterStartupScript(Me.GetType(), "Pedidos", newWin, True)
        End If
        BindListView()
    End Sub
End Class