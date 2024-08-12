Imports System
Imports sycsa.Information
Imports sycsa.BusinessLayer

Public Class AccountLogin
    Inherits System.Web.UI.Page
    Public ObjBLCustomer As New BLCustomers
    Dim _Script As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Title
        Page.Title = "Información de acceso"

    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If txtPass.Text = txtPassRepeat.Text Then
                With ObjBLCustomer
                    .Pass = txtPass.Text
                    .UpdatePassword()
                    _Script = "messenger('box_messenger','alert success','Tu Contraseña se actualizo correctamente');"
                    ScriptManager.RegisterStartupScript(Me, GetType(Page), "mensseger", _Script, True)
                End With
            Else
                _Script = "messenger('box_messenger','alert warning','Tu Contraseña no coincide');"
                ScriptManager.RegisterStartupScript(Me, GetType(Page), "mensseger", _Script, True)
            End If
        Catch ex As Exception
            _Script = "messenger('box_messenger','alert warning','Hubo un error interno intenta nuevamente');"
            ScriptManager.RegisterStartupScript(Me, GetType(Page), "mensseger", _Script, True)
        End Try

    End Sub
End Class