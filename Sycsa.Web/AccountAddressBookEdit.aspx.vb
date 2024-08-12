Imports sycsa.BusinessLayer
Imports sycsa.Information
Public Class AccountAddressBookEdit
    Inherits System.Web.UI.Page
    Public ObjBLCustomer As New BLCustomers
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            If Session("AddressEdit") IsNot Nothing Then

                LoadAddressId(CType(Session("AddressEdit"), Int64))

            End If
        End If
    End Sub

    Public Sub LoadAddressId(ByVal Id As Integer)
        Try

            Dim ObjInfoCustomer As New List(Of InfoCustomers)
            With ObjBLCustomer

                .IdAddress = Id
                ObjInfoCustomer = .LoadAddressById()
                txtCompany.Text = ObjInfoCustomer(0).CompanyFac
                txtRFC.Text = ObjInfoCustomer(0).RFCFac
                txtPhoneAddress.Text = ObjInfoCustomer(0).PhoneFac
                txtAdress.Text = ObjInfoCustomer(0).DireccionFac
                txtColony.Text = ObjInfoCustomer(0).ColoniaFac
                txtCP.Text = ObjInfoCustomer(0).CPFac
                txtCity.Text = ObjInfoCustomer(0).CityFac
                txtState.Text = ObjInfoCustomer(0).StateFac

            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            With ObjBLCustomer
                .IdAddress = Session("IdAdrress")
                .CompanyFac = txtCompany.Text
                .RFCFac = txtRFC.Text
                .PhoneFac = txtPhoneAddress.Text
                .DireccionFac = txtAdress.Text
                .ColoniaFac = txtColony.Text
                .CPFac = txtCP.Text
                .CityFac = txtCity.Text
                .StateFac = txtState.Text
                .UpdateAddressCustomer()
                txtCompany.Text = ""
                txtRFC.Text = ""
                txtRFC.Text = ""
                txtPhoneAddress.Text = ""
                txtAdress.Text = ""
                txtColony.Text = ""
                txtCP.Text = ""
                txtCity.Text = ""
                txtState.Text = ""
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class