Public Class SiteControl
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'Acceso solo con login
        If Session("ss_IdUser") Is Nothing Then

            Dim httpReference As String
            httpReference = Page.Request.Url.AbsoluteUri.ToString
            httpReference = ResolveUrl(httpReference)
            Session("UrlReferent") = httpReference

            Response.Redirect("~/wpanel/index.aspx", False)

        Else
            'Usiario logeado

            'txtMM_Username.Text = Session("MM_Nombre")
            't.InnerHtml = Session("MM_Username")

        End If




    End Sub

End Class