Imports System.IO

Partial Class GetImage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim baseFileName As String = Path.GetFileNameWithoutExtension(Request.QueryString("file"))
        Dim filePath As String = GetFilePath(baseFileName)

        If Not String.IsNullOrEmpty(filePath) Then
            If File.Exists(filePath) Then
                Dim fileExtension As String = Path.GetExtension(filePath).ToLower()
                Dim contentType As String = GetContentType(fileExtension)

                If contentType IsNot Nothing Then
                    Response.ContentType = contentType
                    Try
                        Response.TransmitFile(filePath)
                        Response.End()
                    Catch ex As Exception
                        ' Log the exception (implement logging as needed)
                        Response.StatusCode = 500 ' Internal Server Error
                    End Try
                Else
                    Response.StatusCode = 415 ' Unsupported Media Type
                End If
            Else
                Response.StatusCode = 404 ' Not Found
            End If
        Else
            Response.StatusCode = 400 ' Bad Request
        End If
    End Sub

    Private Function GetFilePath(baseFileName As String) As String
        Dim directoryPath As String = Server.MapPath("~/local/imagenes/")
        Dim fileExtensions As String() = {".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".webp", ".ico", ".svg"}

        For Each ext In fileExtensions
            Dim filePath As String = Path.Combine(directoryPath, baseFileName & ext)
            If File.Exists(filePath) Then
                Return filePath
            End If
        Next

        Return Nothing
    End Function

    Private Function GetContentType(extension As String) As String
        Select Case extension
            Case ".jpg", ".jpeg"
                Return "image/jpeg"
            Case ".png"
                Return "image/png"
            Case ".gif"
                Return "image/gif"
            Case ".bmp"
                Return "image/bmp"
            Case ".tiff"
                Return "image/tiff"
            Case ".webp"
                Return "image/webp"
            Case ".ico"
                Return "image/x-icon"
            Case ".svg"
                Return "image/svg+xml"
            Case Else
                Return Nothing
        End Select
    End Function
End Class
