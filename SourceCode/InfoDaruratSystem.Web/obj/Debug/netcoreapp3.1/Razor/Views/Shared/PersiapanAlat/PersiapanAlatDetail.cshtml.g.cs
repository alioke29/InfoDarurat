#pragma checksum "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\PersiapanAlat\PersiapanAlatDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31e9803665ecb6745371537b6cc105decc697f82"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_PersiapanAlat_PersiapanAlatDetail), @"mvc.1.0.view", @"/Views/Shared/PersiapanAlat/PersiapanAlatDetail.cshtml")]
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
#nullable restore
#line 1 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\PersiapanAlat\PersiapanAlatDetail.cshtml"
using InfoDaruratSystem.Web.Library.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31e9803665ecb6745371537b6cc105decc697f82", @"/Views/Shared/PersiapanAlat/PersiapanAlatDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9922e81b2b11cb63f93ab2f703bcb0705b00c63e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_PersiapanAlat_PersiapanAlatDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\PersiapanAlat\PersiapanAlatDetail.cshtml"
  
    ViewData["Title"] = "Panggilan Detail Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""modal-form-persiapanalatdetail"" class=""modal"" aria-hidden=""true""
     data-keyboard=""false"" data-backdrop=""static""
     style=""top:5%; left:25%; width:50%; overflow:hidden;  "">

    <div class=""modal-dialog"" >
        <div class=""modal-content"" style=""width:120%;"">

            <div class=""modal-header btn-primary"" style=""text-align:left; background-color:white;"">
                <h4 class=""modal-title font-bold"" style=""color:#F03737;""><div id=""title""></div></h4>
            </div>

            <div class=""modal-body"" style=""height:450px; padding-left:30px; padding-top:30px;"" "">

                <form class=""form-horizontal"">

                    <input type=""hidden"" id=""hdnId"" value="""" />
                    <input type=""hidden"" id=""hdnDaftarAlat"" value="""" />
                    <input type=""hidden"" id=""hdnNamaAlat"" value="""" />

                    <div class=""form-group row"">
                        <label class=""col-lg-3"">Panggilan</label>
                        <div class=");
            WriteLiteral(@"""col-lg-6"">
                            <input id=""hiddenPanggilanId"" type=""hidden"" value="""" />
                            <select class=""form-control"" id=""ddlPanggilan"">
                                <option value="""">-- select panggilan --</option>
");
#nullable restore
#line 32 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\PersiapanAlat\PersiapanAlatDetail.cshtml"
                                 foreach (var itemPanggilan in (ViewData["vdPanggilanList"] as List<PanggilanEntity.Panggilan>))
                                {
                                    List<LevelEntity.Level> listLevel = ViewData["vdLevelList"] as List<LevelEntity.Level>;
                                    string levelName = listLevel.Where(x => x.ID == Convert.ToInt16(itemPanggilan.IDLevel)).FirstOrDefault().LevelName;


#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <option");
            BeginWriteAttribute("value", " value=\"", 1876, "\"", 1901, 1);
#nullable restore
#line 37 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\PersiapanAlat\PersiapanAlatDetail.cshtml"
WriteAttributeValue("", 1884, itemPanggilan.ID, 1884, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 37 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\PersiapanAlat\PersiapanAlatDetail.cshtml"
                                                                 Write(itemPanggilan.Nama);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 37 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\PersiapanAlat\PersiapanAlatDetail.cshtml"
                                                                                       Write(levelName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 37 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\PersiapanAlat\PersiapanAlatDetail.cshtml"
                                                                                                    Write(itemPanggilan.Spec);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 38 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\PersiapanAlat\PersiapanAlatDetail.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </select>
                        </div>
                    </div>

                    <div class=""form-group"" style=""display:none;"">
                        <label class=""col-lg-3"">Nama Peralatan</label>
                        <div class=""col-lg-6"">
                            <input id=""txtNamaAlat"" type=""text"" placeholder=""Nama Peralatan"" class=""form-control"" value=""");
#nullable restore
#line 47 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\PersiapanAlat\PersiapanAlatDetail.cshtml"
                                                                                                                    Write(ViewData["vdNamaAlatSelected"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
                        </div>
                    </div>

                    <br />

                    <div class=""form-group row"" style=""width:60%; height:300px; overflow-y:scroll;overflow-x:hidden; padding-left:20px; "">

                        <table class=""table table-striped table-bordered table-hover daftarAlatTable"" style=""width: 100%;"">
                            <thead>
                                <tr>
                                    <th class=""text-center"">Nama Peralatan</th>
                                </tr>
                            </thead>
                            <tbody>

");
#nullable restore
#line 63 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\PersiapanAlat\PersiapanAlatDetail.cshtml"
                                 if (ViewData["vdDaftarAlatList"] != null)
                                {

                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\PersiapanAlat\PersiapanAlatDetail.cshtml"
                                     foreach (var item in (ViewData["vdDaftarAlatList"] as List<DaftarAlatEntity.DaftarAlat>))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <tr>
                                            <td>

                                                <span class=""checkboxtext"">
                                                    <input id=""cbNamaAlat"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 3626, "\"", 3648, 1);
#nullable restore
#line 72 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\PersiapanAlat\PersiapanAlatDetail.cshtml"
WriteAttributeValue("", 3634, item.NamaAlat, 3634, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                                    ");
#nullable restore
#line 73 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\PersiapanAlat\PersiapanAlatDetail.cshtml"
                                               Write(item.NamaAlat);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </span>\r\n                                            </td>\r\n\r\n                                        </tr>\r\n");
#nullable restore
#line 78 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\PersiapanAlat\PersiapanAlatDetail.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 78 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\PersiapanAlat\PersiapanAlatDetail.cshtml"
                                     
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tbody>
                        </table>
                    </div>

                </form>
            </div>


            <div class=""modal-footer"" style=""width:100%; left:10%;"">
                <button class=""btn btn-primary mt-2 mr-1"" type=""button"" style=""width:20%; left:0; background-color:#F03737;""
                        onclick=""getClose();"">
                    <b>Cancel</b>
                </button>
                <button class=""btn btn-primary mt-2 mr-1"" type=""button"" style=""width:20%; left:0; background-color:#F03737;""
                        onclick=""getSave();"">
                    <b>Save</b>
                </button>

            </div>

        </div>
    </div>
</div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
