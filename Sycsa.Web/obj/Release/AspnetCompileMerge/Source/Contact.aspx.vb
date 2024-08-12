Imports sycsa.Web.vpublic
Imports sycsa.BusinessLayer


Public Class contact
    Inherits System.Web.UI.Page
    Public Html As New vpublic
    Public ObjBLCustomer As New BLCustomers
    Dim _Script As String
    Public common As New CONECTASQL.ConectaSQL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Contacto"
        Dim DataSet As New DataSet
        'Dim id As String = IIf(Session("MM_CLIENTE") Is Nothing, "0", Session("MM_CLIENTE"))

        DataSet = common.sqlconsulta("SELECT [DIRECCION], [NUMERO],[COLONIA],[CP],[CIUDAD],[ESTADO],[NOMBRE_CORTO], [TELEFONOS], [EMAIL] FROM [EMPRESAS]  where CLAVE=1", "dProducto")
        Dim direccion As String = StrConv(DataSet.Tables(0).Rows(0).Item("DIRECCION").ToString, VbStrConv.ProperCase)
        Dim num As String = DataSet.Tables(0).Rows(0).Item("NUMERO").ToString
        Dim colonia As String = StrConv(DataSet.Tables(0).Rows(0).Item("COLONIA").ToString, VbStrConv.ProperCase)
        Dim cp As String = DataSet.Tables(0).Rows(0).Item("CP").ToString
        Dim ciudad As String = StrConv(DataSet.Tables(0).Rows(0).Item("CIUDAD").ToString, VbStrConv.ProperCase)
        Dim estado As String = StrConv(DataSet.Tables(0).Rows(0).Item("ESTADO").ToString, VbStrConv.ProperCase)
        Html._Layout_title = DataSet.Tables(0).Rows(0).Item("NOMBRE_CORTO").ToString & " | Tienda online"
        Html._Layout_metadescription = ""
        Html._Layout_metadekeyword = ""
        Html._Layout_Lenguage = "spanish"
        Html._Layout_Empresa = DataSet.Tables(0).Rows(0).Item("NOMBRE_CORTO").ToString
        Html._Layout_bannerOption = 0
        Html._Layout_menuOption = 0
        Html._Layout_address = direccion & " " & num & ", Col. " & colonia & ", C.P. " & cp & ", " & ciudad & ", " & estado
        Html._Layout_phone = DataSet.Tables(0).Rows(0).Item("TELEFONOS").ToString
        Html._Layout_emailContact = DataSet.Tables(0).Rows(0).Item("EMAIL").ToString
        Html._Layout_skype = ""
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