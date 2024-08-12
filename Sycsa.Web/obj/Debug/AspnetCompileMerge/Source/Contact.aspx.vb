Imports sycsa.Web.vpublic
Imports sycsa.BusinessLayer


Public Class contact
    Inherits System.Web.UI.Page
    Public Html As New vpublic
    Public ObjBLCustomer As New BLCustomers
    Dim _Script As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Contacto"
    End Sub




    Protected Sub btnContact_Click(sender As Object, e As EventArgs) Handles btnContact.Click
        Try
            With ObjBLCustomer
                .Subject = txtsubject.Text
                .ContactName = txtname.Text
                .ContactEmail = txtEmail.Text
                .ContactMsg = txtMessage.Text
                .SaveContact()
                txtsubject.Text = ""
                txtname.Text = ""
                txtEmail.Text = ""
                txtMessage.Text = ""
                _Script = "messenger('box_messenger','alert info','Tu Mensaje Fue enviado exitosamente');"
                ScriptManager.RegisterStartupScript(Me, GetType(Page), "mensseger", _Script, True)
                'Dim _Script As String = "Alert('Se  envio el correo exitosamente')"
                'Dim cs As ClientScriptManager = Page.ClientScript
                'cs.RegisterClientScriptBlock(Me.GetType(), "mensseger", _Script, False)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function RegErr(_Error As String)
        'Funcion para el registro de error si esque llega a generarse en tiempo de ejecución




        Return Nothing
    End Function


End Class