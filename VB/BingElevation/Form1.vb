Imports DevExpress.XtraMap
Imports System
Imports System.Windows.Forms

Namespace BingElevation
    Partial Public Class Form1
        Inherits Form

        Private Const yourBingKey As String = "Enter Your Bing Key Here"
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            imageDataProvider.BingKey = yourBingKey

'            #Region "#ElevationDataProviderConfiguring"
            ' Create a new elevation data provider.
            Dim dataProvider As BingElevationDataProvider = New BingElevationDataProvider With {.BingKey = yourBingKey, .ProcessMouseEvents = True}
            informationLayer.DataProvider = dataProvider
            ' Process result obtaining.
            AddHandler dataProvider.ElevationsCalculated, AddressOf OnElevationsCalculated
'            #End Region ' #ElevationDataProviderConfiguring
        End Sub

        #Region "#ElevationObtained"
        Private Sub OnElevationsCalculated(ByVal sender As Object, ByVal e As ElevationsCalculatedEventArgs)
            If e.Cancelled = True OrElse e.Error IsNot Nothing Then
                Return
            End If
            If e.Result.ResultCode <> RequestResultCode.Success Then
                Return
            End If

            informationLayer.Data.Items.Clear()
            ' foreach requested location create a new callout with elevation value.
            For Each elevationResult As ElevationInformation In e.Result.Locations
                informationLayer.Data.Items.Add(New MapCallout With {.Location = elevationResult.Location, .Text = String.Format("Elevation: {0}m.", elevationResult)})
            Next elevationResult
        End Sub
        #End Region ' #ElevationObtained
    End Class
End Namespace
