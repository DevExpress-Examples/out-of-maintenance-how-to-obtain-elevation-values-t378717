<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128576738/16.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T378717)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/BingElevation/Form1.cs) (VB: [Form1.vb](./VB/BingElevation/Form1.vb))**
<!-- default file list end -->
# How to: Obtain Elevation Values


This example demonstrates how to send a request to the Bing Elevation service and process request results.


<h3>Description</h3>

<p>To send elevation requests, assign a <strong>BingElevationDataProvider</strong> object to the <strong>InformationLayer.DataProvider</strong> property.</p>
<p>Then, handle the provider's <strong>ElevationsCalculated</strong> event. In the event handler, create a new map item with the required elevation information.</p>
<p>This information is stored by the <strong>ElevatioInformation</strong> objects in the <strong>Result.Locations</strong> collection of the event arguments.&nbsp;Objects provide the <strong>Location</strong> property containing the point sent with a request and <strong>Elevation</strong> of this location.</p>

<br/>


