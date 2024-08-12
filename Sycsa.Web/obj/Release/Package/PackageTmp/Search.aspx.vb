Imports System.Web
Imports sycsa.BusinessLayer
Imports sycsa.Information



Public Class search
    Inherits System.Web.UI.Page

    Dim Objt As New BLProducts
    Public Html As New vpublic
    Dim _Script As String
    Public _cookieSherchCurrent As HttpCookie
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Page.Title = "Busqueda de producto"
            _cookieSherchCurrent = Request.Cookies("_searchLast")


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

                'get values of search
                LoadShearch(
                         _cookieSherchCurrent.Item("productName"), _
                         _cookieSherchCurrent.Item("productCat"))

            Else

                'Add cart
                Dim _Event As String = Request.Params("__EVENTTARGET")
                Dim _Param As String = Request.Params("__EVENTARGUMENT")
                Dim TestArray() As String = _Param.Split(",")
                If _Event = "addCart" Then

                    Dim Cart As ShoppingCart = ShoppingCart.CapturarProducto()
                    Cart.Agregar(CType(TestArray(0), Int64), CDbl(TestArray(2)), TestArray(1))

                    Html.updElemntsCart()
                    _Script = "messenger('box_messenger','alert info','Tu producto se agrego al carrito');"
                    ScriptManager.RegisterStartupScript(Me, GetType(Page), "mensseger", _Script, True)
                    'Se agrega a carrito de compras
                    'Response.Redirect("~/ShowCart.aspx?", False)
                    BindData()

                End If

            End If


        Catch ex As Exception

        End Try


    End Sub

    Protected Sub OnPagePropertiesChanging(sender As Object, e As PagePropertiesChangingEventArgs)

        DataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, False)

        LoadShearch(
                 _cookieSherchCurrent.Item("productName"), _
                 _cookieSherchCurrent.Item("productCat"))

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
        Dim _cokiePagedProducts As HttpCookie = New HttpCookie("_PagedProducts")

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

        'get values of search
        LoadShearch(
                 _cookieSherchCurrent.Item("productName"), _
                 _cookieSherchCurrent.Item("productCat"))

    End Sub



    Sub LoadShearch(_Field As String, _Categorie As String)

        Try
            Dim data As DataSet

            Objt.idCategory = _Categorie
            Objt.ProductName = _Field
            Objt.UnitInStock = IIf(Session("MM_Lista") Is Nothing, 0, Session("MM_Lista"))
            data = Objt.Loadlistproduct

            ListProducts.DataSource = data.Tables(0)
            ListProducts.DataBind()

        Catch ex As Exception
            Throw ex
        End Try


    End Sub
    Sub BindData()
        Dim showcart As New ShowCart
        Dim showcartToltip As New SiteWeb
        showcart.updateCarrito()
        showcartToltip.updateCarrito()
    End Sub


End Class