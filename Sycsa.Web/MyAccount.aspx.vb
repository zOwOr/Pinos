Imports System
Imports sycsa.BusinessLayer
Imports sycsa.DataAccessLayer

Public Class myAccount
    Inherits System.Web.UI.Page
    Public ObjBLCustomer As New BLCustomers

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Mi cuenta"
        If IsPostBack = False Then
            'If Session("MM_UserId") IsNot Nothing Then

            'End If
            If Session("MM_UserId") Is Nothing Then

                Dim httpReference As String
                httpReference = Page.Request.Url.AbsoluteUri.ToString
                httpReference = ResolveUrl(httpReference)
                Session("PageReferent") = httpReference

                'Response.Redirect("~/Login.aspx?", True)
            Else
                LoadById(Session("MM_UserId"))
            End If
        End If
    End Sub
    Public Sub LoadById(ByVal Id As Integer)
        Try
            Dim ObjInfoCustomer As New List(Of Information.InfoCustomers)
            With ObjBLCustomer
                .IdCustomer = Id
                ObjInfoCustomer = .LoadById()
                txtNombre.Text = ObjInfoCustomer(0).Name
                txtLastName.Text = ObjInfoCustomer(0).LastName
                txtEmail.Text = ObjInfoCustomer(0).Email
                txtphone.Text = ObjInfoCustomer(0).Phone
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            With ObjBLCustomer
                .IdCustomer = Session("MM_UserId")
                .Name = txtNombre.Text
                .LastName = txtLastName.Text
                .Email = txtEmail.Text
                .Phone = txtphone.Text
                .UpdateCount()
            End With
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class