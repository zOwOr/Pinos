Imports System.Xml

Public Class Productos
    Inherits System.Web.UI.Page

    Public Html As New vpublic
    Dim _cokiePagedProducts As HttpCookie = New HttpCookie("_PagedProducts")
    Public common As New CONECTASQL.ConectaSQL
    Dim _Script As String



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim pageNumber As Integer = If(Request.QueryString("page") Is Nothing, 1, Convert.ToInt32(Request.QueryString("page")))

        If Not IsPostBack Then
            ScriptManager.RegisterStartupScript(Me, GetType(Page), "clearLocalStorage", "localStorage.clear();", True)
            Dim productCount As Integer = GetProductCount()
            lblProductCount.Text = "Total de productos: " & productCount.ToString()

            Dim modalToShow As String = Request.QueryString("modal")
            If Not String.IsNullOrEmpty(modalToShow) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "showModal", $"$(document).ready(function() {{ $('#{modalToShow}').modal('show'); }});", True)
            End If

            SetSearchControls()
            LoadDropDownLists()
            RestoreSelectedValues()
            BindListView(pageNumber)

        Else
            Dim _Event As String = Request.Params("__EVENTTARGET")
            Dim _Param As String = Request.Params("__EVENTARGUMENT")
            Html._Lista = If(Session("MM_Lista") Is Nothing, 0, Session("MM_Lista"))

            If _Event = "addCart" Then
                Dim TestArray() As String = _Param.Split(","c)
                Dim Cart As ShoppingCart = ShoppingCart.CapturarProducto()
                Cart.Agregar(CType(TestArray(0), Int64), CDbl(TestArray(2)), TestArray(1))

                Html.updElemntsCart()
                _Script = "messenger('box_messenger','alert info','Tu producto se agregó al carrito');"
                ScriptManager.RegisterStartupScript(Me, GetType(Page), "messenger", _Script, True)
                BindListView(pageNumber)  ' Mantén la paginación
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
                BindListView(pageNumber)  ' Mantén la paginación
            End If
        End If
    End Sub


    Private Function GetProductCount() As Integer
        Dim _Query As String
        Dim count As Integer = 0
        Dim searchTerms As String = Request.QueryString("searchTerm")
        Dim searchField As String = Request.QueryString("searchField")
        Dim paramC As String = Request.QueryString("paramC")
        Dim paramSC As String = Request.QueryString("paramSC")

        _Query = "SELECT COUNT(*) FROM producto " &
        "INNER JOIN producto_unidad ON producto.clave = producto_unidad.clave " &
        "WHERE PRODUCTO.EMPRESA = 1 AND PRODUCTO.VENTA = 1 AND PRODUCTO.en_linea = 1 "

        If Not String.IsNullOrEmpty(paramC) Then
            _Query += "AND producto.familia = '" & paramC & "' "
        End If

        If Not String.IsNullOrEmpty(paramSC) Then
            _Query += "AND producto.sub_fam = '" & paramSC & "' "
        End If

        If Not String.IsNullOrEmpty(searchTerms) Then
            Dim terms() As String = searchTerms.Split(" "c)
            Dim searchConditions As New List(Of String)

            If searchField = "all" Then
                searchConditions.AddRange(terms.Select(Function(term) $"producto.codigo_pro LIKE '%{term}%' OR producto.descripcion LIKE '%{term}%' OR producto.codigo_pv LIKE '%{term}%' OR producto.codigo_fac LIKE '%{term}%' OR producto.marca LIKE '%{term}%' OR producto.imagen LIKE '%{term}%' OR producto.clave LIKE '%{term}%'"))
            Else
                searchConditions.AddRange(terms.Select(Function(term) $"producto.{searchField} LIKE '%{term}%'"))
            End If

            _Query += "AND (" & String.Join(" AND ", searchConditions) & ") "
        End If

        count = Convert.ToInt32(common.sqlconsulta(_Query, "countTable").Tables(0).Rows(0)(0))
        Return count
    End Function








    Public Function GetCategoryDisplay(category As Object) As String
        If category Is DBNull.Value OrElse category Is Nothing OrElse category.ToString().Trim() = String.Empty Then
            Return "Sin Categoria"
        End If
        Return category.ToString()
    End Function

    Public Function Getcodigo_facDisplay(codigo_fac As Object) As String
        If codigo_fac Is DBNull.Value OrElse codigo_fac Is Nothing OrElse codigo_fac.ToString().Trim() = String.Empty Then
            Return "Sin Codigo Fac"
        End If
        Return codigo_fac.ToString()
    End Function

    Public Function Getcodigo_pvDisplay(codigo_pv As Object) As String
        If codigo_pv Is DBNull.Value OrElse codigo_pv Is Nothing OrElse codigo_pv.ToString().Trim() = String.Empty Then
            Return "Sin Codigo PV"
        End If
        Return codigo_pv.ToString()
    End Function

    Private Sub BindListView(pageNumber As Integer)
        Dim pageSize As Integer = 10
        Dim searchTerm As String = Request.QueryString("searchTerm")
        Dim searchField As String = Request.QueryString("searchField")
        Dim paramC As String = Request.QueryString("paramC")
        Dim paramSC As String = Request.QueryString("paramSC")

        ' Establecer filtros según los valores seleccionados en los DropDownList
        If ddlFamilia.SelectedValue <> "" Then
            paramC = ddlFamilia.SelectedValue
        End If

        If ddlSubfamilia.SelectedValue <> "" Then
            paramSC = ddlSubfamilia.SelectedValue
        End If

        ' Llamar a LoadListProducts con los parámetros adecuados
        ListProducts.DataSource = LoadListProducts(Nothing, Nothing, pageNumber, pageSize, searchTerm, searchField)
        ListProducts.DataBind()
        GeneratePagination(pageNumber, pageSize)
    End Sub



    Private Sub SetSearchControls()
        ' Recupera los parámetros de búsqueda de la consulta
        Dim searchTerm As String = Request.QueryString("searchTerm")
        Dim searchFieldValue As String = Request.QueryString("searchField")
        Dim paramC As String = Request.QueryString("paramC")
        Dim paramSC As String = Request.QueryString("paramSC")

        ' Establece el texto del TextBox
        If Not String.IsNullOrEmpty(searchTerm) Then
            SearchBox.Text = Server.UrlDecode(searchTerm)
        End If

        ' Establece el valor seleccionado del DropDownList de búsqueda
        If Not String.IsNullOrEmpty(searchFieldValue) Then
            If searchField.Items.FindByValue(searchFieldValue) IsNot Nothing Then
                searchField.SelectedValue = searchFieldValue
            End If
        End If

        ' Establece el valor seleccionado de Familia
        If Not String.IsNullOrEmpty(paramC) Then
            If ddlFamilia.Items.FindByValue(paramC) IsNot Nothing Then
                ddlFamilia.SelectedValue = paramC
            End If
        End If

        ' Establece el valor seleccionado de Subfamilia
        If Not String.IsNullOrEmpty(paramSC) Then
            If ddlSubfamilia.Items.FindByValue(paramSC) IsNot Nothing Then
                ddlSubfamilia.SelectedValue = paramSC
            End If
        End If
    End Sub



    Protected Sub SearchButton_Click(sender As Object, e As EventArgs)
        Dim searchTerm As String = SearchBox.Text.Trim() ' Accede al texto del TextBox
        Dim searchFieldValue As String = searchField.SelectedValue ' Accede al valor seleccionado del DropDownList
        Dim paramC As String = ddlFamilia.SelectedValue
        Dim paramSC As String = ddlSubfamilia.SelectedValue
        Response.Redirect($"Productos.aspx?page=1&searchTerm={Server.UrlEncode(searchTerm)}&searchField={Server.UrlEncode(searchFieldValue)}&paramC={Server.UrlEncode(paramC)}&paramSC={Server.UrlEncode(paramSC)}")
    End Sub






    Private Sub GeneratePagination(pageNumber As Integer, pageSize As Integer)
        Dim totalRecords As Integer = GetProductCount()  ' Usa el conteo filtrado
        Dim totalPages As Integer = Math.Ceiling(totalRecords / pageSize)
        Dim maxPagesToShow As Integer = 5
        Dim halfPagesToShow As Integer = Math.Floor(maxPagesToShow / 2)

        Dim startPage As Integer = Math.Max(1, pageNumber - halfPagesToShow)
        Dim endPage As Integer = Math.Min(totalPages, pageNumber + halfPagesToShow)

        If startPage > 1 Then
            startPage = Math.Max(1, endPage - maxPagesToShow + 1)
        End If

        If endPage < totalPages Then
            endPage = Math.Min(totalPages, startPage + maxPagesToShow - 1)
        End If

        Dim paginationHtml As String = "<nav aria-label='Page navigation'><ul class='pagination justify-content-center'>"

        ' Parámetros de búsqueda
        Dim searchTerm As String = Server.UrlEncode(Request.QueryString("searchTerm"))
        Dim searchField As String = Server.UrlEncode(Request.QueryString("searchField"))
        Dim paramC As String = Server.UrlEncode(Request.QueryString("paramC"))
        Dim paramSC As String = Server.UrlEncode(Request.QueryString("paramSC"))

        If pageNumber > 1 Then
            paginationHtml &= $"<li class='page-item'><a class='page-link' href='Productos.aspx?page={pageNumber - 1}&searchTerm={searchTerm}&searchField={searchField}&paramC={paramC}&paramSC={paramSC}' aria-label='Previous'><span aria-hidden='true'>&laquo;</span><span class='sr-only'>Anterior</span></a></li>"
        Else
            paginationHtml &= "<li class='page-item disabled'><a class='page-link' href='#' aria-label='Previous'><span aria-hidden='true'>&laquo;</span><span class='sr-only'>Anterior</span></a></li>"
        End If

        If startPage > 1 Then
            paginationHtml &= $"<li class='page-item'><a class='page-link' href='Productos.aspx?page=1&searchTerm={searchTerm}&searchField={searchField}&paramC={paramC}&paramSC={paramSC}'>1</a></li>"
            If startPage > 2 Then
                paginationHtml &= "<li class='page-item disabled'><span class='page-link'>...</span></li>"
            End If
        End If

        For i As Integer = startPage To endPage
            If i = pageNumber Then
                paginationHtml &= $"<li class='page-item active'><span class='page-link'>{i}<span class='sr-only'>(current)</span></span></li>"
            Else
                paginationHtml &= $"<li class='page-item'><a class='page-link' href='Productos.aspx?page={i}&searchTerm={searchTerm}&searchField={searchField}&paramC={paramC}&paramSC={paramSC}'>{i}</a></li>"
            End If
        Next

        If endPage < totalPages Then
            If endPage < totalPages - 1 Then
                paginationHtml &= "<li class='page-item disabled'><span class='page-link'>...</span></li>"
            End If
            paginationHtml &= $"<li class='page-item'><a class='page-link' href='Productos.aspx?page={totalPages}&searchTerm={searchTerm}&searchField={searchField}&paramC={paramC}&paramSC={paramSC}'>{totalPages}</a></li>"
        End If

        If pageNumber < totalPages Then
            paginationHtml &= $"<li class='page-item'><a class='page-link' href='Productos.aspx?page={pageNumber + 1}&searchTerm={searchTerm}&searchField={searchField}&paramC={paramC}&paramSC={paramSC}' aria-label='Next'><span aria-hidden='true'>&raquo;</span><span class='sr-only'>Siguiente</span></a></li>"
        Else
            paginationHtml &= "<li class='page-item disabled'><a class='page-link' href='#' aria-label='Next'><span aria-hidden='true'>&raquo;</span><span class='sr-only'>Siguiente</span></a></li>"
        End If

        paginationHtml &= "</ul></nav>"

        PaginationPlaceholder.Controls.Add(New LiteralControl(paginationHtml))
    End Sub





    Sub BindData()
        Dim showcart As New ShowCart
        Dim showcartToltip As New SiteWeb
        showcart.updateCarrito()
        showcartToltip.updateCarrito()
    End Sub

    Private Function LoadListProducts(_id As String, _type As String, pageNumber As Integer, pageSize As Integer, searchTerm As String, searchField As String) As DataSet
        Dim DataSet As DataSet
        Dim _Query As String
        Dim precio As String

        Dim showPrice As Boolean = GetShowPriceSetting()


        If showPrice OrElse Session("MM_Lista") IsNot Nothing Then
            If Session("MM_Lista") Is Nothing Then
                precio = "producto_unidad.precio_V1 as UnitPrice,"
            Else
                precio = "producto_unidad.precio_V" & Session("MM_Lista") & " as UnitPrice,"
            End If
        Else
            ' Si no se debe mostrar el precio
            precio = "'Iniciar sesión para mostrar precio' as UnitPrice,"
        End If

        Dim offset As Integer = (pageNumber - 1) * pageSize

        _Query = "SELECT producto.clave as ProductID, producto_unidad.unidad as Unidad, producto.codigo_pro as ProductName, producto.descripcion as shortDescription, " & precio & " producto_unidad.precio_V1_II, producto.familia as Categoria, producto.sub_fam as Subcategoria, producto.moneda, producto.codigo_bar, producto.codigo_pv, producto.codigo_fac, producto.marca as Marca, producto.imagen as ProductImagen, iif(existencias.cant_act < 100, 'BAJA',iif(existencias.cant_act < 200, 'MEDIA',iif(existencias.cant_act > 200, 'ALTA',''))) AS EXISTENCIA " &
        "FROM producto " &
        "INNER JOIN producto_unidad ON producto.clave = producto_unidad.clave " &
        "left outer JOIN existencias ON producto.clave = existencias.codigo_pro " &
        "WHERE PRODUCTO.EMPRESA = 1 AND PRODUCTO.VENTA = 1 AND PRODUCTO.en_linea = 1 "

        ' Añadir filtros de Familia y Subfamilia si están seleccionados
        If Not String.IsNullOrEmpty(_id) Then
            Select Case _type
                Case "C"
                    _Query += "AND producto.familia = '" & _id & "' "
                Case "SC"
                    _Query += "AND producto.sub_fam = '" & _id & "' "
                Case "M"
                    _Query += "AND producto.MARCA = '" & _id & "' "
            End Select
        End If

        ' Añadir filtro de Familia y Subfamilia si ambos están seleccionados
        Dim paramC As String = Request.QueryString("paramC")
        Dim paramSC As String = Request.QueryString("paramSC")
        If Not String.IsNullOrEmpty(paramC) Then
            _Query += "AND producto.familia = '" & paramC & "' "
        End If
        If Not String.IsNullOrEmpty(paramSC) Then
            _Query += "AND producto.sub_fam = '" & paramSC & "' "
        End If

        ' Añadir filtro de búsqueda
        If Not String.IsNullOrEmpty(searchTerm) Then
            Dim terms() As String = searchTerm.Split(" "c)
            Dim searchConditions As New List(Of String)

            If searchField = "all" Then
                searchConditions.AddRange(terms.Select(Function(term) $"producto.codigo_pro LIKE '%{term}%' OR producto.descripcion LIKE '%{term}%' OR producto.codigo_pv LIKE '%{term}%' OR producto.codigo_fac LIKE '%{term}%' OR producto.marca LIKE '%{term}%' OR producto.imagen LIKE '%{term}%' OR producto.clave LIKE '%{term}%'"))
            Else
                searchConditions.AddRange(terms.Select(Function(term) $"producto.{searchField} LIKE '%{term}%'"))
            End If

            _Query += "AND (" & String.Join(" AND ", searchConditions) & ") "
        End If

        _Query += "ORDER BY producto.clave OFFSET " & offset & " ROWS FETCH NEXT " & pageSize & " ROWS ONLY"

        DataSet = common.sqlconsulta(_Query, "dProducto")

        Return DataSet
    End Function





    Private Sub LoadDropDownLists()
        Dim query As String = "SELECT DISTINCT familia FROM producto WHERE EMPRESA = 1 AND VENTA = 1 AND en_linea = 1 ORDER BY familia"
        Dim dtFamilia As DataTable = common.sqlconsulta(query, "Familias").Tables(0)
        ddlFamilia.DataSource = dtFamilia
        ddlFamilia.DataTextField = "familia"
        ddlFamilia.DataValueField = "familia"
        ddlFamilia.DataBind()
        ddlFamilia.Items.Insert(0, New ListItem("Seleccione Familia", ""))

        query = "SELECT DISTINCT sub_fam FROM producto WHERE EMPRESA = 1 AND VENTA = 1 AND en_linea = 1 ORDER BY sub_fam"
        Dim dtSubfam As DataTable = common.sqlconsulta(query, "Subfamilias").Tables(0)
        ddlSubfamilia.DataSource = dtSubfam
        ddlSubfamilia.DataTextField = "sub_fam"
        ddlSubfamilia.DataValueField = "sub_fam"
        ddlSubfamilia.DataBind()
        ddlSubfamilia.Items.Insert(0, New ListItem("Seleccione Subfamilia", ""))
    End Sub

    Private Sub RestoreSelectedValues()
        ' Recupera los parámetros de búsqueda de la consulta
        Dim paramC As String = Request.QueryString("paramC")
        Dim paramSC As String = Request.QueryString("paramSC")

        ' Restaura el valor seleccionado de Familia
        If Not String.IsNullOrEmpty(paramC) Then
            If ddlFamilia.Items.FindByValue(paramC) IsNot Nothing Then
                ddlFamilia.SelectedValue = paramC
            End If
        End If

        ' Restaura el valor seleccionado de Subfamilia
        If Not String.IsNullOrEmpty(paramSC) Then
            If ddlSubfamilia.Items.FindByValue(paramSC) IsNot Nothing Then
                ddlSubfamilia.SelectedValue = paramSC
            End If
        End If
    End Sub

    Protected Sub ddlFamilia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFamilia.SelectedIndexChanged
        Dim url As String = $"Productos.aspx?page=1&paramC={Server.UrlEncode(ddlFamilia.SelectedValue)}&paramSC={Server.UrlEncode(ddlSubfamilia.SelectedValue)}&searchTerm={Server.UrlEncode(SearchBox.Text)}&searchField={Server.UrlEncode(searchField.SelectedValue)}"
        Response.Redirect(url)
    End Sub

    Protected Sub ddlSubfamilia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSubfamilia.SelectedIndexChanged
        Dim url As String = $"Productos.aspx?page=1&paramC={Server.UrlEncode(ddlFamilia.SelectedValue)}&paramSC={Server.UrlEncode(ddlSubfamilia.SelectedValue)}&searchTerm={Server.UrlEncode(SearchBox.Text)}&searchField={Server.UrlEncode(searchField.SelectedValue)}"
        Response.Redirect(url)
    End Sub



    Public Function GetTotalRecords() As Integer
        Dim _Query As String = "SELECT COUNT(*) FROM producto WHERE PRODUCTO.EMPRESA = 1 AND PRODUCTO.VENTA = 1 AND PRODUCTO.en_linea = 1"
        Dim totalRecords As Integer = Convert.ToInt32(common.sqlconsulta(_Query, "totalRecords").Tables(0).Rows(0)(0))
        Return totalRecords
    End Function


    Private Function GetShowPriceSetting() As Boolean
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(Server.MapPath("~/local/sql.data.dll.xml")) ' Ruta al archivo XML

        Dim node As XmlNode = xmlDoc.SelectSingleNode("/NewDataSet/Conexion/Preciologuin")
        If node IsNot Nothing Then
            Return Boolean.Parse(node.InnerText)
        End If

        Return False ' Valor por defecto
    End Function
End Class
