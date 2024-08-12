Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class ShowCart
    Inherits System.Web.UI.Page
    Public Html As New vpublic

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Page.Title = "Carrito de compras"

        If IsPostBack = False Then
            BindData()
        End If

    End Sub

    Protected Sub gvListProductos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvListProductos.RowCommand

        Try

            If e.CommandName = "Delete" Then

                Dim productId As String() = e.CommandArgument.ToString().Split(",")
                ShoppingCart.CapturarProducto().EliminarProductos(productId(0), productId(1))

            ElseIf e.CommandName = "Update" Then
                For Each _row As GridViewRow In gvListProductos.Rows
                    If _row.RowType = DataControlRowType.DataRow Then

                        Try

                            Dim productId As String() = e.CommandArgument.ToString().Split(",")
                            Dim idcarrito As Label = _row.Cells(2).FindControl("idcarrito")
                            Dim cantidad As TextBox = _row.Cells(2).FindControl("txtCantidad")
                            Dim idcarritocom As String() = idcarrito.Text.ToString().Split(",")
                            If productId(0) = idcarritocom(0) AndAlso productId(1) = idcarritocom(1) Then
                                ShoppingCart.CapturarProducto().CantidadDeProductos(productId(0), CType(cantidad.Text, Int64), productId(1))
                            End If


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

    Sub BindData()
        'gvListProductos = New GridView

        gvListProductos.DataSource = ShoppingCart.CapturarProducto().ListProducts.AsEnumerable
        gvListProductos.DataBind()

        Html._PorcentajeIva = Session("_PorcentajeIva")
        Html._SubTotal = Session("_SubTotal")

        If gvListProductos.Rows.Count = 0 Then
            divButton.Visible = False
        End If

    End Sub

    Protected Sub btnComprar_Click(sender As Object, e As EventArgs) Handles btnComprar.Click
        Response.Redirect("CheckoutShipping.aspx", True)
    End Sub

    Public Sub updateCarrito()
        gvListProductos = New GridView

        gvListProductos.DataSource = ShoppingCart.CapturarProducto().ListProducts.AsEnumerable
        gvListProductos.DataBind()

        Html._PorcentajeIva = Session("_PorcentajeIva")
        Html._SubTotal = Session("_SubTotal")

    End Sub


End Class