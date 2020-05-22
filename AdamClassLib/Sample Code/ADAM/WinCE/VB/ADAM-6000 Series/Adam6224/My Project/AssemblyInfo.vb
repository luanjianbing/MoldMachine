Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' 組件的一般資訊是由下列的屬性集控制
' 變更這些屬性的值即可修改組件的相關
' 資訊。

' 檢閱組件屬性的值

<Assembly: AssemblyTitle("Adam6224")>
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyCompany("")>
<Assembly: AssemblyProduct("Adam6224")>
<Assembly: AssemblyCopyright("Copyright ©  2013")>
<Assembly: AssemblyTrademark("")>

<Assembly: CLSCompliant(True)>

<Assembly: ComVisible(False)>

'下列 GUID 為專案公開 (Expose) 至 COM 時所要使用的 typelib ID
<Assembly: Guid("655f097c-d79b-4684-9cf4-8e7d89dcefb3")>

' 組件的版本資訊是由下列四項值構成:
'
'      主要版本
'      次要版本
'      組建編號
'      修訂編號
'
' 您可以指定所有的值，也可以使用 '*' 將組建和修訂編號
' 指定為預設值:
' <Assembly: AssemblyVersion("1.0.*")>

<Assembly: AssemblyVersion("1.0.0.0")>

'下列屬性將會抑制 FxCop 警告 "CA2232 : Microsoft.Usage : 將 STAThreadAttribute 加入組件"
' 因為裝置應用程式不支援 STA 執行緒。
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2232:MarkWindowsFormsEntryPointsWithStaThread")>
