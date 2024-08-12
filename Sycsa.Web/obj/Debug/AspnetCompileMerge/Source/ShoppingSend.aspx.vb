Imports sycsa.BusinessLayer

Public Class ShoppingSend
    Inherits System.Web.UI.Page
    Public Html As New vpublic
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If IsPostBack = False Then

            'Remover sesion de carrito
            Session.Remove("ss_ShoppingCart")
            Html.updElemntsCart()
            'If Session("_IdCliente") Is Nothing Then
            '    Response.Redirect("~/home.aspx", False)
            'End If


            'Carga texto segun el lenguaje

            txtLabelTitle.InnerHtml = "Gracias por su preferencia"

            'textInfo1.InnerHtml = "Te enviamos un email a la dirección que indicaste en el formulario anterior, " & _
            '                      "en el mensaje encontraras una liga el cual te servirá  para validar tu cuenta y puedas acceder al sitio. " & _
            '                      "<br /><br /> <strong>Gracias por tu preferencia. </strong> "

            'textInfo2.InnerHtml = "¡Tu cuenta esta casi lista!"
            'textInfo3.InnerHtml = "Boletines"
            'textInfo4.InnerHtml = "Recibe las últimas noticias y promociones del sitio"

            textInfo5.InnerHtml = "¡Pedido enviado!"
            textInfo6.InnerHtml = "Su solicitud esta siendo revisada, gracias por su preferencia."

            'ListCategories.Attributes.Item("data-placeholder") = "clic para ver las opciones"

            'chNews.Text = "Subcribirme a boletines del sitio"
            'btnEnviar.Text = "Suscribirme"


        End If


    End Sub

End Class