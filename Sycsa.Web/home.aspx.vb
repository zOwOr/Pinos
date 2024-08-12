Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Xml
Imports Org.BouncyCastle.Crypto.Generators
Imports sycsa.Information
Imports sycsa.BusinessLayer
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Public Class home
    Inherits System.Web.UI.Page

    Public common As New CONECTASQL.ConectaSQL
    Public Html As New vpublic
    Dim _cokiePagedProducts As HttpCookie = New HttpCookie("_PagedProducts")
    Dim _Script As String
    Public Property WebmailUrl As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Carrito de compras"

        If Not IsPostBack Then
            LoadConnectionSettings()
            hlProduct.NavigateUrl = WebmailUrl

            ' Asigna la URL al Literal para depuración
            Dim litUrl As Literal = CType(FindControl("litUrl"), Literal)
            If litUrl IsNot Nothing Then
                litUrl.Text = "URL cargada: " & WebmailUrl
            End If
            BindData()

        Else
            'Add cart
            Dim _Event As String = Request.Params("__EVENTTARGET")
            Dim _Param As String = Request.Params("__EVENTARGUMENT")
            Html._Lista = IIf(Session("MM_Lista") Is Nothing, 0, Session("MM_Lista"))

            If _Event = "addCart" Then
                Dim TestArray() As String = _Param.Split(","c)
                Dim Cart As ShoppingCart = ShoppingCart.CapturarProducto()
                Cart.Agregar(CType(TestArray(0), Int64), CDbl(TestArray(2)), TestArray(1))

                Html.updElemntsCart()
                _Script = "messenger('box_messenger','alert info','Tu producto se agregó al carrito');"
                ScriptManager.RegisterStartupScript(Me, GetType(Page), "messenger", _Script, True)
                BindData()
            ElseIf _Event = "addAllToCart" Then
                Dim items() As String = _Param.Split("|"c)
                Dim Cart As ShoppingCart = ShoppingCart.CapturarProducto()
                Dim errorMessage As String = String.Empty

                For Each item As String In items
                    Dim TestArray() As String = item.Split(","c)

                    If TestArray.Length >= 3 AndAlso IsNumeric(TestArray(0)) AndAlso IsNumeric(TestArray(2)) Then
                        Dim productId As Long = CType(TestArray(0), Long)
                        Dim quantity As Double = CDbl(TestArray(2))
                        Dim description As String = TestArray(1)

                        Cart.Agregar(productId, quantity, description)
                    Else
                        errorMessage = "Error al agregar algunos productos al carrito. Datos inválidos."
                    End If
                Next

                Html.updElemntsCart()
                _Script = If(String.IsNullOrEmpty(errorMessage),
                     "messenger('box_messenger','alert info','Todos los productos se agregaron al carrito');",
                     $"messenger('box_messenger','alert error','{errorMessage}');")
                ScriptManager.RegisterStartupScript(Me, GetType(Page), "messenger", _Script, True)
                BindData()
            End If


        End If
    End Sub



    Sub HandlePostBack()
        Dim _Event As String = Request.Params("__EVENTTARGET")
        Dim _Param As String = Request.Params("__EVENTARGUMENT")
        Dim TestArray() As String = _Param.Split(",")
        Html._Lista = IIf(Session("MM_Lista") Is Nothing, 0, Session("MM_Lista"))

        If _Event = "addCart" Then
            Dim Cart As ShoppingCart = ShoppingCart.CapturarProducto()
            Cart.Agregar(CType(TestArray(0), Int64), CDbl(TestArray(2)), TestArray(1))
            Html.updElemntsCart()
            _Script = "messenger('box_messenger','alert info','Tu producto se agrego al carrito');"
            ScriptManager.RegisterStartupScript(Me, GetType(Page), "mensseger", _Script, True)
            BindData()
        End If
    End Sub

    Sub BindData()

        Dim showcart As New ShowCart
        Dim showcartToltip As New SiteWeb
        Dim precio As String
        Dim DataSet As New DataSet


        If Session("MM_CLIENTE") Is Nothing Then
            precio = "producto_unidad.precio_V1 as UnitPrice,"
        Else
            precio = "producto_unidad.precio_V" & Session("MM_CLIENTE") & " as UnitPrice,"
        End If

        Dim id As String = IIf(Session("MM_CLIENTE") Is Nothing, "0", Session("MM_CLIENTE"))

        Dim sql As String = "Select  VW_DOCVEN.tipo_doc,  VW_DOCVEN.folio, VW_DOCVEN.FECHA_ALTA AS fecha, docvende.cantidad,  docvende.unidad , docvende.codigo_pro as IdProduct , producto.descripcion as Producto, producto.imagen as ProductImagen , docvende.precio_uni , docvende.t_desc_vol, isnull(docvende.tasa_iva,16) as tasa_iva,  docvende.tasa_ieps , docvende.DESCRIP_AM, docvende.cantidad_unidad, docvende.descrip_am From   VW_DOCVEN inner join docvende on VW_DOCVEN.clave = docvende.clave  inner join producto on docvende.codigo_pro = producto.clave where  VW_DOCVEN.TIPO_DOC = 'FAC'   AND  VW_DOCVEN.CLIENTE = " & id & "  AND   VW_DOCVEN.empresa = 1 ORDER BY  VW_DOCVEN.CLAVE DESC"
        DataSet = common.sqlconsulta(sql, "dProducto")
        gvListProductos.DataSource = DataSet
        gvListProductos.DataBind()
        showcart.updateCarrito()
        showcartToltip.updateCarrito()

    End Sub
    Function LoadListProducts(_id As String, _type As String)
        Dim DataSet As DataSet
        Dim _Query As String
        Dim precio As String

        If Session("MM_Lista") Is Nothing Then
            precio = "producto_unidad.precio_V1 as UnitPrice,"
        Else
            precio = "producto_unidad.precio_V" & Session("MM_Lista") & " as UnitPrice,"
        End If

        _Query = "Select producto.clave as ProductID, producto_unidad.unidad as Unidad, producto.codigo_pro as ProductName, producto.descripcion as shortDescription, " & precio & " producto_unidad.precio_V1_II, producto.familia as Categoria, producto.sub_fam as Subcategoria, producto.moneda, producto.codigo_bar, producto.codigo_pv, producto.marca as Marca, producto.imagen as ProductImagen From producto inner join producto_unidad on producto.clave=producto_unidad.clave"

        If _type = "C" Then

            _Query += " where PRODUCTO.EMPRESA=1 AND PRODUCTO.VENTA=1 and PRODUCTO.en_linea=1 and producto.familia ='" & _id & "'"

        ElseIf _type = "SC" Then

            _Query += " where PRODUCTO.EMPRESA=1 AND PRODUCTO.VENTA=1 and PRODUCTO.en_linea=1 and producto.sub_fam ='" & _id & "'"

        ElseIf _type = "M" Then

            _Query += " where PRODUCTO.EMPRESA=1 AND PRODUCTO.VENTA=1 and PRODUCTO.en_linea=1 and producto.MARCA ='" & _id & "'"

        ElseIf _type = "ALL" Then

            _Query += " where PRODUCTO.EMPRESA=1 AND PRODUCTO.VENTA=1 and PRODUCTO.en_linea=1"

        End If

        DataSet = common.sqlconsulta(_Query, "dProducto")

        Return DataSet
    End Function

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

    Sub LoadConnectionSettings()
        Dim xmlPath As String = Server.MapPath("~/local/sql.data.dll.xml")
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(xmlPath)

        Dim urlNode As XmlNode = xmlDoc.SelectSingleNode("/NewDataSet/Conexion/webmail")
        If urlNode IsNot Nothing Then
            WebmailUrl = urlNode.InnerText
            System.Diagnostics.Debug.WriteLine("URL cargada del XML: " & WebmailUrl)
        Else
            WebmailUrl = String.Empty
            System.Diagnostics.Debug.WriteLine("No se encontró la URL en el XML.")
        End If
    End Sub


    Protected Sub btnUseUrl_Click(sender As Object, e As EventArgs)
        Dim webmail As String = WebmailUrl
        System.Diagnostics.Debug.WriteLine("Botón clickeado. URL: " & webmail)

        If Not String.IsNullOrEmpty(webmail) Then
            Try
                ' Verifica que la URL sea válida
                If Uri.IsWellFormedUriString(webmail, UriKind.Absolute) Then
                    Response.Redirect(webmail)
                Else
                    System.Diagnostics.Debug.WriteLine("La URL no es válida: " & webmail)
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("Error al redirigir: " & ex.Message)
            End Try
        Else
            System.Diagnostics.Debug.WriteLine("La URL es vacía o no válida.")
        End If
    End Sub


End Class
