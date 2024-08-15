Imports System.IO

Partial Class GetImage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim fileName As String = Request.QueryString("file")
        If Not String.IsNullOrEmpty(fileName) Then
            Dim filePath As String = Server.MapPath("~/local/imagenes/" & fileName & ".jpg") ' Cambia la extensión según el formato

            If File.Exists(filePath) Then
                Response.ContentType = "image/jpeg" ' Cambia el tipo de contenido según la extensión del archivo
                Response.TransmitFile(filePath)
                Response.End()
            Else
                Response.StatusCode = 404 ' Archivo no encontrado
                Response.Write("Archivo no encontrado.")
            End If
        Else
            Response.StatusCode = 400 ' Solicitud incorrecta
            Response.Write("Nombre de archivo no especificado.")
        End If
    End Sub
End Class
