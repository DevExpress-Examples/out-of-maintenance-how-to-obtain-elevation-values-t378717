using DevExpress.XtraMap;
using System;
using System.Windows.Forms;

namespace BingElevation {
    public partial class Form1 : Form {
        const string yourBingKey = "Enter Your Bing Key Here";
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            imageDataProvider.BingKey = yourBingKey;

            #region #ElevationDataProviderConfiguring
            // Create a new elevation data provider.
            BingElevationDataProvider dataProvider = new BingElevationDataProvider {
                BingKey = yourBingKey,
                ProcessMouseEvents = true
            };
            informationLayer.DataProvider = dataProvider;
            // Process result obtaining.
            dataProvider.ElevationsCalculated += OnElevationsCalculated;
            #endregion #ElevationDataProviderConfiguring
        }

        #region #ElevationObtained
        private void OnElevationsCalculated(object sender, ElevationsCalculatedEventArgs e) {
            if(e.Cancelled == true || e.Error != null) return;
            if(e.Result.ResultCode != RequestResultCode.Success) return;

            informationLayer.Data.Items.Clear();
            // foreach requested location create a new callout with elevation value.
            foreach (ElevationInformation elevationResult in e.Result.Locations) {
                informationLayer.Data.Items.Add(new MapCallout {
                    Location = elevationResult.Location,
                    Text = String.Format("Elevation: {0}m.", elevationResult)
                });
            }
        }
        #endregion #ElevationObtained
    }
}
