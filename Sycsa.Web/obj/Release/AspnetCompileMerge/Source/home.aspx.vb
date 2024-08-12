Public Class home
    Inherits System.Web.UI.Page
    Public common As New CONECTASQL.ConectaSQL
    Public Html As New vpublic
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Carrito de compras"

        If IsPostBack = False Then
            'If Session("MM_CLIENTE") IsNot Nothing Then
            BindData()
            'End If

        End If
    End Sub
    Sub BindData()
        Dim DataSet As New DataSet
        Dim id As String = IIf(Session("MM_CLIENTE") Is Nothing, "0", Session("MM_CLIENTE"))

        Dim sql As String = "Select top 5 VW_DOCVEN.tipo_doc,  VW_DOCVEN.folio, VW_DOCVEN.FECHA_ALTA AS fecha, docvende.cantidad,  docvende.unidad , docvende.codigo_pro as IdProduct , producto.descripcion as Producto , docvende.precio_uni , docvende.t_desc_vol, isnull(docvende.tasa_iva,16) as tasa_iva,  docvende.tasa_ieps , docvende.DESCRIP_AM, docvende.cantidad_unidad, docvende.descrip_am From   VW_DOCVEN inner join docvende on VW_DOCVEN.clave = docvende.clave  inner join producto on docvende.codigo_pro = producto.clave where  VW_DOCVEN.TIPO_DOC LIKE 'PED'   AND  VW_DOCVEN.CLIENTE = " & id & "  AND   VW_DOCVEN.empresa = 1 ORDER BY  VW_DOCVEN.CLAVE DESC"
        DataSet = common.sqlconsulta(sql, "dProducto")
        gvListProductos.DataSource = DataSet
        gvListProductos.DataBind()

    End Sub
    Protected Sub gvListProductos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvListProductos.RowCommand

        Try
            If e.CommandName = "Update" Then

                For Each _row As GridViewRow In gvListProductos.Rows
                    If _row.RowType = DataControlRowType.DataRow Then

                        Try

                            Dim productId As String() = e.CommandArgument.ToString().Split(",")
                            Dim cantidad As TextBox = _row.Cells(2).FindControl("txtCantidad")
                            Dim Cart As ShoppingCart = ShoppingCart.CapturarProducto()
                            Cart.Agregar(productId(0), CType(cantidad.Text, Int64), productId(1))

                        Catch ex As Exception
                        End Try

                    End If
                Next

            End If

            Html.updElemntsCart()
            Response.Redirect(Request.Url.AbsoluteUri)

        Catch ex As Exception

        End Try

    End Sub
End Class