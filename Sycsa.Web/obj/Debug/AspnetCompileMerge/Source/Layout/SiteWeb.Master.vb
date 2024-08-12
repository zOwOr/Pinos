Imports sycsa.Web.vpublic
Imports sycsa.BusinessLayer
Imports sycsa.Information


Public Class SiteWeb
    Inherits System.Web.UI.MasterPage
    Public Html As New vpublic, dtCategories As DataSet, dtSubcategories As DataSet
    Dim ObjBLCategories As New BLCategories
    Public ObjBLSubcategories As New BLSubCategories
    Public ObjBLCustomer As New BLCustomers
    Public ObjBL As New BLOptions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'Load list Categories
        dtCategories = ObjBLCategories.LoadLayout
        dlCategories.DataSource = dtCategories
        If Request.QueryString("cs") <> "" Then
            Dim _page = "Login.aspx"
            Session.Remove("MM_UserId")
            Session.Remove("MM_UserName")
            Session.Remove("MM_CIA")
            Session.Remove("MM_Lista")
            Session.Remove("MM_CLIENTE")
            Html._Lista = 0
            Response.Redirect(_page, True)
        End If

        If IsPostBack = False Then
            dlCategories.DataTextField = "CategoryName"
            dlCategories.DataValueField = "idCategories"
            dlCategories.DataBind()

            '-------------------
            If Session("MM_UserName") Is Nothing Then
                dvLogin.Visible = True
                dvLogin1.Visible = True
                dvLogin2.Visible = False
                Html._Lista = 0
            Else
                txtLabelQuantity.Text = "Bienvenido " & Session("MM_UserName") & " " & Session("MM_CIA")
                dvLogin.Visible = False
                dvLogin1.Visible = False
                dvLogin2.Visible = True
            End If


        Else


            If IsPostBack = False Then

            Else

                Dim _Event As String = Request.Params("__EVENTTARGET")
                Dim _Param As String = Request.Params("__EVENTARGUMENT")

                If _Event = "shearch" Then
                    Dim _cookieSherch As HttpCookie = New HttpCookie("_searchLast")
                    Dim _cookieSherchCurrent As HttpCookie = Request.Cookies("_searchLast")
                    Dim _Product As String = txtShears.Text

                    If _cookieSherchCurrent Is Nothing Then
                        _cookieSherch.Values.Add("productName", _Product)
                        _cookieSherch.Values.Add("productCat", dlCategories.SelectedValue)
                        _cookieSherch.Expires = DateTime.Now.AddHours(6)
                        Response.Cookies.Add(_cookieSherch)
                    Else
                        _cookieSherch.Item("productName") = _Product
                        _cookieSherch.Item("productCat") = dlCategories.SelectedValue
                        Response.SetCookie(_cookieSherch)
                    End If

                    Response.Redirect("~/Search.aspx?", True)
                End If


            End If



        End If

        BindData()


    End Sub



    Protected Sub gvListProductos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvListProductos.RowCommand

        Try

            If e.CommandName = "Eliminar" Then
                Dim productId As String() = e.CommandArgument.ToString().Split(",")
                ShoppingCart.CapturarProducto().EliminarProductos(productId(0), productId(1))
            End If

            Html.updElemntsCart()

            Response.Redirect(Request.Url.AbsoluteUri)

        Catch ex As Exception
        End Try

    End Sub


    Sub BindData()

        ' Valores a cargar desde la base de datos
        '-------------------

        Html._Layout_title = "Sycsa.net | Tienda online"

        Html._Layout_metadescription = ""
        Html._Layout_metadekeyword = ""
        Html._Layout_Lenguage = "spanish"

        Html._Layout_bannerOption = 0
        Html._Layout_menuOption = 0

        Html._Layout_address = "Dr. coss norte #839 Col. Centro, C.P. 64000 Monterrey, Nuevo Leon"
        Html._Layout_phone = "(81)8142-0172 o 8142-0381 Ext: 800 al 804, 10 lineas"  
        Html._Layotu_emailContact = "contacto@sycsa.net"
        Html._Layotu_skype = "sycsa.net"

        If Session("_TotalItemsProduct") = 0 Then
            cartFooterPrice.Visible = False
        End If

        gvListProductos.DataSource = ShoppingCart.CapturarProducto().ListProducts.AsEnumerable
        gvListProductos.DataBind()

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim _page = "Login.aspx?Login=Err"
        Dim httpReference As String
        httpReference = Page.Request.Url.AbsoluteUri.ToString
        httpReference = ResolveUrl(httpReference)
        Session("PageReferent") = httpReference
        If StarLogin(txtUserName.Value, txtPassword.Value) = True Then

            If Session("PageReferent") IsNot Nothing Then
                _page = CType(Session("PageReferent"), String)
                Session.Remove("PageReferent")
            Else
                _page = "MyAccount.aspx?"
            End If

            Response.Redirect(_page, True)

        Else
            txtUserName.Value = txtUserName.Value
            txtUserName.Value = ""
        End If
    End Sub

    Public Function StarLogin(ByVal UserLogin As String, ByVal UserPass As String) As Boolean
        Dim _Login As Boolean = False
        Dim ObjCustomerInfo As New List(Of InfoCustomers)
        With ObjBLCustomer
            .UserName = UserLogin
            .Pass = UserPass
            ObjCustomerInfo = .LoadLogin()

            If ObjCustomerInfo.Count > 0 Then

                If ObjCustomerInfo(0).IdCustomer <> Nothing Then

                    Session("MM_UserId") = ObjCustomerInfo(0).IdCustomer
                    Session("MM_UserName") = ObjCustomerInfo(0).Name
                    Session("MM_Lista") = ObjCustomerInfo(0).Paid
                    Session("MM_CIA") = ObjCustomerInfo(0).CompanyFac
                    Session("MM_CLIENTE") = ObjCustomerInfo(0).StateFac
                    Html._Lista = ObjCustomerInfo(0).Paid
                    txtLabelQuantity.Text = "Bienvenido " & Session("MM_UserName") & " " & Session("MM_CIA")
                    ShoppingCart.CapturarProducto.UpdateTarifas()
                    Html.updElemntsCart()
                    _Login = True

                End If

            End If


        End With

        Return _Login

    End Function
    Sub updateCarrito()
        cartFooterPrice = New HtmlGenericControl
        gvListProductos = New GridView
        cartFooterPrice.Visible = True
        gvListProductos.DataSource = ShoppingCart.CapturarProducto().ListProducts.AsEnumerable
        gvListProductos.DataBind()
    End Sub
End Class