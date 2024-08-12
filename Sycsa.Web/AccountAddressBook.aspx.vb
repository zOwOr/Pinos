Imports System
Imports sycsa.BusinessLayer
Imports sycsa.Information


Public Class AccountAddressBook
    Inherits System.Web.UI.Page
    Public ObjBLAddress As New BLCustomersAddresses
    Public DtAddress As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Direcciones"
        DtAddress = ObjBLAddress.LoadAll()

        If IsPostBack = False Then
        Else

            Dim _Event As String = Request.Params("__EVENTTARGET")
            Dim _Param As String = Request.Params("__EVENTARGUMENT")

            If _Event = "Edt" Then

                Session("AddressEdit") = _Param
                Response.Redirect("~/AccountAddressBookEdit.aspx", True)

            ElseIf _Event = "del" Then
                Delete(_Param)

                Response.Redirect(Request.Url.AbsoluteUri)

            End If

        End If

    End Sub

    Public Sub Delete(ByVal Id As Integer)
        Try
            With ObjBLAddress
                .IdAddress = Id
                .Delete()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class