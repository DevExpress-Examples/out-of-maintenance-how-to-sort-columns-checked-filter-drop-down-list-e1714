<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128631968/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1714)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [E1714.cs](./CS/WindowsApplication1/E1714.cs) (VB: [E1714.vb](./VB/WindowsApplication1/E1714.vb))
<!-- default file list end -->
# How to sort column's checked filter drop down list


<p>This example demonstrates how to sort items shown within the <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument1425">checked filter drop down list</a> the via the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseColumnView_ShowFilterPopupCheckedListBoxtopic">ShowFilterPopupCheckedListBox</a> event.<br />
This will be a generic solution that can be used for columns of various types. To achieve this, we will implement a class supporting the <a href="http://msdn.microsoft.com/en-us/library/system.collections.icomparer.aspx">IComparer</a> interface, and will use it to sort the items in ascending and descending order.</p>

<br/>


