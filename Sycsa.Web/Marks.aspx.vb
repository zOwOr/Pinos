Imports sycsa.Information
Imports sycsa.BusinessLayer
Imports System

Public Class marks
    Inherits System.Web.UI.Page
    Public marks As New BLMarks

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Categorias"
        BindListView()
    End Sub
    Private Sub BindListView()

        With marks
            ListProducts.DataSource = .LoadMark()
        End With
        ListProducts.DataBind()


    End Sub

End Class