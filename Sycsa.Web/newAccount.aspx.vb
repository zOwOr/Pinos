Imports System
Imports sycsa.Information
Imports sycsa.BusinessLayer

Public Class newAccount
    Inherits System.Web.UI.Page
    Public ObjBLCustomer As New BLCustomers
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Crear cuenta"
    End Sub

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Try
            With ObjBLCustomer
                .Email = txtREmail.Text
                .Pass = txtRPassword.Text
                .Name = txtName.Text
                .LastName = txtLastName.Text
                .Phone = txtPhone.Text
                .CompanyFac = "SYCSA"
                .Save()
            End With
            'redireccion al final
            Response.Redirect("~/myAccount.aspx?", True)
        Catch ex As Exception
            RegErr(ex.Message)
        End Try
    End Sub



    Function RegErr(_Error As String)
        'Funcion para el registro de error si esque llega a generarse en tiempo de ejecución
        Return Nothing
    End Function




End Class