﻿Imports sycsa.Web.vpublic
Imports sycsa.BusinessLayer
Imports sycsa.Information
Imports System.Globalization

Public Class SiteWeb
    Inherits System.Web.UI.MasterPage
    Public Html As New vpublic, dtCategories As DataSet, dtSubcategories As DataSet
    Dim ObjBLCategories As New BLCategories
    Public ObjBLSubcategories As New BLSubCategories
    Public ObjBLCustomer As New BLCustomers
    Public ObjBL As New BLOptions
    Public common As New CONECTASQL.ConectaSQL



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
                'dvDocFisc.Visible = False
                Html._Lista = 0
            Else
                Dim DataSet As New DataSet
                DataSet = common.sqlconsulta("SELECT [RFC] FROM [EMPRESAS] WHERE CLAVE=1", "dProducto")
                txtLabelQuantity.Text = "Bienvenido " & Session("MM_UserName") & " " & Session("MM_CIA")
                dvLogin.Visible = False
                dvLogin1.Visible = False
                dvLogin2.Visible = True
                Session("EMP_RFC") = DataSet.Tables(0).Rows(0).Item("RFC").ToString
                'dvDocFisc.Visible = True
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

                    Response.Redirect("~/home.aspx", True)
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
        Dim DataSet As New DataSet
        'Dim id As String = IIf(Session("MM_CLIENTE") Is Nothing, "0", Session("MM_CLIENTE"))
        ' [NOMBRE_CORTO], [TELEFONOS], [EMAIL]
        DataSet = common.sqlconsulta("SELECT [DIRECCION], [NUMERO],[COLONIA],[CP],[CIUDAD],[ESTADO],[NOMBRE_CORTO], [TELEFONOS], [EMAIL] FROM [EMPRESAS]  where CLAVE=1", "dProducto")

        Html._Layout_title = DataSet.Tables(0).Rows(0).Item("NOMBRE_CORTO").ToString & " | Tienda online"
        Dim direccion As String = StrConv(DataSet.Tables(0).Rows(0).Item("DIRECCION").ToString, VbStrConv.ProperCase)
        Dim num As String = DataSet.Tables(0).Rows(0).Item("NUMERO").ToString
        Dim colonia As String = StrConv(DataSet.Tables(0).Rows(0).Item("COLONIA").ToString, VbStrConv.ProperCase)
        Dim cp As String = DataSet.Tables(0).Rows(0).Item("CP").ToString
        Dim ciudad As String = StrConv(DataSet.Tables(0).Rows(0).Item("CIUDAD").ToString, VbStrConv.ProperCase)
        Dim estado As String = StrConv(DataSet.Tables(0).Rows(0).Item("ESTADO").ToString, VbStrConv.ProperCase)

        Html._Layout_metadescription = ""
        Html._Layout_metadekeyword = ""
        Html._Layout_Lenguage = "spanish"
        Html._Layout_Empresa = DataSet.Tables(0).Rows(0).Item("NOMBRE_CORTO").ToString
        Html._Layout_bannerOption = 0
        Html._Layout_menuOption = 0
        Html._Layout_address = direccion & " " & num & ", Col. " & colonia & ", C.P. " & cp & ", " & ciudad & ", " & estado
        Html._Layout_phone = DataSet.Tables(0).Rows(0).Item("TELEFONOS").ToString
        Html._Layout_emailContact = DataSet.Tables(0).Rows(0).Item("EMAIL").ToString

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