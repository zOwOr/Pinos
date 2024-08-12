Imports System
Imports sycsa.BusinessLayer

Public Class AccountAddressBookNew
    Inherits System.Web.UI.Page
    Public ObjBLCustomer As New BLCustomers
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Nueva dirección"
        If IsPostBack = False Then
            If Session("MM_UserId") IsNot Nothing Then
                btnSave.Enabled = True
            End If
        End If
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            With ObjBLCustomer
                .IdCustomer = Session("MM_UserId")
                .CompanyFac = txtCompany.Text
                .RFCFac = txtRFC.Text
                .PhoneFac = txtPhoneAddress.Text
                .DireccionFac = txtAdress.Text
                .ColoniaFac = txtColony.Text
                .CPFac = txtCP.Text
                .CityFac = txtCity.Text
                .StateFac = txtState.Text
                .SaveAddress()
                txtCompany.Text = ""
                txtRFC.Text = ""
                txtPhoneAddress.Text = ""
                txtAdress.Text = ""
                txtColony.Text = ""
                txtCP.Text = ""
                txtState.Text = ""
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class