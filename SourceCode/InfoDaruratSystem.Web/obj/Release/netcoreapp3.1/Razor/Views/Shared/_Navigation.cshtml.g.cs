#pragma checksum "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\_Navigation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97cdb193493e3265dcd8c1ff922072609c9308e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Navigation), @"mvc.1.0.view", @"/Views/Shared/_Navigation.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\_ViewImports.cshtml"
using InfoDaruratSystem.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\_ViewImports.cshtml"
using InfoDaruratSystem.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97cdb193493e3265dcd8c1ff922072609c9308e6", @"/Views/Shared/_Navigation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9922e81b2b11cb63f93ab2f703bcb0705b00c63e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Navigation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<InfoDaruratSystem.Web.Library.Entities.MenuEntity.Menu>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\_Navigation.cshtml"
  

    ViewBag.Title = "Home";



#line default
#line hidden
#nullable disable
            WriteLiteral(@"



<div class=""left-side-menu"">
    <div class=""sidebar-content"" >
        <div id=""sidebar-menu"" class=""slimscroll-menu"">

            <!--- Sidemenu -->

            <ul class=""metismenu"" id=""menu-bar"">

                <li>
                    <a onclick=""loadingProcess()""");
            BeginWriteAttribute("href", " href=\"", 405, "\"", 440, 1);
#nullable restore
#line 23 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 412, Url.Action("Index", "Home"), 412, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <i data-feather=\"home\"></i>\r\n                        <span>Dashboard</span>\r\n                    </a>\r\n                </li>\r\n\r\n                <!-- Get Treeview Control -->\r\n                ");
#nullable restore
#line 30 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\_Navigation.cshtml"
           Write(Html.Partial("UserControls/TreeviewMenu"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n            </ul>\r\n\r\n\r\n\r\n            <!-- End Sidebar -->\r\n\r\n            <div class=\"clearfix\"></div>\r\n        </div>\r\n\r\n    </div>\r\n    <!-- Sidebar -left -->\r\n\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<InfoDaruratSystem.Web.Library.Entities.MenuEntity.Menu>> Html { get; private set; }
    }
}
#pragma warning restore 1591