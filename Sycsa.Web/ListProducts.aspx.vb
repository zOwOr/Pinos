Imports System
Imports sycsa.Information
Imports sycsa.BusinessLayer
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common



Public Class ListProducts
    Inherits System.Web.UI.Page
    Public Html As New vpublic
    Dim _cokiePagedProducts As HttpCookie = New HttpCookie("_PagedProducts")
    Public common As New CONECTASQL.ConectaSQL
    Dim _Script As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Title
        Page.Title = "Lista de Productos"

        If IsPostBack = False Then

            Dim cookiePagedProducts As HttpCookie = Request.Cookies("_PagedProducts")
            If cookiePagedProducts IsNot Nothing Then

                Dim _nRows = cookiePagedProducts.Item("ProductRows")

                ResultPage.SelectedValue = _nRows
                DataPager.PageSize = _nRows
                DataPager.SetPageProperties(0, _nRows, False)

            Else
                DataPager.PageSize = 10
                DataPager.SetPageProperties(0, 10, False)
            End If


            BindListView()

        Else
            'Add cart
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
                'Se agrega a carrito de compras
                'Response.Redirect("~/ShowCart.aspx?", False)
                'Dim csname1 As String = "PopupScript"
                'Dim csname2 As String = "ButtonClickScript"
                'Dim cstype As Type = Me.GetType()
                'Dim _Script As String = " <script> $('#msjcarrito').removeClass(""hidden"").addClass(""alert info"");  </script>"
                'Dim cs As ClientScriptManager = Page.ClientScript
                'cs.RegisterStartupScript(cstype, csname1, _Script, True)
                BindData()

            End If

        End If



    End Sub

    Function LoadListProducts(_id As String, _type As String)
        Dim DataSet As DataSet
        Dim _Query As String
        Dim precio As String

        If Session("MM_Lista") Is Nothing Then
            precio = "producto_unidad.precio_V1_II as UnitPrice,"
        Else
            precio = "producto_unidad.precio_V" & Session("MM_Lista") & "_II as UnitPrice,"
        End If

        _Query = "Select producto.clave as ProductID, producto_unidad.unidad as Unidad ,producto.codigo_pro as ProductName, producto.descripcion as shortDescription, " & precio & " producto_unidad.precio_V1_II, producto.familia as Categoria, producto.sub_fam as Subcategoria, producto.moneda, producto.codigo_bar, producto.codigo_pv, producto.marca as Marca, producto.imagen as ProductImagen From producto inner join producto_unidad on producto.clave=producto_unidad.clave"

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

    Protected Sub OnPagePropertiesChanging(sender As Object, e As PagePropertiesChangingEventArgs)

        DataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, False)
        'TryCast(ListView1.FindControl("DataPager1"), DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, False)
        BindListView()

    End Sub


    Protected Sub listPages_Click(sender As Object, e As BulletedListEventArgs)
        Dim pageNo = Integer.Parse(TryCast(sender, BulletedList).Items(e.Index).Text)
        Dim startIndex = (pageNo - 1) * DataPager.PageSize
        DataPager.SetPageProperties(startIndex, DataPager.PageSize, True)
    End Sub


    Protected Overrides Sub InitializeCulture()
        UICulture = If(Request.QueryString("lg") Is Nothing, "ES", Request.QueryString("lg"))
        MyBase.InitializeCulture()
    End Sub


    Protected Sub ResultPage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ResultPage.SelectedIndexChanged

        Dim cookiePagedProducts As HttpCookie = Request.Cookies("_PagedProducts")
        Dim _Rows = ResultPage.SelectedValue
        If cookiePagedProducts Is Nothing Then

            _cokiePagedProducts.Values.Add("ProductRows", _Rows)
            _cokiePagedProducts.Expires = DateTime.Now.AddHours(5)
            Response.Cookies.Add(_cokiePagedProducts)

        Else

            cookiePagedProducts.Item("ProductRows") = _Rows
            Response.SetCookie(cookiePagedProducts)

        End If

        dataPagerNumeric.PageSize = ResultPage.SelectedValue
        dataPagerNumeric.SetPageProperties(0, ResultPage.SelectedValue, True)

        BindListView()

    End Sub


    Private Sub BindListView()

        Dim _ID As String

        'Consultas
        If Request.QueryString("paramC") <> "" Then

            _ID = Request.QueryString("paramC")
            ListProducts.DataSource = LoadListProducts(_ID, "C")

        ElseIf Request.QueryString("paramSC") <> "" Then

            _ID = Request.QueryString("paramSC")
            ListProducts.DataSource = LoadListProducts(_ID, "SC")

        ElseIf Request.QueryString("paramM") <> "" Then

            _ID = Request.QueryString("paramM")
            ListProducts.DataSource = LoadListProducts(_ID, "M")

        ElseIf Request.QueryString("paramAll") <> "" Then

            _ID = Request.QueryString("paramAll")
            ListProducts.DataSource = LoadListProducts(_ID, "ALL")

        Else
            ListProducts.DataSource = LoadListProducts(0, "ALL")
        End If


        ListProducts.DataBind()


    End Sub
    Sub BindData()
        Dim showcart As New ShowCart
        Dim showcartToltip As New SiteWeb
        showcart.updateCarrito()
        showcartToltip.updateCarrito()
    End Sub


End Class