Imports sycsa.Information
Imports sycsa.BusinessLayer

Public Class ShowProduct
    Inherits System.Web.UI.Page

    Dim ObjBLProducts As New BLProducts
    Dim objBLCategorie As New BLCategories
    Public ObjBLSubCat As New BLSubCategories
    Public _ProductID As Int64
    Public _Unidad As String
    Public Html As New vpublic

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            'Load data
            If Request.QueryString("pk") <> "" Then
                Dim _Param As String = Request.QueryString("pk")
                Dim _Param2 As String = Request.QueryString("pu")
                _ProductID = _Param
                _Unidad = _Param2
                LoadProduct(_Param, "Es", _Unidad)
            Else
                Response.Redirect("~/ListProducts.aspx?action=show&paramAll=all")
            End If

        Else

            'Add cart
            Dim _Event As String = Request.Params("__EVENTTARGET")
            Dim _Param As String = Request.Params("__EVENTARGUMENT")
            Dim TestArray() As String = _Param.Split(",")

            If _Event = "addCart" Then

                'Se agrega producto al carrito de compras
                Dim Cart As ShoppingCart = ShoppingCart.CapturarProducto()
                Cart.Agregar(CType(TestArray(0), Int64), CDbl(TestArray(2)), TestArray(1))
                'Agrega el numero de productos deseados
                'If IsNumeric(CDbl(TestArray(1))) = False Then
                '    Cart.CantidadDeProductos(CType(_Param, Int64), 1)
                'Else
                '    Cart.CantidadDeProductos(CType(TestArray(0), Int64), CDbl(TestArray(1)))
                'End If


                Html.updElemntsCart()

                'Se agrega a carrito de compras
                Response.Redirect("~/ShowCart.aspx?", False)

            End If



        End If

    End Sub




    Private Sub LoadProduct(_param As Int64, _Lenguage As String, _Unidad As String)

        Try


            Dim ObjInfoProduct As New List(Of InfoProducts)
            With ObjBLProducts
                .ProductId = _param
                .Unidad = _Unidad
                ObjInfoProduct = .LoaProductForSales
            End With


            'Labels
            'Se carga el texto segun el idioma que  se hallan selecionado por el usuario
            '-------------------------------------------------------------------------------

            Dim _ButtonCart As String = ""
            _ButtonCart = "         "
            txtLabelButtonCart.InnerHtml = _ButtonCart

            txtLabelMark.Text = "Fabricante"
            txtLabelAvailability.Text = "Disponibilidad"
            txtLabelQuantity.Text = "Cantidad"
            txtLabelCodeProduct.Text = "Codigo"


            HmtlUnitStock.Visible = False 'IIf(ObjInfoProduct(0).HiddenStock = True, False, True)
            Htmlprice.Visible = False 'IIf(ObjInfoProduct(0).HiddenPrice = True, False, True)

            'Datos del producto
            txtProductName.InnerHtml = ObjInfoProduct(0).ProductName
            LinkMark.NavigateUrl = "~/ListProducts.aspx?paramM=" & ObjInfoProduct(0).MarkId
            LinkMark.Text = ObjInfoProduct(0).MarckName

            txtAvailability.Text = FormatNumber(ObjInfoProduct(0).UnitInStock, 0)
            txtPrice.Text = FormatCurrency(ObjInfoProduct(0).UnitPrice, 2)
            txtCodeProduct.Text = ObjInfoProduct(0).ProductKey

            tab1Description.InnerHtml = ObjInfoProduct(0).LongDescription
            txtshortDescriptionProduct.InnerHtml = ObjInfoProduct(0).ShortDescription

            Dim nombreImagen As String = String.Empty
            nombreImagen = ObjInfoProduct(0).Imagen.Substring(ObjInfoProduct(0).Imagen.LastIndexOf("\") + 1)

            If Not String.IsNullOrEmpty(nombreImagen) Then
                htmlDivCarousel.Visible = False
                ImagenDefaultProduct.ImageUrl = "~/fotos/" & nombreImagen
                ImagenDefaultProduct.Attributes.Add("data-large", "/fotos/" & nombreImagen)
                LInkFullScreen_Button.NavigateUrl = "~/fotos/" & nombreImagen
            Else
                htmlDivCarousel.Visible = False
                ImagenDefaultProduct.ImageUrl = "~/imagen/no_image.gif"
                ImagenDefaultProduct.Attributes.Add("data-large", "/imagen/no_image.gif")
                LInkFullScreen_Button.NavigateUrl = "~/imagen/no_image.gif"
            End If
            '--------------------------------
            'Imagenes of product
            '--------------------------------
            Dim datos As New DataTable
            With ObjBLProducts
                '.idProduct = CType(_param, Int64)
                'datos = .LoadImagen().Tables(0)
            End With

            Dim _ElementHtml As String = ""
            If datos.Rows.Count > 0 Then

                For Each irow As DataRow In datos.Rows

                    If irow("ImgDefault") = True Then

                        ImagenDefaultProduct.ImageUrl = irow("ProductImagen")
                        ImagenDefaultProduct.Attributes.Add("data-large", irow("ProductImagen"))
                        LInkFullScreen_Button.NavigateUrl = irow("ProductImagen")

                    End If

                    _ElementHtml = _ElementHtml & "<li>" &
                                    " <a class=""fancybox"" rel=""product-images"" href=""" & irow("ProductImagen") & """></a> " &
                                    " <img src=""" & irow("ProductImagen") & """ data-large=""" & irow("ProductImagen") & """ alt="""" /> " &
                                    "</li>"

                Next

            Else

                'htmlDivCarousel.Visible = False
                'ImagenDefaultProduct.ImageUrl = "~/imagen/no_image.gif"
                'ImagenDefaultProduct.Attributes.Add("data-large", "/imagen/no_image.gif")
                'LInkFullScreen_Button.NavigateUrl = "~/imagen/no_image.gif"

            End If


            PanelImagen.InnerHtml = _ElementHtml


            'Load Carousel
            Dim datosRelated As New DataTable
            With ObjBLProducts
                .MarkId = ObjInfoProduct(0).MarkId
                .SubCategory = ObjInfoProduct(0).SubCategory
                'datosRelated = .LoaProductForSalesRelated.Tables(0)
            End With


            _ElementHtml = ""
            For Each irow As DataRow In datosRelated.Rows

                _ElementHtml = _ElementHtml & "<div>" &
                                         "<div class=""product"">" &
                                        "	<div class=""product-image"">" &
                                        "		<img src=""" & IIf(IsDBNull(irow("ProductImagen")) = False, irow("ProductImagen"), "/imagen/no_image.gif") & """ width=""65%"" alt=""" & irow("ProductName") & """>" &
                                        "	</div>" &
                                         " " &
                                        "	<div class=""product-info"">" &
                                        "		<h5><a href=""ShowProduct.aspx?pk=" & irow("ProductID") & """>" & irow("ProductName") & "</a></h5>" &
                                        "		<span class=""price"">" & IIf(irow("hiddenPrice") = 1, "", FormatCurrency(irow("UnitPrice"), 2)) & "</span>" &
                                        "		<div class=""rating readonly-rating"" data-score=""4""></div>" &
                                        "	</div>" &
                                        " " &
                                        "	<div class=""product-actions"">" &
                                        " " &
                                        "		<span class=""add-to-cart"" style=""width:12px !important;""   onclick=""return AddCart(' " & irow("ProductID") & " ');"" > " &
                                        "			<span class=""action-wrapper""  >" &
                                        "				<i class=""icons icon-basket-2"" ></i>   " & _ButtonCart &
                                        "			</span>" &
                                        "		</span>" &
                                        " " &
                                        "	</div>" &
                                        " " &
                                        "</div>" &
                                      "</div>"

            Next

            HtmlCarousel.InnerHtml = _ElementHtml



        Catch ex As Exception
        End Try


    End Sub


End Class